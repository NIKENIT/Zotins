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
    public partial class NoizeGenForm : Form
    {
        ResultBox ownerForm;
        Lab2Form lab2OwnerForm;
        string mode;
        int colorLayer;
        Stopwatch stopwatch = new Stopwatch();
        public NoizeGenForm(Form OwnerForm, string Mode = "RGB")
        {
            InitializeComponent();

            if (OwnerForm is ResultBox)
                ownerForm = (ResultBox)OwnerForm;
            else if (OwnerForm is Lab2Form)
                lab2OwnerForm = (Lab2Form)OwnerForm;

            this.FormClosing += new FormClosingEventHandler(NGFormClosing);
            mode = Mode;
            colorLayer = parseModeIntoLayerCode(Mode);
        }

        private void NGFormClosing(object sender, FormClosingEventArgs e)
        {
            if (ownerForm != null)
                ownerForm.revertImage();                  
        }

        public int parseModeIntoLayerCode(string mode)
        {
            switch (mode.Trim().ToUpper())
            {
                case "RGB":
                case "YUV":
                case "HSL":
                case "HSV":
                    return 0;
                case "Y":
                case "H":
                case "R":
                    return 1;
                case "G":
                case "U":
                case "S":
                    return 2;
                case "V":
                case "L":
                case "B":
                    return 3;
                default:
                    return -1;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Уровень \nшума " + trackBar1.Value + "%";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Уровень \nшума " + trackBar2.Value + "%";
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label6.Text = "Уровень \nшума " + trackBar3.Value + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            int colorLayer = determineChannel();

            Bitmap image;
            if (ownerForm != null)
                image = ownerForm.originalImage;
            else
                image = lab2OwnerForm.originalImage;

            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyImpulseNoize(mode, image, trackBar1.Value, (int)numericUpDown1.Value, colorLayer);

            if (ownerForm != null)
            {
                ownerForm.localImage = new Bitmap(result);
                ownerForm.updatePicturebox();
            }
            else
            {
                lab2OwnerForm.resultImage = new Bitmap(result);
                lab2OwnerForm.updateResultBox();
            }

            stopwatch.Stop();
            timeLabel.Text = "Time taken: " + stopwatch.ElapsedMilliseconds;
        }

        private int determineChannel()
        {
            if (radioButton1.Checked)
                return 0;
            else if (radioButton2.Checked)
                return 1;
            else if (radioButton3.Checked)
                return 2;
            else if (radioButton4.Checked)
                return 3;
            else
                return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            int colorLayer = determineChannel();

            Bitmap image;
            if (ownerForm != null)
                image = ownerForm.localImage;
            else
                image = lab2OwnerForm.resultImage;

            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = new Bitmap(ng.applyImpulseNoize(mode, image, trackBar1.Value, (int)numericUpDown1.Value, colorLayer));

            if (ownerForm != null)
            {
                ownerForm.localImage = new Bitmap(result);
                ownerForm.updatePicturebox();
            }
            else
            {
                lab2OwnerForm.resultImage = new Bitmap(result);
                lab2OwnerForm.updateResultBox();
            }

            stopwatch.Stop();
            timeLabel.Text = "Time taken: " + stopwatch.ElapsedMilliseconds;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            int colorLayer = determineChannel();

            Bitmap image;
            if (ownerForm != null)
                image = ownerForm.originalImage;
            else
                image = lab2OwnerForm.originalImage;

            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyAdditiveNoize(mode, image, trackBar2.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, colorLayer);

            if (ownerForm != null)
            {
                ownerForm.localImage = new Bitmap(result);
                ownerForm.updatePicturebox();
            }
            else
            {
                lab2OwnerForm.resultImage = new Bitmap(result);
                lab2OwnerForm.updateResultBox();
            }

            stopwatch.Stop();
            timeLabel2.Text = "Time taken: " + stopwatch.ElapsedMilliseconds;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            int colorLayer = determineChannel();

            Bitmap image;
            if (ownerForm != null)
                image = ownerForm.localImage;
            else
                image = lab2OwnerForm.resultImage;

            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyAdditiveNoize(mode, image, trackBar2.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, colorLayer);

            if (ownerForm != null)
            {
                ownerForm.localImage = new Bitmap(result);
                ownerForm.updatePicturebox();
            }
            else
            {
                lab2OwnerForm.resultImage = new Bitmap(result);
                lab2OwnerForm.updateResultBox();
            }

            stopwatch.Stop();
            timeLabel2.Text = "Time taken: " + stopwatch.ElapsedMilliseconds;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            int colorLayer = determineChannel();

            Bitmap image;
            if (ownerForm != null)
                image = ownerForm.originalImage;
            else
                image = lab2OwnerForm.originalImage;

            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyAdditiveNoize(mode, image, trackBar3.Value, (int)numericUpDown4.Value, (int)numericUpDown5.Value, colorLayer);

            if (ownerForm != null)
            {
                ownerForm.localImage = new Bitmap(result);
                ownerForm.updatePicturebox();
            }
            else
            {
                lab2OwnerForm.resultImage = new Bitmap(result);
                lab2OwnerForm.updateResultBox();
            }

            stopwatch.Stop();
            timeLabel3.Text = "Time taken: " + stopwatch.ElapsedMilliseconds;
        }

        private void NoizeGenForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            int colorLayer = determineChannel();

            Bitmap image;
            if (ownerForm != null)
                image = ownerForm.localImage;
            else
                image = lab2OwnerForm.resultImage;

            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyAdditiveNoize(mode, image, trackBar3.Value, (int)numericUpDown4.Value, (int)numericUpDown5.Value, colorLayer);

            if (ownerForm != null)
            {
                ownerForm.localImage = new Bitmap(result);
                ownerForm.updatePicturebox();
            }
            else
            {
                lab2OwnerForm.resultImage = new Bitmap(result);
                lab2OwnerForm.updateResultBox();
            }

            stopwatch.Stop();
            timeLabel3.Text = "Time taken: " + stopwatch.ElapsedMilliseconds;
        }
    }
}
