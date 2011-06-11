using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PMMS.DataBasesBackup
{
    class DateCommon
    {
        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <param name="backup_Path">需要备份的文件名（完整路径）</param>
        /// <returns>是否备份成功</returns>
        //public bool DB_Backup(string backup_Path)
        //{
        //    bool isSucc = false;
        //    string dbRealPath = Application.StartupPath + "\\db\\wangpuzs";
        //    try
        //    {
        //        if (File.Exists(backup_Path))
        //        {
        //            DialogResult dr = MessageBox.Show("存在相同名称的文件，是否覆盖", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        //            if (dr == DialogResult.Yes)
        //            {
        //                //File.Copy(dbRealPath, backup_Path + ConstDefine.DB_DESTFILETYPE, true);
        //                File.Copy(dbRealPath, backup_Path, true);
        //                isSucc = true;
        //            }
        //            else
        //            {
        //                isSucc = false;
        //            }
        //            //MessageBox.Show("备份数据库失败！现有数据库文件丢失。");
        //        }
        //        else
        //        {
        //            //File.Copy(dbRealPath, backup_Path + ConstDefine.DB_DESTFILETYPE);
        //            File.Copy(dbRealPath, backup_Path);
        //            isSucc = true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("备份数据库失败！请检查保存路径。");
        //        isSucc = false;
        //    }
        //    return isSucc;
        //}

        ///// <summary>
        ///// 数据库还原
        ///// </summary>
        ///// <param name="restore_Path">需要还原的数据库备份文件名（完整路径）</param>
        ///// <returns></returns>
        //public bool DB_Restore(string restore_Path)
        //{
        //    bool isSucc = false;
        //    string dbRealPath = System.Net.Mime.MediaTypeNames.Application.StartupPath + "\\db\\wangpuzs";
        //    try
        //    {
        //        if (!restore_Path.Equals("") && File.Exists(restore_Path))
        //        {
        //            string name = restore_Path.Substring(restore_Path.Length - 5);
        //            if (name == ".back")
        //            {
        //                if (DialogResult.Yes == MessageBox.Show("还原后部分数据将有可能丢失！是否将现有数据库还原为 " + restore_Path + " ？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
        //                {
        //                    File.Copy(restore_Path, dbRealPath, true);
        //                    isSucc = true;
        //                }
        //            }
        //        }
        //        //MessageBox.Show("错误！请选择扩展名为\".back\"的正确的数据备份文件。");
        //    }
        //    catch (Exception)
        //    {
        //        isSucc = false;
        //    }
        //    return isSucc;
        //}
    }
}
