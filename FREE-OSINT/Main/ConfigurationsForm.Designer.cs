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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkPerformance = new System.Windows.Forms.CheckBox();
            this.checkTips = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.btnDone.Location = new System.Drawing.Point(359, 369);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(149, 55);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(434, 48);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numericUpDown1.Size = new System.Drawing.Size(74, 22);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Containers per row";
            // 
            // checkPerformance
            // 
            this.checkPerformance.AutoSize = true;
            this.checkPerformance.Location = new System.Drawing.Point(304, 91);
            this.checkPerformance.Name = "checkPerformance";
            this.checkPerformance.Size = new System.Drawing.Size(150, 21);
            this.checkPerformance.TabIndex = 6;
            this.checkPerformance.Text = "Performance Mode";
            this.checkPerformance.UseVisualStyleBackColor = true;
            this.checkPerformance.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkTips
            // 
            this.checkTips.AutoSize = true;
            this.checkTips.Location = new System.Drawing.Point(304, 118);
            this.checkTips.Name = "checkTips";
            this.checkTips.Size = new System.Drawing.Size(88, 21);
            this.checkTips.TabIndex = 7;
            this.checkTips.Text = "Skip Tips";
            this.checkTips.UseVisualStyleBackColor = true;
            // 
            // ConfigurationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 450);
            this.Controls.Add(this.checkTips);
            this.Controls.Add(this.checkPerformance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.labelHierarchy);
            this.Controls.Add(this.listViewColors);
            this.Name = "ConfigurationsForm";
            this.Text = "Configurations";
            this.Shown += new System.EventHandler(this.ConfigurationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkPerformance;
        private System.Windows.Forms.CheckBox checkTips;
    }
}