using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.DataTransferObjects.ViewColumns;

namespace BusinessLogicLayer.ViewEnlisters
{
    internal class Audit : ViewEnlisterBase<DTOVw.Audit, VwAudit>
    {
        protected override IQueryable<VwAudit> QueryOneSort(IQueryable<VwAudit> query, bool isFirstSort, DTOVw.ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch ( orderDesc.ColumnId )
            {
                case (int)EnAudit.Id: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Id);
                case (int)EnAudit.BusinessProcess: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.BusinessProcess);
                case (int)EnAudit.Name: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Name);
                case (int)EnAudit.VerificationPeriodStart: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.VerificationPeriodStart);
                case (int)EnAudit.VerificationPeriodStop: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.VerificationPeriodStop);
                case (int)EnAudit.GroundForVerification: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.GroundForVerification);
                case (int)EnAudit.ParPlanScheduleOfControlEvent: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ParPlanScheduleOfControlEvent);
                case (int)EnAudit.FilePlanScheduleOfControlEvent: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.FilePlanScheduleOfControlEvent);
                case (int)EnAudit.NumLocalRegulatory: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.NumLocalRegulatory);
                case (int)EnAudit.FileLocalRegulatory: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.FileLocalRegulatory);
                case (int)EnAudit.VerificationPeriod: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.VerificationPeriod);
                case (int)EnAudit.VerificationTermStart: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.VerificationTermStart);
                case (int)EnAudit.VerficationTermEnd: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.VerficationTermEnd);
                case (int)EnAudit.NumberAndDateLocRegPrepare: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.NumberAndDateLocRegPrepare);
                case (int)EnAudit.NumberAndDateLocRegAcceptance: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.NumberAndDateLocRegAcceptance);
                case (int)EnAudit.CapmonitoringCompletedOnDate: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CapmonitoringCompletedOnDate);
                case (int)EnAudit.NextCapmonitoringDate: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.NextCapmonitoringDate);
                case (int)EnAudit.CapmonitoringCompleteDate: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CapmonitoringCompleteDate);
                case (int)EnAudit.AuditSubjectPos: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditSubjectPos);
                case (int)EnAudit.AuditSubjectName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditSubjectName);
                case (int)EnAudit.MonitoringProgressStatusPos: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.MonitoringProgressStatusPos);
                case (int)EnAudit.MonitoringProgressStatusName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.MonitoringProgressStatusName);
                case (int)EnAudit.AuditObjectId: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditObjectId);
                case (int)EnAudit.AuditObjectName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditObjectName);
                case (int)EnAudit.ResponsibleEmployeeId: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleEmployeeId);
                case (int)EnAudit.ResponsibleEmployeeFirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleEmployeeFirstName);
                case (int)EnAudit.ResponsibleEmployeeLastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleEmployeeLastName);
                case (int)EnAudit.ResponsibleEmployeePatronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleEmployeePatronymic);
                case (int)EnAudit.ResponsibleEmployeeEmail: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleEmployeeEmail);
                case (int)EnAudit.AuditSuperviserId: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditSuperviserId);
                case (int)EnAudit.AuditSuperviserFirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditSuperviserFirstName);
                case (int)EnAudit.AuditSuperviserLastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditSuperviserLastName);
                case (int)EnAudit.AuditSuperviserPatronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditSuperviserPatronymic);
                case (int)EnAudit.AuditSuperviserEmail: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditSuperviserEmail);
                default: throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.Audit.QueryOneSort()");
            };
        }            
    }
}
