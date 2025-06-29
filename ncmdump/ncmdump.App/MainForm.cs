using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniFile;


namespace ncmdump.App {
    public partial class MainForm : Form {

        string mNcmDumpPath = "";
        FileInfo[] ncms = null;
        IniFile.Ini ini = null;
        public MainForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void selectFolderToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            changedNcmPath(folderBrowserDialog.SelectedPath);
        }

        private void changedNcmPath( string path, bool mute = false )
        {
            if (!string.IsNullOrEmpty( path ) || !Directory.Exists( path ))
            {
                RefreshNcms( path, mute );
            }
        }

        private void LoadIni()
        {
            if ( !System.IO.File.Exists( iniFilePath ) )
            {
                System.IO.File.Create( iniFilePath );
            }
            ini = new Ini( iniFilePath );
        }

        private string getDefaultNcmPath()
        {
            var defaultNcmPath = ini["Configs"]?["Default Path"].ToString();
            if ( !Directory.Exists( defaultNcmPath ) || defaultNcmPath == null )
            {
                return Environment.GetFolderPath( Environment.SpecialFolder.MyMusic );
            }
            return defaultNcmPath;
        }

        public string iniFilePath { get{ return Path.Combine( Path.GetDirectoryName( Process.GetCurrentProcess().MainModule.FileName ), "ncmdumphelper.ini" ); } }

        private void MainForm_Load( Object sender, EventArgs e )
        {
            LoadIni();
            mNcmDumpPath = Path.Combine( Application.StartupPath, "main.exe" );
            if( !System.IO.File.Exists( mNcmDumpPath ) ) {
                MessageBox.Show( "ncmdump does not fould.\nPlease put main.exe at root of application of ncmdump.App", "Error" );
                System.Diagnostics.Process.Start( "https://github.com/taurusxin/ncmdump/releases/tag/1.5.0" );
            }
            tb_path.Text = getDefaultNcmPath();
            findAllNcmsInFolderRecursion();
        }
        private void RefreshNcms( string path, bool mute = false )
        {
            if( !Directory.Exists( path ) ) {
                if (!mute) { MessageBox.Show(string.Format("[{0}] 路径不存在", path),"Error"); }
                return;
            }
            tb_path.Text = path;
            DirectoryInfo directoryInfo = new DirectoryInfo( path );
            var ncmFiles = directoryInfo.GetFiles("*.ncm");
            if( ncmFiles.Length == 0 ) {
                if (!mute)
                {  MessageBox.Show( "该文件夹没有ncm文件" ); }
                return;
            }
            lb_ncms.DataSource = ncmFiles;
            Text = string.Format( "在路径 [{1}] 中找到了 ({0}) 个ncm文件", ncmFiles.Length, path );
        }

        private void ConversionNcms()
        {
            var ncms = lb_ncms.DataSource as FileInfo[];
            if( ncms == null ) {
                MessageBox.Show( string.Format( "ncms do not exsit" ), "Error" );
                return;
            }
            if( ncms.Length == 0 ) {
                MessageBox.Show( string.Format( "no ncm exsits" ), "Error" );
                return;
            }

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Enabled = false;
            int i = 0;
            foreach( var ncm in ncms ) {
                ++i;
                Text = string.Format( "{1}/{2} Processing [{0}] ", ncm.Name, i, ncms.Length );
                string cmd = string.Format( "/C {0} \"{1}\"", mNcmDumpPath, ncm.FullName );

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "CMD.exe";
                startInfo.Arguments = cmd;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                if( cb_ifDoDelete.Checked ) {
                    System.IO.File.Delete( ncm.FullName );
                }
            }
            this.Enabled = true;
            Text = "Finished";
        }

        private void bt_refresh_Click( Object sender, EventArgs e )
        {
            RefreshNcms( tb_path.Text );
        }

        private void backgroundWorker1_DoWork( Object sender, DoWorkEventArgs e )
        {

        }

        private void bt_conversion_Click_1( Object sender, EventArgs e )
        {
            RefreshNcms( tb_path.Text );
            ConversionNcms();
        }

        private void findAllNcmsInTheChildFoldersToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            findAllNcmsInFolderRecursion();
        }

        private void findAllNcmsInFolderRecursion()
        {
            var files = GetAllNcmFiles( new DirectoryInfo( tb_path.Text ) );
            lb_ncms.DataSource = files;
            if (files == null)
            {
                return;
            }
            this.Text = string.Format( "在路径 [{1}] 中找到了 ({0}) 个ncm文件 [已遍历子文件夹]", files.Length, tb_path.Text );
        }

        public static FileInfo[] GetAllNcmFiles( DirectoryInfo dir )
        {
            if (!dir.Exists)
            {
                return null;
            }
            List<FileInfo> fileInfos = new List<FileInfo>(dir.GetFiles("*.ncm"));
            DirectoryInfo[] allDir= dir.GetDirectories();
            foreach( DirectoryInfo d in allDir ) {
                fileInfos.AddRange( GetAllNcmFiles( d ) );
            }
            return fileInfos.ToArray();
        }

        private void selectDefaultMusicFolderToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            tb_path.Text = getDefaultNcmPath();
        }

        private void 设置当前目录为默认路径ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var ini = new Ini
            {
                new Section("Configs")
                {
                    ["Default Path"] = tb_path.Text,
                }
            };
            ini.SaveTo( iniFilePath );
        }

        private void tb_path_TextChanged( object sender, EventArgs e )
        {
            changedNcmPath( tb_path.Text, true );
        }
    }
}
