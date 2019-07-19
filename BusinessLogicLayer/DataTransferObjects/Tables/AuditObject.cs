using System;
using System.Collections.Generic;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class AuditObject : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
