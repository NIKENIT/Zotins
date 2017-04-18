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
            this.GlobalMethodsButton = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBox)).BeginInit();
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
            this.LocalMethodsButton.Text = "Бинаризация";
            this.LocalMethodsButton.UseVisualStyleBackColor = true;
            this.LocalMethodsButton.Click += new System.EventHandler(this.LocalMethodsButton_Click);
            // 
            // GlobalMethodsButton
            // 
            this.GlobalMethodsButton.Location = new System.Drawing.Point(516, 70);
            this.GlobalMethodsButton.Name = "GlobalMethodsButton";
            this.GlobalMethodsButton.Size = new System.Drawing.Size(132, 51);
            this.GlobalMethodsButton.TabIndex = 2;
            this.GlobalMethodsButton.Text = "Морфологическая обработка";
            this.GlobalMethodsButton.UseVisualStyleBackColor = true;
            this.GlobalMethodsButton.Click += new System.EventHandler(this.GlobalMethodsButton_Click);
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
            // Lab3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 523);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.GlobalMethodsButton);
            this.Controls.Add(this.LocalMethodsButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Lab3Form";
            this.Text = "Lab3Form";
            this.Load += new System.EventHandler(this.Lab3Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LocalMethodsButton;
        private System.Windows.Forms.Button GlobalMethodsButton;
        private System.Windows.Forms.PictureBox resultBox;
    }
}