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
using System.Windows.Forms.DataVisualization.Charting;

namespace Zotin_1
{
    public partial class HystogramModificationForm : Form
    {
        ResultBox ownerForm;
        double[] hystogram;
        double[] r, g, b;
        string rName, gName, bName;
        double Const;

        public HystogramModificationForm(ResultBox owner, double[] Hystogram)
        {
            InitializeComponent();
            ownerForm = owner;
            hystogram = Hystogram;            
            this.FormClosing += new FormClosingEventHandler(HMFormClosing);
            Const = 255/((double)ownerForm.originalImage.Width * ownerForm.originalImage.Height);
        }

        private void HMFormClosing(object sender, FormClosingEventArgs e)
        {
            ownerForm.revertImage();
        }

        private void recalculateHystorgams()
        {
            ownerForm.CountHystograms("RGB", out r, out g, out b, out rName, out gName, out bName);
            chartFullHystogram.Series.Clear();

            Series series = this.chartFullHystogram.Series.Add("Grayscale");
            series.IsVisibleInLegend = false;
            series.ChartType = SeriesChartType.SplineArea;
            for (int i = 1; i < hystogram.Length - 1; i++)
            {
                series.Points.AddXY(i, hystogram[i]);
            }
            series.Color = Color.Gray;

            Series seriesR = this.chartFullHystogram.Series.Add(rName);
            seriesR.IsVisibleInLegend = false;
            seriesR.ChartType = SeriesChartType.Line;
            for (int i = 1; i < r.Length; i++)
            {
                seriesR.Points.AddXY(i, r[i]);
            }
            seriesR.Color = Color.Red;

            Series seriesG = this.chartFullHystogram.Series.Add(gName);
            seriesG.IsVisibleInLegend = false;
            seriesG.ChartType = SeriesChartType.Line;
            for (int i = 1; i < g.Length - 1; i++)
            {
                seriesG.Points.AddXY(i, g[i]);
            }
            seriesG.Color = Color.Green;

            Series seriesB = this.chartFullHystogram.Series.Add(bName);
            seriesB.IsVisibleInLegend = false;
            seriesB.ChartType = SeriesChartType.Line;
            for (int i = 1; i < b.Length - 1; i++)
            {
                seriesB.Points.AddXY(i, b[i]);
            }
            seriesB.Color = Color.Blue;

            button1.PerformClick();
            button3.PerformClick();
            button4.PerformClick();
        }

        private void HystogramModificationForm_Load(object sender, EventArgs e)
        {
            recalculateHystorgams();
            clearDrawingHystograms();            
        }

        private void clearDrawingHystograms()
        {
            DrawingR.Series.Clear();
            DrawingG.Series.Clear();
            DrawingB.Series.Clear();

            Series seriesR = this.DrawingR.Series.Add(bName);
            seriesR.IsVisibleInLegend = false;
            seriesR.ChartType = SeriesChartType.Line;
            DrawingR.ChartAreas[0].AxisX.Maximum = 255;
            DrawingR.ChartAreas[0].AxisX.Minimum = 0;
            DrawingR.ChartAreas[0].AxisY.Maximum = 255;
            DrawingR.ChartAreas[0].AxisY.Minimum = 0;
            seriesR.Points.AddXY(0, 0);
            seriesR.Points.AddXY(255, 255);

            seriesR.Color = Color.Red;

            Series seriesG = this.DrawingG.Series.Add(bName);
            seriesG.IsVisibleInLegend = false;
            seriesG.ChartType = SeriesChartType.Line;
            DrawingG.ChartAreas[0].AxisX.Maximum = 255;
            DrawingG.ChartAreas[0].AxisX.Minimum = 0;
            DrawingG.ChartAreas[0].AxisY.Maximum = 255;
            DrawingG.ChartAreas[0].AxisY.Minimum = 0;
            seriesG.Points.AddXY(0, 0);
            seriesG.Points.AddXY(255, 255);

            seriesG.Color = Color.Green;

            Series seriesB = this.DrawingB.Series.Add(bName);
            seriesB.IsVisibleInLegend = false;
            seriesB.ChartType = SeriesChartType.Line;
            DrawingB.ChartAreas[0].AxisX.Maximum = 255;
            DrawingB.ChartAreas[0].AxisX.Minimum = 0;
            DrawingB.ChartAreas[0].AxisY.Maximum = 255;
            DrawingB.ChartAreas[0].AxisY.Minimum = 0;
            seriesB.Points.AddXY(0, 0);
            seriesB.Points.AddXY(255, 255);

            seriesB.Color = Color.Blue;

            //////////////////////////////////////////////////////////////////////////////////////////

            rNormChart.Series.Clear();
            gNormChart.Series.Clear();
            bNormChart.Series.Clear();

            Series seriesRN = this.rNormChart.Series.Add(bName);
            seriesRN.IsVisibleInLegend = false;
            seriesRN.ChartType = SeriesChartType.Spline;
            rNormChart.ChartAreas[0].AxisX.Maximum = 255;
            rNormChart.ChartAreas[0].AxisX.Minimum = 0;
            rNormChart.ChartAreas[0].AxisY.Maximum = 3.5;
            rNormChart.ChartAreas[0].AxisY.Minimum = 0.2;
            seriesRN.Points.AddXY(0, 1);
            seriesRN.Points.AddXY(255, 1);
            seriesRN.Color = Color.Red;

            Series seriesGN = this.gNormChart.Series.Add(bName);
            seriesGN.IsVisibleInLegend = false;
            seriesGN.ChartType = SeriesChartType.Spline;
            gNormChart.ChartAreas[0].AxisX.Maximum = 255;
            gNormChart.ChartAreas[0].AxisX.Minimum = 0;
            gNormChart.ChartAreas[0].AxisY.Maximum = 3.5;
            gNormChart.ChartAreas[0].AxisY.Minimum = 0.2;
            seriesGN.Points.AddXY(0, 1);
            seriesGN.Points.AddXY(255, 1);
            seriesGN.Color = Color.Green;

            Series seriesBN = this.bNormChart.Series.Add(bName);
            seriesBN.IsVisibleInLegend = false;
            seriesBN.ChartType = SeriesChartType.Spline;
            bNormChart.ChartAreas[0].AxisX.Maximum = 255;
            bNormChart.ChartAreas[0].AxisX.Minimum = 0;
            bNormChart.ChartAreas[0].AxisY.Maximum = 3.5;
            bNormChart.ChartAreas[0].AxisY.Minimum = 0.2;
            seriesBN.Points.AddXY(0, 1);
            seriesBN.Points.AddXY(255, 1);
            seriesBN.Color = Color.Blue;

        }

