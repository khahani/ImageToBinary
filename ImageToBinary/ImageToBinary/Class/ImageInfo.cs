using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ImageToBinary.Class
{
    [Serializable]
    public class ImageInfo
    {
        public ImageInfo()
        {
            Pixels = new List<PixelInfo>();
        }

        public List<PixelInfo> Pixels { get; set; }

        public bool SaveToBinary(string path)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                         FileMode.Create,
                                         FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    [Serializable]
    public class PixelInfo
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }

}
