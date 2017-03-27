namespace Zotin_1
{
    partial class ResultBox
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hystogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noizeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyUsingHystogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(30, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(605, 467);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(662, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorBalanceToolStripMenuItem,
            this.hystogramToolStripMenuItem,
            this.noizeGeneratorToolStripMenuItem,
            this.modifyUsingHystogramToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // colorBalanceToolStripMenuItem
            // 
            this.colorBalanceToolStripMenuItem.Name = "colorBalanceToolStripMenuItem";
            this.colorBalanceToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.colorBalanceToolStripMenuItem.Text = "Color balance";
            this.colorBalanceToolStripMenuItem.Click += new System.EventHandler(this.colorBalanceToolStripMenuItem_Click);
            // 
            // hystogramToolStripMenuItem
            // 
            this.hystogramToolStripMenuItem.Name = "hystogramToolStripMenuItem";
            this.hystogramToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.hystogramToolStripMenuItem.Text = "Hystogram";
            this.hystogramToolStripMenuItem.Click += new System.EventHandler(this.hystogramToolStripMenuItem_Click);
            // 
            // noizeGeneratorToolStripMenuItem
            // 
            this.noizeGeneratorToolStripMenuItem.Name = "noizeGeneratorToolStripMenuItem";
            this.noizeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.noizeGeneratorToolStripMenuItem.Text = "Noize generator";
            this.noizeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.noizeGeneratorToolStripMenuItem_Click);
            // 
            // modifyUsingHystogramToolStripMenuItem
            // 
            this.modifyUsingHystogramToolStripMenuItem.Name = "modifyUsingHystogramToolStripMenuItem";
            this.modifyUsingHystogramToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.modifyUsingHystogramToolStripMenuItem.Text = "Modify using hystogram";
            this.modifyUsingHystogramToolStripMenuItem.Click += new System.EventHandler(this.modifyUsingHystogramToolStripMenuItem_Click);
            // 
            // ResultBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 506);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ResultBox";
            this.Text = "ResultBox";
            this.Load += new System.EventHandler(this.ResultBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorBalanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hystogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noizeGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyUsingHystogramToolStripMenuItem;
    }
}