        private double[] calculateRange(double[] array, int from, int to)
        {
            int rangeFrom = from;
            int rangeTo = to;
            double[] resultArray;

            if (rangeFrom > rangeTo)
            {
                //атата, нехорошо.
                int temp = rangeFrom;
                rangeFrom = rangeTo;
                rangeTo = temp;
            }

            resultArray = new double[rangeTo - rangeFrom + 1];

            int counter = 0;
            for (int i = rangeFrom; i <= rangeTo; i++)
            {
                resultArray[counter] = array[i];
                counter++;
            }

            return resultArray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] rFormHystogram = calculateRange(r, (int)numericUpDown1.Value, (int)numericUpDown2.Value);            

            chartExampleHystogramR.Series.Clear();
            Series seriesR = this.chartExampleHystogramR.Series.Add(rName);
            seriesR.IsVisibleInLegend = false;
            seriesR.ChartType = SeriesChartType.Line;
            for (int i = 1; i < rFormHystogram.Length-1; i++)
            {
                seriesR.Points.AddXY(i, rFormHystogram[i]);
            }
            seriesR.Color = Color.Red;

            double[] normalizedHystogram = processHystogram(rFormHystogram);

            NormalizedR.Series.Clear();
            Series seriesNR = this.NormalizedR.Series.Add(rName);
            seriesNR.IsVisibleInLegend = false;
            seriesNR.ChartType = SeriesChartType.SplineArea;
            for (int i = 0; i < normalizedHystogram.Length; i++)
            {
                seriesNR.Points.AddXY(i, normalizedHystogram[i]);
            }
            seriesNR.Color = Color.Red;
        }

        private double[] avgHystogram(double[] hystogram, int n)
        {
            double[] result = new double[hystogram.Length];
            hystogram.CopyTo(result, 0);

            for (int i = 1; i < hystogram.Length; i++)
            {
                result[i] = result[i] / n * i;
            }

            return result;
        }

        private double[] normalizeHystogram(double[] hystogram)
        {
            double[] result = new double[hystogram.Length];
            hystogram.CopyTo(result, 0);

            for(int i = 1; i < hystogram.Length; i++)
            {
                result[i] = result[i - 1] + result[i];
            }

            return result;
        }

