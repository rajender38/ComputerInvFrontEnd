using System;
using System.Collections.Generic;

#nullable disable

namespace ComputersInventory.DAL
{
    public partial class ComputerType
    {
        public ComputerType()
        {
            ComputerTypeFields = new HashSet<ComputerTypeField>();
            Computers = new HashSet<Computer>();
        }

        public int ComputerTypeId { get; set; }
        public string Name { get; set; }
        public bool Processor { get; set; }
        public bool UsbPorts { get; set; }

        public bool RamSlots { get; set; }
        public bool FormFactor { get; set; }
        public bool Quantity { get; set; }
        public bool ScreenSize { get; set; }
        public bool Brand { get; set; }

        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<ComputerTypeField> ComputerTypeFields { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
    }
}
