using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zotin_1
{
    public partial class LocalMethods : Form
    {
        Lab3Form ownerForm;
        List<List<bool>> mask = new List<List<bool>>();
        int colorIndex = 0;
        Stopwatch stopwatch;

        public LocalMethods(Lab3Form OwnerForm)
        {
            InitializeComponent();

            ownerForm = OwnerForm;
        }

        private void LocalMethods_Load(object sender, EventArgs e)
        {
            mask = Morphology.createMaskList(3, 3);
            redrawMask();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = applyBernzenThersholding(ownerForm.originalImage,
                                        new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                                        new Point((int)numericUpDownX.Value, (int)numericUpDownY.Value), grayscaleCheckBox.Checked);
            ownerForm.updateResultBox();

            stopwatch.Stop();
            ownerForm.bernsenLabel.Text = "Bernsen time: " + stopwatch.ElapsedMilliseconds;
        }

        public Bitmap convertImageToGrayscale(Bitmap image)
        {
            Bitmap result = new Bitmap(image);

            for(int i = 0; i < image.Width; i++)
            {
                for(int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i, j);
                    int grayscale = (int)((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114));

                    result.SetPixel(i, j, Color.FromArgb(grayscale, grayscale, grayscale));
                }
            }
            return result;
        }

        public Bitmap applyBernzenThersholding(Bitmap image, Point imageSize, Point filterSize, bool convert = true)
        {
            Bitmap rezult = new Bitmap(image);
            Bitmap tempImage;
            if (convert)
                tempImage = convertImageToGrayscale(image);
            else
                tempImage = new Bitmap(image);

            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, filterSize);

            for (int x = 0; x < apertures.Count; x++)
            {
                int minValue = 255, maxValue = 0;
                double average;

                List<List<Point>> matrix = apertures[x].matrix;
                foreach (var matrixLine in matrix)
                {
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        //т.к. картинка черно белая, то значения РГБ одинаковы, можно брыть любое из трех.
                        if (tempImage.GetPixel(pixelPosX, pixelPosY).R > maxValue)
                            maxValue = tempImage.GetPixel(pixelPosX, pixelPosY).R;
                        if (tempImage.GetPixel(pixelPosX, pixelPosY).R < minValue)
                            minValue = tempImage.GetPixel(pixelPosX, pixelPosY).R;
                    }
                }
                average = ((double)minValue + maxValue) / 2;

                foreach (var matrixLine in matrix)
                {
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        
                        if (tempImage.GetPixel(pixelPosX, pixelPosY).R < average)
                            rezult.SetPixel(pixelPosX, pixelPosY, Color.FromArgb(0, 0, 0));
                        else
                            rezult.SetPixel(pixelPosX, pixelPosY, Color.FromArgb(255, 255, 255));
                    }
                }
            }

            service = null;
            for (int i = 0; i < apertures.Count; i++)
            {
                apertures[i].Dispose();
            }
            apertures.Clear();

            return rezult;
        }

        public Bitmap applyNiblackThersholding(Bitmap image, Point imageSize, Point filterSize, double k = 0.2, bool convert = true)
        {
            Bitmap rezult = new Bitmap(image);
            Bitmap tempImage;
            if (convert)
                tempImage = convertImageToGrayscale(image);
            else
                tempImage = new Bitmap(image);

            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, filterSize);

            for (int x = 0; x < apertures.Count; x++)
            {
                int minValue = 255, maxValue = 0;
                double average, RMS, differenceSum, value;

                List<List<Point>> matrix = apertures[x].matrix;
                foreach (var matrixLine in matrix)
                {
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        //т.к. картинка черно белая, то значения РГБ одинаковы, можно брыть любое из трех.
                        if (tempImage.GetPixel(pixelPosX, pixelPosY).R > maxValue)
                            maxValue = tempImage.GetPixel(pixelPosX, pixelPosY).R;
                        if (tempImage.GetPixel(pixelPosX, pixelPosY).R < minValue)
                            minValue = tempImage.GetPixel(pixelPosX, pixelPosY).R;
                    }
                }
                average = ((double)minValue + maxValue) / 2;
                RMS = 0;
                differenceSum = 0;

                foreach (var matrixLine in matrix)
                {
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;
                        differenceSum = Math.Pow((tempImage.GetPixel(pixelPosX, pixelPosY).R - average), 2); 
                    }
                }

                RMS += Math.Sqrt(differenceSum / (filterSize.X * filterSize.Y));
                value = (int)(average + k * RMS);

                foreach (var matrixLine in matrix)
                {
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        if (tempImage.GetPixel(pixelPosX, pixelPosY).R < value)
                            rezult.SetPixel(pixelPosX, pixelPosY, Color.FromArgb(0, 0, 0));
                        else
                            rezult.SetPixel(pixelPosX, pixelPosY, Color.FromArgb(255, 255, 255));
                    }
                }
            }

            service = null;
            for (int i = 0; i < apertures.Count; i++)
            {
                apertures[i].Dispose();
            }
            apertures.Clear();

            return rezult;
        }

        public Bitmap applyOtzuThersholding(Bitmap image, Point imageSize, int k, out int realThreshold, bool convert = true)
        {
            Bitmap rezult = new Bitmap(image);
            
            Otzu.ApplyOtsuThreshold(ref rezult, out realThreshold, k);
            return rezult;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = applyNiblackThersholding(ownerForm.originalImage,
                            new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                            new Point((int)numericUpDownX.Value, (int)numericUpDownY.Value), 0.2, grayscaleCheckBox.Checked);
            ownerForm.updateResultBox();

            stopwatch.Stop();
            ownerForm.niblackLabel.Text = "Niblack time: " + stopwatch.ElapsedMilliseconds;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            int realThreshold = 0;
            ownerForm.resultImage = applyOtzuThersholding(ownerForm.originalImage,
                new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height), 
                (int)numericUpDownOtzu.Value, out realThreshold);
            ownerForm.updateResultBox();
            label3.Text = "ResultThreshhold: " + realThreshold;

            stopwatch.Stop();
            ownerForm.otzuLabel.Text = "Otzu time: " + stopwatch.ElapsedMilliseconds;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = Morphology.applyDillation("RGB", 0, ownerForm.originalImage,
                new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                mask, new Point(mask.Count, mask[0].Count));
            ownerForm.updateResultBox();

            stopwatch.Stop();
            ownerForm.DilationLabel.Text = "Dillation time: " + stopwatch.ElapsedMilliseconds;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            MaskRedactorForm mrf = new MaskRedactorForm(mask);
            DialogResult dr =  mrf.ShowDialog();
            if(dr == DialogResult.OK)
            {
                mask = mrf.localMask;
                redrawMask();
            }
        }

        private void redrawMask()
        {
            textBox1.Clear();

            for(int i = 0; i < mask.Count; i++)
            {
                for(int j = 0; j < mask[i].Count; j++)
                {
                    string value;
                    if (mask[i][j] == true)
                        value = "1";
                    else
                        value = "0";

                    textBox1.AppendText(value + "  ");
                }
                textBox1.AppendText("\n");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = Morphology.applyErosion("RGB", 0, ownerForm.originalImage,
                new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                mask, new Point(mask.Count, mask[0].Count));
            ownerForm.updateResultBox();

            stopwatch.Stop();
            ownerForm.erosionLabel.Text = "Erosion time: " + stopwatch.ElapsedMilliseconds;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ownerForm.originalImage = ownerForm.resultImage;
            ownerForm.updateResultBox();
            ownerForm.updateOriginalBox();
        }

        private void LocalMethods_FormClosing(object sender, FormClosingEventArgs e)
        {
            ownerForm.resetOriginalImage();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ownerForm.resetOriginalImage();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(ownerForm.originalImage);
            if(colorIndex == 4)
            {
                image = convertImageToGrayscale(ownerForm.originalImage);
            }

            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = Segmentation.applyRobertsSegmentation("RGB", colorIndex, image,
                    new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                    (float)numericUpDownAmp.Value, (double)numericUpDownRobertsThreshold.Value);
            ownerForm.updateResultBox();

            stopwatch.Stop();
            ownerForm.robertsLabel.Text = "Roberts time: " + stopwatch.ElapsedMilliseconds;
        }

        private void radioButtonRGB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRGB.Checked)
                colorIndex = 0;
        }

        private void radioButtonR_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonR.Checked)
                colorIndex = 1;
        }

        private void radioButtonG_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonG.Checked)
                colorIndex = 2;
        }

        private void radioButtonB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonB.Checked)
                colorIndex = 3;
        }

        private void radioButtonGrayscale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGrayscale.Checked)
                colorIndex = 4;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(ownerForm.originalImage);
            if (colorIndex == 4)
            {
                image = convertImageToGrayscale(ownerForm.originalImage);
            }

            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = Segmentation.applySobelSegmentation("RGB", colorIndex, image,
                    new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                    (float)numericUpDownAmp.Value, (double)numericUpDownRobertsThreshold.Value);
            ownerForm.updateResultBox();

            stopwatch.Stop();
            ownerForm.sobelLabel.Text = "Sobel time: " + stopwatch.ElapsedMilliseconds;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(ownerForm.originalImage);
            if (colorIndex == 4)
            {
                image = convertImageToGrayscale(ownerForm.originalImage);
            }

            stopwatch = new Stopwatch();
            stopwatch.Start();

            Bitmap gauss = LinearFiltersChooserForm.applyGaussianBlurFilter("RGB", ownerForm.originalImage, new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height), new Point(3, 3));

            //ownerForm.resultImage = Segmentation.applyCannySegmentation("RGB", colorIndex, image,
            //        new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
            //        (int)numericUpDownMask.Value, (double)numericUpDownSigma.Value, (float)numericUpDownAmp.Value, (double)numericUpDownRobertsThreshold.Value);
            ownerForm.resultImage = Segmentation.applyCannySegmentation2("RGB", colorIndex, image,
                new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height), gauss);

            ownerForm.updateResultBox();

            stopwatch.Stop();
            ownerForm.laplasLabel.Text = "Laplas time: " + stopwatch.ElapsedMilliseconds;
        }
    }
}
