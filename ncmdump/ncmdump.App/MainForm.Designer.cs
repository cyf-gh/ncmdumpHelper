namespace ncmdump.App {
    partial class MainForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDefaultMusicFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.设置当前目录为默认路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAllNcmsInTheChildFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_ncms = new System.Windows.Forms.ListBox();
            this.bt_conversion = new System.Windows.Forms.Button();
            this.cb_ifDoDelete = new System.Windows.Forms.CheckBox();
            this.tt_path = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.advanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(834, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolderToolStripMenuItem,
            this.selectDefaultMusicFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.设置当前目录为默认路径ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // selectFolderToolStripMenuItem
            // 
            this.selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
            this.selectFolderToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.selectFolderToolStripMenuItem.Text = "选择文件夹";
            this.selectFolderToolStripMenuItem.Click += new System.EventHandler(this.selectFolderToolStripMenuItem_Click);
            // 
            // selectDefaultMusicFolderToolStripMenuItem
            // 
            this.selectDefaultMusicFolderToolStripMenuItem.Name = "selectDefaultMusicFolderToolStripMenuItem";
            this.selectDefaultMusicFolderToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.selectDefaultMusicFolderToolStripMenuItem.Text = "选择默认音乐文件夹";
            this.selectDefaultMusicFolderToolStripMenuItem.Click += new System.EventHandler(this.selectDefaultMusicFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(254, 6);
            // 
            // 设置当前目录为默认路径ToolStripMenuItem
            // 
            this.设置当前目录为默认路径ToolStripMenuItem.Name = "设置当前目录为默认路径ToolStripMenuItem";
            this.设置当前目录为默认路径ToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.设置当前目录为默认路径ToolStripMenuItem.Text = "设置当前目录为默认路径";
            this.设置当前目录为默认路径ToolStripMenuItem.Click += new System.EventHandler(this.设置当前目录为默认路径ToolStripMenuItem_Click);
            // 
            // advanceToolStripMenuItem
            // 
            this.advanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findAllNcmsInTheChildFoldersToolStripMenuItem,
            this.switchConsoleToolStripMenuItem});
            this.advanceToolStripMenuItem.Name = "advanceToolStripMenuItem";
            this.advanceToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.advanceToolStripMenuItem.Text = "高级";
            // 
            // findAllNcmsInTheChildFoldersToolStripMenuItem
            // 
            this.findAllNcmsInTheChildFoldersToolStripMenuItem.Name = "findAllNcmsInTheChildFoldersToolStripMenuItem";
            this.findAllNcmsInTheChildFoldersToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.findAllNcmsInTheChildFoldersToolStripMenuItem.Text = "遍历子文件夹搜索NCM文件";
            this.findAllNcmsInTheChildFoldersToolStripMenuItem.Click += new System.EventHandler(this.findAllNcmsInTheChildFoldersToolStripMenuItem_Click);
            // 
            // switchConsoleToolStripMenuItem
            // 
            this.switchConsoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开ToolStripMenuItem,
            this.关ToolStripMenuItem});
            this.switchConsoleToolStripMenuItem.Name = "switchConsoleToolStripMenuItem";
            this.switchConsoleToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.switchConsoleToolStripMenuItem.Text = "控制台显示";
            // 
            // 开ToolStripMenuItem
            // 
            this.开ToolStripMenuItem.Name = "开ToolStripMenuItem";
            this.开ToolStripMenuItem.Size = new System.Drawing.Size(107, 26);
            this.开ToolStripMenuItem.Text = "开";
            this.开ToolStripMenuItem.Click += new System.EventHandler(this.consoleOnToolStripMenuItem_Click);
            // 
            // 关ToolStripMenuItem
            // 
            this.关ToolStripMenuItem.Name = "关ToolStripMenuItem";
            this.关ToolStripMenuItem.Size = new System.Drawing.Size(107, 26);
            this.关ToolStripMenuItem.Text = "关";
            this.关ToolStripMenuItem.Click += new System.EventHandler(this.consoleOffToolStripMenuItem_Click);
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(138, 4);
            this.tb_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(482, 25);
            this.tb_path.TabIndex = 3;
            this.tb_path.Text = "%HOMEPATH%\\Music";
            this.tb_path.TextChanged += new System.EventHandler(this.tb_path_TextChanged);
            this.tb_path.DoubleClick += new System.EventHandler(this.tb_path_DoubleClick);
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(626, 0);
            this.bt_refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(205, 29);
            this.bt_refresh.TabIndex = 4;
            this.bt_refresh.Text = "搜索当前目录NCM文件";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lb_ncms, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bt_conversion, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cb_ifDoDelete, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 425);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lb_ncms
            // 
            this.lb_ncms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_ncms.FormattingEnabled = true;
            this.lb_ncms.ItemHeight = 15;
            this.lb_ncms.Location = new System.Drawing.Point(3, 2);
            this.lb_ncms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_ncms.Name = "lb_ncms";
            this.lb_ncms.Size = new System.Drawing.Size(828, 358);
            this.lb_ncms.TabIndex = 3;
            // 
            // bt_conversion
            // 
            this.bt_conversion.Location = new System.Drawing.Point(3, 387);
            this.bt_conversion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_conversion.Name = "bt_conversion";
            this.bt_conversion.Size = new System.Drawing.Size(828, 36);
            this.bt_conversion.TabIndex = 7;
            this.bt_conversion.Text = "开始转换";
            this.bt_conversion.UseVisualStyleBackColor = true;
            this.bt_conversion.Click += new System.EventHandler(this.bt_conversion_Click_1);
            // 
            // cb_ifDoDelete
            // 
            this.cb_ifDoDelete.AutoSize = true;
            this.cb_ifDoDelete.Checked = true;
            this.cb_ifDoDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ifDoDelete.Location = new System.Drawing.Point(3, 364);
            this.cb_ifDoDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_ifDoDelete.Name = "cb_ifDoDelete";
            this.cb_ifDoDelete.Size = new System.Drawing.Size(158, 19);
            this.cb_ifDoDelete.TabIndex = 6;
            this.cb_ifDoDelete.Text = "转换后删除NCM文件";
            this.cb_ifDoDelete.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuck off ncms! by cyf";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectFolderToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lb_ncms;
        private System.Windows.Forms.CheckBox cb_ifDoDelete;
        private System.Windows.Forms.Button bt_conversion;
        private System.Windows.Forms.ToolStripMenuItem advanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAllNcmsInTheChildFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDefaultMusicFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 设置当前目录为默认路径ToolStripMenuItem;
        private System.Windows.Forms.ToolTip tt_path;
        private System.Windows.Forms.ToolStripMenuItem switchConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关ToolStripMenuItem;
    }
}

