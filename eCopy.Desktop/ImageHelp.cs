using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace eCopy.Desktop
{
    public class ImageHelp
    {
        public static byte[] FromImageToByte(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image FromByteToImage(byte[] image)
        {
            var ms = new MemoryStream(image);
            return Image.FromStream(ms);
        }
    }
}
