using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zotin_1
{
    public partial class ResultBox : Form
    {
        public Bitmap localImage;
        public Bitmap originalImage;
        public string mode;

        public ResultBox(Bitmap image = null, string title = "", MyImage[] images = null, string Mode = "")
        {
            InitializeComponent();
            if (image != null)
            {
                originalImage = new Bitmap(image);
                localImage = new Bitmap(image);
                //localImage.LockBits();
                pictureBox1.Image = localImage;
                pictureBox1.Invalidate();
                this.Text = "Transform Field: " + title;
                mode = Mode;
            }
            
            if(images != null)
            {
                foreach(MyImage tempImage in images)
                {
                    ResultBox result = new ResultBox(tempImage.image, tempImage.fieldNameForTransform, null, Mode);
                    result.Show();
                }
                this.Close();
            }            
        }

        private void ResultBox_Load(object sender, EventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void updatePicturebox()
        {
            pictureBox1.Image = new Bitmap(localImage);
        }

        public void revertImage()
        {
            pictureBox1.Image = new Bitmap(originalImage);
            localImage = new Bitmap(originalImage);
        }

        private void colorBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorBalanceForm cbForm = new ColorBalanceForm(this, mode);
            cbForm.ShowDialog();
        }

        public void CountHystograms(string mode, out double[] R, out double[] G, out double[] B, out string rName, out string gName, out string bName)
        {
            //int[] points = new int[100];
            R = new double[256];
            G = new double[256];
            B = new double[256];
            rName = "Red";
            gName = "Green";
            bName = "Blue";
            Color color;
            for (int i = 0; i < localImage.Width; i++)
            {
                for (int j = 0; j < localImage.Height; j++)
                {
                    color = localImage.GetPixel(i, j);
                    if (mode == "RGB")
                    {
                        rName = "Red";
                        gName = "Green";
                        bName = "Blue";
                        ++R[color.R];
                        ++G[color.G];
                        ++B[color.B];
                    }
                    else if (mode == "YUV")
                    {
                        double Y, U, V;
                        ModelSettingsChooser.ColorToYUV(color, out Y, out U, out V);
                        rName = "Y";
                        gName = "U";
                        bName = "V";
                        ++R[(int)Y];
                        ++G[(int)U];
                        ++B[(int)V];
                    }
                    else if (mode == "HSL")
                    {
                        double H, S, L;
                        ModelSettingsChooser.ColorToHSL(color, out H, out S, out L);
                        rName = "Hue";
                        gName = "Saturation";
                        bName = "Brightness";
                        ++R[(int)(H*255)];
                        ++G[(int)(S*255)];
                        ++B[(int)(L*255)];
                    }
                    else if (mode == "HSV")
                    {
                        double H, S, V;
                        ModelSettingsChooser.ColorToHSV(color, out H, out S, out V);
                        rName = "Hue";
                        gName = "Saturation";
                        bName = "Value";
                        ++R[(int)(H/360*255)];
                        ++G[(int)(S*255)];
                        ++B[(int)(V*255)];
                    }
                }
            }
            //double maxValue = 0;
            //for (int i = 0; i < 256; ++i)
            //{
            //    if (R[i] > maxValue)
            //        maxValue = R[i];
            //    if (G[i] > maxValue)
            //        maxValue = G[i];
            //    if (B[i] > maxValue)
            //        maxValue = B[i];
            //}
        }

        public static double[] getGrayscaleHystogram(Bitmap image)
        {
            double[] resultHystogram = new double[256];
            Color color; 
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    color = image.GetPixel(i, j);
                    int grayscale = (int)((color.R * 0.3) + (color.G * 0.59) + (color.B * 0.11));
                    ++resultHystogram[grayscale];
                }
            }
            return resultHystogram;
        }

        private void hystogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] R, G, B;
            string rName, gName, bName;
            CountHystograms(mode, out R, out G, out B, out rName, out gName, out bName);

            HystogramForm hf = new HystogramForm(R, G, B, rName, gName, bName, this.Text + " from mode " + mode);
            hf.Show();
        }

        private void noizeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoizeGenForm ng = new NoizeGenForm(this, mode);
            ng.ShowDialog();
        }

        private void modifyUsingHystogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageCorrectionForm ng = new ImageCorrectionForm(this);
            ng.ShowDialog();
        }

        private void modifyUsingHystogramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double[] hystogram = getGrayscaleHystogram(originalImage);
            HystogramModificationForm hmf = new HystogramModificationForm(this, hystogram);
            hmf.ShowDialog();
        }
    }
}
