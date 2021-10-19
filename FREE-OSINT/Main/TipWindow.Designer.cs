namespace FREE_OSINT.Main
{
    partial class TipWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipWindow));
            this.button1 = new System.Windows.Forms.Button();
            this.checkSkipTips = new System.Windows.Forms.CheckBox();
            this.PictureDisplayBox = new System.Windows.Forms.PictureBox();
            this.tipText = new System.Windows.Forms.TextBox();
            this.btnMore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(774, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkSkipTips
            // 
            this.checkSkipTips.AutoSize = true;
            this.checkSkipTips.Location = new System.Drawing.Point(774, 406);
            this.checkSkipTips.Name = "checkSkipTips";
            this.checkSkipTips.Size = new System.Drawing.Size(101, 21);
            this.checkSkipTips.TabIndex = 1;
            this.checkSkipTips.Text = "Skip all tips";
            this.checkSkipTips.UseVisualStyleBackColor = true;
            // 
            // PictureDisplayBox
            // 
            this.PictureDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplayBox.Location = new System.Drawing.Point(12, 12);
            this.PictureDisplayBox.Name = "PictureDisplayBox";
            this.PictureDisplayBox.Size = new System.Drawing.Size(756, 455);
            this.PictureDisplayBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureDisplayBox.TabIndex = 2;
            this.PictureDisplayBox.TabStop = false;
            this.PictureDisplayBox.Click += new System.EventHandler(this.PictureDisplayBox_Click);
            // 
            // tipText
            // 
            this.tipText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tipText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipText.Location = new System.Drawing.Point(12, 473);
            this.tipText.Multiline = true;
            this.tipText.Name = "tipText";
            this.tipText.ReadOnly = true;
            this.tipText.Size = new System.Drawing.Size(872, 61);
            this.tipText.TabIndex = 3;
            // 
            // btnMore
            // 
            this.btnMore.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMore.Location = new System.Drawing.Point(774, 433);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(110, 34);
            this.btnMore.TabIndex = 4;
            this.btnMore.Text = "More";
            this.btnMore.UseVisualStyleBackColor = false;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // TipWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(895, 541);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.tipText);
            this.Controls.Add(this.PictureDisplayBox);
            this.Controls.Add(this.checkSkipTips);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TipWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tips";
            this.Load += new System.EventHandler(this.TipWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplayBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkSkipTips;
        private System.Windows.Forms.PictureBox PictureDisplayBox;
        private System.Windows.Forms.TextBox tipText;
        private System.Windows.Forms.Button btnMore;
    }
}