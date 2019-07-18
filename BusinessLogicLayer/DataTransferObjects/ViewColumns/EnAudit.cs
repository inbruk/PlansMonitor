using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects.ViewColumns
{
    public enum EnAudit
    {
         Id = 1,
         BusinessProcess = 2,
         Name = 3,
         VerificationPeriodStart = 4,
         VerificationPeriodStop = 5,
         GroundForVerification = 6,
         ParPlanScheduleOfControlEvent = 7,
         FilePlanScheduleOfControlEvent = 8,
         NumLocalRegulatory = 9,
         FileLocalRegulatory = 10,
         VerificationPeriod = 11,
         VerificationTermStart = 12,
         VerficationTermEnd = 13,
         NumberAndDateLocRegPrepare = 14,
         NumberAndDateLocRegAcceptance = 15,
         CapmonitoringCompletedOnDate = 16,
         NextCapmonitoringDate = 17,
         CapmonitoringCompleteDate = 18,
         AuditSubjectPos = 19,
         AuditSubjectName = 20,
         MonitoringProgressStatusPos = 21,
         MonitoringProgressStatusName = 22,
         AuditObjectId = 23,
         AuditObjectName = 24,
         ResponsibleEmployeeId = 25,
         ResponsibleEmployeeFirstName = 26,
         ResponsibleEmployeeLastName = 27,
         ResponsibleEmployeePatronymic = 28,
         ResponsibleEmployeeEmail = 29,
         AuditSuperviserId = 30,
         AuditSuperviserFirstName = 31,
         AuditSuperviserLastName = 32,
         AuditSuperviserPatronymic = 33,
         AuditSuperviserEmail = 34,
    }
}
