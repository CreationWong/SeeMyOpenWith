using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace SeeMyOpenWith
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/runLog.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            
            Log.Information("Application started");
            
            // 读取管理员标识
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);

            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                Log.Information("检测到管理员权限");
                Log.Information("正在打开窗口");
                Application.Run(new Form());
                Log.Information("窗口关闭");
                Log.Information("Application ended");
                Log.CloseAndFlush();
                return;
            }
            else
            {
                Log.Warning("程序没有以管理员权限运行");
                DialogResult result = MessageBox.Show("不是以管理员权限运行!\n是否尝试提权?", ":(",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    Log.Warning("用户拒绝提权");
                    goto End;
                }

                try
                {
                    // 提权代码
                    // CreationWong - 20250603
                    
                    Log.Information("程序尝试提权");
                    
                    ProcessStartInfo processStartInfo = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas"
                    };

                    Log.Information("启动新进程并提权");

                    Process process = Process.Start(processStartInfo);
                    
                    Application.Exit();
                }
                catch (Exception e)
                {
                    MessageBox.Show("程序内部出现错误. \n请将程序 logs 目录下文件提交给开发者", ":( 程序内部出现错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("检测到提权错误:");
                    Log.Error(e.Message);
                    goto End;
                }
                
                // to 程序结束区
                End:
                    Log.Information("Application ended");
                    Log.CloseAndFlush();
                    return;
            }
        }
    }
}
