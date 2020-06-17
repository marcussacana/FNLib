using AdvancedBinary;
using System.Drawing;
using System.IO;

namespace FNLib
{
#pragma warning disable 649
    public struct FNAHeader
    {
        public uint Signature;
        public uint Version;
        public uint FNASize;
        public uint TextureOffset;

        [PArray, StructField]
        public FNAStructure[] Fonts;
    };

    public struct FNAStructure
    {
        [PArray, StructField]
        public FontTable[] Tables;
    };

    public struct FontTable
    {
        public int Height;
        public int PaddingBottom;
        [PArray, StructField]
        public Glyph[] Gylphs;
    };

    public struct Glyph
    {
        public ushort Width;
        internal uint TextureOffset;
        internal uint TextureSize;

        [Ignore]       
        internal Stream Data;
        [Ignore]
        public char Char;
        [Ignore]
        public JITBitmap Texture;
    };

#pragma warning restore 649
}
