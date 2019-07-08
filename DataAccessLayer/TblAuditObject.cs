using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblAuditObject
    {
        public TblAuditObject()
        {
            TblAudit = new HashSet<TblAudit>();
            TblUser = new HashSet<TblUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblAudit> TblAudit { get; set; }
        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
