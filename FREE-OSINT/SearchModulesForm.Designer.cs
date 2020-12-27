namespace FREE_OSINT
{
    partial class SearchModulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchModulesForm));
            this.btnInteract = new System.Windows.Forms.Button();
            this.listModules = new System.Windows.Forms.CheckedListBox();
            this.btnSearchModules = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInteract
            // 
            this.btnInteract.Image = ((System.Drawing.Image)(resources.GetObject("btnInteract.Image")));
            this.btnInteract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInteract.Location = new System.Drawing.Point(393, 13);
            this.btnInteract.Name = "btnInteract";
            this.btnInteract.Size = new System.Drawing.Size(395, 47);
            this.btnInteract.TabIndex = 1;
            this.btnInteract.Text = "     Interact";
            this.btnInteract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnSearchModules.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchModules.Image")));
            this.btnSearchModules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchModules.Location = new System.Drawing.Point(393, 382);
            this.btnSearchModules.Name = "btnSearchModules";
            this.btnSearchModules.Size = new System.Drawing.Size(395, 43);
            this.btnSearchModules.TabIndex = 3;
            this.btnSearchModules.Text = "     Search using 0 modules";
            this.btnSearchModules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchModules.UseVisualStyleBackColor = true;
            this.btnSearchModules.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigure.Image")));
            this.btnConfigure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigure.Location = new System.Drawing.Point(392, 66);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(395, 47);
            this.btnConfigure.TabIndex = 4;
            this.btnConfigure.Text = "     Configure";
            this.btnConfigure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // ModulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.btnSearchModules);
            this.Controls.Add(this.listModules);
            this.Controls.Add(this.btnInteract);
            this.Name = "ModulesForm";
            this.Text = "Modules";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closingForm);
            this.Load += new System.EventHandler(this.ModulesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInteract;
        private System.Windows.Forms.CheckedListBox listModules;
        private System.Windows.Forms.Button btnSearchModules;
        private System.Windows.Forms.Button btnConfigure;
    }
}