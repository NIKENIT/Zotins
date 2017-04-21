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
    public partial class LinearFiltersChooserForm : Form
    {
        public LinearFiltersChooserForm(Lab2Form owner)
        {
            InitializeComponent();
            ownerForm = owner;
        }
        Lab2Form ownerForm;
        int colorChannel = 0;
        Stopwatch stopwatch;

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = applyMeanFilter("RGB", ownerForm.originalImage,
                                                    new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height), 
                                                    new Point((int)xSizeNumUpDown.Value, (int)ySizeNumUpDown.Value), colorChannel);
            ownerForm.updateResultBox();

            long memory2 = GC.GetTotalMemory(false);
            long memory1 = GC.GetTotalMemory(true);

            stopwatch.Stop();
            ownerForm.meanFilterLabel.Text = "MeanFilter time: " + stopwatch.ElapsedMilliseconds;
        }

        public Bitmap applyMeanFilter(string colorMode, Bitmap image, Point imageSize, Point filterSize, int colorChannelIndex = 0)
        {
            Bitmap rezult = new Bitmap(image);

            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, filterSize);

            for(int x = 0; x < apertures.Count; x ++)
            {
                int rSum = 0, gSum = 0, bSum = 0, kSum = 0;

                //for(int i = 0; i < apertures[x].matrix.Count; i++)
                //{
                    List<List<Point>> matrix = apertures[x].matrix;
                    foreach(var matrixLine in matrix)
                    {
                        foreach(var Point in matrixLine)
                        {
                            int pixelPosX = Point.X;
                            int pixelPosY = Point.Y;

                            Color color = image.GetPixel(pixelPosX, pixelPosY);
                            rSum += color.R;
                            gSum += color.G;
                            bSum += color.B;
                            kSum += 1;
                        }
                    }
                //}

                if (kSum <= 0)
                    kSum = 1;

                rSum = rSum / kSum;
                if (rSum < 0)
                    rSum = 0;
                else if (rSum > 255)
                    rSum = 255;

                gSum = gSum / kSum;
                if (gSum < 0)
                    gSum = 0;
                else if (gSum > 255)
                    gSum = 255;

                bSum = bSum / kSum;
                if (bSum < 0)
                    bSum = 0;
                else if (bSum > 255)
                    bSum = 255;

                int aperturePosX = matrix.Count / 2;
                int aperturePosY = matrix[aperturePosX].Count / 2;


                Color oldColor = image.GetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y);

                if(colorChannelIndex == 0)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(rSum, gSum, bSum));
                }
                else if(colorChannelIndex == 1)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(rSum, oldColor.G, oldColor.B));
                }
                else if (colorChannelIndex == 2)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, gSum, oldColor.B));
                }
                else if (colorChannelIndex == 3)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, oldColor.G, bSum));
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

        private void medianFilterButton_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = applyMedianFilter("RGB", ownerForm.originalImage,
                                        new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                                         new Point((int)xSizeNumUpDown.Value, (int)ySizeNumUpDown.Value), colorChannel);
            ownerForm.updateResultBox();


            long memory2 = GC.GetTotalMemory(false);
            long memory1 = GC.GetTotalMemory(true);
            //MessageBox.Show("Memory2: " + memory2 + "\nMemory1: " + memory1);

            stopwatch.Stop();
            ownerForm.MedianFilterLabel.Text = "MedianFilter time: " + stopwatch.ElapsedMilliseconds;
        }

        public Bitmap applyMedianFilter(string colorMode, Bitmap image, Point imageSize, Point filterSize, int colorChannelIndex = 0)
        {
            Bitmap rezult = new Bitmap(image);

            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, filterSize);

            List<int> redList = new List<int>();
            List<int> greenList = new List<int>();
            List<int> blueList = new List<int>();

            for (int x = 0; x < apertures.Count; x++)
            {
                redList.Clear();
                blueList.Clear();
                greenList.Clear();

                List<List<Point>> matrix = apertures[x].matrix;
                foreach (var matrixLine in matrix)
                {
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        Color color = image.GetPixel(pixelPosX, pixelPosY);
                        redList.Add(color.R);
                        greenList.Add(color.G);
                        blueList.Add(color.B);
                    }
                }

                redList.Sort();
                greenList.Sort();
                blueList.Sort();

                int apertureCenter = redList.Count / 2;
                int rValue = redList[apertureCenter];
                int gValue = greenList[apertureCenter];
                int bValue = blueList[apertureCenter];

                int aperturePosX = matrix.Count / 2;
                int aperturePosY = matrix[aperturePosX].Count / 2;

                Color oldColor = image.GetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y);

                if (colorChannelIndex == 0)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(rValue, gValue, bValue));
                }
                else if (colorChannelIndex == 1)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(rValue, oldColor.G, oldColor.B));
                }
                else if (colorChannelIndex == 2)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, gValue, oldColor.B));
                }
                else if (colorChannelIndex == 3)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, oldColor.G, bValue));
                }
            }

            service = null;
            for(int i = 0; i < apertures.Count; i++)
            {
                apertures[i].Dispose();
            }
            apertures.Clear();

            return rezult;
        }

        public static double calculateGaussian(int x, double sigma)
        {
            // ?? correct maybe ??
            //return (1 / (2 * Math.PI * (Math.Pow(sigma, 2)))) * Math.Exp(-1 * (Math.Pow(x, 2) / (2 * Math.Pow(sigma, 2))));
            return (1 / (Math.Sqrt(2 * Math.PI) * sigma)) * Math.Exp(-1 * (Math.Pow(x, 2) / (2 * Math.Pow(sigma, 2))));
        }

        public static Bitmap applyGaussianBlurFilter(string colorMode, Bitmap image, Point imageSize, Point filterSize, int colorChannelIndex = 0)
        {
            Bitmap rezult = new Bitmap(image);

            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, filterSize);

            double sigma = 0.5;

            for (int x = 0; x < apertures.Count; x++)
            {
                double rSum = 0, gSum = 0, bSum = 0, kSum = 0;

                List<List<Point>> matrix = apertures[x].matrix;
                int line = 0;
                foreach (var matrixLine in matrix)
                {
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        Color color = image.GetPixel(pixelPosX, pixelPosY);
                        double kVal = calculateGaussian(line, sigma);

                        rSum += color.R * kVal;
                        gSum += color.G * kVal;
                        bSum += color.B * kVal;

                        kSum += kVal;
                    }
                    line++;
                }

                if (kSum <= 0)
                    kSum = 1;

                rSum = rSum / kSum;
                if (rSum < 0)
                    rSum = 0;
                else if (rSum > 255)
                    rSum = 255;

                gSum = gSum / kSum;
                if (gSum < 0)
                    gSum = 0;
                else if (gSum > 255)
                    gSum = 255;

                bSum = bSum / kSum;
                if (bSum < 0)
                    bSum = 0;
                else if (bSum > 255)
                    bSum = 255;



                int aperturePosX = matrix.Count / 2;
               

                if (matrix.Count != 0 && matrix[aperturePosX].Count / 2 != 0)
                {
                    int aperturePosY = matrix[aperturePosX].Count / 2;

                    Color oldColor = image.GetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y);

                    if (colorChannelIndex == 0)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb((int)rSum, (int)gSum, (int)bSum));
                    }
                    else if (colorChannelIndex == 1)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb((int)rSum, oldColor.G, oldColor.B));
                    }
                    else if (colorChannelIndex == 2)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, (int)gSum, oldColor.B));
                    }
                    else if (colorChannelIndex == 3)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, oldColor.G, (int)bSum));
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

        public int getClippingColor(int value1, int value2, double threshold)
        {
            if (Math.Abs(value1 - value2) <= threshold)
                return 1;
            else
                return 0;
        }

        public int getSuitabilityValue(int value1, int value2, double threshold)
        {
            if (Math.Abs(value1 - value2) <= threshold)
                return value1;
            else
                return 0;
        }

        public Bitmap applyJimCasaburiFilter(string colorMode, Bitmap image, Point imageSize, Point filterSize, double threshold, int colorChannelIndex = 0)
        {
            Bitmap rezult = new Bitmap(image);

            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, filterSize);

            double sigma = 0.5;

            for (int x = 0; x < apertures.Count; x++)
            {
                double ccRed = 0, svRed = 0, ccGreen = 0, svGreen = 0, ccBlue = 0, svBlue = 0;
                Color centerColor = image.GetPixel(apertures[x].x, apertures[x].y);

                List<List<Point>> matrix = apertures[x].matrix;
                //int line = 0;
                foreach (var matrixLine in matrix)
                {
                    //int point = 0;
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        Color color = image.GetPixel(pixelPosX, pixelPosY);

                        ccRed += getClippingColor(color.R, centerColor.R, threshold);
                        svRed += getSuitabilityValue(color.R, centerColor.R, threshold);

                        ccGreen += getClippingColor(color.G, centerColor.G, threshold);
                        svGreen += getSuitabilityValue(color.G, centerColor.G, threshold);

                        ccBlue += getClippingColor(color.B, centerColor.B, threshold);
                        svBlue += getSuitabilityValue(color.B, centerColor.B, threshold);



                        //point++;
                    }
                    //line++;
                }

                int R;
                if (ccRed != 0)
                    R = (int)(svRed / ccRed);
                else
                    R = centerColor.R;

                int G;
                if (ccGreen != 0)
                    G = (int)(svGreen / ccGreen);
                else
                    G = centerColor.G;

                int B;
                if (ccBlue != 0)
                    B = (int)(svBlue / ccBlue);
                else
                    B = centerColor.B;


                int aperturePosX = matrix.Count / 2;
                if (matrix.Count != 0 && matrix[aperturePosX].Count / 2 != 0)
                {
                    int aperturePosY = matrix[aperturePosX].Count / 2;

                    Color oldColor = image.GetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y);

                    if (colorChannelIndex == 0)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb((int)R, (int)G, (int)B));
                    }
                    else if (colorChannelIndex == 1)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb((int)R, oldColor.G, oldColor.B));
                    }
                    else if (colorChannelIndex == 2)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, (int)G, oldColor.B));
                    }
                    else if (colorChannelIndex == 3)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, oldColor.G, (int)B));
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

        private void JimCasaburiFilterButton_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            double threshold = (double)numericUpDown1.Value;

            ownerForm.resultImage = applyJimCasaburiFilter("RGB", ownerForm.originalImage,
                            new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                             new Point((int)xSizeNumUpDown.Value, (int)ySizeNumUpDown.Value), threshold, colorChannel);
            ownerForm.updateResultBox();


            long memory2 = GC.GetTotalMemory(false);
            long memory1 = GC.GetTotalMemory(true);
            //MessageBox.Show("Memory2: " + memory2 + "\nMemory1: " + memory1);

            stopwatch.Stop();
            ownerForm.JimFilterLabel.Text = "JimCasaburi time: " + stopwatch.ElapsedMilliseconds;
        }

        private void splitMiddleFilterButton_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = applySplitMiddleFilter("RGB", ownerForm.originalImage,
                            new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                             new Point((int)xSizeNumUpDown.Value, (int)ySizeNumUpDown.Value), (int)dUpDown.Value,  colorChannel);
            ownerForm.updateResultBox();


            long memory2 = GC.GetTotalMemory(false);
            long memory1 = GC.GetTotalMemory(true);
            //MessageBox.Show("Memory2: " + memory2 + "\nMemory1: " + memory1);

            stopwatch.Stop();
            ownerForm.CutMiddleFilterLabel.Text = "CutMiddleFilter time: " + stopwatch.ElapsedMilliseconds;
        }

        public Bitmap applySplitMiddleFilter(string colorMode, Bitmap image, Point imageSize, Point filterSize, int d,  int colorChannelIndex = 0)
        {
            Bitmap rezult = new Bitmap(image);

            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, filterSize);

            List<int> redList = new List<int>();
            List<int> greenList = new List<int>();
            List<int> blueList = new List<int>();

            List<int> redListAfterD = new List<int>();
            List<int> greenListAfterD = new List<int>();
            List<int> blueListAfterD = new List<int>();

            if (d >= filterSize.X * filterSize.Y)
            {
                MessageBox.Show("D не может быть больше или равен общему количеству пикселей в апертуре");
                return rezult;
            }

            for (int x = 0; x < apertures.Count; x++)
            {
                redList.Clear();
                blueList.Clear();
                greenList.Clear();

                redListAfterD.Clear();
                greenListAfterD.Clear();
                blueListAfterD.Clear();

                List<List<Point>> matrix = apertures[x].matrix;
                //int line = 0;
                foreach (var matrixLine in matrix)
                {
                    //int point = 0;
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        Color color = image.GetPixel(pixelPosX, pixelPosY);
                        redList.Add(color.R);
                        greenList.Add(color.G);
                        blueList.Add(color.B);

                        //point++;
                    }
                    //line++;
                }

                redList.Sort();
                greenList.Sort();
                blueList.Sort();

                //отсечение краев
                for(int i = d / 2; i < redList.Count - d / 2; i++)
                {
                    redListAfterD.Add(redList[i]);
                    greenListAfterD.Add(greenList[i]);
                    blueListAfterD.Add(blueList[i]);
                }

                int rSum = 0, gSum = 0, bSum = 0, kSum = 0;
                for(int i = 0; i < redListAfterD.Count; i++)
                {
                    rSum += redListAfterD[i];
                    gSum += greenListAfterD[i];
                    bSum += blueListAfterD[i];
                    kSum += 1;
                }

                if (kSum <= 0)
                    kSum = 1;

                rSum = rSum / kSum;
                if (rSum < 0)
                    rSum = 0;
                else if (rSum > 255)
                    rSum = 255;

                gSum = gSum / kSum;
                if (gSum < 0)
                    gSum = 0;
                else if (gSum > 255)
                    gSum = 255;

                bSum = bSum / kSum;
                if (bSum < 0)
                    bSum = 0;
                else if (bSum > 255)
                    bSum = 255;


                int aperturePosX = matrix.Count / 2;
                if (matrix.Count != 0 && matrix[aperturePosX].Count / 2 != 0)
                {
                    int aperturePosY = matrix[aperturePosX].Count / 2;

                    Color oldColor = image.GetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y);

                    if (colorChannelIndex == 0)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb((int)rSum, (int)gSum, (int)bSum));
                    }
                    else if (colorChannelIndex == 1)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb((int)rSum, oldColor.G, oldColor.B));
                    }
                    else if (colorChannelIndex == 2)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, (int)gSum, oldColor.B));
                    }
                    else if (colorChannelIndex == 3)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, oldColor.G, (int)bSum));
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

        public Bitmap applyRecursiveFilter(string colorMode, Bitmap image, Point imageSize, Point filterSize, int colorChannelIndex = 0)
        {
            Bitmap rezult = new Bitmap(image);

            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, filterSize);

            List<int> redList = new List<int>();
            List<int> greenList = new List<int>();
            List<int> blueList = new List<int>();

            double[] rSumsArray = new double[apertures.Count];
            double[] gSumsArray = new double[apertures.Count];
            double[] bSumsArray = new double[apertures.Count];

            for (int x = 0; x < apertures.Count; x++)
            {
                redList.Clear();
                blueList.Clear();
                greenList.Clear();
                int rSum = 0, gSum = 0, bSum = 0, kSum = 0;
                List<List<Point>> matrix = apertures[x].matrix;
                bool isSideAperture = false;
                foreach (var matrixLine in matrix)
                {
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;

                        //проверяем, выйдем ли мы за границы изображения слева, при расчетах, 
                        // ведь идем от -r до +r потом.
                        if (pixelPosX <= filterSize.X || pixelPosY <= filterSize.Y)
                            isSideAperture = true;

                        Color color = image.GetPixel(pixelPosX, pixelPosY);
                        redList.Add(color.R);
                        greenList.Add(color.G);
                        blueList.Add(color.B);
                        kSum += 1;
                    }
                }
                //если при расчетах выйдем за рамки, считаем просто стреднее арифметическое.
                if(isSideAperture)
                {
                    for(int i = 0; i < redList.Count; i++)
                    {
                        rSum += redList[i];
                        gSum += greenList[i];
                        bSum += blueList[i];
                        
                    }

                    rSumsArray[x] = rSum;
                    gSumsArray[x] = gSum;
                    bSumsArray[x] = bSum;
                }
                else
                {
                    int rSum1 = 0, gSum1 = 0, bSum1 = 0, kSum1 = 0;
                    int rSum2 = 0, gSum2 = 0, bSum2 = 0, kSum2 = 0;

                    //крайне правый элемент предыдущего окна
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        Color color = image.GetPixel(matrix[i][0].X - 1, matrix[i][0].Y);
                        rSum1 += color.R;
                        gSum1 += color.G;
                        bSum1 += color.B;
                        kSum1 += 1;
                    }

                    for (int i = 0; i < matrix.Count; i++)
                    {
                        Color color = image.GetPixel(matrix[i][filterSize.X - 1].X, matrix[i][filterSize.X - 1].Y);
                        rSum2 += color.R;
                        gSum2 += color.G;
                        bSum2 += color.B;
                        kSum2 += 1;
                    }

                    //вычислять рекурсию только если предыдущая апертура на той же линии
                    if (apertures[x].y == apertures[x - 1].y)
                    {
                        double rSumReal = rSumsArray[x - 1] - rSum1 + rSum2;
                        double gSumReal = gSumsArray[x - 1] - rSum1 + rSum2;
                        double bSumReal = gSumsArray[x - 1] - rSum1 + rSum2;

                        rSumsArray[x] = rSumReal;
                        gSumsArray[x] = gSumReal;
                        bSumsArray[x] = bSumReal;
                    }
                    else
                    {
                        for (int i = 0; i < redList.Count; i++)
                        {
                            rSum += redList[i];
                            gSum += greenList[i];
                            bSum += blueList[i];
                        }

                        rSumsArray[x] = rSum;
                        gSumsArray[x] = gSum;
                        bSumsArray[x] = bSum;
                    }


                }

               // int pixelCount = filterSize.X * filterSize.Y;

                rSum = (int)rSumsArray[x] / kSum;
                if (rSum < 0)
                    rSum = 0;
                else if (rSum > 255)
                    rSum = 255;

                gSum = (int)gSumsArray[x] / kSum;
                if (gSum < 0)
                    gSum = 0;
                else if (gSum > 255)
                    gSum = 255;

                bSum = (int)bSumsArray[x] / kSum;
                if (bSum < 0)
                    bSum = 0;
                else if (bSum > 255)
                    bSum = 255;

                int aperturePosX = matrix.Count / 2;
                if (matrix.Count != 0 && matrix[aperturePosX].Count / 2 != 0)
                {
                    int aperturePosY = matrix[aperturePosX].Count / 2;

                    Color oldColor = image.GetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y);

                    if (colorChannelIndex == 0)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb((int)rSum, (int)gSum, (int)bSum));
                    }
                    else if (colorChannelIndex == 1)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb((int)rSum, oldColor.G, oldColor.B));
                    }
                    else if (colorChannelIndex == 2)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, (int)gSum, oldColor.B));
                    }
                    else if (colorChannelIndex == 3)
                    {
                        rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, oldColor.G, (int)bSum));
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

        private void RecursiveFilterButton_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = applyRecursiveFilter("RGB", ownerForm.originalImage,
                new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                 new Point((int)xSizeNumUpDown.Value, (int)ySizeNumUpDown.Value), colorChannel);
            ownerForm.updateResultBox();


            long memory2 = GC.GetTotalMemory(false);
            long memory1 = GC.GetTotalMemory(true);
            //MessageBox.Show("Memory2: " + memory2 + "\nMemory1: " + memory1);

            stopwatch.Stop();
            ownerForm.RecursiveFilterLabel.Text = "RecursiveFilter time: " + stopwatch.ElapsedMilliseconds;
        }

        private void AdaptiveFilterButton_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = applyAdaptiveFilter(ownerForm.originalImage,
                                                        new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                                                         new Point((int)xSizeNumUpDown.Value, (int)ySizeNumUpDown.Value), colorChannel);
            ownerForm.updateResultBox();


            long memory2 = GC.GetTotalMemory(false);
            long memory1 = GC.GetTotalMemory(true);
            //MessageBox.Show("Memory2: " + memory2 + "\nMemory1: " + memory1);

            stopwatch.Stop();
            ownerForm.AdaptiveFilterLabel.Text = "AdaptiveFilter time: " + stopwatch.ElapsedMilliseconds;
        }

        public int adaptiveFilterProcess(Bitmap image, string colorMode, int x, int y, Point filterSize, Point imageSize, Point maxFilterSize)
        {
            ApertureService service = new ApertureService();
            int pixelPosX = 0, pixelPosY = 0;
            int rMax = 0, gMax = 0, bMax = 0;
            int rMin = 256, gMin = 256, bMin = 256;
            int rMedian, gMedian, bMedian;
            Color thisPixelColor = image.GetPixel(x, y);

            List<int> redList = new List<int>();
            List<int> greenList = new List<int>();
            List<int> blueList = new List<int>();


            for (int i = 0; i < filterSize.X; i++)
            {
                for (int j = 0; j < filterSize.Y; j++)
                {
                    service.getAperturePosition(x, y, imageSize, i, j, new Point(filterSize.X, filterSize.Y), out pixelPosX, out pixelPosY);

                    if (pixelPosX == -1 || pixelPosY == -1)
                        continue;
                    else
                    {
                        Color color = image.GetPixel(pixelPosX, pixelPosY);

                        if (rMax < color.R)
                            rMax = color.R;
                        if (rMin > color.R)
                            rMin = color.R;

                        if (gMax < color.G)
                            gMax = color.G;
                        if (gMin > color.G)
                            gMin = color.G;

                        if (bMax < color.B)
                            bMax = color.B;
                        if (bMin > color.B)
                            bMin = color.B;

                        redList.Add(color.R);
                        greenList.Add(color.G);
                        blueList.Add(color.B);

                    }
                }
            }

            //сортировка списков
            redList.Sort();
            greenList.Sort();
            blueList.Sort();

            //находим медиану яркости для апертуры
            int apertureCenter = redList.Count / 2;
            rMedian = redList[apertureCenter];
            gMedian = greenList[apertureCenter];
            bMedian = blueList[apertureCenter];

            int checkMedian, checkMin, checkMax, checkColor;

            if (colorMode == "R")
            {
                checkMedian = rMedian;
                checkMin = rMin;
                checkMax = rMax;
                checkColor = thisPixelColor.R;
            }
            else if (colorMode == "G")
            {
                checkMedian = gMedian;
                checkMin = gMin;
                checkMax = gMax;
                checkColor = thisPixelColor.G;
            }
            else if (colorMode == "B")
            {
                checkMedian = bMedian;
                checkMin = bMin;
                checkMax = bMax;
                checkColor = thisPixelColor.B;
            }
            else
                return 0;

            //branch a
            if (checkMedian - checkMin > 0 && checkMedian - checkMax < 0) //goto branch b
            {
                //branch b
                if (checkColor - checkMin > 0 && checkColor - checkMax < 0)
                {
                    return checkColor;
                }
                else
                {
                    return checkMedian;
                }
            }
            else
            {
                filterSize.X++;
                filterSize.Y++;

                if (filterSize.X > maxFilterSize.X || filterSize.Y > maxFilterSize.Y)
                {
                    return checkColor;
                }
                else
                {
                    return adaptiveFilterProcess(image, colorMode, x, y, filterSize, imageSize, maxFilterSize);
                }
            }
        }

        public Bitmap applyAdaptiveFilter(Bitmap image, Point imageSize, Point maxFilterSize, int colorChannel = 0)
        {
            Bitmap rezult = new Bitmap(image);

            int minXFilterSize = 2;
            int minYFilterSize = 2;

            int xFilterSize, yFilterSize;

            for (int x = 0; x < imageSize.X; x++)
            {
                for (int y = 0; y < imageSize.Y; y++)
                {
                    
                    xFilterSize = minXFilterSize;
                    yFilterSize = minYFilterSize;
                    Color oldColor = image.GetPixel(x, y);
                    int R, G, B;
                    if (colorChannel == 0)
                    {
                        R = adaptiveFilterProcess(image, "R", x, y, new Point(xFilterSize, yFilterSize), imageSize, maxFilterSize);
                        G = adaptiveFilterProcess(image, "G", x, y, new Point(xFilterSize, yFilterSize), imageSize, maxFilterSize);
                        B = adaptiveFilterProcess(image, "B", x, y, new Point(xFilterSize, yFilterSize), imageSize, maxFilterSize);
                    }
                    else if(colorChannel == 1)
                    {
                        R = adaptiveFilterProcess(image, "R", x, y, new Point(xFilterSize, yFilterSize), imageSize, maxFilterSize);
                        G = oldColor.G;
                        B = oldColor.B;
                    }
                    else if(colorChannel == 2)
                    {
                        R = oldColor.R;
                        G = adaptiveFilterProcess(image, "G", x, y, new Point(xFilterSize, yFilterSize), imageSize, maxFilterSize);
                        B = oldColor.B;
                    }
                    else if(colorChannel == 3)
                    {
                        R = oldColor.R;
                        G = oldColor.G;
                        B = adaptiveFilterProcess(image, "B", x, y, new Point(xFilterSize, yFilterSize), imageSize, maxFilterSize);
                    }
                    else
                    {
                        R = oldColor.R;
                        G = oldColor.G;
                        B = oldColor.B;
                    } 

                    Color color = Color.FromArgb(R, G, B);
                    rezult.SetPixel(x, y, color);     
                }
            }

            return rezult;
        }

        private void gaussianFilterButtom_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            ownerForm.resultImage = applyGaussianBlurFilter("RGB", ownerForm.originalImage,
                                                            new Point(ownerForm.originalImage.Width, ownerForm.originalImage.Height),
                                                             new Point((int)xSizeNumUpDown.Value, (int)ySizeNumUpDown.Value), colorChannel);
            ownerForm.updateResultBox();


            long memory2 = GC.GetTotalMemory(false);
            long memory1 = GC.GetTotalMemory(true);
            MessageBox.Show("Memory2: " + memory2 + "\nMemory1: " + memory1);

            stopwatch.Stop();
            ownerForm.GaussFilterLabel.Text = "GaussianFilter time: " + stopwatch.ElapsedMilliseconds;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            colorChannel = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            colorChannel = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            colorChannel = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            colorChannel = 3;
        }
    }
}
