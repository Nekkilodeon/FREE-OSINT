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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnInteract
            // 
            this.btnInteract.Image = ((System.Drawing.Image)(resources.GetObject("btnInteract.Image")));
            this.btnInteract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInteract.Location = new System.Drawing.Point(468, 26);
            this.btnInteract.Name = "btnInteract";
            this.btnInteract.Size = new System.Drawing.Size(320, 37);
            this.btnInteract.TabIndex = 1;
            this.btnInteract.Text = "     Interact";
            this.btnInteract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInteract.UseVisualStyleBackColor = true;
            this.btnInteract.Click += new System.EventHandler(this.btnInteract_Click);
            // 
            // listModules
            // 
            this.listModules.FormattingEnabled = true;
            this.listModules.Location = new System.Drawing.Point(13, 64);
            this.listModules.Name = "listModules";
            this.listModules.Size = new System.Drawing.Size(448, 361);
            this.listModules.TabIndex = 2;
            this.listModules.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listModulesItemChecked);
            this.listModules.SelectedIndexChanged += new System.EventHandler(this.listModules_SelectedIndexChanged);
            // 
            // btnSearchModules
            // 
            this.btnSearchModules.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchModules.Image")));
            this.btnSearchModules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchModules.Location = new System.Drawing.Point(468, 382);
            this.btnSearchModules.Name = "btnSearchModules";
            this.btnSearchModules.Size = new System.Drawing.Size(320, 43);
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
            this.btnConfigure.Location = new System.Drawing.Point(468, 69);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(320, 33);
            this.btnConfigure.TabIndex = 4;
            this.btnConfigure.Text = "     Configure";
            this.btnConfigure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(468, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Menu;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(472, 132);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(316, 235);
            this.txtDescription.TabIndex = 6;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(14, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(448, 22);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // SearchModulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.btnSearchModules);
            this.Controls.Add(this.listModules);
            this.Controls.Add(this.btnInteract);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchModulesForm";
            this.Text = "Modules";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closingForm);
            this.Load += new System.EventHandler(this.ModulesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInteract;
        private System.Windows.Forms.CheckedListBox listModules;
        private System.Windows.Forms.Button btnSearchModules;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSearch;
    }
}