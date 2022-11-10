using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class BuydetailsTbl
    {
      
        public int? Codebuy { get; set; }
        public int? Codetoy { get; set; }
        public int? Countbuy { get; set; }
        
        public virtual BuyingTbl CodebuyNavigation { get; set; }
        public virtual ToysTbl CodetoyNavigation { get; set; }
    }
}
