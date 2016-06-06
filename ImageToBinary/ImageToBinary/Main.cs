using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageToBinary.Class;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace ImageToBinary
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "All files|*.*|Image (.jpg)|*.jpg"
            };

            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                this.Path.Text = dialog.FileName;
                this.ThePicture.ImageLocation = dialog.FileName;
            }
        }

        private void Crop_Click(object sender, EventArgs e)
        {
            Image srcImage = Bitmap.FromFile(this.Path.Text);
            Image dstImage = Class.Crop.CropToCircle(srcImage, Color.Transparent);
            this.ThePicture.Image = dstImage;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Picture (.jpg)|*.jpg"
            };

            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                Image cropedImage = ThePicture.Image;
                cropedImage.Save(dialog.FileName, ImageFormat.Jpeg);

                Converter converter = new Converter();
                ImageInfo imageInfo = converter.GetImageInRGB(cropedImage);

                imageInfo.SaveToBinary(dialog.FileName.Replace(".jpg", ".bin"));

                MessageBox.Show("با موفقیت ذخیره شد.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
