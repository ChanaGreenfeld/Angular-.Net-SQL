using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class CategoryTbl
    {
        public CategoryTbl()
        {
            ToysTbls = new HashSet<ToysTbl>();
        }

        public int IdCategory { get; set; }
        public string NameCategory { get; set; }

        public virtual ICollection<ToysTbl> ToysTbls { get; set; }
    }
}
