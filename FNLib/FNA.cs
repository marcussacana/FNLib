using AdvancedBinary;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FNLib
{
    public static class FNA
    {
        static Encoding SJIS = Encoding.GetEncoding(932);
        public static async Task<FNAHeader> Open(Stream Input, Action<int> OnProgressChanged)
        {
            BackgroundWorker Worker = new BackgroundWorker();
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += Worker_Open;

            object Result = null;
            bool Running = true;
            Worker.ProgressChanged += (a, b) => OnProgressChanged?.Invoke(b.ProgressPercentage);
            Worker.RunWorkerCompleted += (a, b) =>
            {
                Result = b.Result;
                Running = false;
            };

            Worker.RunWorkerAsync(Input);

            while (Running)
                await Task.Delay(100);

            return (FNAHeader)Result;
        }

        public static async Task Save(this FNAHeader Font, Stream Output, Action<int> OnProgressChanged)
        {
            BackgroundWorker Worker = new BackgroundWorker();
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += Worker_Save;

            bool Running = true;
            Worker.ProgressChanged += (a, b) => OnProgressChanged?.Invoke(b.ProgressPercentage);
            Worker.RunWorkerCompleted += (a, b) => Running = false;

            Worker.RunWorkerAsync(new object[] { Font, Output });

            while (Running)
                await Task.Delay(100);
        }

        private static void Worker_Open(object sender, DoWorkEventArgs e)
        {
            var Worker = (BackgroundWorker)sender;
            var Input = (Stream)e.Argument;
            StructReader Reader = new StructReader(Input);

            if (Reader.PeekInt() != 0x414E46)
                throw new Exception("The Input file isn't a FNA File");

            FNAHeader FontInfo = new FNAHeader();
            Reader.ReadStruct(ref FontInfo);

            if (FontInfo.Version != 0)
                throw new Exception("Unsupported FNA Version");

            int LastReportedProgress = -1;
            int Current = 0;
            int Steps = (from a in FontInfo.Fonts select (from b in a.Tables select b.Gylphs.Length).Sum()).Sum();

            for (int a = 0; a < FontInfo.Fonts.Length; a++)
            {
                ref var Font = ref FontInfo.Fonts[a];
                for (int b = 0; b < Font.Tables.Length; b++)
                {
                    ref var Table = ref Font.Tables[b];
                    for (uint i = 0; i < Table.Gylphs.Length; i++)
                    {
                        if (Worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }


                        int Progress = (int)Math.Abs(((double)(100 * ++Current)) / Steps);
                        if (Progress != LastReportedProgress)
                        {
                            LastReportedProgress = Progress;
                            Worker.ReportProgress(Progress);
                        }

                        ref var Glyph = ref Table.Gylphs[i];
                        
                        if (Glyph.TextureOffset != 0)
                            Glyph.Data = new VirtStream(Input, Glyph.TextureOffset, Glyph.TextureSize);
                        else
                            Glyph.Data = null;

                        Glyph.Char = IndexToChar(i);
                        Glyph.CreateTexture(Table.Height);
                    }
                }
            }

            e.Result = FontInfo;
        }

        private static void Worker_Save(object sender, DoWorkEventArgs e)
        {
            var Worker = (BackgroundWorker)sender;
            var FontInfo = (FNAHeader)((object[])e.Argument)[0];
            var Output = (Stream)((object[])e.Argument)[1];

            uint TextureOffset = 0;

            using (MemoryStream Buffer = new MemoryStream())
            using (StructWriter Measure = new StructWriter(Buffer))
            {
                Worker.ReportProgress(-1);
                Measure.WriteStruct(ref FontInfo);
                TextureOffset = (uint)Buffer.Length;
            }

            FontInfo.Signature = 0x414E46;
            FontInfo.Version = 0;
            FontInfo.TextureOffset = TextureOffset;

            int LastReportedProgress = -1;
            int Current = 0;
            int Steps = (from a in FontInfo.Fonts select (from b in a.Tables select b.Gylphs.Length).Sum()).Sum();


            using (Stream Textures = new MemoryStream())
            {
                for (int a = 0; a < FontInfo.Fonts.Length; a++)
                {
                    ref var Font = ref FontInfo.Fonts[a];
                    for (int b = 0; b < Font.Tables.Length; b++)
                    {
                        ref var Table = ref Font.Tables[b];
                        for (uint i = 0; i < Table.Gylphs.Length; i++)
                        {

                            ref var Glyph = ref Table.Gylphs[i];

                            if (Glyph.Texture.Changed)
                                Glyph.FlushTexture();

                            if (Glyph.Data == null || Glyph.Data.Length == 0)
                            {
                                Glyph.TextureOffset = 0;
                                Glyph.TextureSize = 0;
                                continue;
                            }

                            Glyph.TextureOffset = TextureOffset;
                            Glyph.TextureSize = (uint)Glyph.Data.Length;

                            Glyph.Data.Position = 0;

                            TextureOffset += Glyph.TextureSize;

                            Glyph.Data.CopyTo(Textures);

                            if (Worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }

                            int Progress = (int)Math.Abs(((double)(100 * ++Current)) / Steps);
                            if (Progress != LastReportedProgress)
                            {
                                LastReportedProgress = Progress;
                                Worker.ReportProgress(Progress);
                            }
                        }
                    }
                }

                FontInfo.FNASize = TextureOffset;

                using (StructWriter Writer = new StructWriter(Output))
                {
                    Worker.ReportProgress(-1);
                    Writer.WriteStruct(ref FontInfo);
                    Writer.Flush();
                    Textures.Position = 0;
                    Textures.CopyTo(Output);
                    Output.Flush();
                }
            }
        }

        static Stream ToDecompressor(this Stream Input)
        {
            return new ZInputStream(Input);
        }
        static byte[] Compress(this Stream Input)
        {
            using (MemoryStream Buffer = new MemoryStream())
            {
                using (var Compressor = new ZOutputStream(Buffer, CompressionLevel.Z_BEST_COMPRESSION))
                {
                    Input.CopyTo(Compressor);
                    Compressor.Flush();
                }
                return Buffer.ToArray();
            }

        }

        static byte[] Compress(this byte[] Data)
        {
            using (MemoryStream Buffer = new MemoryStream(Data))
                return Buffer.Compress();
        }
        static byte[] ToByteArray(this Stream Data)
        {
            using (MemoryStream Buff = new MemoryStream())
            {
                Data.CopyTo(Buff);
                Data.Close();
                return Buff.ToArray();
            }
        }

        static void CreateTexture(ref this Glyph Glyph, int Height)
        {
            var lGlyph = Glyph;
            Glyph.Texture = new JITBitmap(() =>
            {
                if (lGlyph.Data == null)
                    return null;
                var Data = lGlyph.Data.ToDecompressor().ToByteArray();
                return ReadTexture(Data, Height);
            }, null, null);
        }

        static void FlushTexture(ref this Glyph Glyph)
        {
            if (Glyph.Texture.PixelFormat != PixelFormat.Format1bppIndexed)
                throw new Exception($"Invalid Glyph Pixel Format to {Glyph.Char} character");

            byte[] Buffer = WriteTexture(Glyph.Texture);

            Glyph.Data = new MemoryStream(Buffer.Compress());
        }

        unsafe static Bitmap ReadTexture(byte[] Data, int Height)
        {
            int Width = (Data.Length * 8) / Height;

            var FullRegion = new Rectangle(0, 0, Width, Height);

            Bitmap Texture = new Bitmap(Width, Height, PixelFormat.Format1bppIndexed);

            var Locker = Texture.LockBits(FullRegion, ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
            Marshal.Copy(Data, 0, Locker.Scan0, Data.Length);
            Texture.UnlockBits(Locker);

            return Texture.FlipTexture();
        }
        unsafe static byte[] WriteTexture(Bitmap Texture)
        {
            Bitmap Tmp = Texture;

            int NewWidth = Tmp.Width;


            //Fix 8-Bit Padding
            if (NewWidth % 8 != 0)
                NewWidth += 8 - (NewWidth % 8);

            //Fix 32-Bit Padding
            if ((NewWidth / 8) % 4 != 0)
                NewWidth += (4 - ((NewWidth / 8) % 4)) * 8;

            Tmp = new Bitmap(NewWidth, Texture.Height);
            using (Graphics g = Graphics.FromImage(Tmp))
            {
                g.DrawImage(Texture, Point.Empty);
                g.Flush();
            }

            var FullRegion = new Rectangle(0, 0, Tmp.Width, Tmp.Height);
            Tmp = Tmp.FlipTexture().Clone(FullRegion, PixelFormat.Format1bppIndexed);

            var Locker = Tmp.LockBits(FullRegion, ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
            byte[] Data = new byte[(Tmp.Width * Tmp.Height) / 8];

            Marshal.Copy(Locker.Scan0, Data, 0, Data.Length);
            Tmp.UnlockBits(Locker);

            return Data;
        }

        static Bitmap FlipTexture(this Bitmap Texture, bool AllowDispose = true)
        {
            Bitmap New = new Bitmap(Texture.Width, Texture.Height);
            using (Graphics g = Graphics.FromImage(New))
            {
                var Container = g.BeginContainer();
                g.ScaleTransform(1, -1);
                g.TranslateTransform(0, Texture.Height * -1);
                g.DrawImage(Texture, Point.Empty);
                g.EndContainer(Container);
                g.Flush();
            }

            var Rect = new Rectangle(0, 0, Texture.Width, Texture.Height);
            var Format = Texture.PixelFormat;


            if (AllowDispose)
                Texture.Dispose();

            return New.Clone(Rect, Format);
        }

        //Stolen from: https://github.com/nunuhara/xsystem4/blob/master/src/fnl.c
        static uint SjisToIndex(ushort Code)
        {
            // one byte
            if (Code < 0x20)
                return 0;
            if (Code < 0x7f)
                return Code - 0x20u;
            if (Code < 0xa1)
                return 0;
            if (Code < 0xe0)
                return Code - 0x42u;

            // two byte
            byte fst = (byte)(Code >> 8);
            byte snd = (byte)(Code & 0xFF);

            if (fst < 0x81)
                return 0;
            if (snd < 0x40 || snd == 0x7f || snd > 0xfc)
                return 0;

            return Code - (0x80A2u + (68u * (fst - 0x81u)) + (snd > 0x7F ? 1u : 0u));
        }

        static char IndexToChar(uint Index)
        {
            var CodedChar = IndexToSjis(Index);
            byte[] Buffer = new byte[] { (byte)(CodedChar >> 8), (byte)(CodedChar & 0xFF) };
            return SJIS.GetString(Buffer).Trim('\x0').FirstOrDefault();
        }

        static uint IndexToSjis(uint Index)
        {
            if (Index == 0)
                return 0;

            if (Index < 0x5F)
                return Index + 0x20;
            if (Index < 0x9E)
                return Index + 0x42;

            Index -= 0x9E;

            //0xBC Chars Per Major
            uint Major = Index / 0xBCu;
            uint Minor = Index % 0xBCu;

            Major += 0x81;
            Minor += 0x40;

            if (Minor >= 0x7F)
                Minor++;

            return Major << 8 | Minor;
        }
    }
}
