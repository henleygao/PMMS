using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.System
{
    public class UserUpdateView
    {
        public int Id { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        public  string Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public  string Name { get; set; }
    }
}
