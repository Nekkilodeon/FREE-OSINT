namespace FREE_OSINT.Main
{
    partial class ConfigurationsForm
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
            this.listViewColors = new System.Windows.Forms.ListView();
            this.columnColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnColorText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelHierarchy = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewColors
            // 
            this.listViewColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnColor,
            this.columnNum,
            this.columnColorText});
            this.listViewColors.FullRowSelect = true;
            this.listViewColors.HideSelection = false;
            this.listViewColors.Location = new System.Drawing.Point(12, 48);
            this.listViewColors.MultiSelect = false;
            this.listViewColors.Name = "listViewColors";
            this.listViewColors.Size = new System.Drawing.Size(273, 150);
            this.listViewColors.TabIndex = 1;
            this.listViewColors.UseCompatibleStateImageBehavior = false;
            this.listViewColors.View = System.Windows.Forms.View.Details;
            this.listViewColors.SelectedIndexChanged += new System.EventHandler(this.ListViewColors_SelectedIndexChanged);
            this.listViewColors.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoubleClick);
            this.listViewColors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.listViewColors.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.listViewColors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // columnColor
            // 
            this.columnColor.Text = "";
            this.columnColor.Width = 20;
            // 
            // columnNum
            // 
            this.columnNum.Text = "Nº";
            this.columnNum.Width = 30;
            // 
            // columnColorText
            // 
            this.columnColorText.Text = "Color";
            this.columnColorText.Width = 100;
            // 
            // labelHierarchy
            // 
            this.labelHierarchy.AutoSize = true;
            this.labelHierarchy.Location = new System.Drawing.Point(13, 25);
            this.labelHierarchy.Name = "labelHierarchy";
            this.labelHierarchy.Size = new System.Drawing.Size(140, 17);
            this.labelHierarchy.TabIndex = 2;
            this.labelHierarchy.Text = "Node color hierarchy";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(639, 383);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(149, 55);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // ConfigurationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.labelHierarchy);
            this.Controls.Add(this.listViewColors);
            this.Name = "ConfigurationsForm";
            this.Text = "Configurations";
            this.Load += new System.EventHandler(this.ConfigurationsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewColors;
        private System.Windows.Forms.Label labelHierarchy;
        private System.Windows.Forms.ColumnHeader columnColor;
        private System.Windows.Forms.ColumnHeader columnColorText;
        private System.Windows.Forms.ColumnHeader columnNum;
        private System.Windows.Forms.Button btnDone;
    }
}