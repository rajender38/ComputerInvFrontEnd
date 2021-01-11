using System;
using System.Collections.Generic;

#nullable disable

namespace ComputersInventory.DAL
{
    public partial class ScreenSize
    {
        public ScreenSize()
        {
            Computers = new HashSet<Computer>();
        }

        public int ScreenSizeId { get; set; }
        public string ScreenSize1 { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
