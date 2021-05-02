using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modulesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modulesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.allModulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workplace_panel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageWorspace = new System.Windows.Forms.TabPage();
            this.panelDrawWorkspace = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRecolor = new System.Windows.Forms.Button();
            this.btnResetBoxes = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.slideWidth = new System.Windows.Forms.TrackBar();
            this.slideHeight = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectFont = new System.Windows.Forms.Button();
            this.btnHDPIEnable = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnStraight = new System.Windows.Forms.Button();
            this.btn4way = new System.Windows.Forms.Button();
            this.btnBezier = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutoLayout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeViewTargets = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnColapse = new System.Windows.Forms.Button();
            this.labelWorkspaceName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStripTargets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnPerformance = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.workplace_panel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageWorspace.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slideWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideHeight)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modulesToolStripMenuItem,
            this.resultsToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.modulesToolStripMenuItem2,
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1582, 28);
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
            this.modulesToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.modulesToolStripMenuItem.Text = "Search";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.showToolStripMenuItem.Text = "Modules";
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
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modulesToolStripMenuItem1,
            this.showFolderToolStripMenuItem1,
            this.editToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // modulesToolStripMenuItem1
            // 
            this.modulesToolStripMenuItem1.Name = "modulesToolStripMenuItem1";
            this.modulesToolStripMenuItem1.Size = new System.Drawing.Size(174, 26);
            this.modulesToolStripMenuItem1.Text = "Modules";
            this.modulesToolStripMenuItem1.Click += new System.EventHandler(this.modulesToolStripMenuItem1_Click);
            // 
            // showFolderToolStripMenuItem1
            // 
            this.showFolderToolStripMenuItem1.Name = "showFolderToolStripMenuItem1";
            this.showFolderToolStripMenuItem1.Size = new System.Drawing.Size(174, 26);
            this.showFolderToolStripMenuItem1.Text = "Show Folder";
            this.showFolderToolStripMenuItem1.Click += new System.EventHandler(this.showFolderToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // modulesToolStripMenuItem2
            // 
            this.modulesToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allModulesToolStripMenuItem});
            this.modulesToolStripMenuItem2.Name = "modulesToolStripMenuItem2";
            this.modulesToolStripMenuItem2.Size = new System.Drawing.Size(80, 24);
            this.modulesToolStripMenuItem2.Text = "Modules";
            // 
            // allModulesToolStripMenuItem
            // 
            this.allModulesToolStripMenuItem.Name = "allModulesToolStripMenuItem";
            this.allModulesToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.allModulesToolStripMenuItem.Text = "All modules";
            this.allModulesToolStripMenuItem.Click += new System.EventHandler(this.allModulesToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem1});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.configToolStripMenuItem.Text = "Tools";
            // 
            // configToolStripMenuItem1
            // 
            this.configToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("configToolStripMenuItem1.Image")));
            this.configToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configToolStripMenuItem1.Name = "configToolStripMenuItem1";
            this.configToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.configToolStripMenuItem1.Text = "Options";
            this.configToolStripMenuItem1.Click += new System.EventHandler(this.configToolStripMenuItem1_Click);
            // 
            // workplace_panel
            // 
            this.workplace_panel.AutoScroll = true;
            this.workplace_panel.BackColor = System.Drawing.SystemColors.Window;
            this.workplace_panel.Controls.Add(this.tabControl);
            this.workplace_panel.Controls.Add(this.panel2);
            this.workplace_panel.Controls.Add(this.panel1);
            this.workplace_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workplace_panel.Location = new System.Drawing.Point(0, 28);
            this.workplace_panel.Name = "workplace_panel";
            this.workplace_panel.Size = new System.Drawing.Size(1582, 825);
            this.workplace_panel.TabIndex = 2;
            this.workplace_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.workplace_panel_Paint);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageWorspace);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Location = new System.Drawing.Point(335, 85);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1247, 740);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.onDrawTabs);
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownTabs);
            // 
            // tabPageWorspace
            // 
            this.tabPageWorspace.BackColor = System.Drawing.Color.White;
            this.tabPageWorspace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageWorspace.Controls.Add(this.panelDrawWorkspace);
            this.tabPageWorspace.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPageWorspace.Location = new System.Drawing.Point(4, 25);
            this.tabPageWorspace.Name = "tabPageWorspace";
            this.tabPageWorspace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorspace.Size = new System.Drawing.Size(1239, 711);
            this.tabPageWorspace.TabIndex = 0;
            this.tabPageWorspace.Text = "Workspace";
            // 
            // panelDrawWorkspace
            // 
            this.panelDrawWorkspace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDrawWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrawWorkspace.Location = new System.Drawing.Point(3, 3);
            this.panelDrawWorkspace.Name = "panelDrawWorkspace";
            this.panelDrawWorkspace.Size = new System.Drawing.Size(1233, 705);
            this.panelDrawWorkspace.TabIndex = 2;
            this.panelDrawWorkspace.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawWorkspace_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.Controls.Add(this.btnPerformance);
            this.panel2.Controls.Add(this.btnRecolor);
            this.panel2.Controls.Add(this.btnResetBoxes);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.slideWidth);
            this.panel2.Controls.Add(this.slideHeight);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnSelectFont);
            this.panel2.Controls.Add(this.btnHDPIEnable);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnSaveImage);
            this.panel2.Controls.Add(this.btnStraight);
            this.panel2.Controls.Add(this.btn4way);
            this.panel2.Controls.Add(this.btnBezier);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnAutoLayout);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(335, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1247, 85);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnRecolor
            // 
            this.btnRecolor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecolor.Location = new System.Drawing.Point(971, 4);
            this.btnRecolor.Name = "btnRecolor";
            this.btnRecolor.Size = new System.Drawing.Size(129, 31);
            this.btnRecolor.TabIndex = 20;
            this.btnRecolor.Text = "Recolor";
            this.btnRecolor.UseVisualStyleBackColor = true;
            this.btnRecolor.Click += new System.EventHandler(this.btnRecolor_Click);
            // 
            // btnResetBoxes
            // 
            this.btnResetBoxes.Location = new System.Drawing.Point(79, 3);
            this.btnResetBoxes.Name = "btnResetBoxes";
            this.btnResetBoxes.Size = new System.Drawing.Size(95, 23);
            this.btnResetBoxes.TabIndex = 19;
            this.btnResetBoxes.Text = "Reset";
            this.btnResetBoxes.UseVisualStyleBackColor = true;
            this.btnResetBoxes.Click += new System.EventHandler(this.btnResetBoxes_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(149, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Height";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Width";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Box";
            // 
            // slideWidth
            // 
            this.slideWidth.Location = new System.Drawing.Point(26, 53);
            this.slideWidth.Maximum = 100;
            this.slideWidth.Minimum = -99;
            this.slideWidth.Name = "slideWidth";
            this.slideWidth.Size = new System.Drawing.Size(95, 56);
            this.slideWidth.TabIndex = 15;
            this.slideWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slideWidth.Scroll += new System.EventHandler(this.slideWidth_Scroll);
            // 
            // slideHeight
            // 
            this.slideHeight.Location = new System.Drawing.Point(127, 53);
            this.slideHeight.Maximum = 100;
            this.slideHeight.Minimum = -99;
            this.slideHeight.Name = "slideHeight";
            this.slideHeight.Size = new System.Drawing.Size(95, 56);
            this.slideHeight.SmallChange = 10;
            this.slideHeight.TabIndex = 14;
            this.slideHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slideHeight.Scroll += new System.EventHandler(this.slideHeight_Scroll);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(785, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Font";
            // 
            // btnSelectFont
            // 
            this.btnSelectFont.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelectFont.Location = new System.Drawing.Point(836, 4);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(129, 31);
            this.btnSelectFont.TabIndex = 12;
            this.btnSelectFont.Text = "Change";
            this.btnSelectFont.UseVisualStyleBackColor = true;
            this.btnSelectFont.Click += new System.EventHandler(this.btnSelectFont_Click);
            // 
            // btnHDPIEnable
            // 
            this.btnHDPIEnable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHDPIEnable.Location = new System.Drawing.Point(1106, 4);
            this.btnHDPIEnable.Name = "btnHDPIEnable";
            this.btnHDPIEnable.Size = new System.Drawing.Size(129, 31);
            this.btnHDPIEnable.TabIndex = 8;
            this.btnHDPIEnable.Text = "HDPI support";
            this.btnHDPIEnable.UseVisualStyleBackColor = true;
            this.btnHDPIEnable.Click += new System.EventHandler(this.btnHDPIEnable_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Alignment";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveImage.Location = new System.Drawing.Point(304, 4);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(129, 31);
            this.btnSaveImage.TabIndex = 5;
            this.btnSaveImage.Text = "Horizontal";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnStraight
            // 
            this.btnStraight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStraight.Location = new System.Drawing.Point(1106, 47);
            this.btnStraight.Name = "btnStraight";
            this.btnStraight.Size = new System.Drawing.Size(129, 29);
            this.btnStraight.TabIndex = 4;
            this.btnStraight.Text = "Straight";
            this.btnStraight.UseVisualStyleBackColor = true;
            this.btnStraight.Click += new System.EventHandler(this.btnStraight_Click);
            // 
            // btn4way
            // 
            this.btn4way.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn4way.Location = new System.Drawing.Point(971, 47);
            this.btn4way.Name = "btn4way";
            this.btn4way.Size = new System.Drawing.Size(129, 29);
            this.btn4way.TabIndex = 3;
            this.btn4way.Text = "4 Way Links";
            this.btn4way.UseVisualStyleBackColor = true;
            this.btn4way.Click += new System.EventHandler(this.btn4way_Click);
            // 
            // btnBezier
            // 
            this.btnBezier.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBezier.Location = new System.Drawing.Point(836, 47);
            this.btnBezier.Name = "btnBezier";
            this.btnBezier.Size = new System.Drawing.Size(129, 29);
            this.btnBezier.TabIndex = 2;
            this.btnBezier.Text = "Bezier";
            this.btnBezier.UseVisualStyleBackColor = true;
            this.btnBezier.Click += new System.EventHandler(this.btnBezier_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(759, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Line Type";
            // 
            // btnAutoLayout
            // 
            this.btnAutoLayout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAutoLayout.Location = new System.Drawing.Point(304, 46);
            this.btnAutoLayout.Name = "btnAutoLayout";
            this.btnAutoLayout.Size = new System.Drawing.Size(129, 31);
            this.btnAutoLayout.TabIndex = 0;
            this.btnAutoLayout.Text = "Vertical";
            this.btnAutoLayout.UseVisualStyleBackColor = true;
            this.btnAutoLayout.Click += new System.EventHandler(this.btnAutoLayout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.treeViewTargets);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 825);
            this.panel1.TabIndex = 0;
            // 
            // treeViewTargets
            // 
            this.treeViewTargets.AllowDrop = true;
            this.treeViewTargets.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewTargets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTargets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewTargets.FullRowSelect = true;
            this.treeViewTargets.Location = new System.Drawing.Point(0, 85);
            this.treeViewTargets.Margin = new System.Windows.Forms.Padding(10);
            this.treeViewTargets.Name = "treeViewTargets";
            this.treeViewTargets.ShowLines = false;
            this.treeViewTargets.ShowPlusMinus = false;
            this.treeViewTargets.ShowRootLines = false;
            this.treeViewTargets.Size = new System.Drawing.Size(335, 740);
            this.treeViewTargets.TabIndex = 3;
            this.treeViewTargets.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTargets_AfterSelect);
            this.treeViewTargets.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.nodeClick);
            this.treeViewTargets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownTreeView);
            this.treeViewTargets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.doubleClickTreeView);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.labelWorkspaceName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(335, 85);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnExpand);
            this.panel4.Controls.Add(this.btnColapse);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(335, 25);
            this.panel4.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(3, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nodes";
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(301, -1);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(37, 37);
            this.btnExpand.TabIndex = 5;
            this.btnExpand.Text = "<>";
            this.btnExpand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnColapse
            // 
            this.btnColapse.Location = new System.Drawing.Point(267, -1);
            this.btnColapse.Name = "btnColapse";
            this.btnColapse.Size = new System.Drawing.Size(37, 32);
            this.btnColapse.TabIndex = 4;
            this.btnColapse.Text = "><";
            this.btnColapse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColapse.UseVisualStyleBackColor = true;
            this.btnColapse.Click += new System.EventHandler(this.btnColapse_Click);
            // 
            // labelWorkspaceName
            // 
            this.labelWorkspaceName.AutoSize = true;
            this.labelWorkspaceName.Location = new System.Drawing.Point(113, 40);
            this.labelWorkspaceName.Name = "labelWorkspaceName";
            this.labelWorkspaceName.Size = new System.Drawing.Size(56, 17);
            this.labelWorkspaceName.TabIndex = 1;
            this.labelWorkspaceName.Text = "Untitled";
            this.labelWorkspaceName.Click += new System.EventHandler(this.labelWorkspaceName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workspace";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(6, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menuStripTargets
            // 
            this.menuStripTargets.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripTargets.Name = "menuStripTargets";
            this.menuStripTargets.Size = new System.Drawing.Size(61, 4);
            // 
            // btnPerformance
            // 
            this.btnPerformance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPerformance.Location = new System.Drawing.Point(531, 4);
            this.btnPerformance.Name = "btnPerformance";
            this.btnPerformance.Size = new System.Drawing.Size(203, 31);
            this.btnPerformance.TabIndex = 21;
            this.btnPerformance.Text = "Refresh";
            this.btnPerformance.UseVisualStyleBackColor = true;
            this.btnPerformance.Click += new System.EventHandler(this.btnPerformance_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.workplace_panel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FREE-OSINT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closingForm);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.workplace_panel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageWorspace.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slideWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideHeight)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modulesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnColapse;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnHDPIEnable;
        private System.Windows.Forms.Button btnSelectFont;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar slideHeight;
        private System.Windows.Forms.TrackBar slideWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnResetBoxes;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageWorspace;
        private System.Windows.Forms.ToolStripMenuItem modulesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem allModulesToolStripMenuItem;
        private ToolStripMenuItem configToolStripMenuItem;
        private ToolStripMenuItem configToolStripMenuItem1;
        private Button btnRecolor;
        private Button btnPerformance;
    }
}

