namespace Zotin_1
{
    partial class Lab2Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LinearFilters = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.msePanel = new System.Windows.Forms.Panel();
            this.MSEIntLabel = new System.Windows.Forms.Label();
            this.MSEBLabel = new System.Windows.Forms.Label();
            this.MSEGLabel = new System.Windows.Forms.Label();
            this.MSERLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PSNRIntLabel = new System.Windows.Forms.Label();
            this.PSNRBLabel = new System.Windows.Forms.Label();
            this.PSNRGLabel = new System.Windows.Forms.Label();
            this.PSNRRLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AdaptiveFilterLabel = new System.Windows.Forms.Label();
            this.RecursiveFilterLabel = new System.Windows.Forms.Label();
            this.CutMiddleFilterLabel = new System.Windows.Forms.Label();
            this.JimFilterLabel = new System.Windows.Forms.Label();
            this.GaussFilterLabel = new System.Windows.Forms.Label();
            this.MedianFilterLabel = new System.Windows.Forms.Label();
            this.meanFilterLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBox)).BeginInit();
            this.msePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox.Location = new System.Drawing.Point(12, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(540, 561);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RGB",
            "YUV"});
            this.comboBox1.Location = new System.Drawing.Point(558, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // LinearFilters
            // 
            this.LinearFilters.Location = new System.Drawing.Point(559, 40);
            this.LinearFilters.Name = "LinearFilters";
            this.LinearFilters.Size = new System.Drawing.Size(201, 36);
            this.LinearFilters.TabIndex = 2;
            this.LinearFilters.Text = "Линейные фильтры";
            this.LinearFilters.UseVisualStyleBackColor = true;
            this.LinearFilters.Click += new System.EventHandler(this.LinearFilters_Click);
            // 
            // resultBox
            // 
            this.resultBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultBox.Location = new System.Drawing.Point(766, 12);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(540, 561);
            this.resultBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultBox.TabIndex = 3;
            this.resultBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Сравнить изображения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "MSE Results";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(561, 507);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Добавить шум";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(561, 549);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 24);
            this.button3.TabIndex = 7;
            this.button3.Text = "Применить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(668, 549);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 24);
            this.button4.TabIndex = 8;
            this.button4.Text = "Сброс";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // msePanel
            // 
            this.msePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msePanel.Controls.Add(this.MSEIntLabel);
            this.msePanel.Controls.Add(this.MSEBLabel);
            this.msePanel.Controls.Add(this.MSEGLabel);
            this.msePanel.Controls.Add(this.MSERLabel);
            this.msePanel.Controls.Add(this.label1);
            this.msePanel.Location = new System.Drawing.Point(560, 124);
            this.msePanel.Name = "msePanel";
            this.msePanel.Size = new System.Drawing.Size(200, 100);
            this.msePanel.TabIndex = 9;
            this.msePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MSEIntLabel
            // 
            this.MSEIntLabel.AutoSize = true;
            this.MSEIntLabel.Location = new System.Drawing.Point(6, 83);
            this.MSEIntLabel.Name = "MSEIntLabel";
            this.MSEIntLabel.Size = new System.Drawing.Size(77, 13);
            this.MSEIntLabel.TabIndex = 9;
            this.MSEIntLabel.Text = "Difference Int: ";
            // 
            // MSEBLabel
            // 
            this.MSEBLabel.AutoSize = true;
            this.MSEBLabel.Location = new System.Drawing.Point(6, 63);
            this.MSEBLabel.Name = "MSEBLabel";
            this.MSEBLabel.Size = new System.Drawing.Size(72, 13);
            this.MSEBLabel.TabIndex = 8;
            this.MSEBLabel.Text = "Difference B: ";
            // 
            // MSEGLabel
            // 
            this.MSEGLabel.AutoSize = true;
            this.MSEGLabel.Location = new System.Drawing.Point(6, 42);
            this.MSEGLabel.Name = "MSEGLabel";
            this.MSEGLabel.Size = new System.Drawing.Size(73, 13);
            this.MSEGLabel.TabIndex = 7;
            this.MSEGLabel.Text = "Difference G: ";
            // 
            // MSERLabel
            // 
            this.MSERLabel.AutoSize = true;
            this.MSERLabel.Location = new System.Drawing.Point(6, 22);
            this.MSERLabel.Name = "MSERLabel";
            this.MSERLabel.Size = new System.Drawing.Size(73, 13);
            this.MSERLabel.TabIndex = 6;
            this.MSERLabel.Text = "Difference R: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PSNRIntLabel);
            this.panel1.Controls.Add(this.PSNRBLabel);
            this.panel1.Controls.Add(this.PSNRGLabel);
            this.panel1.Controls.Add(this.PSNRRLabel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(560, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 10;
            // 
            // PSNRIntLabel
            // 
            this.PSNRIntLabel.AutoSize = true;
            this.PSNRIntLabel.Location = new System.Drawing.Point(6, 83);
            this.PSNRIntLabel.Name = "PSNRIntLabel";
            this.PSNRIntLabel.Size = new System.Drawing.Size(77, 13);
            this.PSNRIntLabel.TabIndex = 9;
            this.PSNRIntLabel.Text = "Difference Int: ";
            // 
            // PSNRBLabel
            // 
            this.PSNRBLabel.AutoSize = true;
            this.PSNRBLabel.Location = new System.Drawing.Point(6, 63);
            this.PSNRBLabel.Name = "PSNRBLabel";
            this.PSNRBLabel.Size = new System.Drawing.Size(72, 13);
            this.PSNRBLabel.TabIndex = 8;
            this.PSNRBLabel.Text = "Difference B: ";
            // 
            // PSNRGLabel
            // 
            this.PSNRGLabel.AutoSize = true;
            this.PSNRGLabel.Location = new System.Drawing.Point(6, 42);
            this.PSNRGLabel.Name = "PSNRGLabel";
            this.PSNRGLabel.Size = new System.Drawing.Size(73, 13);
            this.PSNRGLabel.TabIndex = 7;
            this.PSNRGLabel.Text = "Difference G: ";
            // 
            // PSNRRLabel
            // 
            this.PSNRRLabel.AutoSize = true;
            this.PSNRRLabel.Location = new System.Drawing.Point(6, 22);
            this.PSNRRLabel.Name = "PSNRRLabel";
            this.PSNRRLabel.Size = new System.Drawing.Size(73, 13);
            this.PSNRRLabel.TabIndex = 6;
            this.PSNRRLabel.Text = "Difference R: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "PSNR Results";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.AdaptiveFilterLabel);
            this.panel2.Controls.Add(this.RecursiveFilterLabel);
            this.panel2.Controls.Add(this.CutMiddleFilterLabel);
            this.panel2.Controls.Add(this.JimFilterLabel);
            this.panel2.Controls.Add(this.GaussFilterLabel);
            this.panel2.Controls.Add(this.MedianFilterLabel);
            this.panel2.Controls.Add(this.meanFilterLabel);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(560, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 165);
            this.panel2.TabIndex = 11;
            // 
            // AdaptiveFilterLabel
            // 
            this.AdaptiveFilterLabel.AutoSize = true;
            this.AdaptiveFilterLabel.Location = new System.Drawing.Point(6, 138);
            this.AdaptiveFilterLabel.Name = "AdaptiveFilterLabel";
            this.AdaptiveFilterLabel.Size = new System.Drawing.Size(74, 13);
            this.AdaptiveFilterLabel.TabIndex = 12;
            this.AdaptiveFilterLabel.Text = "AdaptiveFilter:";
            // 
            // RecursiveFilterLabel
            // 
            this.RecursiveFilterLabel.AutoSize = true;
            this.RecursiveFilterLabel.Location = new System.Drawing.Point(6, 120);
            this.RecursiveFilterLabel.Name = "RecursiveFilterLabel";
            this.RecursiveFilterLabel.Size = new System.Drawing.Size(80, 13);
            this.RecursiveFilterLabel.TabIndex = 11;
            this.RecursiveFilterLabel.Text = "RecursiveFilter:";
            // 
            // CutMiddleFilterLabel
            // 
            this.CutMiddleFilterLabel.AutoSize = true;
            this.CutMiddleFilterLabel.Location = new System.Drawing.Point(6, 102);
            this.CutMiddleFilterLabel.Name = "CutMiddleFilterLabel";
            this.CutMiddleFilterLabel.Size = new System.Drawing.Size(79, 13);
            this.CutMiddleFilterLabel.TabIndex = 10;
            this.CutMiddleFilterLabel.Text = "CutMiddleFilter:";
            // 
            // JimFilterLabel
            // 
            this.JimFilterLabel.AutoSize = true;
            this.JimFilterLabel.Location = new System.Drawing.Point(6, 83);
            this.JimFilterLabel.Name = "JimFilterLabel";
            this.JimFilterLabel.Size = new System.Drawing.Size(91, 13);
            this.JimFilterLabel.TabIndex = 9;
            this.JimFilterLabel.Text = "JimCasaburiFilter: ";
            // 
            // GaussFilterLabel
            // 
            this.GaussFilterLabel.AutoSize = true;
            this.GaussFilterLabel.Location = new System.Drawing.Point(6, 63);
            this.GaussFilterLabel.Name = "GaussFilterLabel";
            this.GaussFilterLabel.Size = new System.Drawing.Size(76, 13);
            this.GaussFilterLabel.TabIndex = 8;
            this.GaussFilterLabel.Text = "GaussianFilter:";
            // 
            // MedianFilterLabel
            // 
            this.MedianFilterLabel.AutoSize = true;
            this.MedianFilterLabel.Location = new System.Drawing.Point(6, 42);
            this.MedianFilterLabel.Name = "MedianFilterLabel";
            this.MedianFilterLabel.Size = new System.Drawing.Size(70, 13);
            this.MedianFilterLabel.TabIndex = 7;
            this.MedianFilterLabel.Text = "MedianFilter: ";
            // 
            // meanFilterLabel
            // 
            this.meanFilterLabel.AutoSize = true;
            this.meanFilterLabel.Location = new System.Drawing.Point(6, 22);
            this.meanFilterLabel.Name = "meanFilterLabel";
            this.meanFilterLabel.Size = new System.Drawing.Size(63, 13);
            this.meanFilterLabel.TabIndex = 6;
            this.meanFilterLabel.Text = "MeanFIlter: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Time Taken";
            // 
            // Lab2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 585);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.msePanel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.LinearFilters);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.PictureBox);
            this.Name = "Lab2Form";
            this.Text = "Lab2Form";
            this.Load += new System.EventHandler(this.Lab2Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBox)).EndInit();
            this.msePanel.ResumeLayout(false);
            this.msePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button LinearFilters;
        private System.Windows.Forms.PictureBox resultBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel msePanel;
        private System.Windows.Forms.Label MSEBLabel;
        private System.Windows.Forms.Label MSEGLabel;
        private System.Windows.Forms.Label MSERLabel;
        private System.Windows.Forms.Label MSEIntLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PSNRIntLabel;
        private System.Windows.Forms.Label PSNRBLabel;
        private System.Windows.Forms.Label PSNRGLabel;
        private System.Windows.Forms.Label PSNRRLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label JimFilterLabel;
        public System.Windows.Forms.Label GaussFilterLabel;
        public System.Windows.Forms.Label MedianFilterLabel;
        public System.Windows.Forms.Label meanFilterLabel;
        public System.Windows.Forms.Label CutMiddleFilterLabel;
        public System.Windows.Forms.Label AdaptiveFilterLabel;
        public System.Windows.Forms.Label RecursiveFilterLabel;
    }
}