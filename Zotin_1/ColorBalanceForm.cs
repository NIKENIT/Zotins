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
    public partial class ColorBalanceForm : Form
    {
        ResultBox OwnerForm;
        string mode;
        Stopwatch stopwatch = new Stopwatch();
        public ColorBalanceForm(ResultBox ownerForm, string Mode = "RGB")
        {
            InitializeComponent();
            OwnerForm = ownerForm;
            this.FormClosing += new FormClosingEventHandler(CBFormClosing);
            mode = Mode;
        }

        private void CBFormClosing(object sender, FormClosingEventArgs e)
        {
            OwnerForm.revertImage();
        }

        //цветовой баланс R
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //setR();
                label2.Text = "Red " + (100 + trackBar1.Value * 10).ToString()  + "%";
        }

        private void setR()
        {
            UInt32 p;
            for (int i = 0; i < OwnerForm.localImage.Width; i++)
                for (int j = 0; j < OwnerForm.localImage.Height; j++)
                {
                    p = ColorBalance_R((UInt32)OwnerForm.originalImage.GetPixel(i, j).ToArgb(), trackBar1.Value, trackBar1.Maximum);
                    OwnerForm.localImage.SetPixel(i, j, Color.FromArgb((int)p));
                }
            OwnerForm.updatePicturebox();
        }

        //цветовой баланс G
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //setG();
            label4.Text = "Green " + (100 + trackBar2.Value * 10).ToString() + "%";
        }

        private void setG()
        {
            UInt32 p;
            for (int i = 0; i < OwnerForm.localImage.Width; i++)
                for (int j = 0; j < OwnerForm.localImage.Height; j++)
                {
                    p = ColorBalance_G((UInt32)OwnerForm.originalImage.GetPixel(i, j).ToArgb(), trackBar2.Value, trackBar2.Maximum);
                    OwnerForm.localImage.SetPixel(i, j, Color.FromArgb((int)p));
                }
            OwnerForm.updatePicturebox();
        }

        //цветовой баланс B
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //setB();
            label6.Text = "Blue " + (100 + trackBar3.Value * 10).ToString() + "%";
        }

        private void setB()
        {
            UInt32 p;
            for (int i = 0; i < OwnerForm.localImage.Width; i++)
                for (int j = 0; j < OwnerForm.localImage.Height; j++)
                {
                    p = ColorBalance_B((UInt32)OwnerForm.originalImage.GetPixel(i, j).ToArgb(), trackBar3.Value, trackBar3.Maximum);
                    OwnerForm.localImage.SetPixel(i, j, Color.FromArgb((int)p));
                }
            OwnerForm.updatePicturebox();
        }

        private void ColorBalanceForm_Load(object sender, EventArgs e)
        {

        }


        //цветовой баланс R
        public UInt32 ColorBalance_R(UInt32 point, int poz, int lenght)
        {
            int R;
            int G;
            int B;

            int N = (100 / lenght) * poz; //кол-во процентов

            R = (int)(((point & 0x00FF0000) >> 16) + N * 128 / 100);
            G = (int)((point & 0x0000FF00) >> 8);
            B = (int)(point & 0x000000FF);

            //контролируем переполнение переменных
            if (R < 0) R = 0;
            if (R > 255) R = 255;

            point = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);

            return point;
        }

        //цветовой баланс G
        public UInt32 ColorBalance_G(UInt32 point, int poz, int lenght)
        {
            int R;
            int G;
            int B;

            int N = (100 / lenght) * poz; //кол-во процентов

            R = (int)((point & 0x00FF0000) >> 16);
            G = (int)(((point & 0x0000FF00) >> 8) + N * 128 / 100);
            B = (int)(point & 0x000000FF);

            //контролируем переполнение переменных
            if (G < 0) G = 0;
            if (G > 255) G = 255;

            point = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);

            return point;
        }

        //цветовой баланс B
        public UInt32 ColorBalance_B(UInt32 point, int poz, int lenght)
        {
            int R;
            int G;
            int B;

            int N = (100 / lenght) * poz; //кол-во процентов

            R = (int)((point & 0x00FF0000) >> 16);
            G = (int)((point & 0x0000FF00) >> 8);
            B = (int)((point & 0x000000FF) + N * 128 / 100);

            //контролируем переполнение переменных
            if (B < 0) B = 0;
            if (B > 255) B = 255;

            point = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);

            return point;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();
            setR();
            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label1.Text = " Hue " + trackBar4.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();
            setG();
            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();
            setB();
            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Saturation " + (100 + trackBar5.Value * 10).ToString() + "%";
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Brightness " + (100 + trackBar6.Value * 10).ToString() + "%";
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            label7.Text = "Value " + (100 + trackBar7.Value * 10).ToString() + "%";
        }

        //h
        private void button4_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < OwnerForm.localImage.Width; i++)
                for (int j = 0; j < OwnerForm.localImage.Height; j++)
                {
                    Color color = OwnerForm.originalImage.GetPixel(i, j);
                    double h, s, v;
                    ModelSettingsChooser.ColorToHSV(color, out h, out s, out v);

                    h = h + trackBar4.Value;

                    // корректировки
                    if (h > 360)
                        h = h - 360;
                    if (h < 0)
                        h = h + 360;

                    color = ModelSettingsChooser.HSVToColor(h, s, v);
                    OwnerForm.localImage.SetPixel(i, j, color);
                }
            OwnerForm.updatePicturebox();

            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        //s
        private void button5_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < OwnerForm.localImage.Width; i++)
                for (int j = 0; j < OwnerForm.localImage.Height; j++)
                {
                    Color color = OwnerForm.originalImage.GetPixel(i, j);
                    double h, s, v;
                    ModelSettingsChooser.ColorToHSV(color, out h, out s, out v);

                    s = s + (s/10 * trackBar5.Value);

                    if (s > 1)
                        s = 1;
                    else if (s < 0)
                        s = 0;

                    color = ModelSettingsChooser.HSVToColor(h, s, v);
                    OwnerForm.localImage.SetPixel(i, j, color);
                }
            OwnerForm.updatePicturebox();

            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        //l
        private void button6_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < OwnerForm.localImage.Width; i++)
                for (int j = 0; j < OwnerForm.localImage.Height; j++)
                {
                    Color color = OwnerForm.originalImage.GetPixel(i, j);
                    double h, s, l;
                    ModelSettingsChooser.ColorToHSL(color, out h, out s, out l);

                    l = l + (l / 10 * trackBar6.Value);

                    if (l > 1)
                        l = 1;
                    else if (l < 0)
                        l = 0;

                    color = ModelSettingsChooser.HSLToColor(h, s, l);
                    OwnerForm.localImage.SetPixel(i, j, color);
                }
            OwnerForm.updatePicturebox();


            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        //v
        private void button7_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < OwnerForm.localImage.Width; i++)
                for (int j = 0; j < OwnerForm.localImage.Height; j++)
                {
                    Color color = OwnerForm.originalImage.GetPixel(i, j);
                    double h, s, v;
                    ModelSettingsChooser.ColorToHSV(color, out h, out s, out v);

                    v = v + (v / 10 * trackBar7.Value);

                    if (v > 1)
                        v = 1;
                    else if (v < 0)
                        v = 0;
                            
                    color = ModelSettingsChooser.HSVToColor(h, s, v);
                    OwnerForm.localImage.SetPixel(i, j, color);
                }
            OwnerForm.updatePicturebox();

            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            label8.Text = "Contrast " + (100 + trackBar8.Value * 10).ToString() + "%";
        }

        //c
        private void button8_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            stopwatch.Start();

            double contrastValue = Math.Pow((100.0 + (trackBar8.Value*10)) / 100.0, 2);
            for (int i = 0; i < OwnerForm.localImage.Width; i++)
                for (int j = 0; j < OwnerForm.localImage.Height; j++)
                {
                    int r, g, b;
                    Color color = OwnerForm.originalImage.GetPixel(i, j);
                    r = (int)(((((color.R / 255.0) - 0.5) * contrastValue) + 0.5) * 255);
                    g = (int)(((((color.G / 255.0) - 0.5) * contrastValue) + 0.5) * 255);
                    b = (int)(((((color.B / 255.0) - 0.5) * contrastValue) + 0.5) * 255);

                    if (r > 255)
                        r = 255;
                    else if (r < 0)
                        r = 0;

                    if (g > 255)
                        g = 255;
                    else if (g < 0)
                        g = 0;

                    if (b > 255)
                        b = 255;
                    else if (b < 0)
                        b = 0;
                    OwnerForm.localImage.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            OwnerForm.updatePicturebox();

            stopwatch.Stop();
            timeLabel.Text = "Time taken " + stopwatch.ElapsedMilliseconds;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OwnerForm.originalImage = new Bitmap(OwnerForm.localImage);
        }
    }
}
