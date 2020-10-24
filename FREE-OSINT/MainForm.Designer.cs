namespace FREE_OSINT
{
    partial class MainForm
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
            this.btnModules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModules
            // 
            this.btnModules.Location = new System.Drawing.Point(12, 12);
            this.btnModules.Name = "btnModules";
            this.btnModules.Size = new System.Drawing.Size(184, 42);
            this.btnModules.TabIndex = 0;
            this.btnModules.Text = "Search";
            this.btnModules.UseVisualStyleBackColor = true;
            this.btnModules.Click += new System.EventHandler(this.btnModules_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnModules);
            this.Name = "MainForm";
            this.Text = "FREE-OSINT";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModules;
    }
}

