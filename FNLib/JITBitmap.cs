using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;

namespace FNLib
{
    public class JITBitmap : IDisposable
    {
        public bool Changed { get; private set; }

        internal Bitmap _Base;
        internal Bitmap Base
        {
            get
            {
                if (_Base != null)
                    return _Base;
                return _Base = OnOpen.Invoke();
            }
        }
        public int Width => Base.Width;
        public int Height => Base.Height;
        public PixelFormat PixelFormat => Base.PixelFormat;

        Func<Bitmap> OnOpen;

        Action<BitmapData> OnLockBits;
        Action<BitmapData> OnUnlockBits;

        public JITBitmap(Size Size, Action<BitmapData> OnLockBits, Action<BitmapData> OnUnlockBits) : this(Size.Width, Size.Height, PixelFormat.Format32bppArgb, OnLockBits, OnUnlockBits) { }
        public JITBitmap(int Width, int Height, Action<BitmapData> OnLockBits, Action<BitmapData> OnUnlockBits) : this(Width, Height, PixelFormat.Format32bppArgb, OnLockBits, OnUnlockBits) { }
        public JITBitmap(int Width, int Height, PixelFormat Format, Action<BitmapData> OnLockBits, Action<BitmapData> OnUnlockBits) : this(new Bitmap(Width, Height, Format), OnLockBits, OnUnlockBits) { }
        public JITBitmap(Func<Bitmap> OnOpen, Action<BitmapData> OnLockBits, Action<BitmapData> OnUnlockBits)
        {
            this.OnOpen = OnOpen;
            this.OnLockBits = OnLockBits;
            this.OnUnlockBits = OnUnlockBits;
        }
        public JITBitmap(Bitmap From, Action<BitmapData> OnLockBits, Action<BitmapData> OnUnlockBits)
        {
            _Base = From;
            this.OnLockBits = OnLockBits;
            this.OnUnlockBits = OnUnlockBits;
        }

        public void Dispose()
        {
            Base.Dispose();
        }

        public Color GetPixel(int X, int Y)
        {
            return Base.GetPixel(X, Y);
        }
        public Color GetPixel(Point Pos)
        {
            return Base.GetPixel(Pos.X, Pos.Y);
        }

        /// <summary>
        /// Change a Pixel, you must call <see cref="Flush"/> after end the changes
        /// </summary>
        /// <param name="X">The X Postion of the Pixel</param>
        /// <param name="T">The Y Postion of the Pixel</param>
        /// <param name="Pixel">The New Pixel</param>
        public void SetPixel(int X, int Y, Color Pixel)
        {
            Base.SetPixel(X, Y, Pixel);
        }

        /// <summary>
        /// Change a Pixel, you must call <see cref="Flush"/> after end the changes
        /// </summary>
        /// <param name="Pos">The Postion of the Pixel</param>
        /// <param name="Pixel">The New Pixel</param>
        public void SetPixel(Point Pos, Color Pixel)
        {
            Base.SetPixel(Pos.X, Pos.Y, Pixel);
        }

        public void SetBitmap(Bitmap NewBitmap)
        {
            if (Base.PixelFormat != NewBitmap.PixelFormat)
                throw new Exception($"You must use the {Base.PixelFormat} in this object");

            _Base = NewBitmap;
            Flush();
        }

        /// <summary>
        /// Apply the changes by the SetPixel Method
        /// </summary>
        public void Flush()
        {
            var Bitmap = Base.LockBits(new Rectangle(Point.Empty, Base.Size), ImageLockMode.ReadWrite, Base.PixelFormat);
            OnUnlockBits?.Invoke(Bitmap);
            Base.UnlockBits(Bitmap);
            Changed = true;
        }

        /// <summary>
        /// Get a Graphics Instance from this Image
        /// </summary>
        /// <returns>The Graphics Instance</returns>
        public Graphics GetGraphics()
        {
            return Graphics.FromImage(Base);
        }

        public object Clone()
        {
            return Base.Clone();
        }
        public Bitmap Clone(Size Size)
        {
            return Base.Clone(new Rectangle(Point.Empty, Size), Base.PixelFormat);
        }
        public Bitmap Clone(Size Size, PixelFormat Format)
        {
            return Base.Clone(new Rectangle(Point.Empty, Size), Format);
        }
        public Bitmap Clone(Rectangle Area)
        {
            return Base.Clone(Area, Base.PixelFormat);
        }
        public Bitmap Clone(Rectangle Area, PixelFormat Format)
        {
            return Base.Clone(Area, Format);
        }

        public BitmapData LockBits()
        {
            return LockBits(Base.Size);
        }
        public BitmapData LockBits(Size Size)
        {
            return LockBits(Size, ImageLockMode.ReadWrite, Base.PixelFormat);
        }
        public BitmapData LockBits(Size Size, ImageLockMode LockMode)
        {
            return LockBits(Size, LockMode, Base.PixelFormat);
        }
        public BitmapData LockBits(Rectangle Area)
        {
            return LockBits(Area, ImageLockMode.ReadWrite, Base.PixelFormat);
        }
        public BitmapData LockBits(Rectangle Area, ImageLockMode LockMode)
        {
            return LockBits(Area, LockMode, Base.PixelFormat);
        }
        public BitmapData LockBits(Size Size, ImageLockMode LockMode, PixelFormat Format)
        {
            var Data = Base.LockBits(new Rectangle(Point.Empty, Size), LockMode, Format);
            OnLockBits?.Invoke(Data);
            return Data;
        }
        public BitmapData LockBits(Rectangle Area, ImageLockMode LockMode, PixelFormat Format)
        {
            var Data = Base.LockBits(Area, LockMode, Format);
            OnLockBits?.Invoke(Data);
            return Data;
        }
        public BitmapData LockBits(Rectangle Area, ImageLockMode LockMode, PixelFormat Format, BitmapData OriData)
        {
            var Data = Base.LockBits(Area, LockMode, Format, OriData);
            OnLockBits?.Invoke(Data);
            return Data;
        }

        public void RotateFlip(RotateFlipType Type)
        {
            Base.RotateFlip(Type);
            Flush();
        }

        public void UnlockBits(BitmapData Data)
        {
            OnUnlockBits?.Invoke(Data);
            Base.UnlockBits(Data);
            Changed = true;
        }

        public static implicit operator Bitmap(JITBitmap JBitmap)
        {
            return JBitmap.Base;
        }
    }
}
