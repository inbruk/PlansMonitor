using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblUserRole
    {
        public TblUserRole()
        {
            TblUser = new HashSet<TblUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool? IsAuditOjectRestricted { get; set; }

        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
