using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;
using SeeMyOpenWith.module;
using Serilog;

namespace SeeMyOpenWith;

public partial class Main : Form
{
    // 类声明
    RegIO _regIo = new RegIO();

    public Main()
    {
        Log.Information("Main 已打开");
        InitializeComponent();
    }

    private void Form_Load(object sender, EventArgs e)
    {
        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);

        if (principal.IsInRole(WindowsBuiltInRole.Administrator))
        {
#if DEBUG
            Log.Debug("Main 标题添加调试后缀");
            Text = "See My Open With - Debug \t 开发模式! 请不要在正式环境使用!!";
#else
            Text = "See My Open With - Administrator";
#endif           
        }

        Log.Information("开始填充列表");
        FefreshListView();
    }

    private void ToolStripMenuItemFlush_Click(object sender, EventArgs e)
    {
#if DEBUG
        Log.Debug("ToolStripMenuItemFlush_Click 触发");
#endif
        Log.Information("用户单击刷新");
        FefreshListView();
    }
    private void listViewReg_KeyDown(object sender, KeyEventArgs e)
    {
        var listViewDispose = new ListViewDispose(listViewReg);

        // 获取选中项的应用程序名称 存储为 appName
        var appName = listViewDispose.GetAppName();
        if (appName == null) return;

        // F5 刷新
        if (e.KeyCode == Keys.F5)
        {
            Log.Information("用户按下 F5 刷新");
            FefreshListView();
        }

        // Del 删除
        if (e.KeyCode == Keys.Delete)
        {
            if (MessageBoxDel(appName))
            {
                _regIo.DeleteRegistryApp(appName);

                Log.Information("开始刷新列表");
                FefreshListView();
            }
        }
    }

    private void ToolStripMenuItemSearch_Click(object sender, EventArgs e)
    {
#if DEBUG
        Log.Debug("ToolStripMenuItemSearch_Click 触发");
#endif
        Log.Information("用户单击搜索");

        var listViewDispose = new ListViewDispose(listViewReg);
        // 获取选中项的应用程序名称
        var appName = listViewDispose.GetAppName();

        if (appName == null) return;

        WebSearch(appName);
    }

    private void ToolStripMenuItemRevise_Click(object sender, EventArgs e)
    {
#if DEBUG
        Log.Debug("ToolStripMenuItemRevise_Click 触发");
#endif
        Log.Information("用户单击修改");

        MessageBox.Show("功能开发中...", ":(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
    {
#if DEBUG
        Log.Debug("ToolStripMenuItemDel_Click 触发");
#endif
        Log.Information("用户单击删除");
        var listViewDispose = new ListViewDispose(listViewReg);
        var appName = listViewDispose.GetAppName();
        if (appName == null) return;

        if (MessageBoxDel(appName))
        {
            _regIo.DeleteRegistryApp(appName);

            Log.Information("开始刷新列表");
            FefreshListView();
        }
    }
    
    private void buttonOpenLog_Click(object sender, EventArgs e)
    {
#if DEBUG
        Log.Debug("buttonOpenLog_Click 触发");
#endif
        var processStartInfo = new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = ".\\logs"
        };
        Process.Start(processStartInfo);
    }

    private void FefreshListView()
    {
        var listViewDispose = new ListViewDispose(listViewReg);
        listViewDispose.PopulateApplicationsListView();
    }

    /// <summary>
    /// 显示删除提醒弹窗
    /// </summary>
    /// <param name="appName">显示应用名称</param>
    /// <returns>bool</returns>
    private bool MessageBoxDel(string appName)
    {
        // 询问用户是否确认删除
        var result = MessageBox.Show(
            $"确定要删除注册表中的应用程序 '{appName}' 吗？此操作不可恢复！",
            "确认删除",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.No)
        {
            Log.Information("用户取消删除操作");
            return false;
        }

        return true;
    }

    /// <summary>
    ///     调用搜索引擎搜索应用名
    /// </summary>
    /// <param name="appName">应用程序名</param>
    /// <param name="search">(可选)默认必应- 搜索引擎 URL </param>
    private void WebSearch(string appName, string search = "www.bing.com/search?q=")
    {
        Log.Information($"WebSearch(\"{appName}\", \"{search}\")");

        var processStartInfo = new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = $"https://{search}{appName}"
        };
        Process.Start(processStartInfo);
    }
}