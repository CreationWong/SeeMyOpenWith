using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Serilog;

namespace SeeMyOpenWith
{
    public partial class Form : System.Windows.Forms.Form
    {
        public string RegPath = @"HKEY_CLASSES_ROOT\Applications";

        public Form()
        {
            Log.Information("Form 已打开");
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);

            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
#if DEBUG
                Log.Debug("Form 标题添加管理员后缀");
#endif
                this.Text = "See My Open With - Administrator";
            }

            // 调用 PopulateApplicationsListView 方法填充 ListView
            Log.Information("开始填充列表");
            PopulateApplicationsListView(listViewReg);
        }
        
        private void toolStripMenuItemSearch_Click(object sender, EventArgs e)
        {
#if DEBUG
            Log.Debug("toolStripMenuItemSearch_Click 触发");
#endif
            Log.Information("用户单击搜索");
            
            // 获取选中项的应用程序名称
            if (GetAppName() == null)
            {
                return;
            }
            
            string appName = GetAppName();
            
            WebSearch(appName);
        }
        
        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
#if DEBUG
            Log.Debug("toolStripMenuItemDel_Click 触发");
#endif
            Log.Information("用户单击删除");

            // 获取选中项的应用程序名称
            if (GetAppName() == null)
            {
                return;
            }
            
            string appName = GetAppName();
            
            // 询问用户是否确认删除
            DialogResult result = MessageBox.Show(
                $"确定要删除注册表中的应用程序 '{appName}' 吗？此操作不可恢复！",
                "确认删除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
            {
                Log.Information("用户取消删除操作");
                return;
            }

            try
            {
                // 构造注册表路径
                string regPath = @"Applications\" + appName;

                // 打开 HKEY_CLASSES_ROOT 并尝试删除子项
                using (RegistryKey appsKey = Registry.ClassesRoot.OpenSubKey("Applications", true)) // true 表示可写
                {
                    if (appsKey == null)
                    {
                        Log.Warning("注册表路径 {RegPath} 不存在", RegPath);
                        MessageBox.Show("未找到 Applications 注册表项", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 检查目标子项是否存在
                    string[] subKeys = appsKey.GetSubKeyNames();
                    if (!subKeys.Contains(appName))
                    {
                        Log.Warning($"注册表项 {appName} 不存在");
                        MessageBox.Show($"未找到应用程序 {appName} 的注册表项", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 删除注册表项
                    appsKey.DeleteSubKeyTree(appName); // 递归删除整个子项
                    Log.Information($"已删除注册表项: {RegPath}\\{appName}", RegPath);

                    // 从 ListView 中移除该项
                    listViewReg.SelectedItems[0].Remove();

                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
#if DEBUG
            catch (UnauthorizedAccessException ex)
            {
                Log.Error($"权限不足，无法删除注册表项: {ex.Message}");
                MessageBox.Show("删除失败：权限不足！请以管理员身份运行程序。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
            catch (Exception ex)
            {
                Log.Error($"删除注册表项时出错: {ex.Message}");
                MessageBox.Show($"删除失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// 初始化 ListView 
        /// </summary>
        /// <param name="listView">name</param>
        private void PopulateApplicationsListView(ListView listView)
        {
            try
            {
#if DEBUG
                Log.Debug("初始化 ListView ");
#else
                Log.Information("初始化列表内容");
#endif
                listView.Items.Clear();

                Log.Information("开始读取注册表 {RegPath}", RegPath);
                using (RegistryKey applicationsKey = Registry.ClassesRoot.OpenSubKey("Applications"))
                {
                    if (applicationsKey != null)
                    {
                        string[] appNames = applicationsKey.GetSubKeyNames();
                        Log.Information("找到 {Count} 个应用程序注册项", appNames.Length);

                        foreach (string appName in appNames)
                        {
                            try
                            {
                                string explain = GetOpenDescription(applicationsKey, appName);
                                string command = GetOpenCommand(applicationsKey, appName);

                                ListViewItem item = new ListViewItem(appName);
                                item.SubItems.Add(explain);
                                item.SubItems.Add(command);

                                listView.Items.Add(item);
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex, "处理应用程序 {AppName} 时出错", appName);
                            }
                        }
                    }
                    else
                    {
                        Log.Warning("无法访问 {RegPath}", RegPath);
                    }
                }
                Log.Information("ListView填充完成，共 {Count} 条记录", listView.Items.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "填充ListView时发生错误");
                throw;
            }
        }

        private string GetOpenDescription(RegistryKey applicationsKey, string appName)
        {
            try
            {
                using (RegistryKey appKey = applicationsKey.OpenSubKey(appName))
                using (RegistryKey shellKey = appKey?.OpenSubKey("shell"))
                using (RegistryKey openKey = shellKey?.OpenSubKey("open"))
                {
                    string friendlyName = openKey?.GetValue("FriendlyAppName")?.ToString();
                    if (!string.IsNullOrEmpty(friendlyName))
                    {
#if DEBUG
                        Log.Debug("应用程序 {AppName} 找到 FriendlyAppName: {FriendlyName}", appName, friendlyName);
#endif
                        return friendlyName;
                    }

                    string defaultValue = openKey?.GetValue("")?.ToString() ?? "无";
#if DEBUG
                    Log.Debug("应用程序 {AppName} 使用默认描述: {Description}", appName, defaultValue);
#endif
                    return defaultValue;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "获取应用程序 {AppName} 描述时出错", appName);
                return "Error reading description";
            }
        }

        private string GetOpenCommand(RegistryKey applicationsKey, string appName)
        {
            // 获取 Applications\程序名\shell\open\command 的值
            using (RegistryKey appKey = applicationsKey.OpenSubKey(appName))
            using (RegistryKey shellKey = appKey?.OpenSubKey("shell"))
            using (RegistryKey openKey = shellKey?.OpenSubKey("open"))
            using (RegistryKey commandKey = openKey?.OpenSubKey("command"))
            {
                return commandKey?.GetValue("")?.ToString() ?? "无";
            }
        }
        
        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <returns>string || Null</returns>
        private string GetAppName()
        {
#if DEBUG
            Log.Debug("GetAppName() 触发");   
#endif
            // 检查是否有选中的项
            if (listViewReg.SelectedItems.Count == 0)
            {
                Log.Warning("未选中任何项目");
                MessageBox.Show("请先选择一个应用程序", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            
            // 返回选中项的应用程序名称
            
            return listViewReg.SelectedItems[0].Text;
        }

        /// <summary>
        /// 调用搜索引擎搜索应用名
        /// </summary>
        /// <param name="appName">应用程序名</param>
        /// <param name="search">(可选)默认必应- 搜索引擎 URL </param>
        private void WebSearch(string appName,string search = "www.bing.com/search?q=")
        {
            Log.Information($"WebSearch(\"{appName}\", \"{search}\")");
            
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = $"https://{search}{appName}",
            };
            Process.Start(processStartInfo);
        }
    }
}
