using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblAudit
    {
        public TblAudit()
        {
            TblCorrectiveAction = new HashSet<TblCorrectiveAction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AuditObject { get; set; }
        public DateTime VerificationPeriodStart { get; set; }
        public DateTime VerificationPeriodStop { get; set; }
        public string GroundForVerification { get; set; }
        public string ParPlanScheduleOfControlEvent { get; set; }
        public string FilePlanScheduleOfControlEvent { get; set; }
        public string NumLocalRegulatory { get; set; }
        public string FileLocalRegulatory { get; set; }
        public string VerificationPeriod { get; set; }
        public DateTime VerificationTermStart { get; set; }
        public string VerficationTermEnd { get; set; }
        public int ResponsibleEmployee { get; set; }
        public string NumberAndDateLocRegPrepare { get; set; }
        public string NumberAndDateLocRegAcceptance { get; set; }
        public DateTime? CapmonitoringCompletedOnDate { get; set; }
        public DateTime? NextCapmonitoringDate { get; set; }
        public int AuditSubject { get; set; }
        public int MonitoringProgressStatus { get; set; }
        public DateTime? CapmonitoringCompleteDate { get; set; }
        public int? AuditSuperviser { get; set; }

        public virtual TblAuditObject AuditObjectNavigation { get; set; }
        public virtual TblUser AuditSuperviserNavigation { get; set; }
        public virtual TblUser ResponsibleEmployeeNavigation { get; set; }
        public virtual ICollection<TblCorrectiveAction> TblCorrectiveAction { get; set; }
    }
}
