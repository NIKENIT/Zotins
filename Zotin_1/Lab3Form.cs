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
    public partial class Lab3Form : Form
    {
        public Lab3Form(Bitmap Source)
        {
            InitializeComponent();
            source = Source;
        }
        Bitmap source;
        public Bitmap originalImage;
        public Bitmap resultImage;

        private void Lab3Form_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = source;
            originalImage = new Bitmap(source);
        }

        private void LocalMethodsButton_Click(object sender, EventArgs e)
        {
            LocalMethods lm = new LocalMethods(this);
            lm.Show();
        }

        public void updateResultBox()
        {
            resultBox.Image = new Bitmap(resultImage);
        }

        private void GlobalMethodsButton_Click(object sender, EventArgs e)
        {

        }

        internal void updateOriginalBox()
        {
            pictureBox1.Image = new Bitmap(originalImage);
        }

        internal void resetOriginalImage()
        {
            pictureBox1.Image = new Bitmap(source);
            originalImage = new Bitmap(source);
        }
    }
}
