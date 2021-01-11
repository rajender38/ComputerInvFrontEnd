using System;
using System.Collections.Generic;

#nullable disable

namespace ComputersInventory.DAL
{
    public partial class Computer
    {
        public int ComputerId { get; set; }
        public int? ComputerTypeId { get; set; }
        public string Processor { get; set; }
        public string Brand { get; set; }
        public int? UsbPorts { get; set; }
        public int? RamSlots { get; set; }
        public int? FormFactor { get; set; }
        public int? Quantity { get; set; }
        public int? ScreenSizeId { get; set; }
        public bool IsActive { get; set; }

        public virtual ComputerType ComputerType { get; set; }
        public virtual FormFactor FormFactorNavigation { get; set; }
        public virtual ScreenSize ScreenSize { get; set; }
    }
}
