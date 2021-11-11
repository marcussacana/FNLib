using FNLib;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FNLRemapper
{
    public partial class Main : Form
    {
        Stream FontReader;
        public string FontPath;
        public FNAHeader FontInfo;
        public int SelectedFont;
        public int SelectedTable;
        public Main()
        {
            InitializeComponent();

            cbFont.Items.AddRange(FontFamily.Families.Select((a) => a.Name).ToArray());
            cbFontType.SelectedIndex = 2;
        }

        private void btnOpenFont_Click(object sender, EventArgs e)
        {
            FontOpenDialog.ShowDialog();
        }

        private void btnSaveFont_Click(object sender, EventArgs e)
        {
            FontSaveDialog.ShowDialog();
        }

        private void FontOpenDialog_FileOk(object sender, CancelEventArgs e)
        {
            Progress.Style = ProgressBarStyle.Marquee;
            Progress.Value = 0;
            Progress.Visible = true;
            pnFontMenu.Visible = false;
            FontPath = FontOpenDialog.FileName;
            BeginInvoke(new MethodInvoker(async () =>
            {
                FontReader?.Dispose();
                FontReader = File.Open(FontPath, FileMode.Open, FileAccess.Read);
                FontInfo = await FNA.Open(FontReader, null);

                pnFontMenu.Visible = true;
                Progress.Visible = false;
                cbFace.Enabled = true;
                cbTable.Enabled = true;
                btnSaveFont.Enabled = true;
                btnRedraw.Enabled = true;
                btnRedrawTables.Enabled = true;

                cbFace.Items.Clear();

                for (int i = 0; i < FontInfo.Fonts.Length; i++)
                    cbFace.Items.Add(i);

                cbFace.SelectedIndex = 0;
            }));
        }

        private void FontSaveDialog_FileOk(object sender, CancelEventArgs e)
        {
            Progress.Style = ProgressBarStyle.Blocks;
            Progress.Value = 0;
            Progress.Visible = true;
            pnFontMenu.Visible = false;
            var NewFontPath = FontSaveDialog.FileName;
            BeginInvoke(new MethodInvoker(async () =>
            {
                if (FontPath == NewFontPath)
                {
                    Progress.Visible = false;
                    pnFontMenu.Visible = true;
                    MessageBox.Show("You can't overwrite the open file.", "FNLRemapper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (Stream Output = File.Create(NewFontPath))
                    await FontInfo.Save(Output, (a) =>
                    {
                        Progress.Style = a == -1 ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
                        if (a != -1)
                            Progress.Value = a;
                    });

                Progress.Visible = false;
                pnFontMenu.Visible = true;
                MessageBox.Show("Font Saved!", "FNLRemapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }

        private void RefreshPreview(object sender, EventArgs e)
        {
            tmRefreshPreview.Stop();
            tmRefreshPreview.Start();
        }

        private void RefreshPreviewNow(object sender, EventArgs e)
        {
            tmRefreshPreview.Stop();

            Bitmap Image = new Bitmap(1, 1);
            foreach (var Char in tbPreview.Text)
            {
                var vChar = Char;
                if (vChar == ' ')
                    vChar = '\x0';

                var Query = (from x in FontInfo.Fonts[SelectedFont].Tables[SelectedTable].Gylphs where x.Char == vChar select x);
                if (!Query.Any())
                    continue;

                var Glyph = Query.First();
                var Texture = Glyph.Texture.Clone(new Size(Glyph.Width, Glyph.Texture.Height), PixelFormat.Format32bppArgb);
                Image = SideBySide(Image, Texture, new Point(0, 0));
            }

            Preview.Image?.Dispose();
            Preview.Image = Image;
        }
        private Bitmap SideBySide(Bitmap A, Bitmap B, Point DrawAt)
        {
            Bitmap Output = new Bitmap(A.Width + B.Width + DrawAt.X, Math.Max(A.Height, B.Height + DrawAt.Y));
            CopyBitmap(A, Output, 0, 0, A.Width, A.Height, 0, 0);
            CopyBitmap(B, Output, 0, 0, B.Width, B.Height, A.Width + DrawAt.X, DrawAt.Y);
            return Output;
        }
        private void CopyBitmap(Bitmap From, Bitmap To, int SourceX, int SourceY, int Width, int Height, int DestX, int DestY)
        {
            using (Graphics g = Graphics.FromImage(To))
            {
                g.DrawImage(From, new Rectangle(DestX, DestY, From.Width, From.Height), new Rectangle(SourceX, SourceY, Width, Height), GraphicsUnit.Pixel);
                g.Flush();
            }
        }

        private void FontFaceChanged(object sender, EventArgs e)
        {
            if (cbFace.SelectedIndex < 0)
                return;

            cbTable.Items.Clear();

            SelectedFont = cbFace.SelectedIndex;

            for (int i = 0; i < FontInfo.Fonts[SelectedFont].Tables.Length; i++)
                cbTable.Items.Add(i);

            cbTable.SelectedIndex = 0;
            RefreshPreviewNow(null, null);
        }

        private void FontStyleChanged(object sender, EventArgs e)
        {

            SelectedTable = cbTable.SelectedIndex;
            RefreshPreviewNow(null, null);
        }

        private void OnVirtualFocused(object sender, EventArgs e)
        {
            try
            {
                tbVirtChars.Select(tbPhysChars.SelectionStart, tbPhysChars.SelectionLength);
            }
            catch { }
        }

        private void OnPhysicalFocused(object sender, EventArgs e)
        {
            try
            {
                tbPhysChars.Select(tbVirtChars.SelectionStart, tbPhysChars.SelectionLength);
            }
            catch { }
        }

        private void btnRedrawFaces_Click(object sender, EventArgs e)
        {
            string RemapList = null;
            for (int i = SelectedTable; i < FontInfo.Fonts[SelectedFont].Tables.Length; i++)
            {
                SelectedTable = cbTable.SelectedIndex = i;
                RemapList = RedrawTable(i * 4.5f, i);
                Application.DoEvents();
            }
            RefreshPreview(null, null);
            Clipboard.SetText(RemapList);
            MessageBox.Show("Your character remap list has been copied to the clipboard.", "FNLRemapper");
        }
        private void btnRedraw_Click(object sender, EventArgs e)
        {
            var RemapList = RedrawTable(0, SelectedTable);
            RefreshPreview(null, null);
            Clipboard.SetText(RemapList);
            MessageBox.Show("Your character remap list has been copied to the clipboard.", "Your Remap List");
        }
        private string RedrawTable(float SizeExtension, int Factor)
        {
            ref var Table = ref FontInfo.Fonts[SelectedFont].Tables[SelectedTable];
            ref var Glyphs = ref Table.Gylphs;

            if (tbVirtChars.Text.Length > Glyphs.Length)
                throw new Exception("Too many glyphs in the list");

            if (tbVirtChars.Text.Length != tbPhysChars.Text.Length)
            {
                MessageBox.Show("The Virtual Characters List needs have the same amount of characters of the Physical List\nCharacters that you don't need remap put a - in the Physical List.");
                return null;
            }

            var PaddingRigth = int.Parse(tbPaddingRigth.Text);
            var RemapList = "";
            var FSize = float.Parse(tbSize.Text) + SizeExtension;
            var Family = FontFamily.Families.Where(x => x.Name.ToLower().Trim() == cbFont.Text.ToLower().Trim()).Single();
            var Style = GetBestFamilyStyle(Family, cbFontType.SelectedIndex switch { 
                0 => FontStyle.Bold,
                1 => FontStyle.Italic,
                2 => FontStyle.Regular,
                3 => FontStyle.Underline,
                _ => FontStyle.Regular
            });

            var Font = new Font(Family, FSize, Style, GraphicsUnit.Pixel);

            if (ckAutoPadding.Checked)
            {
                var ASize = FSize * 0.22f;
                PaddingRigth += (int)ASize;
            }

            for (int i = 0; i < tbVirtChars.Text.Length; i++)
            {
                Size NewSize;
                char VisibleChar = tbVirtChars.Text[i];
                char RealChar = tbPhysChars.Text[i];
                if (RealChar == '-')
                    RealChar = VisibleChar;
                else
                    RemapList += $"{VisibleChar}={RealChar}\r\n";

                using (Graphics tmp = Graphics.FromHwnd(IntPtr.Zero))
                {
                    tmp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                    NewSize = tmp.MeasureString(VisibleChar.ToString(), Font).ToSize();
                }

                Bitmap Buffer;

                int GlyphBottomOverflow;

                using (var Tmp = new Bitmap(NewSize.Width, NewSize.Height, PixelFormat.Format32bppArgb))
                using (var Base = new Bitmap(NewSize.Width, NewSize.Height, PixelFormat.Format32bppArgb))
                using (Graphics ga = Graphics.FromImage(Tmp))
                using (Graphics gb = Graphics.FromImage(Base))
                {
                    ga.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                    ga.DrawString(VisibleChar.ToString(), Font, Brushes.White, 0, 0);
                    ga.Flush();

                    gb.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                    gb.DrawString("A", Font, Brushes.White, 0, 0);
                    gb.Flush();

                    int BaseBottom = ScanBottom(Base);
                    int GlyphBottom = ScanBottom(Tmp);
                    GlyphBottomOverflow = GlyphBottom - BaseBottom;

                    Buffer = Tmp.Clone(new Rectangle(Point.Empty, Tmp.Size), PixelFormat.Format1bppIndexed);
                }


                if (char.IsWhiteSpace(VisibleChar))
                    continue;

                var Fixed = FixCharacter(Buffer, Table.Height, Table.PaddingBottom - GlyphBottomOverflow, PaddingRigth, out int Width);

                int x = GetGlyphIndex(Glyphs, RealChar);

                if (x == -1)
                    throw new Exception($"The {RealChar} Glyph Not Found in the Font");

                Glyphs[x].Width = (ushort)(Width);
                Glyphs[x].Texture.SetBitmap(Fixed ?? Buffer);
            }

            return RemapList;
        }

        FontStyle GetBestFamilyStyle(FontFamily Family, FontStyle Prior)
        {
            if (Family.IsStyleAvailable(Prior))
                return Prior;

            var Styles = new[] { FontStyle.Regular, FontStyle.Bold, FontStyle.Regular, FontStyle.Italic, FontStyle.Underline };
            foreach (var Style in Styles)
            {
                if (Family.IsStyleAvailable(Style))
                    return Style;
            }
            throw new Exception("Font Not Supported");
        }

        static int ScanBottom(Bitmap Bitmap)
        {
            for (int Y = Bitmap.Height - 1; Y >= 0; Y--)
                for (int X = 0; X < Bitmap.Width; X++)
                {
                    var Pixel = Bitmap.GetPixel(X, Y);
                    if (Pixel.A == 0)
                        continue;
                    return Y;
                }
            return Bitmap.Height;
        }

        static Bitmap FixCharacter(Bitmap source, int Height, int Bottom, int PaddingRigth, out int Width)
        {
            Width = source.Width;
            bool Empty = true;
            var srcRect = new Rectangle();
            for (int X = 0; X < source.Width && Empty; X++)
                for (int Y = 0; Y < source.Height; Y++)
                {
                    var Pixel = source.GetPixel(X, Y);
                    var Sum = Pixel.R + Pixel.G + Pixel.B;
                    if (Sum == 0)
                        continue;

                    if (X > 1)
                        X -= 2;

                    Empty = false;
                    srcRect.X = X;
                    break;
                }

            if (Empty)
                return null;

            Empty = true;
            for (int X = source.Width - 1; X >= 0 && Empty; X--)
                for (int Y = source.Height - 1; Y >= 0; Y--)
                {
                    var Pixel = source.GetPixel(X, Y);
                    var Sum = Pixel.R + Pixel.G + Pixel.B;
                    if (Sum == 0)
                        continue;

                    if (X < source.Width - 1)
                        X += 2;

                    Empty = false;
                    srcRect.Width = X - srcRect.X;
                    break;
                }

            if (Empty)
                return null;

            Empty = true;
            for (int Y = 0; Y < source.Height && Empty; Y++)
                for (int X = 0; X < source.Width; X++)
                {
                    var Pixel = source.GetPixel(X, Y);
                    var Sum = Pixel.R + Pixel.G + Pixel.B;
                    if (Sum == 0)
                        continue;

                    if (Y > 0)
                        Y--;

                    Empty = false;
                    srcRect.Y = Y;
                    break;
                }

            if (Empty)
                return null;

            Empty = true;
            for (int Y = source.Height - 1; Y >= 0 && Empty; Y--)
                for (int X = source.Width - 1; X >= 0; X--)
                {
                    var Pixel = source.GetPixel(X, Y);
                    var Sum = Pixel.R + Pixel.G + Pixel.B;
                    if (Sum == 0)
                        continue;

                    if (Y < source.Height)
                        Y++;

                    Empty = false;
                    srcRect.Height = Y - srcRect.Y;
                    break;
                }

            if (Empty)
                return null;

            Width = srcRect.Width + PaddingRigth;

            using (Bitmap dest = new Bitmap(Width, Height, PixelFormat.Format24bppRgb))
            {
                Rectangle destRect = new Rectangle(0, Height - srcRect.Height - Bottom, srcRect.Width, srcRect.Height);
                using (Graphics graphics = Graphics.FromImage(dest))
                {
                    graphics.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
                    graphics.Flush();
                }
                return dest.Clone(new Rectangle(Point.Empty, dest.Size), PixelFormat.Format1bppIndexed);
            }
        }
        private int GetGlyphIndex(Glyph[] Glyphs, char c)
        {
            for (int i = 0; i < Glyphs.Length; i++)
            {
                if (Glyphs[i].Char == c)
                    return i;
            }
            return -1;
        }
    }
}
