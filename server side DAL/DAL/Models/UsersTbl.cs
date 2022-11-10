using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class UsersTbl
    {
        public UsersTbl()
        {
            BuyingTbls = new HashSet<BuyingTbl>();
        }

        public int Codeuser { get; set; }
        public string Nameuser { get; set; }
        public string Passworduser { get; set; }
        public string Phoneuser { get; set; }
        public string Addressuser { get; set; }

        public virtual ICollection<BuyingTbl> BuyingTbls { get; set; }
    }
}
