using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Enum;

namespace PMMS.Entities
{
    public class User
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual UserStatus Status { get; set; }
    }
}
