using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Serilog;

namespace SeeMyOpenWith.module;

public class RegIO
{
    private const string RegPath = "HKEY_CLASSES_ROOT\\Applications";
    
    public void DeleteRegistryApp(string appName)
    {
        try
        {
            // 构造注册表路径
            var regPath = @"Applications\" + appName;

            // 打开 HKEY_CLASSES_ROOT 并尝试删除子项
            using (var appsKey = Registry.ClassesRoot.OpenSubKey("Applications", true))
            {
                if (appsKey == null)
                {
                    Log.Warning("注册表路径 {RegPath} 不存在", RegPath);
                    MessageBox.Show("未找到 Applications 注册表项", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 检查目标子项是否存在
                var subKeys = appsKey.GetSubKeyNames();
                if (!subKeys.Contains(appName))
                {
                    Log.Warning($"注册表项 {appName} 不存在");
                    MessageBox.Show($"未找到应用程序 {appName} 的注册表项", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 删除注册表项
                appsKey.DeleteSubKeyTree(appName);
                Log.Information($"已删除注册表项: {RegPath}\\{appName}", RegPath);

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
}