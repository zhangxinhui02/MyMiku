using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace 我的Miku.工具
{
    public static class 加速
    {
        [DllImport("psapi.dll")]

        static extern int EmptyWorkingSet(IntPtr hwProc);

        
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                //以下系统进程没有权限，所以跳过，防止出错影响效率。
                if ((process.ProcessName == "System") && (process.ProcessName == "Idle"))
                    continue;
                try
                {
                    EmptyWorkingSet(process.Handle);
                }
                catch
                {
                }
            }
        }



    }
}
