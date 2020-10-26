namespace FREE_OSINT
{
    partial class Query_InsertForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.listViewModules = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtLimitResults = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimitResults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Query";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(13, 71);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(775, 22);
            this.txtQuery.TabIndex = 1;
            // 
            // listViewModules
            // 
            this.listViewModules.Enabled = false;
            this.listViewModules.FullRowSelect = true;
            this.listViewModules.GridLines = true;
            this.listViewModules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewModules.HideSelection = false;
            this.listViewModules.Location = new System.Drawing.Point(400, 141);
            this.listViewModules.Name = "listViewModules";
            this.listViewModules.Size = new System.Drawing.Size(386, 251);
            this.listViewModules.TabIndex = 2;
            this.listViewModules.UseCompatibleStateImageBehavior = false;
            this.listViewModules.View = System.Windows.Forms.View.Details;
            this.listViewModules.SelectedIndexChanged += new System.EventHandler(this.listViewModules_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected modules";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Extras";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(400, 398);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(386, 40);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(379, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtLimitResults
            // 
            this.txtLimitResults.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtLimitResults.Location = new System.Drawing.Point(112, 139);
            this.txtLimitResults.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtLimitResults.Name = "txtLimitResults";
            this.txtLimitResults.Size = new System.Drawing.Size(141, 22);
            this.txtLimitResults.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Limit results";
            // 
            // Query_InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLimitResults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewModules);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label1);
            this.Name = "Query_InsertForm";
            this.Text = "Query_InsertForm";
            ((System.ComponentModel.ISupportInitialize)(this.txtLimitResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.ListView listViewModules;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown txtLimitResults;
        private System.Windows.Forms.Label label4;
    }
}