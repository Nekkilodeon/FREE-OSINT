namespace FREE_OSINT
{
    partial class ModulesForm
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
            this.btnInteract = new System.Windows.Forms.Button();
            this.listModules = new System.Windows.Forms.CheckedListBox();
            this.btnSearchModules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInteract
            // 
            this.btnInteract.Location = new System.Drawing.Point(393, 13);
            this.btnInteract.Name = "btnInteract";
            this.btnInteract.Size = new System.Drawing.Size(395, 47);
            this.btnInteract.TabIndex = 1;
            this.btnInteract.Text = "Interact";
            this.btnInteract.UseVisualStyleBackColor = true;
            this.btnInteract.Click += new System.EventHandler(this.btnInteract_Click);
            // 
            // listModules
            // 
            this.listModules.FormattingEnabled = true;
            this.listModules.Location = new System.Drawing.Point(13, 13);
            this.listModules.Name = "listModules";
            this.listModules.Size = new System.Drawing.Size(373, 412);
            this.listModules.TabIndex = 2;
            this.listModules.SelectedIndexChanged += new System.EventHandler(this.listModules_SelectedIndexChanged);
            // 
            // btnSearchModules
            // 
            this.btnSearchModules.Location = new System.Drawing.Point(393, 382);
            this.btnSearchModules.Name = "btnSearchModules";
            this.btnSearchModules.Size = new System.Drawing.Size(395, 43);
            this.btnSearchModules.TabIndex = 3;
            this.btnSearchModules.Text = "Search using 0 modules";
            this.btnSearchModules.UseVisualStyleBackColor = true;
            this.btnSearchModules.Click += new System.EventHandler(this.button2_Click);
            // 
            // ModulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearchModules);
            this.Controls.Add(this.listModules);
            this.Controls.Add(this.btnInteract);
            this.Name = "ModulesForm";
            this.Text = "Modules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInteract;
        private System.Windows.Forms.CheckedListBox listModules;
        private System.Windows.Forms.Button btnSearchModules;
    }
}