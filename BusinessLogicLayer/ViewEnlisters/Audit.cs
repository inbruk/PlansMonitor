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
        protected override IQueryable<VwAudit> QueryOneSort(IQueryable<VwAudit> query, ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch ( orderDesc.ColumnId )
            {
                case (int)EnAudit.Id:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Id);
                                                  else query = query.OrderByDescending(x => x.Id);
                    break;
                case (int)EnAudit.BusinessProcess:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.BusinessProcess);
                    else query = query.OrderByDescending(x => x.BusinessProcess);
                    break;
                case (int)EnAudit.Name:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Name);
                    else query = query.OrderByDescending(x => x.Name);
                    break;
                case (int)EnAudit.VerificationPeriodStart:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.VerificationPeriodStart);
                    else query = query.OrderByDescending(x => x.VerificationPeriodStart);
                    break;
                case (int)EnAudit.VerificationPeriodStop:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.VerificationPeriodStop);
                    else query = query.OrderByDescending(x => x.VerificationPeriodStop);
                    break;
                case (int)EnAudit.GroundForVerification:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.GroundForVerification);
                    else query = query.OrderByDescending(x => x.GroundForVerification);
                    break;
                case (int)EnAudit.ParPlanScheduleOfControlEvent:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ParPlanScheduleOfControlEvent);
                    else query = query.OrderByDescending(x => x.ParPlanScheduleOfControlEvent);
                    break;
                case (int)EnAudit.FilePlanScheduleOfControlEvent:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.FilePlanScheduleOfControlEvent);
                    else query = query.OrderByDescending(x => x.FilePlanScheduleOfControlEvent);
                    break;
                case (int)EnAudit.NumLocalRegulatory:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.NumLocalRegulatory);
                    else query = query.OrderByDescending(x => x.NumLocalRegulatory);
                    break;
                case (int)EnAudit.FileLocalRegulatory:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.FileLocalRegulatory);
                    else query = query.OrderByDescending(x => x.FileLocalRegulatory);
                    break;
                case (int)EnAudit.VerificationPeriod:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.VerificationPeriod);
                    else query = query.OrderByDescending(x => x.VerificationPeriod);
                    break;
                case (int)EnAudit.VerificationTermStart:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.VerificationTermStart);
                    else query = query.OrderByDescending(x => x.VerificationTermStart);
                    break;
                case (int)EnAudit.VerficationTermEnd:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.VerficationTermEnd);
                    else query = query.OrderByDescending(x => x.VerficationTermEnd);
                    break;
                case (int)EnAudit.NumberAndDateLocRegPrepare:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.NumberAndDateLocRegPrepare);
                    else query = query.OrderByDescending(x => x.NumberAndDateLocRegPrepare);
                    break;
                case (int)EnAudit.NumberAndDateLocRegAcceptance:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.NumberAndDateLocRegAcceptance);
                    else query = query.OrderByDescending(x => x.NumberAndDateLocRegAcceptance);
                    break;
                case (int)EnAudit.CapmonitoringCompletedOnDate:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CapmonitoringCompletedOnDate);
                    else query = query.OrderByDescending(x => x.CapmonitoringCompletedOnDate);
                    break;
                case (int)EnAudit.NextCapmonitoringDate:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.NextCapmonitoringDate);
                    else query = query.OrderByDescending(x => x.NextCapmonitoringDate);
                    break;
                case (int)EnAudit.CapmonitoringCompleteDate:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CapmonitoringCompleteDate);
                    else query = query.OrderByDescending(x => x.CapmonitoringCompleteDate);
                    break;
                case (int)EnAudit.AuditSubjectPos:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditSubjectPos);
                    else query = query.OrderByDescending(x => x.AuditSubjectPos);
                    break;
                case (int)EnAudit.AuditSubjectName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditSubjectName);
                    else query = query.OrderByDescending(x => x.AuditSubjectName);
                    break;
                case (int)EnAudit.MonitoringProgressStatusPos:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.MonitoringProgressStatusPos);
                    else query = query.OrderByDescending(x => x.MonitoringProgressStatusPos);
                    break;
                case (int)EnAudit.MonitoringProgressStatusName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.MonitoringProgressStatusName);
                    else query = query.OrderByDescending(x => x.MonitoringProgressStatusName);
                    break;
                case (int)EnAudit.AuditObjectId:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditObjectId);
                    else query = query.OrderByDescending(x => x.AuditObjectId);
                    break;
                case (int)EnAudit.AuditObjectName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditObjectName);
                    else query = query.OrderByDescending(x => x.AuditObjectName);
                    break;
                case (int)EnAudit.ResponsibleEmployeeId:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleEmployeeId);
                    else query = query.OrderByDescending(x => x.ResponsibleEmployeeId);
                    break;
                case (int)EnAudit.ResponsibleEmployeeFirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleEmployeeFirstName);
                    else query = query.OrderByDescending(x => x.ResponsibleEmployeeFirstName);
                    break;
                case (int)EnAudit.ResponsibleEmployeeLastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleEmployeeLastName);
                    else query = query.OrderByDescending(x => x.ResponsibleEmployeeLastName);
                    break;
                case (int)EnAudit.ResponsibleEmployeePatronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleEmployeePatronymic);
                    else query = query.OrderByDescending(x => x.ResponsibleEmployeePatronymic);
                    break;
                case (int)EnAudit.ResponsibleEmployeeEmail:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleEmployeeEmail);
                    else query = query.OrderByDescending(x => x.ResponsibleEmployeeEmail);
                    break;
                case (int)EnAudit.AuditSuperviserId:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditSuperviserId);
                    else query = query.OrderByDescending(x => x.AuditSuperviserId);
                    break;
                case (int)EnAudit.AuditSuperviserFirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditSuperviserFirstName);
                    else query = query.OrderByDescending(x => x.AuditSuperviserFirstName);
                    break;
                case (int)EnAudit.AuditSuperviserLastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditSuperviserLastName);
                    else query = query.OrderByDescending(x => x.AuditSuperviserLastName);
                    break;
                case (int)EnAudit.AuditSuperviserPatronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditSuperviserPatronymic);
                    else query = query.OrderByDescending(x => x.AuditSuperviserPatronymic);
                    break;
                case (int)EnAudit.AuditSuperviserEmail:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditSuperviserEmail);
                    else query = query.OrderByDescending(x => x.AuditSuperviserEmail);
                    break;
                default:
                    throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.Audit.QueryOneSort()");
            };

            return query;
        }            
    }
}
