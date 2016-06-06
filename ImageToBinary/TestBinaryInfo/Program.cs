using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ImageToBinary.Class;

namespace TestBinaryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path (.bin): ");

            string path = Console.ReadLine();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            ImageInfo obj = (ImageInfo)formatter.Deserialize(stream);
            stream.Close();

            foreach (PixelInfo item in obj.Pixels)
            {
                Console.WriteLine("L:{0} - T:{1} - R:{2} - G:{3} - B:{4}",
                    item.Left,
                    item.Top,
                    item.R,
                    item.G,
                    item.B);
            }

            Console.ReadLine();
        }
    }
}
