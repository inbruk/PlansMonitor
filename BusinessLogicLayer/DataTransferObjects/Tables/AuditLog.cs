using System;
using System.Collections.Generic;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class AuditLog : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int User { get; set; }
        public int Screen { get; set; }
        public int Action { get; set; }
        public string Description { get; set; }
    }
}
