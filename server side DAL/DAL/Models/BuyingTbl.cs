using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class BuyingTbl
    {
        public int Codebuy { get; set; }
        public string Datebuy { get; set; }
        public int? Codeuser { get; set; }
        public int? Sumbuy { get; set; }

        public virtual UsersTbl CodeuserNavigation { get; set; }
    }
}
