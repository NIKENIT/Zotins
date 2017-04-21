namespace Zotin_1
{
    partial class Lab3Form
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LocalMethodsButton = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bernsenLabel = new System.Windows.Forms.Label();
            this.niblackLabel = new System.Windows.Forms.Label();
            this.otzuLabel = new System.Windows.Forms.Label();
            this.DilationLabel = new System.Windows.Forms.Label();
            this.erosionLabel = new System.Windows.Forms.Label();
            this.robertsLabel = new System.Windows.Forms.Label();
            this.sobelLabel = new System.Windows.Forms.Label();
            this.laplasLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(497, 505);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LocalMethodsButton
            // 
            this.LocalMethodsButton.Location = new System.Drawing.Point(517, 13);
            this.LocalMethodsButton.Name = "LocalMethodsButton";
            this.LocalMethodsButton.Size = new System.Drawing.Size(132, 51);
            this.LocalMethodsButton.TabIndex = 1;
            this.LocalMethodsButton.Text = "Обработка";
            this.LocalMethodsButton.UseVisualStyleBackColor = true;
            this.LocalMethodsButton.Click += new System.EventHandler(this.LocalMethodsButton_Click);
            // 
            // resultBox
            // 
            this.resultBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultBox.Location = new System.Drawing.Point(655, 13);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(497, 505);
            this.resultBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultBox.TabIndex = 3;
            this.resultBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.laplasLabel);
            this.panel1.Controls.Add(this.sobelLabel);
            this.panel1.Controls.Add(this.robertsLabel);
            this.panel1.Controls.Add(this.erosionLabel);
            this.panel1.Controls.Add(this.DilationLabel);
            this.panel1.Controls.Add(this.otzuLabel);
            this.panel1.Controls.Add(this.niblackLabel);
            this.panel1.Controls.Add(this.bernsenLabel);
            this.panel1.Location = new System.Drawing.Point(517, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 448);
            this.panel1.TabIndex = 4;
            // 
            // bernsenLabel
            // 
            this.bernsenLabel.AutoSize = true;
            this.bernsenLabel.Location = new System.Drawing.Point(12, 28);
            this.bernsenLabel.Name = "bernsenLabel";
            this.bernsenLabel.Size = new System.Drawing.Size(50, 13);
            this.bernsenLabel.TabIndex = 0;
            this.bernsenLabel.Text = "Бернсен";
            // 
            // niblackLabel
            // 
            this.niblackLabel.AutoSize = true;
            this.niblackLabel.Location = new System.Drawing.Point(12, 43);
            this.niblackLabel.Name = "niblackLabel";
            this.niblackLabel.Size = new System.Drawing.Size(45, 13);
            this.niblackLabel.TabIndex = 1;
            this.niblackLabel.Text = "Ниблек";
            // 
            // otzuLabel
            // 
            this.otzuLabel.AutoSize = true;
            this.otzuLabel.Location = new System.Drawing.Point(12, 58);
            this.otzuLabel.Name = "otzuLabel";
            this.otzuLabel.Size = new System.Drawing.Size(31, 13);
            this.otzuLabel.TabIndex = 2;
            this.otzuLabel.Text = "Отзу";
            // 
            // DilationLabel
            // 
            this.DilationLabel.AutoSize = true;
            this.DilationLabel.Location = new System.Drawing.Point(13, 90);
            this.DilationLabel.Name = "DilationLabel";
            this.DilationLabel.Size = new System.Drawing.Size(52, 13);
            this.DilationLabel.TabIndex = 3;
            this.DilationLabel.Text = "Диляция";
            // 
            // erosionLabel
            // 
            this.erosionLabel.AutoSize = true;
            this.erosionLabel.Location = new System.Drawing.Point(13, 105);
            this.erosionLabel.Name = "erosionLabel";
            this.erosionLabel.Size = new System.Drawing.Size(50, 13);
            this.erosionLabel.TabIndex = 4;
            this.erosionLabel.Text = "Эррозия";
            // 
            // robertsLabel
            // 
            this.robertsLabel.AutoSize = true;
            this.robertsLabel.Location = new System.Drawing.Point(13, 134);
            this.robertsLabel.Name = "robertsLabel";
            this.robertsLabel.Size = new System.Drawing.Size(49, 13);
            this.robertsLabel.TabIndex = 5;
            this.robertsLabel.Text = "Робертс";
            // 
            // sobelLabel
            // 
            this.sobelLabel.AutoSize = true;
            this.sobelLabel.Location = new System.Drawing.Point(13, 149);
            this.sobelLabel.Name = "sobelLabel";
            this.sobelLabel.Size = new System.Drawing.Size(44, 13);
            this.sobelLabel.TabIndex = 6;
            this.sobelLabel.Text = "Собель";
            // 
            // laplasLabel
            // 
            this.laplasLabel.AutoSize = true;
            this.laplasLabel.Location = new System.Drawing.Point(13, 164);
            this.laplasLabel.Name = "laplasLabel";
            this.laplasLabel.Size = new System.Drawing.Size(45, 13);
            this.laplasLabel.TabIndex = 7;
            this.laplasLabel.Text = "Лаплас";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Время выполнения";
            // 
            // Lab3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.LocalMethodsButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Lab3Form";
            this.Text = "Lab3Form";
            this.Load += new System.EventHandler(this.Lab3Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LocalMethodsButton;
        private System.Windows.Forms.PictureBox resultBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label niblackLabel;
        public System.Windows.Forms.Label bernsenLabel;
        public System.Windows.Forms.Label laplasLabel;
        public System.Windows.Forms.Label sobelLabel;
        public System.Windows.Forms.Label robertsLabel;
        public System.Windows.Forms.Label erosionLabel;
        public System.Windows.Forms.Label DilationLabel;
        public System.Windows.Forms.Label otzuLabel;
    }
}