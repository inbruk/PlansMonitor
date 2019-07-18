using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool? IsAuditOjectRestricted { get; set; }
    }
}
