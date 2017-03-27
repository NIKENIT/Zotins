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
    public partial class NoizeGenForm : Form
    {
        ResultBox ownerForm;
        string mode;
        int colorLayer;

        public NoizeGenForm(ResultBox OwnerForm, string Mode = "RGB")
        {
            InitializeComponent();

            InitializeComponent();
            ownerForm = OwnerForm;
            this.FormClosing += new FormClosingEventHandler(NGFormClosing);
            mode = Mode;
            colorLayer = parseModeIntoLayerCode(Mode);
        }

        private void NGFormClosing(object sender, FormClosingEventArgs e)
        {
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
            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyImpulseNoize(mode, ownerForm.originalImage, trackBar1.Value, (int)numericUpDown1.Value, colorLayer);
            ownerForm.localImage = new Bitmap(result);
            ownerForm.updatePicturebox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyImpulseNoize(mode, ownerForm.localImage, trackBar1.Value, (int)numericUpDown1.Value, colorLayer);
            ownerForm.localImage = new Bitmap(result);
            ownerForm.updatePicturebox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyAdditiveNoize(mode, ownerForm.originalImage, trackBar2.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, colorLayer);
            ownerForm.localImage = new Bitmap(result);
            ownerForm.updatePicturebox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyAdditiveNoize(mode, ownerForm.localImage, trackBar2.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, colorLayer);
            ownerForm.localImage = new Bitmap(result);
            ownerForm.updatePicturebox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NoizeGenerator ng = new NoizeGenerator();
            Bitmap result = ng.applyAdditiveNoize(mode, ownerForm.originalImage, trackBar3.Value, (int)numericUpDown4.Value, (int)numericUpDown5.Value, colorLayer);
            ownerForm.localImage = new Bitmap(result);
            ownerForm.updatePicturebox();
        }

        private void NoizeGenForm_Load(object sender, EventArgs e)
        {

        }
    }
}
