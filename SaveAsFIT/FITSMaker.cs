using System.Globalization;
using System.Text;

namespace SaveAsFITS
{
    static class FITSMaker
    {
        public const string FITS_Header_Simple = "SIMPLE  = ";//                   T / file conforms to FITS standard
        public const string FITS_Header_BitPix = "BITPIX  = ";//                  16 / number of bits per data pixel
        public const string FITS_Header_NAxis  = "NAXIS   = ";//                   2 / number of data axes
        public const string FITS_Header_NAxis1 = "NAXIS1  = ";//                 440 / length of data axis 1
        public const string FITS_Header_NAxis2 = "NAXIS2  = ";//                 300 / length of data axis 2
        public const string FITS_Header_BZero  = "BZERO   = ";//               32768 /
        public const string FITS_Header_Comment= "COMMENT   ";//
        public const string FITS_Header_EndOfHeader = "END       ";//
        public static string FITS_Header_Blank = new string(' ',80);
        
        public static string[] CreateFITSHeader(bool Simple, int BitPerPixel, int Width, int Height, int Zero, string Comment)
        {
            var buffer = new string[36];

            buffer[0] = createHeaderString(FITS_Header_Simple, Simple, "file conforms to FITS standard");
            buffer[1] = createHeaderString(FITS_Header_BitPix, BitPerPixel, "16 bits per pixels");
            buffer[2] = createHeaderString(FITS_Header_NAxis, 2, "2D image");
            buffer[3] = createHeaderString(FITS_Header_NAxis1, Width, "image width");
            buffer[4] = createHeaderString(FITS_Header_NAxis2, Height, "image height");
            buffer[5] = createHeaderString(FITS_Header_BZero, Zero, "0 offset for unsigned");
            buffer[6] = createHeaderString(FITS_Header_Comment, Comment);
            buffer[7] = FITS_Header_EndOfHeader.PadRight(80);
            for (var i = 8; i < 36; i++)
            {
                buffer[i] = FITS_Header_Blank;
            }
            return buffer;
        }

        private static string createHeaderString(string varName, string comment)
        {
            var sb = new StringBuilder(varName);
            sb.Append(comment);
            return sb.ToString().PadRight(80);
        }

        private static string createHeaderString(string varName, int val, string comment)
        {
            var sb = new StringBuilder(varName);
            sb.Append(val.ToString(CultureInfo.InvariantCulture).PadLeft(20));
            sb.Append(" / ");
            sb.Append(comment);

            return sb.ToString().PadRight(80);
        }

        private static string createHeaderString(string varName, bool val, string comment)
        {
            var vb = (val) ? "T" : "F";
            var sb = new StringBuilder(varName);
            sb.Append(vb.PadLeft(20));
            sb.Append(" / ");
            sb.Append(comment);

            return sb.ToString().PadRight(80);
        }
    }
}
