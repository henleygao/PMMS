using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Enum;

namespace PMMS.Services.System
{
    public class UserListView
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }
    }
}
