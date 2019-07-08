using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblAuditAuditSuperviserNavigation = new HashSet<TblAudit>();
            TblAuditLog = new HashSet<TblAuditLog>();
            TblAuditResponsibleEmployeeNavigation = new HashSet<TblAudit>();
            TblRemarkResponsibleAuditorNavigation = new HashSet<TblRemark>();
            TblRemarkResponsibleControllerNavigation = new HashSet<TblRemark>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool AccessGranted { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public int? VerificationObject { get; set; }

        public virtual TblUserRole RoleNavigation { get; set; }
        public virtual TblAuditObject VerificationObjectNavigation { get; set; }
        public virtual ICollection<TblAudit> TblAuditAuditSuperviserNavigation { get; set; }
        public virtual ICollection<TblAuditLog> TblAuditLog { get; set; }
        public virtual ICollection<TblAudit> TblAuditResponsibleEmployeeNavigation { get; set; }
        public virtual ICollection<TblRemark> TblRemarkResponsibleAuditorNavigation { get; set; }
        public virtual ICollection<TblRemark> TblRemarkResponsibleControllerNavigation { get; set; }
    }
}
