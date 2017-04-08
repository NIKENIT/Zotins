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
        public Bitmap originalImage;
        public Bitmap YUVImage;
        public Bitmap resultImage;

        private void Lab2Form_Load(object sender, EventArgs e)
        {
            originalImage = new Bitmap(source);
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

            PictureBox.Image = originalImage;
            comboBox1.SelectedIndex = 0;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                PictureBox.Image = originalImage;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                PictureBox.Image = YUVImage;
            }
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
    }
}
