using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblAuditLog
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int User { get; set; }
        public int BusinessObject { get; set; }
        public int Action { get; set; }
        public string Description { get; set; }
        public int Screen { get; set; }

        public virtual TblUser UserNavigation { get; set; }
    }
}
