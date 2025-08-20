using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;

using IniFile;

namespace ncmdump.App
{
    public partial class MainForm : Form
    {
        // 常量定义，避免硬编码字符串
        private const string AppName = "ncmdump.App";
        private const string IniFileName = "ncmdumphelper.ini";
        private const string NcmDumpExecutableName = "main.exe";
        private const string IniSectionConfigs = "Configs";
        private const string IniKeyDefaultPath = "Default Path";
        private const string NcmFileExtension = "*.ncm";

        private string mNcmDumpPath = "";
        private Ini ini; // 不再初始化为null，而是在LoadIni中初始化

        public MainForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        // 属性：更简洁地获取INI文件路径
        public string IniFilePath => Path.Combine( AppDomain.CurrentDomain.BaseDirectory, IniFileName );

        private void MainForm_Load( Object sender, EventArgs e )
        {
            LoadIni(); // 初始化INI文件
            InitializeConsoleVisibility(); // 根据注册表设置控制台显示
            SetupToolTips(); // 设置ToolTip
            CheckNcmDumpExecutable(); // 检查ncmdump.exe是否存在

            tb_path.Text = GetDefaultNcmPath(); // 加载默认路径
            FindAllNcmsInFolderRecursion(); // 首次加载时查找所有NCM文件
        }