        private double[] processHystogram(double[] hystogram)
        {
            double[] result = new double[hystogram.Length];
            hystogram.CopyTo(result, 0);

            //result = avgHystogram(result, (ownerForm.originalImage.Width * ownerForm.originalImage.Height));
            result = normalizeHystogram(result);

            return result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ownerForm.revertImage();
            recalculateHystorgams();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public static IEnumerable<Point> GetPointsOnLine(int x0, int y0, int x1, int y1)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                int t;
                t = x0; // swap x0 and y0
                x0 = y0;
                y0 = t;
                t = x1; // swap x1 and y1
                x1 = y1;
                y1 = t;
            }
            if (x0 > x1)
            {
                int t;
                t = x0; // swap x0 and x1
                x0 = x1;
                x1 = t;
                t = y0; // swap y0 and y1
                y0 = y1;
                y1 = t;
            }
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                yield return new Point((steep ? y : x), (steep ? x : y));
                error = error - dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
            yield break;
        }

        private void DrawingR_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            HitTestResult result = DrawingR.HitTest(args.X, args.Y);
            ChartArea chartAreas = DrawingR.ChartAreas[0];
            int X = (int)chartAreas.AxisX.PixelPositionToValue(args.X);
            int Y = (int)chartAreas.AxisY.PixelPositionToValue(args.Y);

            if (X >= 0 && X <= 255 && Y >= 0 && Y <= 255)
            {
                //MessageBox.Show("Coordinates: X " + X + " Y " + Y);
                DataPoint[] dataPoints = DrawingR.Series[0].Points.ToArray();

                bool xFound = false;
                for(int i = 0; i < dataPoints.Length; i++)
                {
                    if(dataPoints[i].XValue == X)
                    {
                        dataPoints[i].YValues[0] = Y;
                        xFound = true;
                    }
                }

                DrawingR.Series[0].Points.Clear();
                SortedDictionary<int, int> realPoints = new SortedDictionary<int, int>();

                foreach (DataPoint point in dataPoints)
                {
                    realPoints.Add((int)point.XValue, (int)point.YValues[0]);
                }
                if(xFound == false)
                {
                    realPoints.Add(X, Y);                    
                }
                

                foreach(var point in realPoints)
                {
                    DrawingR.Series[0].Points.AddXY(point.Key, point.Value);
                }
            }
        }

        private void DrawingR_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = DrawingR.HitTest(e.X, e.Y);
            ChartArea chartAreas = DrawingR.ChartAreas[0];

            double X = chartAreas.AxisX.PixelPositionToValue(e.X);
            double Y = chartAreas.AxisY.PixelPositionToValue(e.Y);

            chartAreas.CursorX.Position = X;
            chartAreas.CursorY.Position = Y;

            if(X >= -1 && Y >= -1 && X <=256 && Y <= 256)
                rHystoLabel.Text = "Coordinates " + (int)X + "; " + (int)Y;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void DrawingG_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            HitTestResult result = DrawingG.HitTest(args.X, args.Y);
            ChartArea chartAreas = DrawingG.ChartAreas[0];
            int X = (int)chartAreas.AxisX.PixelPositionToValue(args.X);
            int Y = (int)chartAreas.AxisY.PixelPositionToValue(args.Y);

            if (X >= 0 && X <= 255 && Y >= 0 && Y <= 255)
            {
                //MessageBox.Show("Coordinates: X " + X + " Y " + Y);
                DataPoint[] dataPoints = DrawingG.Series[0].Points.ToArray();

                bool xFound = false;
                for (int i = 0; i < dataPoints.Length; i++)
                {
                    if (dataPoints[i].XValue == X)
                    {
                        dataPoints[i].YValues[0] = Y;
                        xFound = true;
                    }
                }

                DrawingG.Series[0].Points.Clear();
                SortedDictionary<int, int> realPoints = new SortedDictionary<int, int>();

                foreach (DataPoint point in dataPoints)
                {
                    realPoints.Add((int)point.XValue, (int)point.YValues[0]);
                }
                if (xFound == false)
                {
                    realPoints.Add(X, Y);
                }


                foreach (var point in realPoints)
                {
                    DrawingG.Series[0].Points.AddXY(point.Key, point.Value);
                }
            }
        }

        private void DrawingB_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            HitTestResult result = DrawingB.HitTest(args.X, args.Y);
            ChartArea chartAreas = DrawingB.ChartAreas[0];
            int X = (int)chartAreas.AxisX.PixelPositionToValue(args.X);
            int Y = (int)chartAreas.AxisY.PixelPositionToValue(args.Y);

            if (X >= 0 && X <= 255 && Y >= 0 && Y <= 255)
            {
                //MessageBox.Show("Coordinates: X " + X + " Y " + Y);
                DataPoint[] dataPoints = DrawingB.Series[0].Points.ToArray();

                bool xFound = false;
                for (int i = 0; i < dataPoints.Length; i++)
                {
                    if (dataPoints[i].XValue == X)
                    {
                        dataPoints[i].YValues[0] = Y;
                        xFound = true;
                    }
                }

                DrawingB.Series[0].Points.Clear();
                SortedDictionary<int, int> realPoints = new SortedDictionary<int, int>();

                foreach (DataPoint point in dataPoints)
                {
                    realPoints.Add((int)point.XValue, (int)point.YValues[0]);
                }
                if (xFound == false)
                {
                    realPoints.Add(X, Y);
                }


                foreach (var point in realPoints)
                {
                    DrawingB.Series[0].Points.AddXY(point.Key, point.Value);
                }
            }
        }

        private void DrawingG_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = DrawingG.HitTest(e.X, e.Y);
            ChartArea chartAreas = DrawingG.ChartAreas[0];

            double X = chartAreas.AxisX.PixelPositionToValue(e.X);
            double Y = chartAreas.AxisY.PixelPositionToValue(e.Y);

            chartAreas.CursorX.Position = X;
            chartAreas.CursorY.Position = Y;

            if (X >= -1 && Y >= -1 && X <= 256 && Y <= 256)
                gHystoLabel.Text = "Coordinates " + (int)X + "; " + (int)Y;
        }

        private void DrawingB_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = DrawingB.HitTest(e.X, e.Y);
            ChartArea chartAreas = DrawingB.ChartAreas[0];

            double X = chartAreas.AxisX.PixelPositionToValue(e.X);
            double Y = chartAreas.AxisY.PixelPositionToValue(e.Y);

            chartAreas.CursorX.Position = X;
            chartAreas.CursorY.Position = Y;

            if (X >= -1 && Y >= -1 && X <= 256 && Y <= 256)
                bHystoLabel.Text = "Coordinates " + (int)X + "; " + (int)Y;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DrawingR.Series[0].Points.Clear();
            if (checkBox1.Checked == true)
            {
                DrawingR.Series[0].Points.AddXY(0, 0);
                DrawingR.Series[0].Points.AddXY(255, 255);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DrawingG.Series[0].Points.Clear();
            if (checkBox2.Checked == true)
            {
                DrawingG.Series[0].Points.AddXY(0, 0);
                DrawingG.Series[0].Points.AddXY(255, 255);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DrawingB.Series[0].Points.Clear();
            if (checkBox3.Checked == true)
            {
                DrawingB.Series[0].Points.AddXY(0, 0);
                DrawingB.Series[0].Points.AddXY(255, 255);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ownerForm.revertImage();
            double[] RnormalizedHystogram;
            if (DrawingR.Series[0].Points.Count > 1)
            {
                RnormalizedHystogram = generateHystogramFromDrawing(DrawingR);
            }
            else
            {
                RnormalizedHystogram = null;
            }

            double[] GnormalizedHystogram;
            if (DrawingG.Series[0].Points.Count > 1)
            {
                GnormalizedHystogram = generateHystogramFromDrawing(DrawingG);
            }
            else
            {
                GnormalizedHystogram = null;
            }

            double[] BnormalizedHystogram;
            if (DrawingB.Series[0].Points.Count > 1)
            {
                BnormalizedHystogram = generateHystogramFromDrawing(DrawingB);
            }
            else
            {
                BnormalizedHystogram = null;
            }

            int R, G, B;
            for (int i = 0; i < ownerForm.originalImage.Width; i++)
            {
                for (int j = 0; j < ownerForm.originalImage.Height; j++)
                {
                    Color color = ownerForm.originalImage.GetPixel(i, j);

                    if (RnormalizedHystogram != null)
                        R = (int)((double)RnormalizedHystogram[color.R]);
                    else
                        R = color.R;

                    if (GnormalizedHystogram != null)
                        G = (int)((double)GnormalizedHystogram[color.G]);
                    else
                        G = color.G;

                    if (BnormalizedHystogram != null)
                        B = (int)((double)BnormalizedHystogram[color.B]);
                    else
                        B = color.B;

                    ownerForm.localImage.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            ownerForm.updatePicturebox();
            recalculateHystorgams();
            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        private double[] generateHystogramFromDrawing(Chart drawingR)
        {
            //магия
            double[] result = new double[256];

            DataPoint[] dataPoints = drawingR.Series[0].Points.ToArray();

            SortedDictionary<int, int> realPoints = new SortedDictionary<int, int>();
            
            //сначала переводим из массива дата-точек в упорядоченный словарь, чтобы упорядочить D:
            foreach (DataPoint point in dataPoints)
            {
                realPoints.Add((int)point.XValue, (int)point.YValues[0]);
            }

            //грязные хаки евривере. но ТАК лень писать норм реализацию...
            //потом словарь превращаем в список точек (он будет уже упорядочен)
            List<Point> pointsList = new List<Point>();
            foreach(var point in realPoints)
            {
                pointsList.Add(new Point(point.Key, point.Value));
            }

            List<Point> resultPoints = new List<Point>();
            //заполняем список между каждыми 2 точками остальными точками, по алгоритму
            for (int i = 0; i < pointsList.Count - 1; i++)
            {
                var test = GetPointsOnLine(pointsList[i].X, pointsList[i].Y, pointsList[i+1].X, pointsList[i+1].Y);
                resultPoints.AddRange(test);
            }
            //сортируем список, ибо иногда там падает порядок.
            resultPoints.Sort((x, y) => x.X.CompareTo(y.X));
            //тёмная магия, удаляем дубликаты по X из списка.
            List<Point> finalPoints = resultPoints.GroupBy(x => x.X).Select(x => x.First()).ToList<Point>();

            //зануление массива и заполнение определенных величин нужными
            Array.Clear(result, 0, result.Length);
            for(int i = 0; i < finalPoints.Count(); i++)
            {
                result[finalPoints[i].X] = finalPoints[i].Y;
            }

            return result;
        }

        private void rNormChart_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            HitTestResult result = rNormChart.HitTest(args.X, args.Y);
            ChartArea chartAreas = rNormChart.ChartAreas[0];
            double X = chartAreas.AxisX.PixelPositionToValue(args.X);
            double Y = chartAreas.AxisY.PixelPositionToValue(args.Y);

            if (X >= 0 && X <= 255 && Y >= 0 && Y <= 255)
            {
                //MessageBox.Show("Coordinates: X " + X + " Y " + Y);
                DataPoint[] dataPoints = rNormChart.Series[0].Points.ToArray();

                bool xFound = false;
                for (int i = 0; i < dataPoints.Length; i++)
                {
                    if (dataPoints[i].XValue == X)
                    {
                        dataPoints[i].YValues[0] = Y;
                        xFound = true;
                    }
                }

                rNormChart.Series[0].Points.Clear();
                SortedDictionary<double, double> realPoints = new SortedDictionary<double, double>();

                foreach (DataPoint point in dataPoints)
                {
                    realPoints.Add(point.XValue, point.YValues[0]);
                }
                if (xFound == false)
                {
                    realPoints.Add(X, Y);
                }


                foreach (var point in realPoints)
                {
                    rNormChart.Series[0].Points.AddXY(point.Key, point.Value);
                }
            }
        }

        private void gNormChart_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            HitTestResult result = gNormChart.HitTest(args.X, args.Y);
            ChartArea chartAreas = gNormChart.ChartAreas[0];
            double X = (double)chartAreas.AxisX.PixelPositionToValue(args.X);
            double Y = (double)chartAreas.AxisY.PixelPositionToValue(args.Y);

            if (X >= 0 && X <= 255 && Y >= 0 && Y <= 255)
            {
                //MessageBox.Show("Coordinates: X " + X + " Y " + Y);
                DataPoint[] dataPoints = gNormChart.Series[0].Points.ToArray();

                bool xFound = false;
                for (int i = 0; i < dataPoints.Length; i++)
                {
                    if (dataPoints[i].XValue == X)
                    {
                        dataPoints[i].YValues[0] = Y;
                        xFound = true;
                    }
                }

                gNormChart.Series[0].Points.Clear();
                SortedDictionary<double, double> realPoints = new SortedDictionary<double, double>();

                foreach (DataPoint point in dataPoints)
                {
                    realPoints.Add((double)point.XValue, (double)point.YValues[0]);
                }
                if (xFound == false)
                {
                    realPoints.Add(X, Y);
                }


                foreach (var point in realPoints)
                {
                    gNormChart.Series[0].Points.AddXY(point.Key, point.Value);
                }
            }
        }

        private void bNormChart_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            HitTestResult result = bNormChart.HitTest(args.X, args.Y);
            ChartArea chartAreas = bNormChart.ChartAreas[0];
            double X = (double)chartAreas.AxisX.PixelPositionToValue(args.X);
            double Y = (double)chartAreas.AxisY.PixelPositionToValue(args.Y);

            if (X >= 0 && X <= 255 && Y >= 0 && Y <= 255)
            {
                //MessageBox.Show("Coordinates: X " + X + " Y " + Y);
                DataPoint[] dataPoints = bNormChart.Series[0].Points.ToArray();

                bool xFound = false;
                for (int i = 0; i < dataPoints.Length; i++)
                {
                    if (dataPoints[i].XValue == X)
                    {
                        dataPoints[i].YValues[0] = Y;
                        xFound = true;
                    }
                }

                bNormChart.Series[0].Points.Clear();
                SortedDictionary<double, double> realPoints = new SortedDictionary<double, double>();

                foreach (DataPoint point in dataPoints)
                {
                    realPoints.Add((double)point.XValue, (double)point.YValues[0]);
                }
                if (xFound == false)
                {
                    realPoints.Add(X, Y);
                }


                foreach (var point in realPoints)
                {
                    bNormChart.Series[0].Points.AddXY(point.Key, point.Value);
                }
            }
        }

        private void rNormChart_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = rNormChart.HitTest(e.X, e.Y);
            ChartArea chartAreas = rNormChart.ChartAreas[0];

            double X = chartAreas.AxisX.PixelPositionToValue(e.X);
            double Y = chartAreas.AxisY.PixelPositionToValue(e.Y);

            chartAreas.CursorX.Position = X;
            chartAreas.CursorY.Position = Y;

            if (X >= -1 && Y >= -1 && X <= 256 && Y <= 256)
                rNormLabel.Text = "Coordinates " + (int)X + "; " + (double)Y;
        }

        private void gNormChart_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = gNormChart.HitTest(e.X, e.Y);
            ChartArea chartAreas = gNormChart.ChartAreas[0];

            double X = chartAreas.AxisX.PixelPositionToValue(e.X);
            double Y = chartAreas.AxisY.PixelPositionToValue(e.Y);

            chartAreas.CursorX.Position = X;
            chartAreas.CursorY.Position = Y;

            if (X >= -1 && Y >= -1 && X <= 256 && Y <= 256)
                gNormLabel.Text = "Coordinates " + (int)X + "; " + (double)Y;
        }

        private void bNormChart_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = bNormChart.HitTest(e.X, e.Y);
            ChartArea chartAreas = bNormChart.ChartAreas[0];

            double X = chartAreas.AxisX.PixelPositionToValue(e.X);
            double Y = chartAreas.AxisY.PixelPositionToValue(e.Y);

            chartAreas.CursorX.Position = X;
            chartAreas.CursorY.Position = Y;

            if (X >= -1 && Y >= -1 && X <= 256 && Y <= 256)
                bNormLabel.Text = "Coordinates " + (int)X + "; " + (double)Y;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            rNormChart.Series[0].Points.Clear();
            if (checkBox6.Checked == true)
            {
                rNormChart.Series[0].Points.AddXY(0, 1);
                rNormChart.Series[0].Points.AddXY(255, 1);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gNormChart.Series[0].Points.Clear();
            if (checkBox5.Checked == true)
            {
                gNormChart.Series[0].Points.AddXY(0, 1);
                gNormChart.Series[0].Points.AddXY(255, 1);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bNormChart.Series[0].Points.Clear();
            if (checkBox4.Checked == true)
            {
                bNormChart.Series[0].Points.AddXY(0, 1);
                bNormChart.Series[0].Points.AddXY(255, 1);
            }
        }

        private void normalizeButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ownerForm.revertImage();

            int RpeakStart = -1, RpeakFinish = -1;
            int GpeakStart = -1, GpeakFinish = -1;
            int BpeakStart = -1, BpeakFinish = -1;
            double[] RnormalizedHystogram;
            if (rNormChart.Series[0].Points.Count > 1)
            {
                RnormalizedHystogram = generateHystogramFromDrawing(rNormChart);
                RnormalizedHystogram = generateNormalizedHystogramFromHystogram(RnormalizedHystogram, r);

                //куски алгоритма нормализации. почти не используется, для будущего нужен
                //////////////////////////////////////////////////////
                int lowestPercent = 1;
                int pixelCount = ownerForm.originalImage.Width * ownerForm.originalImage.Height;
                double rMax = 0, rMin = 99999999;

                for(int i = 0; i < r.Length; i++)
                {
                    if (r[i] > rMax)
                        rMax = r[i];
                    if (r[i] < rMin)
                        rMin = r[i];
                }


                for (int i = 0; i < r.Length; i++)
                {
                    if (r[i] >= ((rMax - rMin)*0.05) && RpeakStart == -1)
                    {
                        RpeakStart = i;
                    }
                }
                for(int i = r.Length - 1; i >= 0; i--)
                {
                    if (r[i] >= ((rMax - rMin) * 0.05) && RpeakFinish == -1)
                    {
                        RpeakFinish = i;
                    }
                }

                if (RpeakStart > -1 && RpeakFinish == -1)
                    RpeakFinish = 255;

                /////////////////////////////////////////////////////////
            }
            else
            {
                RnormalizedHystogram = null;
            }

            double[] GnormalizedHystogram;
            if (gNormChart.Series[0].Points.Count > 1)
            {
                GnormalizedHystogram = generateHystogramFromDrawing(gNormChart);
                GnormalizedHystogram = generateNormalizedHystogramFromHystogram(GnormalizedHystogram, g);

                //////////////////////////////////////////////////////
                int lowestPercent = 1;
                int pixelCount = ownerForm.originalImage.Width * ownerForm.originalImage.Height;
                double gMax = 0, gMin = 99999999;

                for (int i = 0; i < g.Length; i++)
                {
                    if (g[i] > gMax)
                        gMax = g[i];
                    if (g[i] < gMin)
                        gMin = g[i];
                }


                for (int i = 0; i < g.Length; i++)
                {
                    if (g[i] >= ((gMax - gMin) * 0.05) && GpeakStart == -1)
                    {
                        GpeakStart = i;
                    }
                }
                for (int i = g.Length - 1; i >= 0; i--)
                {
                    if (g[i] >= ((gMax - gMin) * 0.05) && GpeakFinish == -1)
                    {
                        GpeakFinish = i;
                    }
                }

                if (GpeakStart > -1 && GpeakFinish == -1)
                    GpeakFinish = 255;

            }
            else
            {
                GnormalizedHystogram = null;
            }

            double[] BnormalizedHystogram;
            if (bNormChart.Series[0].Points.Count > 1)
            {
                BnormalizedHystogram = generateHystogramFromDrawing(bNormChart);
                BnormalizedHystogram = generateNormalizedHystogramFromHystogram(BnormalizedHystogram, b);

                //////////////////////////////////////////////////////
                int lowestPercent = 1;
                int pixelCount = ownerForm.originalImage.Width * ownerForm.originalImage.Height;
                double bMax = 0, bMin = 99999999;

                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i] > bMax)
                        bMax = b[i];
                    if (b[i] < bMin)
                        bMin = b[i];
                }


                for (int i = 0; i < b.Length; i++)
                {
                    if (r[i] >= ((bMax - bMin) * 0.05) && BpeakStart == -1)
                    {
                        BpeakStart = i;
                    }
                }
                for (int i = b.Length - 1; i >= 0; i--)
                {
                    if (b[i] >= ((bMax - bMin) * 0.05) && BpeakFinish == -1)
                    {
                        BpeakFinish = i;
                    }
                }

                if (BpeakStart > -1 && BpeakFinish == -1)
                    BpeakFinish = 255;

            }
            else
            {
                BnormalizedHystogram = null;
            }


            //RpeakFinish = 50;
            //RpeakStart = 5;
            int R, G, B;
            for (int i = 0; i < ownerForm.originalImage.Width; i++)
            {
                for (int j = 0; j < ownerForm.originalImage.Height; j++)
                {
                    Color color = ownerForm.originalImage.GetPixel(i, j);

                    if (RnormalizedHystogram != null)
                        //R = (int)((double)RnormalizedHystogram[color.R]);

                        //обычная нормализация
                        //R = (int)((double)(color.R - RpeakStart) * ((255 - 0) / (double)(RpeakFinish - RpeakStart)) + 0);

                        //нормализация по линиям
                        R = (int)((color.R - RpeakStart) * RnormalizedHystogram[color.R]);
                    else
                        R = color.R;

                    //int I = (I - min) * (newMax - newMin) / (Max - min) + newMin

                    if (GnormalizedHystogram != null)
                        //G = (int)((double)GnormalizedHystogram[color.G]);

                        //G = (int)((double)(color.G - GpeakStart) * ((255 - 0) / (double)(GpeakFinish - GpeakStart)) + 0);
                        G = (int)((color.G - GpeakStart) * GnormalizedHystogram[color.G]);
                    else
                        G = color.G;

                    if (BnormalizedHystogram != null)
                        //B = (int)((double)BnormalizedHystogram[color.B]);

                        //B = (int)((double)(color.B - BpeakStart) * ((255 - 0) / (double)(BpeakFinish - BpeakStart)) + 0);
                        B = (int)((color.B - BpeakStart) * BnormalizedHystogram[color.B]);
                    else
                        B = color.B;

                    if (R > 255)
                        R = 255;
                    else if (R < 0)
                        R = 0;

                    if (G > 255)
                        G = 255;
                    else if (G < 0)
                        G = 0;

                    if (B > 255)
                        B = 255;
                    else if (B < 0)
                        B = 0;

                    ownerForm.localImage.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }


            ownerForm.updatePicturebox();
            recalculateHystorgams();
            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        private double[] generateNormalizedHystogramFromHystogram(double[] linePoints, double[] Hystogram)
        {
            double[] result = new double[256];
            //нижняя граница для поиска пика, 5% от общего числа пикселей
            int lowestPercent = 5;
            int finalStart = 0, finalFinish = 255;
            int pixelCount = ownerForm.originalImage.Width * ownerForm.originalImage.Height;

            int peakStart = -1, peakFinish = -1;
            double rMax = 0, rMin = 99999999;

            for (int i = 0; i < Hystogram.Length; i++)
            {
                if (Hystogram[i] > rMax)
                    rMax = Hystogram[i];
                if (Hystogram[i] < rMin)
                    rMin = Hystogram[i];
            }


            for (int i = 0; i < Hystogram.Length; i++)
            {
                if (Hystogram[i] >= ((rMax - rMin) * ((double)lowestPercent/100)) && peakStart == -1)
                {
                    peakStart = i;
                }
            }
            for (int i = Hystogram.Length - 1; i >= 0; i--)
            {
                if (Hystogram[i] >= ((rMax - rMin) * ((double)lowestPercent / 100)) && peakFinish == -1)
                {
                    peakFinish = i;
                }
            }

            if (peakStart > -1 && peakFinish == -1)
                peakFinish = 255;



            if (peakStart > -1 && peakFinish > -1)
            {
                double sum_kf_hyst = 0;
                for (int i = peakStart; i < peakFinish + 1; i++)
                {
                    sum_kf_hyst += linePoints[i];
                }

                //здесь считаем среднее, чтоб было = 1, если нет - подстраиваем точки? наверное.
                if(sum_kf_hyst / (peakFinish-peakStart) > 1)
                {
                }

                for (int i = 0; i < hystogram.Length; i++)
                {
                    //result[i] = (hystogram[i] - peakStart) * ((255 - 0) / (double)(peakFinish - peakStart));
                    result[i] = (255 / (double)(peakFinish - peakStart)) * linePoints[i] * (sum_kf_hyst / (double)(peakFinish - peakStart));
                }
            }
            else
            {
                MessageBox.Show("Error! Error! Error!");
            }


            return result;
        }

        private int normalizeColorValue(int colorValue, int additionalValue, int minValue = 0, int maxValue = 255)
        {
            int result = colorValue + additionalValue;

            if (result > maxValue)
                result = maxValue;
            else if (result < minValue)
                result = minValue;

            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[] gFormHystogram = calculateRange(g, (int)numericUpDown4.Value, (int)numericUpDown3.Value);

            chartExampleHystogramG.Series.Clear();
            Series seriesG = this.chartExampleHystogramG.Series.Add(gName);
            seriesG.IsVisibleInLegend = false;
            seriesG.ChartType = SeriesChartType.Line;
            for (int i = 1; i < gFormHystogram.Length - 1; i++)
            {
                seriesG.Points.AddXY(i, gFormHystogram[i]);
            }
            seriesG.Color = Color.Green;

            double[] normalizedHystogram = processHystogram(gFormHystogram);

            NormalizedG.Series.Clear();
            Series seriesNG = this.NormalizedG.Series.Add(gName);
            seriesNG.IsVisibleInLegend = false;
            seriesNG.ChartType = SeriesChartType.SplineArea;
            for (int i = 0; i < normalizedHystogram.Length; i++)
            {
                seriesNG.Points.AddXY(i, normalizedHystogram[i]);
            }
            seriesNG.Color = Color.Green;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double[] bFormHystogram = calculateRange(b, (int)numericUpDown6.Value, (int)numericUpDown5.Value);

            chartExampleHystogramB.Series.Clear();
            Series seriesB = this.chartExampleHystogramB.Series.Add(bName);
            seriesB.IsVisibleInLegend = false;
            seriesB.ChartType = SeriesChartType.Line;
            for (int i = 1; i < bFormHystogram.Length - 1; i++)
            {
                seriesB.Points.AddXY(i, bFormHystogram[i]);
            }
            seriesB.Color = Color.Blue;

            double[] normalizedHystogram = processHystogram(bFormHystogram);

            NormalizedB.Series.Clear();
            Series seriesNB = this.NormalizedB.Series.Add(bName);
            seriesNB.IsVisibleInLegend = false;
            seriesNB.ChartType = SeriesChartType.SplineArea;
            for (int i = 0; i < normalizedHystogram.Length; i++)
            {
                seriesNB.Points.AddXY(i, normalizedHystogram[i]);
            }
            seriesNB.Color = Color.Blue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ownerForm.revertImage();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //double[] rFormHystogram = calculateRange(r, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            double[] RnormalizedHystogram = processHystogram(r);

            //double[] bFormHystogram = calculateRange(b, (int)numericUpDown6.Value, (int)numericUpDown5.Value);
            double[] GnormalizedHystogram = processHystogram(g);

            //double[] gFormHystogram = calculateRange(g, (int)numericUpDown4.Value, (int)numericUpDown3.Value);
            double[] BnormalizedHystogram = processHystogram(b);

            int R, G, B;
            for(int i = 0; i < ownerForm.originalImage.Width; i++)
            {
                for (int j = 0; j < ownerForm.originalImage.Height; j++)
                {
                    Color color = ownerForm.originalImage.GetPixel(i, j);
                    
                    R = (int)((double)RnormalizedHystogram[color.R] * Const);

                    //if (R > (int)numericUpDown2.Value)
                    //    R = (int)numericUpDown2.Value;
                    //else if (R < (int)numericUpDown1.Value)
                    //    R = (int)numericUpDown1.Value;

                    G = (int)((double)GnormalizedHystogram[color.G] * Const);

                    //if (G > (int)numericUpDown3.Value)
                    //    G = (int)numericUpDown3.Value;
                    //else if (G < (int)numericUpDown4.Value)
                    //    G = (int)numericUpDown4.Value;

                    B = (int)((double)BnormalizedHystogram[color.B] * Const);

                    //if (B > (int)numericUpDown5.Value)
                    //    B = (int)numericUpDown5.Value;
                    //else if (B < (int)numericUpDown6.Value)
                    //    B = (int)numericUpDown6.Value;

                    ownerForm.localImage.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            ownerForm.updatePicturebox();
            recalculateHystorgams();
            stopwatch.Stop();
            timeLabel.Text = "Time taken: " + stopwatch.ElapsedMilliseconds;
        }
    }
}
