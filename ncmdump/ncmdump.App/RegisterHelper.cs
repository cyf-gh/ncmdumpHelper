using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncmdump.App
{
    public static class RegistryHelper
    {
        // 定义注册表路径和键名
        private const string RegistryKeyPath = "HKEY_CURRENT_USER\\Software\\Lod\\NcmdumpHelper";
        private const string ConsoleSettingKey = "ShowConsole";

        /// <summary>
        /// 从注册表读取控制台显示设置。
        /// 如果键不存在，则返回默认值 false。
        /// </summary>
        /// <returns>如果控制台应该显示则为 true，否则为 false。</returns>
        public static bool GetConsoleSetting()
        {
            try
            {
                // 使用 OpenSubKey 而不是 GetValue，因为 GetValue 会直接尝试访问整个路径，
                // 而 OpenSubKey 可以更安全地处理子键不存在的情况。
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey( "Software\\Lod\\NcmdumpHelper" ))
                {
                    if (key != null)
                    {
                        object value = key.GetValue( ConsoleSettingKey );
                        if (value != null && value is int intValue)
                        {
                            return intValue == 1;
                        }
                    }
                }
            } catch (Exception ex)
            {
                // 捕获可能发生的注册表访问错误
                Console.WriteLine( $"读取注册表错误: {ex.Message}" );
            }
            return false; // 默认不显示控制台
        }

        /// <summary>
        /// 将控制台显示设置写入注册表。
        /// </summary>
        /// <param name="showConsole">是否显示控制台。</param>
        public static void SetConsoleSetting( bool showConsole )
        {
            try
            {
                // 使用 CreateSubKey 确保子键存在，如果不存在则创建
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey( "Software\\Lod\\NcmdumpHelper" ))
                {
                    if (key != null)
                    {
                        key.SetValue( ConsoleSettingKey, showConsole ? 1 : 0, RegistryValueKind.DWord );
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine( $"写入注册表错误: {ex.Message}" );
            }
        }
    }
}
