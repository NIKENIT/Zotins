using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zotin_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap originalImage;

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            openFileDialog1.Multiselect = false;
            dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                originalImage = LoadBitmap(openFileDialog1.FileName);
                pictureBox1.Image = originalImage;
            }
        }

        public static Bitmap LoadBitmap(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                return new Bitmap(fs);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                ModelSettingsChooser form = new ModelSettingsChooser(originalImage);
                form.ShowDialog();
            }
            else
                MessageBox.Show("Изображение не существует");
        }
    }
}
