using System;
using System.Collections.Generic;

#nullable disable

namespace ComputersInventory.DAL
{
    public partial class FormFactor
    {
        public FormFactor()
        {
            Computers = new HashSet<Computer>();
        }

        public int FormFactorId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
