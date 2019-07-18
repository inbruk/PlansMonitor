using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class AuditLog
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int User { get; set; }
        public int Screen { get; set; }
        public int Action { get; set; }
        public string Description { get; set; }
    }
}
