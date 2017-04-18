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
    public partial class ModelSettingsChooser : Form
    {
        public ModelSettingsChooser(Bitmap Source)
        {
            InitializeComponent();
            source = Source;
            comboBox1.SelectedIndex = 0;
        }

        Bitmap source;
        Image result;
        MyImage[] TransformResults;

        private void button1_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "RGB":
                    TransformResults = SplitRgb(source);
                    break;
                case "HSV":
                    TransformResults = ConvertRGBToHSV(source);
                    break;
                case "HSL":
                    TransformResults = ConvertRGBToHSL(source);
                    break;
                case "YUV":
                    TransformResults = ConvertRGBToYUV(source);
                    break;
            }            
            ResultBox rb = new ResultBox(null, null/*"Transform to " + comboBox1.SelectedItem.ToString()*/, TransformResults, comboBox1.SelectedItem.ToString());
            //rb.Show();
        }

        public MyImage[] SplitRgb(Bitmap source)
        {
            MyImage[] tempResults = new MyImage[5];
            Color tempColor;

            tempResults[0] = new MyImage();
            tempResults[0].image = new Bitmap(source);
            tempResults[0].fieldNameForTransform = "R";

            tempResults[1] = new MyImage();
            tempResults[1].image = new Bitmap(source);
            tempResults[1].fieldNameForTransform = "G";

            tempResults[2] = new MyImage();
            tempResults[2].image = new Bitmap(source);
            tempResults[2].fieldNameForTransform = "B";

            tempResults[3] = new MyImage();
            tempResults[3].image = new Bitmap(source);
            tempResults[3].fieldNameForTransform = "RGB";

            tempResults[4] = new MyImage();
            tempResults[4].image = new Bitmap(source);
            tempResults[4].fieldNameForTransform = "RGB Grayscale";

            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    Color color = source.GetPixel(x, y);

                    tempResults[0].image.SetPixel(x, y, Color.FromArgb(color.R, 0, 0));

                    tempResults[1].image.SetPixel(x, y, Color.FromArgb(0, color.G, 0));

                    tempResults[2].image.SetPixel(x, y, Color.FromArgb(0, 0, color.B));

                    tempResults[3].image.SetPixel(x, y, color);

                    int grayscale = (int)((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114));
                    tempResults[4].image.SetPixel(x, y, Color.FromArgb(grayscale, grayscale, grayscale));
                }
            }

            return tempResults;

        }

        public MyImage[] ConvertRGBToYUV(Bitmap source)
        {
            MyImage[] tempResults = new MyImage[4];
            Color tempColor;

            tempResults[0] = new MyImage();
            tempResults[0].image = new Bitmap(source);
            tempResults[0].fieldNameForTransform = "Y";

            tempResults[1] = new MyImage();
            tempResults[1].image = new Bitmap(source);
            tempResults[1].fieldNameForTransform = "U";

            tempResults[2] = new MyImage();
            tempResults[2].image = new Bitmap(source);
            tempResults[2].fieldNameForTransform = "V";

            tempResults[3] = new MyImage();
            tempResults[3].image = new Bitmap(source);
            tempResults[3].fieldNameForTransform = "YUV";

            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    Color color = source.GetPixel(x, y);

                    double Y, U, V;
                    ColorToYUV(color, out Y, out U, out V);

                    tempColor = YUVToColor(Y, 128, 128);
                    tempResults[0].image.SetPixel(x, y, tempColor);

                    tempColor = YUVToColor(128, U, 128);
                    tempResults[1].image.SetPixel(x, y, tempColor);

                    tempColor = YUVToColor(128, 128, V);
                    tempResults[2].image.SetPixel(x, y, tempColor);

                    tempResults[3].image.SetPixel(x, y, Color.FromArgb(TrimRGB(Y), TrimRGB(U), TrimRGB(V)));
                }
            }

            return tempResults;
        }

        public MyImage[] ConvertRGBToHSL(Bitmap source)
        {
            MyImage[] tempResults = new MyImage[3];
            Color tempColor;

            tempResults[0] = new MyImage();
            tempResults[0].image = new Bitmap(source);
            tempResults[0].fieldNameForTransform = "h";

            tempResults[1] = new MyImage();
            tempResults[1].image = new Bitmap(source);
            tempResults[1].fieldNameForTransform = "s";

            tempResults[2] = new MyImage();
            tempResults[2].image = new Bitmap(source);
            tempResults[2].fieldNameForTransform = "l";

            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    Color color = source.GetPixel(x, y);

                    double h, s, l;
                    ColorToHSL(color, out h, out s, out l);

                    tempColor = HSLToColor(h, 1, 0.5);
                    tempResults[0].image.SetPixel(x, y, tempColor);

                    tempColor = HSLToColor(h, s, 0.5);
                    tempResults[1].image.SetPixel(x, y, tempColor);

                    tempColor = HSLToColor(h, 1, l);
                    tempResults[2].image.SetPixel(x, y, tempColor);
                }
            }

            return tempResults;
        }
        // Color.FromArgb(TrimRGB(h), TrimRGB(s), TrimRGB(v))
        public MyImage[] ConvertRGBToHSV(Bitmap source)
        {
            MyImage[] tempResults = new MyImage[3];
            Color tempColor;
            tempResults[0] = new MyImage();
            tempResults[0].image = new Bitmap(source.Width, source.Height);
            tempResults[0].fieldNameForTransform = "h";

            tempResults[1] = new MyImage();
            tempResults[1].image = new Bitmap(source.Width, source.Height);
            tempResults[1].fieldNameForTransform = "s";

            tempResults[2] = new MyImage();
            tempResults[2].image = new Bitmap(source.Width, source.Height);
            tempResults[2].fieldNameForTransform = "v";

            for (int x = 0; x < source.Width; x++)
            {
                for(int y = 0; y < source.Height; y++)
                {
                    Color color = source.GetPixel(x, y);

                    double h, s, v;
                    ColorToHSV(color, out h, out s, out v);

                    tempColor = HSVToColor(h, 1, 0.5);
                    tempResults[0].image.SetPixel(x, y, tempColor);

                    tempColor = HSVToColor(h, s, 0.5);
                    tempResults[1].image.SetPixel(x, y, tempColor);

                    tempColor = HSVToColor(h, 1, v);
                    tempResults[2].image.SetPixel(x, y, tempColor);
                }
            }

            return tempResults;
        }

        public int TrimRGB (double value)
        {
            if (value > 255)
                return 255;
            else if (value < 0)
                return 0;
            else
                return (int)value;
        }

        public static void ColorToYUV(Color color, out double Y, out double U, out double V)
        {
            Y = 0.299 * color.R + 0.587 * color.G + 0.114 * color.B;
            U = -0.147 * color.R - 0.289 * color.G + 0.436 * color.B + 128;
            V = 0.615 * color.R - 0.515 * color.G - 0.100 * color.B + 128;
        }

        public Color YUVToColor(double Y, double U, double V)
        {
            double r, g, b;

            r = Y + 1.14 * (V - 128);
            g = Y - 0.395 * (U - 128) - 0.581 * (V - 128);
            b = Y + 2.032 * (U - 128);

            return Color.FromArgb(TrimRGB(r), TrimRGB(g), TrimRGB(b));
        }

        public static void ColorToYCbCrJPEG(Color color, out double Y, out double Cb, out double Cr)
        {
            Y = 0.299 * color.R + 0.587 * color.G + 0.114 * color.B;
            Cb = 128 - 0.168736 * color.R - 0.331264 * color.G + 0.5 * color.B;
            Cr = 128 + 0.5 * color.R - 0.418688 * color.G - 0.081312 * color.B;
        }

        public static void ColorToHSL3(Color color, out double hue, out double saturation, out double lightness)
        {
            hue = color.GetHue();
            saturation = color.GetSaturation();
            lightness = color.GetBrightness();
        }

        public static void ColorToHSL2(Color color, out double hue, out double saturation, out double lightness)
        {
            double max = Math.Max(color.R, Math.Max(color.G, color.B));
            double min = Math.Min(color.R, Math.Min(color.G, color.B));

            lightness = (double)(max + min) / 2.0;

            if(max == min)
            {
                saturation = 0;
                hue = 0;
            }
            else
            {
                if (lightness <= 0.5)
                    saturation = (double)(max - min) / (max + min);
                else
                    saturation = (double)(max - min) / (2 - (max + min));

                if (color.R == max)
                    hue = (double)(color.G - color.B) / (max - min);
                else if (color.G == max)
                    hue = (double)2.0 + (color.B - color.R) / (max - min);
                else //if (color.B == max)
                    hue = (double)4.0 + (color.R - color.G) / (max - min);

                hue = hue * 60.0;

                if (hue < 0)
                    hue = hue + 360;

            }
        }

        public static void ColorToHSL(Color rgb, out double h, out double s, out double l)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;
            double v;
            double m;
            double vm;
            double r2, g2, b2;

            h = 0; // default to black
            s = 0;
            l = 0;

            v = Math.Max(r, g);
            v = Math.Max(v, b);
            m = Math.Min(r, g);
            m = Math.Min(m, b);

            l = (m + v) / 2.0;
            if (l <= 0.0)
            {
                return;
            }

            vm = v - m;
            s = vm;

            if (s > 0.0)
            {
                s /= (l <= 0.5) ? (v + m) : (2.0 - v - m);
            }
            else
            {
                return;
            }

            r2 = (v - r) / vm;
            g2 = (v - g) / vm;
            b2 = (v - b) / vm;

            if (r == v)
            {
                h = (g == m ? 5.0 + b2 : 1.0 - g2);
            }
            else if (g == v)
            {
                h = (b == m ? 1.0 + r2 : 3.0 - b2);
            }
            else
            {
                h = (r == m ? 3.0 + g2 : 5.0 - r2);
            }
            h /= 6.0;
        }

        public static Color HSLToColor(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;
                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            Color rgb = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
            return rgb;
        }

        public Color HSLToColor2(double h, double s, double l)
        {
            int r, g, b;
            double M1, M2;
            if (s == 0)
            {
                r = g = b = (int)l;
            }
            else
            {
 
                if (l <= 0.5)
                    M2 = l * (l + s);
                else
                    M2 = (l + s) - (l * s);

                M1 = 2.0 * l - M2;

                r = (int)HSLHelper(M1, M2, (h + 120.0) % 360.0);
                g = (int)HSLHelper(M1, M2, h);
                b = (int)HSLHelper(M1, M2, (h - 120.0) % 360.0);
            }
            return Color.FromArgb(TrimRGB(r), TrimRGB(g), TrimRGB(b));
        }

        private static double HSLHelper(double N1, double N2, double Hue)
        {
            if (Hue < 60)
                return N1 + (N2 - N1) * Hue / 60.0;
            else if (Hue < 180)
                return N2;
            else if (Hue < 240)
                return N1 + (N2 - N1) * (240 - Hue) / 60;
            else
                return N1;
        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1 - (1 * (double)min / (double)max);
            value = (double)max / 255;
        }

        public static Color HSVToColor(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private void ModelSettingsChooser_Load(object sender, EventArgs e)
        {

        }
    }
}
