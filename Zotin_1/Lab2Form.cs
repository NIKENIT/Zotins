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
    public partial class Lab2Form : Form
    {
        public Lab2Form(Bitmap Source)
        {
            InitializeComponent();
            source = Source;
        }
        Bitmap source;

        public Bitmap RGBImage;
        public Bitmap YUVImage;

        public Bitmap resultImage;

        //картинка, которую будем обрабатывать.
        public Bitmap originalImage;

        private void Lab2Form_Load(object sender, EventArgs e)
        {
            RGBImage = new Bitmap(source);
            YUVImage = new Bitmap(source.Width, source.Height);
            for(int i = 0; i < source.Width; i++)
            {
                for(int j = 0; j < source.Height; j++)
                {
                    Color color = source.GetPixel(i, j);
                    double Y, U, V;
                    ModelSettingsChooser.ColorToYUV(color, out Y, out U, out V);
                    YUVImage.SetPixel(i, j, Color.FromArgb((int)Y, (int)U, (int)V));
                }
            }

            PictureBox.Image = RGBImage;
            originalImage = new Bitmap(RGBImage);
            comboBox1.SelectedIndex = 0;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                originalImage = new Bitmap(RGBImage);
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                originalImage = new Bitmap(YUVImage);
            }
            PictureBox.Image = originalImage;
        }

        private void LinearFilters_Click(object sender, EventArgs e)
        {
            LinearFiltersChooserForm form = new LinearFiltersChooserForm(this);
            form.ShowDialog();
        }

        public void updateResultBox()
        {
            resultBox.Image = new Bitmap(resultImage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NoizeGenForm ngf = new NoizeGenForm(this, comboBox1.SelectedItem.ToString());
            ngf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            originalImage = new Bitmap(resultImage);
            PictureBox.Image = originalImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                originalImage = new Bitmap(RGBImage);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                originalImage = new Bitmap(YUVImage);
            }
            PictureBox.Image = originalImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double mseR = 0, mseG = 0, mseB = 0, mseInt = 0;
            double psnrR = 0, psnrG = 0, psnrB = 0, psnrInt = 0;
            calculateMSE(originalImage, resultImage, out mseR, out mseG, out mseB, out mseInt);
            calculatePSNR(originalImage, resultImage, out psnrR, out psnrG, out psnrB, out psnrInt);

            MSERLabel.Text = "Difference R: " + Math.Round(mseR, 3);
            MSEGLabel.Text = "Difference G: " + Math.Round(mseG, 3);
            MSEBLabel.Text = "Difference B: " + Math.Round(mseB, 3);
            MSEIntLabel.Text = "Difference Int: " + Math.Round(mseInt, 3);

            PSNRRLabel.Text = "Difference R: " + Math.Round(psnrR, 3);
            PSNRGLabel.Text = "Difference G: " + Math.Round(psnrG, 3);
            PSNRBLabel.Text = "Difference B: " + Math.Round(psnrB, 3);
            PSNRIntLabel.Text = "Difference Int: " + Math.Round(psnrInt, 3);
        }

        public void calculateMSE(Bitmap originalImage, Bitmap resultImage, out double MSEResultR, out double MSEResultG, out double MSEResultB, out double MSEResultInt)
        {
            MSEResultR = 0; MSEResultG = 0; MSEResultB = 0; MSEResultInt = 0;

            if (originalImage == null || resultImage == null)
                return;


            int originalImagePixels = originalImage.Width * originalImage.Height;
            int resultImagePixels = resultImage.Width * resultImage.Height;

            int[] originalR, originalG, originalB, originalIntColor;
            int[] resultR, resultG, resultB, resultIntColor;

            originalR = new int[originalImagePixels];
            originalG = new int[originalImagePixels];
            originalB = new int[originalImagePixels];

            originalIntColor = new int[originalImagePixels];

            resultR = new int[resultImagePixels];
            resultG = new int[resultImagePixels];
            resultB = new int[resultImagePixels];

            resultIntColor = new int[resultImagePixels];

            //сбор сумм всех цветовых каналов
            for (int x = 0; x < originalImage.Width; x++)
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color color = originalImage.GetPixel(x, y);
                    int arrayLocation = originalImage.Height * x + y;

                    originalR[arrayLocation] = color.R;
                    originalG[arrayLocation] = color.G;
                    originalB[arrayLocation] = color.B;

                    originalIntColor[arrayLocation] = color.ToArgb();
                }

            for (int x = 0; x < resultImage.Width; x++)
                for (int y = 0; y < resultImage.Height; y++)
                {
                    Color color = resultImage.GetPixel(x, y);
                    int arrayLocation = resultImage.Height * x + y;

                    resultR[arrayLocation] = color.R;
                    resultG[arrayLocation] = color.G;
                    resultB[arrayLocation] = color.B;

                    resultIntColor[arrayLocation] = color.ToArgb();
                }

            double MSESumR = 0, MSESumG = 0, MSESumB = 0, MSESumInt = 0;

            for (int x = 0; x < originalR.Length; x++)
            {
                MSESumR += Math.Pow((originalR[x] - resultR[x]), 2);
                MSESumG += Math.Pow((originalG[x] - resultG[x]), 2);
                MSESumB += Math.Pow((originalB[x] - resultB[x]), 2);

                MSESumInt += Math.Pow((originalIntColor[x] - resultIntColor[x]), 2);
            }            

            //MSE - средняя арифметическая
            MSEResultR = MSESumR / originalR.Length;
            MSEResultG = MSESumG / originalG.Length;
            MSEResultB = MSESumB / originalB.Length;
            MSEResultInt = MSESumInt / originalIntColor.Length;
        }

        public void calculatePSNR(Bitmap originalImage, Bitmap resultImage, out double PSNRResultR, out double PSNRResultG, out double PSNRResultB, out double PSNRResultInt)
        {
            double MSEResultR = 0, MSEResultG = 0, MSEResultB = 0, MSEResultInt = 0;

            PSNRResultR = 0; PSNRResultG = 0; PSNRResultB = 0; PSNRResultInt = 0;

            if (originalImage == null || resultImage == null)
                return;

            calculateMSE(originalImage, resultImage, out MSEResultR, out MSEResultG, out MSEResultB, out MSEResultInt);

            if (MSEResultR == 0)
                PSNRResultR = 0;
            else
            {
                PSNRResultR = 20 * Math.Log10(255 / (double)Math.Sqrt(MSEResultR));
            }

            if (MSEResultG == 0)
                PSNRResultG = 0;
            else
            {
                PSNRResultG = 20 * Math.Log10(255 / (double)Math.Sqrt(MSEResultG));
            }

            if (MSEResultB == 0)
                PSNRResultB = 0;
            else
            {
                PSNRResultB = 20 * Math.Log10(255 / (double)Math.Sqrt(MSEResultB));
            }

            if (MSEResultInt == 0)
                PSNRResultInt = 0;
            else
            {
                PSNRResultInt = 20 * Math.Log10(255 / (double)Math.Sqrt(MSEResultInt));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            double mseR = 0, mseG = 0, mseB = 0, mseInt = 0;
            double psnrR = 0, psnrG = 0, psnrB = 0, psnrInt = 0;


            Bitmap compareImage;
            if (comboBox1.SelectedIndex == 0)
            {
                compareImage = new Bitmap(RGBImage);
            }
            else
            {
                compareImage = new Bitmap(YUVImage);
            }

            calculateMSE(compareImage, resultImage, out mseR, out mseG, out mseB, out mseInt);
            calculatePSNR(compareImage, resultImage, out psnrR, out psnrG, out psnrB, out psnrInt);

            MSERLabel.Text = "Difference R: " + Math.Round(mseR, 3);
            MSEGLabel.Text = "Difference G: " + Math.Round(mseG, 3);
            MSEBLabel.Text = "Difference B: " + Math.Round(mseB, 3);
            MSEIntLabel.Text = "Difference Int: " + Math.Round(mseInt, 3);

            PSNRRLabel.Text = "Difference R: " + Math.Round(psnrR, 3);
            PSNRGLabel.Text = "Difference G: " + Math.Round(psnrG, 3);
            PSNRBLabel.Text = "Difference B: " + Math.Round(psnrB, 3);
            PSNRIntLabel.Text = "Difference Int: " + Math.Round(psnrInt, 3);
        }
    }
}
