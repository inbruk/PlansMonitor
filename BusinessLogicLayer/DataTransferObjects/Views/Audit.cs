using System;
using System.Collections.Generic;
using System.Text;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Views
{
    public class Audit : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public int BusinessProcess { get; set; }
        public string Name { get; set; }
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
        public string NumberAndDateLocRegPrepare { get; set; }
        public string NumberAndDateLocRegAcceptance { get; set; }
        public DateTime? CAPMonitoringCompletedOnDate { get; set; }
        public DateTime? NextCAPMonitoringDate { get; set; }
        public DateTime? CAPMonitoringCompleteDate { get; set; }
        public int AuditSubjectPos { get; set; }
        public string AuditSubjectName { get; set; }
        public int MonitoringProgressStatusPos { get; set; }
        public string MonitoringProgressStatusName { get; set; }
        public int AuditObjectId { get; set; }
        public string AuditObjectName { get; set; }
        public int ResponsibleEmployeeId { get; set; }
        public string ResponsibleEmployeeFirstName { get; set; }
        public string ResponsibleEmployeeLastName { get; set; }
        public string ResponsibleEmployeePatronymic { get; set; }
        public string ResponsibleEmployeeEmail { get; set; }
        public int AuditSuperviserId { get; set; }
        public string AuditSuperviserFirstName { get; set; }
        public string AuditSuperviserLastName { get; set; }
        public string AuditSuperviserPatronymic { get; set; }
        public string AuditSuperviserEmail { get; set; }
    }
}
