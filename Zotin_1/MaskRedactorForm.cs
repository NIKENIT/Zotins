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
    public partial class MaskRedactorForm : Form
    {
        public MaskRedactorForm(List<List<bool>> mask)
        {
            InitializeComponent();
            localMask = mask;
        }

        public List<List<bool>> localMask;

        private void MaskRedactorForm_Load(object sender, EventArgs e)
        {
            createMatrix(-1, -1);
        }

        private void MaskRedactorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < localMask.Count; i++)
            {
                for (int j = 0; j < localMask[i].Count; j++)
                {
                    NumericUpDown numUD = (NumericUpDown)Controls["numUD" + i + j];
                    if (numUD.Value > 0)
                        localMask[i][j] = true;
                    else
                        localMask[i][j] = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            removeMatrix();
            createMatrix((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void removeMatrix()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.Controls.RemoveByKey("numUD" + i + j);
                }
            }
        }

        private void createMatrix(int mHeight, int mWidth)
        {
            int height = 50;
            int width = 50;

            int x = 30, y = 70;

            if(mHeight > 0 && mWidth > 0)
                localMask = Morphology.createMaskList(mHeight, mWidth);

            for (int i = 0; i < localMask.Count; i++)
            {
                for (int j = 0; j < localMask[i].Count; j++)
                {
                    NumericUpDown numUD = new NumericUpDown();
                    numUD.Height = height;
                    numUD.Width = width;
                    numUD.Name = "numUD" + i + j;
                    numUD.Maximum = 1;
                    numUD.Minimum = 0;
                    numUD.Location = new Point(x, y);
                    numUD.Value = Convert.ToDecimal(localMask[i][j]);
                    this.Controls.Add(numUD);

                    x += 80;
                }

                x = 30;
                y += 30;
            }
        }
    }
}
