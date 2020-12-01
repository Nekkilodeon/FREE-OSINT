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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workplace_panel = new System.Windows.Forms.Panel();
            this.panelDrawWorkspace = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnStraight = new System.Windows.Forms.Button();
            this.btn4way = new System.Windows.Forms.Button();
            this.btnBezier = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutoLayout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelWorkspaceName = new System.Windows.Forms.Label();
            this.treeViewTargets = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripTargets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.workplace_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modulesToolStripMenuItem,
            this.resultsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1262, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // modulesToolStripMenuItem
            // 
            this.modulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.showFolderToolStripMenuItem});
            this.modulesToolStripMenuItem.Name = "modulesToolStripMenuItem";
            this.modulesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.modulesToolStripMenuItem.Text = "Modules";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.showToolStripMenuItem.Text = "All Modules";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // showFolderToolStripMenuItem
            // 
            this.showFolderToolStripMenuItem.Name = "showFolderToolStripMenuItem";
            this.showFolderToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.showFolderToolStripMenuItem.Text = "Show folder";
            this.showFolderToolStripMenuItem.Click += new System.EventHandler(this.showFolderToolStripMenuItem_Click);
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1});
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.resultsToolStripMenuItem.Text = "Results";
            this.resultsToolStripMenuItem.Click += new System.EventHandler(this.resultsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // workplace_panel
            // 
            this.workplace_panel.AutoScroll = true;
            this.workplace_panel.BackColor = System.Drawing.SystemColors.Window;
            this.workplace_panel.Controls.Add(this.panelDrawWorkspace);
            this.workplace_panel.Controls.Add(this.panel2);
            this.workplace_panel.Controls.Add(this.panel1);
            this.workplace_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workplace_panel.Location = new System.Drawing.Point(0, 28);
            this.workplace_panel.Name = "workplace_panel";
            this.workplace_panel.Size = new System.Drawing.Size(1262, 645);
            this.workplace_panel.TabIndex = 2;
            this.workplace_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.workplace_panel_Paint);
            // 
            // panelDrawWorkspace
            // 
            this.panelDrawWorkspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDrawWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrawWorkspace.Location = new System.Drawing.Point(292, 50);
            this.panelDrawWorkspace.Name = "panelDrawWorkspace";
            this.panelDrawWorkspace.Size = new System.Drawing.Size(970, 595);
            this.panelDrawWorkspace.TabIndex = 2;
            this.panelDrawWorkspace.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawWorkspace_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSaveImage);
            this.panel2.Controls.Add(this.btnStraight);
            this.panel2.Controls.Add(this.btn4way);
            this.panel2.Controls.Add(this.btnBezier);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnAutoLayout);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(292, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 50);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveImage.Location = new System.Drawing.Point(828, 7);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(129, 31);
            this.btnSaveImage.TabIndex = 5;
            this.btnSaveImage.Text = "Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnStraight
            // 
            this.btnStraight.Location = new System.Drawing.Point(352, 9);
            this.btnStraight.Name = "btnStraight";
            this.btnStraight.Size = new System.Drawing.Size(129, 29);
            this.btnStraight.TabIndex = 4;
            this.btnStraight.Text = "Straight";
            this.btnStraight.UseVisualStyleBackColor = true;
            this.btnStraight.Click += new System.EventHandler(this.btnStraight_Click);
            // 
            // btn4way
            // 
            this.btn4way.Location = new System.Drawing.Point(217, 9);
            this.btn4way.Name = "btn4way";
            this.btn4way.Size = new System.Drawing.Size(129, 29);
            this.btn4way.TabIndex = 3;
            this.btn4way.Text = "4 Way Links";
            this.btn4way.UseVisualStyleBackColor = true;
            this.btn4way.Click += new System.EventHandler(this.btn4way_Click);
            // 
            // btnBezier
            // 
            this.btnBezier.Location = new System.Drawing.Point(82, 9);
            this.btnBezier.Name = "btnBezier";
            this.btnBezier.Size = new System.Drawing.Size(129, 29);
            this.btnBezier.TabIndex = 2;
            this.btnBezier.Text = "Bezier";
            this.btnBezier.UseVisualStyleBackColor = true;
            this.btnBezier.Click += new System.EventHandler(this.btnBezier_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Line Type";
            // 
            // btnAutoLayout
            // 
            this.btnAutoLayout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAutoLayout.Location = new System.Drawing.Point(653, 7);
            this.btnAutoLayout.Name = "btnAutoLayout";
            this.btnAutoLayout.Size = new System.Drawing.Size(169, 31);
            this.btnAutoLayout.TabIndex = 0;
            this.btnAutoLayout.Text = "Auto Layout";
            this.btnAutoLayout.UseVisualStyleBackColor = true;
            this.btnAutoLayout.Click += new System.EventHandler(this.btnAutoLayout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.treeViewTargets);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 645);
            this.panel1.TabIndex = 0;
            // 
            // labelWorkspaceName
            // 
            this.labelWorkspaceName.AutoSize = true;
            this.labelWorkspaceName.Location = new System.Drawing.Point(3, 30);
            this.labelWorkspaceName.Name = "labelWorkspaceName";
            this.labelWorkspaceName.Size = new System.Drawing.Size(56, 17);
            this.labelWorkspaceName.TabIndex = 1;
            this.labelWorkspaceName.Text = "Untitled";
            this.labelWorkspaceName.Click += new System.EventHandler(this.labelWorkspaceName_Click);
            // 
            // treeViewTargets
            // 
            this.treeViewTargets.AllowDrop = true;
            this.treeViewTargets.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTargets.FullRowSelect = true;
            this.treeViewTargets.Location = new System.Drawing.Point(0, 100);
            this.treeViewTargets.Name = "treeViewTargets";
            this.treeViewTargets.ShowLines = false;
            this.treeViewTargets.ShowPlusMinus = false;
            this.treeViewTargets.ShowRootLines = false;
            this.treeViewTargets.Size = new System.Drawing.Size(290, 543);
            this.treeViewTargets.TabIndex = 3;
            this.treeViewTargets.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTargets_AfterSelect);
            this.treeViewTargets.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.nodeClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Targets";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workspace";
            // 
            // menuStripTargets
            // 
            this.menuStripTargets.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripTargets.Name = "menuStripTargets";
            this.menuStripTargets.Size = new System.Drawing.Size(61, 4);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelWorkspaceName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 100);
            this.panel3.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.workplace_panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "FREE-OSINT";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.workplace_panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.Panel workplace_panel;
        private System.Windows.Forms.ContextMenuStrip menuStripTargets;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelWorkspaceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAutoLayout;
        private System.Windows.Forms.Panel panelDrawWorkspace;
        private System.Windows.Forms.Button btnStraight;
        private System.Windows.Forms.Button btn4way;
        private System.Windows.Forms.Button btnBezier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeViewTargets;
        private System.Windows.Forms.Panel panel3;
    }
}

