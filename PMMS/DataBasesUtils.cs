using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace PMMS
{
    public class DataBasesUtils
    {
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="dbFile">需要备份的数据库文件</param>
        /// <param name="backupPath">备份文件</param>
        public static void Backup(string dbFile, string backupFile)
        {
            File.Copy(dbFile, backupFile, true);
        }

        public static void Restore(string dbFile, string restoreFile)
        {
            File.Copy(restoreFile, dbFile, true);
        }


        private static void ExecuteCmd(string command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.StandardInput.WriteLine("D:");
            p.StandardInput.WriteLine("cd D:\\htk0");
            p.StandardInput.WriteLine(command);

            //p.StandardInput.WriteLine(@"net use \\192.168.1.14\mfgdata 68800er /user:cyap@ntuni.com");
            p.StandardInput.WriteLine("exit");
            p.WaitForExit();
            p.Close();
        }
    }
}
