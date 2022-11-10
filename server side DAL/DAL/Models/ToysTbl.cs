using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class ToysTbl
    {
        public int Codetoy { get; set; }
        public string Nametoy { get; set; }
        public string Describetoy { get; set; }
        public int? Codecategory { get; set; }
        public int? Price { get; set; }
        public string Picture { get; set; }

        public virtual CategoryTbl CodecategoryNavigation { get; set; }
    }
}
