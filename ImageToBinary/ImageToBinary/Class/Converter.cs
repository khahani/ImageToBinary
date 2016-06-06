using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToBinary.Class
{
    public class Converter
    {
        public ImageInfo GetImageInRGB(Image image)
        {
            ImageInfo imageInfo = new ImageInfo();

            Bitmap img = new Bitmap(image);
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    Color pixel = img.GetPixel(j, i);

                    imageInfo.Pixels.Add(new PixelInfo
                        {
                            Left = j,
                            Top = i,
                            R = pixel.R,
                            G = pixel.G,
                            B = pixel.B
                        });
                }
            }

            return imageInfo;
        }
    }
}