        /// <summary>
        /// 初始化INI文件对象。如果文件不存在则创建。
        /// </summary>
        private void LoadIni()
        {
            if (!File.Exists( IniFilePath ))
            {
                try
                {
                    File.Create( IniFilePath ).Dispose(); // 使用Dispose确保文件句柄释放
                } catch (Exception ex)
                {
                    MessageBox.Show( $"无法创建INI文件: {ex.Message}", "文件错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    // 考虑退出应用程序或禁用相关功能
                }
            }
            ini = new Ini( IniFilePath );
        }

        /// <summary>
        /// 根据注册表设置控制台的初始可见性。
        /// </summary>
        private void InitializeConsoleVisibility()
        {
            bool showConsole = RegistryHelper.GetConsoleSetting();
            if (showConsole)
            {
                ConsoleHelper.ShowConsole();
                Console.WriteLine( "控制台已显示。" );
            } else
            {
                ConsoleHelper.HideConsole();
            }
        }

        /// <summary>
        /// 设置控件的ToolTip。
        /// </summary>
        private void SetupToolTips()
        {
            tt_path.SetToolTip( tb_path, "双击打开目录" );
        }

        /// <summary>
        /// 检查ncmdump可执行文件是否存在，如果不存在则提示并打开下载页面。
        /// </summary>
        private void CheckNcmDumpExecutable()
        {
            mNcmDumpPath = Path.Combine( Application.StartupPath, NcmDumpExecutableName );
            if (!File.Exists( mNcmDumpPath ))
            {
                MessageBox.Show( "ncmdump 未找到。\n请将 main.exe 放到 ncmdump.App 应用程序的根目录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                try
                {
                    Process.Start( "https://github.com/taurusxin/ncmdump/releases/tag/1.5.0" );
                } catch (Exception ex)
                {
                    MessageBox.Show( $"无法打开下载链接: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        /// <summary>
        /// 从INI文件获取默认的NCM路径。如果路径不存在或无效，则返回我的音乐文件夹。
        /// </summary>
        /// <returns>默认的NCM路径。</returns>
        private string GetDefaultNcmPath()
        {
            string defaultNcmPath = ini[IniSectionConfigs]?[IniKeyDefaultPath].ToString();
            if (string.IsNullOrWhiteSpace( defaultNcmPath ) || !Directory.Exists( defaultNcmPath ))
            {
                return Environment.GetFolderPath( Environment.SpecialFolder.MyMusic );
            }
            return defaultNcmPath;
        }

        private void selectFolderToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    ChangedNcmPath( folderBrowserDialog.SelectedPath );
                }
            }
        }

        /// <summary>
        /// 启动一个 CMD 窗口，并将其当前目录设置为应用程序的启动目录。
        /// </summary>
        private void OpenCmdAtAppDirectory()
        {
            try
            {
                // 获取当前应用程序的启动目录
                string appDirectory = Application.StartupPath;

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    // /K 参数表示执行完命令后保持 CMD 窗口打开
                    // cd /d 表示切换目录，/d 用于切换不同驱动器的目录
                    Arguments = $"/K \"cd /d \"{appDirectory}\"\"", // CMD 窗口打开后，直接切换到应用目录
                    UseShellExecute = true, // 重要：设置为 true 才能让 CMD 拥有自己的独立窗口
                    CreateNoWindow = false, // 明确表示要创建窗口
                    WindowStyle = ProcessWindowStyle.Normal // 确保窗口正常显示
                };

                // 启动 CMD 进程
                Process.Start( startInfo );
                Log.Info( $"已在 [{appDirectory}] 目录启动 CMD 窗口。" );
                MessageBox.Show( $"已成功打开CMD窗口。\nCMD窗口的当前目录为:\n{appDirectory}\n\n您可以在其中直接运行 'main.exe'。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
            } catch (Exception ex)
            {
                Log.Error( $"启动 CMD 窗口时发生错误: {ex.Message}" );
                MessageBox.Show( $"启动 CMD 窗口时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        /// <summary>
        /// 更改NCM路径并刷新文件列表。
        /// </summary>
        /// <param name="path">新的NCM路径。</param>
        /// <param name="mute">是否静默处理，不显示错误消息框。</param>
        private void ChangedNcmPath( string path, bool mute = false )
        {
            if (string.IsNullOrWhiteSpace( path ) || !Directory.Exists( path ))
            {
                if (!mute)
                {
                    MessageBox.Show( $"[{path}] 路径不存在或无效。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                lb_ncms.DataSource = null; // 清空列表
                Text = $"{AppName}";
                return;
            }
            tb_path.Text = path;
            RefreshNcmList( path );
        }

        /// <summary>
        /// 刷新NCM文件列表。
        /// </summary>
        /// <param name="path">要扫描的路径。</param>
        private void RefreshNcmList( string path )
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo( path );
                FileInfo[] ncmFiles = directoryInfo.GetFiles( NcmFileExtension );

                if (ncmFiles.Length == 0)
                {
                    MessageBox.Show( "该文件夹没有ncm文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    lb_ncms.DataSource = null;
                } else
                {
                    lb_ncms.DataSource = ncmFiles;
                }
                UpdateFormTitle( ncmFiles.Length, path );
            } catch (Exception ex)
            {
                MessageBox.Show( $"刷新文件列表时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                lb_ncms.DataSource = null;
                Text = $"{AppName}";
            }
        }

        /// <summary>
        /// 更新窗体标题显示找到的NCM文件数量和路径。
        /// </summary>
        /// <param name="count">NCM文件数量。</param>
        /// <param name="path">当前路径。</param>
        /// <param name="recursive">是否为递归查找。</param>
        private void UpdateFormTitle( int count, string path, bool recursive = false )
        {
            string recursiveText = recursive ? " [已遍历子文件夹]" : "";
            Text = $"{AppName} - 在路径 [{path}] 中找到了 ({count}) 个ncm文件{recursiveText}";
        }

        /// <summary>
        /// 将NCM文件转换为标准音频文件。
        /// </summary>
        private async void ConvertNCMs() // 标记为异步方法
        {
            var ncms = lb_ncms.DataSource as FileInfo[];
            if (ncms == null || ncms.Length == 0)
            {
                MessageBox.Show( "没有要转换的ncm文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }

            // 禁用UI，改变鼠标光rmat( "{1}/{2} Processing [{0}] ", 标，提升用户体验
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            this.StartPosition = FormStartPosition.CenterScreen; // 保持居中

            StringBuilder overallStandardOutput = new StringBuilder();
            StringBuilder overallStandardError = new StringBuilder();

            try
            {
                for (int i = 0; i < ncms.Length; i++)
                {
                    var ncm = ncms[i];
                    UpdateFormTitle( i + 1, ncm.Name ); // 更新进度
                    Application.DoEvents(); // 强制UI更新

                    string cmdArgs = $"/C \"\"{mNcmDumpPath}\" \"{ncm.FullName}\"\"";

                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "CMD.exe",
                        Arguments = cmdArgs,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                    };

                    using (Process process = new Process { StartInfo = startInfo })
                    {
                        StringBuilder standardOutput = new StringBuilder();
                        StringBuilder standardError = new StringBuilder();

                        // 异步事件处理，避免阻塞
                        process.OutputDataReceived += ( sender, e ) =>
                        {
                            if (e.Data != null)
                            {
                                standardOutput.AppendLine( e.Data );
                            }
                        };
                        process.ErrorDataReceived += ( sender, e ) =>
                        {
                            if (e.Data != null)
                            {
                                standardError.AppendLine( e.Data );
                            }
                        };

                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();

                        await Task.Run( () => { 
                            process.WaitForExit();
                            process.CancelOutputRead();
                            process.CancelErrorRead();
                            Console.WriteLine( $"--- Processing {ncm.Name} ---" );
                            if (standardOutput.Length > 0)
                            {
                                Console.WriteLine( "Standard Output:\n" + standardOutput.ToString() );
                                overallStandardOutput.Append( standardOutput.ToString() );
                            }
                            if (standardError.Length > 0)
                            {
                                Console.WriteLine( "Standard Error:\n" + standardError.ToString() );
                                overallStandardError.Append( standardError.ToString() );
                            }
                            Console.WriteLine( $"Process exited with code: {process.ExitCode}\n" );
                        } ); 

                        if (cb_ifDoDelete.Checked)
                        {
                            try
                            {
                                File.Delete( ncm.FullName );
                            } catch (Exception ex)
                            {
                                Console.WriteLine( $"删除文件 {ncm.FullName} 失败: {ex.Message}" );
                                MessageBox.Show( $"删除文件 {ncm.FullName} 失败: {ex.Message}", "删除错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            }
                        }
                    }
                }
                MessageBox.Show( "所有NCM文件转换完成。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information );
            } catch (Exception ex)
            {
                MessageBox.Show( $"转换过程中发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Console.WriteLine( $"一个全局错误发生: {ex.Message}" );
            } finally
            {
                this.Enabled = true; // 重新启用UI
                this.Cursor = Cursors.Default; // 恢复鼠标光标
                RefreshNcmList( tb_path.Text ); // 刷新列表，显示剩余文件（如果未删除）
                UpdateFormTitle( 0, tb_path.Text ); // 恢复初始标题或显示完成
            }
        }

        private void bt_refresh_Click( Object sender, EventArgs e )
        {
            RefreshNcmList( tb_path.Text );
        }


        private void bt_conversion_Click_1( Object sender, EventArgs e )
        {
            // 在开始转换前，再次刷新文件列表以确保是最新的
            RefreshNcmList( tb_path.Text );
            ConvertNCMs(); // 调用异步方法
        }

        private void findAllNcmsInTheChildFoldersToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            FindAllNcmsInFolderRecursion();
        }

        /// <summary>
        /// 递归查找指定目录及其所有子目录中的NCM文件。
        /// </summary>
        private void FindAllNcmsInFolderRecursion()
        {
            try
            {
                DirectoryInfo currentDir = new DirectoryInfo( tb_path.Text );
                if (!currentDir.Exists)
                {
                    MessageBox.Show( $"路径 [{tb_path.Text}] 不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    lb_ncms.DataSource = null;
                    UpdateFormTitle( 0, tb_path.Text );
                    return;
                }

                FileInfo[] files = GetAllNcmFiles( currentDir );
                lb_ncms.DataSource = files;

                if (files == null || files.Length == 0)
                {
                    MessageBox.Show( "在指定路径及其子文件夹中没有找到ncm文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
                UpdateFormTitle( files?.Length ?? 0, tb_path.Text, true );
            } catch (Exception ex)
            {
                MessageBox.Show( $"递归查找NCM文件时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                lb_ncms.DataSource = null;
                UpdateFormTitle( 0, tb_path.Text );
            }
        }

        /// <summary>
        /// 递归获取指定目录下所有NCM文件。
        /// </summary>
        /// <param name="dir">起始目录。</param>
        /// <returns>所有NCM文件的FileInfo数组。</returns>
        public static FileInfo[] GetAllNcmFiles( DirectoryInfo dir )
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            if (!dir.Exists)
            {
                return fileInfos.ToArray(); // 返回空数组而不是null
            }

            try
            {
                fileInfos.AddRange( dir.GetFiles( NcmFileExtension ) );
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    // 递归调用，并处理潜在的访问拒绝错误
                    try
                    {
                        fileInfos.AddRange( GetAllNcmFiles( subDir ) );
                    } catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine( $"警告: 无权访问目录: {subDir.FullName}" );
                        // 可以选择向用户报告或记录此错误
                    }
                }
            } catch (UnauthorizedAccessException)
            {
                Console.WriteLine( $"警告: 无权访问目录: {dir.FullName}" );
                // 可以选择向用户报告或记录此错误
            } catch (Exception ex)
            {
                Console.WriteLine( $"获取文件时发生未知错误: {ex.Message} 在目录: {dir.FullName}" );
                // 记录其他类型的错误
            }

            return fileInfos.ToArray();
        }

        private void selectDefaultMusicFolderToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            tb_path.Text = Environment.GetFolderPath( Environment.SpecialFolder.MyMusic );
            ChangedNcmPath( tb_path.Text ); // 刷新列表
        }

        private void 设置当前目录为默认路径ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 直接通过 Ini 对象的索引器设置值，它会自动处理 Section 和 Key 的创建
            ini[IniSectionConfigs][IniKeyDefaultPath] = tb_path.Text;
            ini.SaveTo( IniFilePath ); // 保存到文件
            MessageBox.Show( "当前目录已设置为默认路径。", "设置成功", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void tb_path_TextChanged( object sender, EventArgs e )
        {
            // 当文本框内容改变时，静默刷新文件列表
            ChangedNcmPath( tb_path.Text, true );
        }

        private void tb_path_DoubleClick( object sender, EventArgs e )
        {
            if (Directory.Exists( tb_path.Text ))
            {
                try
                {
                    Process.Start( tb_path.Text );
                } catch (Exception ex)
                {
                    MessageBox.Show( $"无法打开目录: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            } else
            {
                MessageBox.Show( $"路径 [{tb_path.Text}] 不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void consoleOnToolStripMenuItem_Click( object sender, EventArgs e )
        {
            RegistryHelper.SetConsoleSetting( true );
            ConsoleHelper.ShowConsole();
            Console.WriteLine( "控制台已显示。" );
        }

        private void consoleOffToolStripMenuItem_Click( object sender, EventArgs e )
        {
            RegistryHelper.SetConsoleSetting( false );
            ConsoleHelper.HideConsole();
            Console.WriteLine( "控制台已隐藏。" ); // 这条消息可能不会被看到，因为控制台可能已经隐藏
        }

        private void ncmdumpToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenCmdAtAppDirectory();
        }
    }
}