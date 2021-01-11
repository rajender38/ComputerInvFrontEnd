using System;
using System.Collections.Generic;

#nullable disable

namespace ComputersInventory.DAL
{
    public partial class ComputerTypeField
    {
        public int ComputerTypeFieldId { get; set; }
        public int? ComputerTypeId { get; set; }
        public string FieldName { get; set; }
        public bool? IsRequired { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ComputerType ComputerType { get; set; }
    }
}
