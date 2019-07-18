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
    internal class Remark : ViewEnlisterBase<DTOVw.Remark, VwRemark, int>
    {
        protected override IQueryable<VwRemark> QueryOneSort(IQueryable<VwRemark> query, ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnRemark.Id:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Id);
                    else query = query.OrderByDescending(x => x.Id);
                    break;
                case (int)EnRemark.ReportSubsectionNumber:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ReportSubsectionNumber);
                    else query = query.OrderByDescending(x => x.ReportSubsectionNumber);
                    break;

                case (int)EnRemark.RemarkType:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.RemarkType);
                    else query = query.OrderByDescending(x => x.RemarkType);
                    break;

                case (int)EnRemark.RemarkDescription:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.RemarkDescription);
                    else query = query.OrderByDescending(x => x.RemarkDescription);
                    break;

                case (int)EnRemark.RevealedRemarkReason:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.RevealedRemarkReason);
                    else query = query.OrderByDescending(x => x.RevealedRemarkReason);
                    break;

                case (int)EnRemark.RevealedRemarkConsequences:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.RevealedRemarkConsequences);
                    else query = query.OrderByDescending(x => x.RevealedRemarkConsequences);
                    break;

                case (int)EnRemark.QuantitativeAssessmentLossesRealized:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.QuantitativeAssessmentLossesRealized);
                    else query = query.OrderByDescending(x => x.QuantitativeAssessmentLossesRealized);
                    break;

                case (int)EnRemark.QuantitativeAssessmentPotentialLosses:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.QuantitativeAssessmentPotentialLosses);
                    else query = query.OrderByDescending(x => x.QuantitativeAssessmentPotentialLosses);
                    break;

                case (int)EnRemark.QuantitativeAssessmentTotalLoss:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.QuantitativeAssessmentTotalLoss);
                    else query = query.OrderByDescending(x => x.QuantitativeAssessmentTotalLoss);
                    break;

                case (int)EnRemark.QualitativeAssessment:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.QualitativeAssessment);
                    else query = query.OrderByDescending(x => x.QualitativeAssessment);
                    break;

                case (int)EnRemark.ResponsibleAuditor:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleAuditor);
                    else query = query.OrderByDescending(x => x.ResponsibleAuditor);
                    break;

                case (int)EnRemark.TotalAssessmentLevel:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.TotalAssessmentLevel);
                    else query = query.OrderByDescending(x => x.TotalAssessmentLevel);
                    break;

                case (int)EnRemark.PersonCMRecommendations:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.PersonCMRecommendations);
                    else query = query.OrderByDescending(x => x.PersonCMRecommendations);
                    break;

                case (int)EnRemark.PageNumber:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.PageNumber);
                    else query = query.OrderByDescending(x => x.PageNumber);
                    break;

                case (int)EnRemark.SectionAttachment:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.SectionAttachment);
                    else query = query.OrderByDescending(x => x.SectionAttachment);
                    break;

                case (int)EnRemark.ViolationContent:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ViolationContent);
                    else query = query.OrderByDescending(x => x.ViolationContent);
                    break;

                case (int)EnRemark.ViolationValuation:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ViolationValuation);
                    else query = query.OrderByDescending(x => x.ViolationValuation);
                    break;

                case (int)EnRemark.AuditObjectComments:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditObjectComments);
                    else query = query.OrderByDescending(x => x.AuditObjectComments);
                    break;

                case (int)EnRemark.AuditObjectFinalAssessment:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AuditObjectFinalAssessment);
                    else query = query.OrderByDescending(x => x.AuditObjectFinalAssessment);
                    break;

                case (int)EnRemark.ViolationsAndDeficienciesCauses:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ViolationsAndDeficienciesCauses);
                    else query = query.OrderByDescending(x => x.ViolationsAndDeficienciesCauses);
                    break;

                case (int)EnRemark.ResponsibleAuditorId:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleAuditorId);
                    else query = query.OrderByDescending(x => x.ResponsibleAuditorId);
                    break;

                case (int)EnRemark.ResponsibleAuditorFirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleAuditorFirstName);
                    else query = query.OrderByDescending(x => x.ResponsibleAuditorFirstName);
                    break;

                case (int)EnRemark.ResponsibleAuditorLastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleAuditorLastName);
                    else query = query.OrderByDescending(x => x.ResponsibleAuditorLastName);
                    break;

                case (int)EnRemark.ResponsibleAuditorPatronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleAuditorPatronymic);
                    else query = query.OrderByDescending(x => x.ResponsibleAuditorPatronymic);
                    break;

                case (int)EnRemark.ResponsibleControllerId:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleControllerId);
                    else query = query.OrderByDescending(x => x.ResponsibleControllerId);
                    break;

                case (int)EnRemark.ResponsibleControllerFirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleControllerFirstName);
                    else query = query.OrderByDescending(x => x.ResponsibleControllerFirstName);
                    break;

                case (int)EnRemark.ResponsibleControllerLastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleControllerLastName);
                    else query = query.OrderByDescending(x => x.ResponsibleControllerLastName);
                    break;

                case (int)EnRemark.ResponsibleControllerPatronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ResponsibleControllerPatronymic);
                    else query = query.OrderByDescending(x => x.ResponsibleControllerPatronymic);
                    break;

                case (int)EnRemark.BusinessProcessPos:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.BusinessProcessPos);
                    else query = query.OrderByDescending(x => x.BusinessProcessPos);
                    break;

                case (int)EnRemark.BusinessProcessName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.BusinessProcessName);
                    else query = query.OrderByDescending(x => x.BusinessProcessName);
                    break;

                case (int)EnRemark.TotalAssessmentLevelPos:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.TotalAssessmentLevelPos);
                    else query = query.OrderByDescending(x => x.TotalAssessmentLevelPos);
                    break;

                case (int)EnRemark.TotalAssessmentLevelName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.TotalAssessmentLevelName);
                    else query = query.OrderByDescending(x => x.TotalAssessmentLevelName);
                    break;

                case (int)EnRemark.RemarkTypePos:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.RemarkTypePos);
                    else query = query.OrderByDescending(x => x.RemarkTypePos);
                    break;

                case (int)EnRemark.RemarkTypeName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.RemarkTypeName);
                    else query = query.OrderByDescending(x => x.RemarkTypeName);
                    break;

                default:
                    throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.Remark.QueryOneSort()");
            };

            return query;
        }
    }
}
