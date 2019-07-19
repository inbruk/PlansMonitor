using System;
using System.Collections.Generic;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class UserRole : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool? IsAuditOjectRestricted { get; set; }
    }
}
