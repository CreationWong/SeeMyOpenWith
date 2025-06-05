using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Serilog;

namespace SeeMyOpenWith.module;

public class ListViewDispose
{
    private const string RegPath = "HKEY_CLASSES_ROOT\\Applications";
    
    private readonly ListView listView;

    public ListViewDispose(ListView listView)
    {
        this.listView = listView;
    }
    
    /// <summary>
    ///     初始化 ListView
    /// </summary>
    /// <param name="listView">name</param>
    public void PopulateApplicationsListView()
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

                    foreach (var appName in appNames)
                        try
                        {
                            var friendlyName = GetFriendlyAppName(applicationsKey, appName);
                            var explain = GetOpenDescription(applicationsKey, appName);
                            var command = GetOpenCommand(applicationsKey, appName);

                            var item = new ListViewItem(appName);
                            item.SubItems.Add(friendlyName); // 添加友好名称
                            item.SubItems.Add(explain);
                            item.SubItems.Add(command);

                            listView.Items.Add(item);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "处理应用程序 {AppName} 时出错", appName);
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
                string defaultValue = openKey?.GetValue("")?.ToString();
                if (!string.IsNullOrEmpty(defaultValue))
                {
#if DEBUG
                    Log.Debug("应用程序 {AppName} 使用默认描述: {DefaultValue}", appName, defaultValue);
#endif
                    return defaultValue;
                }
#if DEBUG
                Log.Debug("应用程序 {AppName} 无描述", appName);
#endif
                return "无描述";
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
            return commandKey?.GetValue("")?.ToString() ?? "NULL";
        }
    }

    private string GetFriendlyAppName(RegistryKey applicationsKey, string appName)
    {
        try
        {
            using (RegistryKey appKey = applicationsKey.OpenSubKey(appName))
            {
                string friendlyName = appKey?.GetValue("FriendlyAppName")?.ToString();
                if (!string.IsNullOrEmpty(friendlyName))
                {
#if DEBUG
                    Log.Debug("{AppName} 友好名称: {friendlyName}", appName, friendlyName);
#endif
                    return friendlyName;
                }

                return "无名称";
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "获取应用程序 {AppName} 的名称时出错", appName);
            return appName;
        }
    }
    
    
    /// <summary>
    ///     获取选中项
    /// </summary>
    /// <returns>string || Null</returns>
    public string GetAppName()
    {
        // 检查是否有选中的项
        if (listView.SelectedItems.Count == 0)
        {
            MessageBox.Show("请先选择一个应用程序", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        // 返回选中项的应用程序名称
        return listView.SelectedItems[0].Text;
    }
}