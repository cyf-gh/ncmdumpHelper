using System;
using System.Drawing; // 用于 Color
using System.Windows.Forms; // 用于 RichTextBox

namespace ncmdump.App
{
    // 定义日志级别枚举
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    /// <summary>
    /// 提供应用程序日志记录功能，将日志输出到 RichTextBox。
    /// </summary>
    public static class Log
    {
        private static RichTextBox _logRichTextBox;

        /// <summary>
        /// 初始化日志记录器，绑定到指定的 RichTextBox。
        /// 在应用程序启动时调用一次。
        /// </summary>
        /// <param name="richTextBox">用于显示日志的 RichTextBox 控件。</param>
        public static void Initialize( RichTextBox richTextBox )
        {
            _logRichTextBox = richTextBox ?? throw new ArgumentNullException( nameof( richTextBox ), "RichTextBox 不能为空。" );
            _logRichTextBox.ReadOnly = true; // 确保日志框是只读的
            _logRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical; // 确保有滚动条
        }

        /// <summary>
        /// 将消息记录到 RichTextBox 日志。
        /// </summary>
        /// <param name="message">要记录的消息。</param>
        /// <param name="level">日志级别。</param>
        public static void Message( string message, LogLevel level )
        {
            if (_logRichTextBox == null)
            {
                // 如果日志框未初始化，则退回至控制台输出或抛出异常
                Console.WriteLine( $"[LOG ERROR] RichTextBox 未初始化。消息: [{level}] {message}" );
                return;
            }

            string formattedMessage = $"[{DateTime.Now:HH:mm:ss}] [{level}] {message}{Environment.NewLine}";

            // 确保在UI线程上更新RichTextBox
            if (_logRichTextBox.InvokeRequired)
            {
                _logRichTextBox.Invoke( new Action( () => AppendLog( formattedMessage, level ) ) );
            } else
            {
                AppendLog( formattedMessage, level );
            }
        }

        /// <summary>
        /// 实际将格式化消息添加到 RichTextBox。
        /// 此方法总是在UI线程上执行。
        /// </summary>
        /// <param name="message">格式化的消息字符串。</param>
        /// <param name="level">日志级别。</param>
        private static void AppendLog( string message, LogLevel level )
        {
            // 设置文本颜色
            Color textColor;
            switch (level)
            {
                case LogLevel.Debug:
                    textColor = Color.Gray;
                    break;
                case LogLevel.Info:
                    textColor = Color.Black;
                    break;
                case LogLevel.Warning:
                    textColor = Color.OrangeRed;
                    break;
                case LogLevel.Error:
                    textColor = Color.Red;
                    break;
                default:
                    textColor = Color.Black; // 默认颜色
                    break;
            }

            _logRichTextBox.SelectionStart = _logRichTextBox.TextLength;
            _logRichTextBox.SelectionLength = 0;
            _logRichTextBox.SelectionColor = textColor;
            _logRichTextBox.AppendText( message );
            _logRichTextBox.SelectionColor = _logRichTextBox.ForeColor; // 恢复默认颜色
            _logRichTextBox.ScrollToCaret(); // 自动滚动到最新消息
        }

        // 快捷方法，方便调用
        public static void Debug( string message ) => Message( message, LogLevel.Debug );
        public static void Info( string message ) => Message( message, LogLevel.Info );
        public static void Warning( string message ) => Message( message, LogLevel.Warning );
        public static void Error( string message ) => Message( message, LogLevel.Error );
    }
}