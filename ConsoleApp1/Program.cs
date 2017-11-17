using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static SerialPort sPort = new SerialPort();
        public static void Main(string[] args)
        {
            LookAndStop(1536);
            string str = "昆明达睿科技有限责任公司";
            int sl = str.Length;
            string sss = "昆明达睿科技";
            int el = sss.Length;

            var t = str.Substring(1,2);

            Program p = new Program();
            sPort.Open();
            sPort.Write(str);
            byte[] by = new byte[1];
            
            //sPort.Read(sPort., 1, sPort.BytesToRead);
            //p.LookAndStop(Convert.ToInt32("1001"));

            //FileStream fs = new FileStream("testKillProcess.txt", FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);
            //foreach (string str in args)
            //{
            //    //开始写入
            //    //sw.WriteLine(str);
            //    p.LookAndStop(Convert.ToInt32(str));
            //}
            //清空缓冲区
            // sw.Flush();
            //关闭流
            // sw.Close();
            //fs.Close();

            Console.ReadLine();

        }
        //根据端口号，查找该端口所在的进程，并结束该进程
        public static void LookAndStop(int port)
        {
            Process pro = new Process();
            // 设置命令行、参数    
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.CreateNoWindow = true;
            // 启动CMD    
            pro.Start();
            // 运行端口检查命令    
            pro.StandardInput.WriteLine("netstat -ano");
            pro.StandardInput.WriteLine("exit");
            // 获取结果    
            Regex reg = new Regex("\\s+", RegexOptions.Compiled);
            string line = null;
            string endStr = ":" + Convert.ToString(port);
            while ((line = pro.StandardOutput.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith("TCP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr[1].EndsWith(endStr))
                    {
                        Console.WriteLine(port+"端口的进程ID：{0}", arr[4]);
                        int pid = Int32.Parse(arr[4]);
                        Process pro80 = Process.GetProcessById(pid);
                        // 处理该进程
                        pro80.Kill();
                        break;
                    }
                }
                else if (line.StartsWith("UDP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr[1].EndsWith(endStr))
                    {
                        Console.WriteLine(port + "端口的进程ID：{0}", arr[3]);
                        int pid = Int32.Parse(arr[3]);
                        Process pro80 = Process.GetProcessById(pid);
                        // 处理该进程
                        pro80.Kill();
                        break;
                    }
                }
            }
            pro.Close();
        }
    }
}
