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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_ncms = new System.Windows.Forms.ListBox();
            this.cb_ifDoDelete = new System.Windows.Forms.CheckBox();
            this.bt_conversion = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.advanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAllNcmsInTheChildFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDefaultMusicFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.advanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolderToolStripMenuItem,
            this.selectDefaultMusicFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectFolderToolStripMenuItem
            // 
            this.selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
            this.selectFolderToolStripMenuItem.Size = new System.Drawing.Size(328, 34);
            this.selectFolderToolStripMenuItem.Text = "Select Folder";
            this.selectFolderToolStripMenuItem.Click += new System.EventHandler(this.selectFolderToolStripMenuItem_Click);
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(158, 5);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(539, 28);
            this.tb_path.TabIndex = 3;
            this.tb_path.Text = "%HOMEPATH%\\Music";
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(701, 5);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(234, 28);
            this.bt_refresh.TabIndex = 4;
            this.bt_refresh.Text = "Find in current folder";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lb_ncms, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cb_ifDoDelete, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.bt_conversion, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(938, 511);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lb_ncms
            // 
            this.lb_ncms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_ncms.FormattingEnabled = true;
            this.lb_ncms.ItemHeight = 18;
            this.lb_ncms.Location = new System.Drawing.Point(3, 3);
            this.lb_ncms.Name = "lb_ncms";
            this.lb_ncms.Size = new System.Drawing.Size(932, 429);
            this.lb_ncms.TabIndex = 3;
            // 
            // cb_ifDoDelete
            // 
            this.cb_ifDoDelete.AutoSize = true;
            this.cb_ifDoDelete.Checked = true;
            this.cb_ifDoDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ifDoDelete.Location = new System.Drawing.Point(3, 438);
            this.cb_ifDoDelete.Name = "cb_ifDoDelete";
            this.cb_ifDoDelete.Size = new System.Drawing.Size(331, 22);
            this.cb_ifDoDelete.TabIndex = 6;
            this.cb_ifDoDelete.Text = "Delete ncm files after conversion";
            this.cb_ifDoDelete.UseVisualStyleBackColor = true;
            // 
            // bt_conversion
            // 
            this.bt_conversion.Location = new System.Drawing.Point(3, 466);
            this.bt_conversion.Name = "bt_conversion";
            this.bt_conversion.Size = new System.Drawing.Size(252, 32);
            this.bt_conversion.TabIndex = 7;
            this.bt_conversion.Text = "Start Conversion";
            this.bt_conversion.UseVisualStyleBackColor = true;
            this.bt_conversion.Click += new System.EventHandler(this.bt_conversion_Click_1);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // advanceToolStripMenuItem
            // 
            this.advanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findAllNcmsInTheChildFoldersToolStripMenuItem});
            this.advanceToolStripMenuItem.Name = "advanceToolStripMenuItem";
            this.advanceToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.advanceToolStripMenuItem.Text = "Advance";
            // 
            // findAllNcmsInTheChildFoldersToolStripMenuItem
            // 
            this.findAllNcmsInTheChildFoldersToolStripMenuItem.Name = "findAllNcmsInTheChildFoldersToolStripMenuItem";
            this.findAllNcmsInTheChildFoldersToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.findAllNcmsInTheChildFoldersToolStripMenuItem.Text = "Find all ncms recusion";
            this.findAllNcmsInTheChildFoldersToolStripMenuItem.Click += new System.EventHandler(this.findAllNcmsInTheChildFoldersToolStripMenuItem_Click);
            // 
            // selectDefaultMusicFolderToolStripMenuItem
            // 
            this.selectDefaultMusicFolderToolStripMenuItem.Name = "selectDefaultMusicFolderToolStripMenuItem";
            this.selectDefaultMusicFolderToolStripMenuItem.Size = new System.Drawing.Size(328, 34);
            this.selectDefaultMusicFolderToolStripMenuItem.Text = "Select Default Music Folder";
            this.selectDefaultMusicFolderToolStripMenuItem.Click += new System.EventHandler(this.selectDefaultMusicFolderToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem advanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAllNcmsInTheChildFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDefaultMusicFolderToolStripMenuItem;
    }
}

