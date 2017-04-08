namespace Zotin_1
{
    partial class LinearFiltersChooserForm
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
            this.meanFilterButton = new System.Windows.Forms.Button();
            this.medianFilterButton = new System.Windows.Forms.Button();
            this.xSizeNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ySizeNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gaussianFilterButtom = new System.Windows.Forms.Button();
            this.JimCasaburiFilterButton = new System.Windows.Forms.Button();
            this.splitMiddleFilterButton = new System.Windows.Forms.Button();
            this.dUpDown = new System.Windows.Forms.NumericUpDown();
            this.RecursiveFilterButton = new System.Windows.Forms.Button();
            this.AdaptiveFilterButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // meanFilterButton
            // 
            this.meanFilterButton.Location = new System.Drawing.Point(13, 13);
            this.meanFilterButton.Name = "meanFilterButton";
            this.meanFilterButton.Size = new System.Drawing.Size(96, 23);
            this.meanFilterButton.TabIndex = 0;
            this.meanFilterButton.Text = "Mean filter";
            this.meanFilterButton.UseVisualStyleBackColor = true;
            this.meanFilterButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // medianFilterButton
            // 
            this.medianFilterButton.Location = new System.Drawing.Point(13, 42);
            this.medianFilterButton.Name = "medianFilterButton";
            this.medianFilterButton.Size = new System.Drawing.Size(96, 23);
            this.medianFilterButton.TabIndex = 1;
            this.medianFilterButton.Text = "MedianFilter";
            this.medianFilterButton.UseVisualStyleBackColor = true;
            this.medianFilterButton.Click += new System.EventHandler(this.medianFilterButton_Click);
            // 
            // xSizeNumUpDown
            // 
            this.xSizeNumUpDown.Location = new System.Drawing.Point(299, 16);
            this.xSizeNumUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.xSizeNumUpDown.Name = "xSizeNumUpDown";
            this.xSizeNumUpDown.Size = new System.Drawing.Size(40, 20);
            this.xSizeNumUpDown.TabIndex = 2;
            this.xSizeNumUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ySizeNumUpDown
            // 
            this.ySizeNumUpDown.Location = new System.Drawing.Point(299, 42);
            this.ySizeNumUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ySizeNumUpDown.Name = "ySizeNumUpDown";
            this.ySizeNumUpDown.Size = new System.Drawing.Size(40, 20);
            this.ySizeNumUpDown.TabIndex = 3;
            this.ySizeNumUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Memory usage:";
            // 
            // gaussianFilterButtom
            // 
            this.gaussianFilterButtom.Location = new System.Drawing.Point(13, 71);
            this.gaussianFilterButtom.Name = "gaussianFilterButtom";
            this.gaussianFilterButtom.Size = new System.Drawing.Size(96, 23);
            this.gaussianFilterButtom.TabIndex = 7;
            this.gaussianFilterButtom.Text = "GaussianFilter";
            this.gaussianFilterButtom.UseVisualStyleBackColor = true;
            this.gaussianFilterButtom.Click += new System.EventHandler(this.gaussianFilterButtom_Click);
            // 
            // JimCasaburiFilterButton
            // 
            this.JimCasaburiFilterButton.Location = new System.Drawing.Point(12, 100);
            this.JimCasaburiFilterButton.Name = "JimCasaburiFilterButton";
            this.JimCasaburiFilterButton.Size = new System.Drawing.Size(96, 23);
            this.JimCasaburiFilterButton.TabIndex = 8;
            this.JimCasaburiFilterButton.Text = "JimCasaburiFilter";
            this.JimCasaburiFilterButton.UseVisualStyleBackColor = true;
            this.JimCasaburiFilterButton.Click += new System.EventHandler(this.JimCasaburiFilterButton_Click);
            // 
            // splitMiddleFilterButton
            // 
            this.splitMiddleFilterButton.Location = new System.Drawing.Point(13, 129);
            this.splitMiddleFilterButton.Name = "splitMiddleFilterButton";
            this.splitMiddleFilterButton.Size = new System.Drawing.Size(192, 23);
            this.splitMiddleFilterButton.TabIndex = 9;
            this.splitMiddleFilterButton.Text = "Фильтр усеченного среднего";
            this.splitMiddleFilterButton.UseVisualStyleBackColor = true;
            this.splitMiddleFilterButton.Click += new System.EventHandler(this.splitMiddleFilterButton_Click);
            // 
            // dUpDown
            // 
            this.dUpDown.Location = new System.Drawing.Point(211, 129);
            this.dUpDown.Name = "dUpDown";
            this.dUpDown.Size = new System.Drawing.Size(40, 20);
            this.dUpDown.TabIndex = 10;
            this.dUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // RecursiveFilterButton
            // 
            this.RecursiveFilterButton.Location = new System.Drawing.Point(13, 158);
            this.RecursiveFilterButton.Name = "RecursiveFilterButton";
            this.RecursiveFilterButton.Size = new System.Drawing.Size(192, 23);
            this.RecursiveFilterButton.TabIndex = 11;
            this.RecursiveFilterButton.Text = "Рекурсивный фильтр";
            this.RecursiveFilterButton.UseVisualStyleBackColor = true;
            this.RecursiveFilterButton.Click += new System.EventHandler(this.RecursiveFilterButton_Click);
            // 
            // AdaptiveFilterButton
            // 
            this.AdaptiveFilterButton.Location = new System.Drawing.Point(13, 187);
            this.AdaptiveFilterButton.Name = "AdaptiveFilterButton";
            this.AdaptiveFilterButton.Size = new System.Drawing.Size(192, 23);
            this.AdaptiveFilterButton.TabIndex = 12;
            this.AdaptiveFilterButton.Text = "Адаптивный фильтр";
            this.AdaptiveFilterButton.UseVisualStyleBackColor = true;
            this.AdaptiveFilterButton.Click += new System.EventHandler(this.AdaptiveFilterButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(211, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(33, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.Text = "R";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(211, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(33, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.Text = "G";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(211, 77);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(32, 17);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.Text = "B";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(210, 10);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(36, 17);
            this.radioButton4.TabIndex = 16;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "All";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(114, 103);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(91, 20);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // LinearFiltersChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 242);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.AdaptiveFilterButton);
            this.Controls.Add(this.RecursiveFilterButton);
            this.Controls.Add(this.dUpDown);
            this.Controls.Add(this.splitMiddleFilterButton);
            this.Controls.Add(this.JimCasaburiFilterButton);
            this.Controls.Add(this.gaussianFilterButtom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ySizeNumUpDown);
            this.Controls.Add(this.xSizeNumUpDown);
            this.Controls.Add(this.medianFilterButton);
            this.Controls.Add(this.meanFilterButton);
            this.Name = "LinearFiltersChooserForm";
            this.Text = "LinearFiltersChooserForm";
            ((System.ComponentModel.ISupportInitialize)(this.xSizeNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button meanFilterButton;
        private System.Windows.Forms.Button medianFilterButton;
        private System.Windows.Forms.NumericUpDown xSizeNumUpDown;
        private System.Windows.Forms.NumericUpDown ySizeNumUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button gaussianFilterButtom;
        private System.Windows.Forms.Button JimCasaburiFilterButton;
        private System.Windows.Forms.Button splitMiddleFilterButton;
        private System.Windows.Forms.NumericUpDown dUpDown;
        private System.Windows.Forms.Button RecursiveFilterButton;
        private System.Windows.Forms.Button AdaptiveFilterButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}