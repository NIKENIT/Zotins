using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zotin_1
{
    public partial class ImageCorrectionForm : Form
    {
        ResultBox ownerForm;
        public ImageCorrectionForm(ResultBox form)
        {
            InitializeComponent();
            ownerForm = form;
            this.FormClosing += new FormClosingEventHandler(IGFormClosing);
        }

        private void IGFormClosing(object sender, FormClosingEventArgs e)
        {
            ownerForm.revertImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.localImage = new Bitmap(ownerForm.originalImage.Width, ownerForm.originalImage.Height);
            ownerForm.updatePicturebox();
            //ownerForm.localImage = ApplyIdealReflectorMethod(ownerForm.originalImage);
            ApplyIdealReflectorMethod();
            ownerForm.updatePicturebox();

            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.localImage = new Bitmap(ownerForm.originalImage.Width, ownerForm.originalImage.Height);
            ownerForm.updatePicturebox();
            //ownerForm.localImage = new Bitmap(ApplyAutoLevelsMethod(ownerForm.originalImage));
            ApplyAutoLevelsMethod();
            ownerForm.updatePicturebox();

            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        //Идеология "Идеальный отражатель"
        public void ApplyIdealReflectorMethod()
        {
            //Bitmap result = new Bitmap(originalImage);
            int Rmax = 1, Gmax = 1, Bmax = 1;
            Color tempColor;

            //находим максимумы R,G,B по изображению
            for (int x = 0; x < ownerForm.originalImage.Width; x++)
            {
                for (int y = 0; y < ownerForm.originalImage.Height; y++)
                {
                    tempColor = ownerForm.originalImage.GetPixel(x, y);
                    if (tempColor.R > Rmax) Rmax = tempColor.R;
                    if (tempColor.G > Gmax) Gmax = tempColor.G;
                    if (tempColor.B > Bmax) Bmax = tempColor.B;
                }
            }
            //устанавливаем
            int R, G, B;
            for (int x = 0; x < ownerForm.originalImage.Width; x++)
            {
                for (int y = 0; y < ownerForm.originalImage.Height; y++)
                {
                    tempColor = ownerForm.originalImage.GetPixel(x, y);
                    R = tempColor.R * (255 / Rmax);
                    G = tempColor.G * (255 / Gmax);
                    B = tempColor.B * (255 / Bmax);
                    ownerForm.localImage.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            //return result;
        }

        //Autolevels
        public void ApplyAutoLevelsMethod()
        {
            
            int Rmin = 255, Gmin = 255, Bmin = 255;
            int Rmax = 0, Gmax = 0, Bmax = 0;
            Color tempColor;

            //находим минимумы и максимумы R,G,B по изображению
            for (int x = 0; x < ownerForm.originalImage.Width; x++)
            {
                for (int y = 0; y < ownerForm.originalImage.Height; y++)
                {
                    tempColor = ownerForm.originalImage.GetPixel(x, y);
                    if (tempColor.R < Rmin) Rmin = tempColor.R;
                    if (tempColor.G < Gmin) Gmin = tempColor.G;
                    if (tempColor.B < Bmin) Bmin = tempColor.B;

                    if (tempColor.R > Rmax) Rmax = tempColor.R;
                    if (tempColor.G > Gmax) Gmax = tempColor.G;
                    if (tempColor.B > Bmax) Bmax = tempColor.B;
                }
            }
            //устанавливаем
            int R, G, B;
            for (int x = 0; x < ownerForm.originalImage.Width; x++)
            {
                for (int y = 0; y < ownerForm.originalImage.Height; y++)
                {
                    tempColor = ownerForm.originalImage.GetPixel(x, y);
                    R = (tempColor.R - Rmin) * (255 / (Rmax - Rmin));
                    G = (tempColor.G - Gmin) * (255 / (Gmax - Gmin));
                    B = (tempColor.B - Bmin) * (255 / (Bmax - Bmin));
                    ownerForm.localImage.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
            ownerForm.updatePicturebox();
        }

        private void ImageCorrectionForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ownerForm.revertImage();
        }
    }
}
