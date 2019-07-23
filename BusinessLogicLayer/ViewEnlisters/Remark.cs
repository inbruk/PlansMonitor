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
    internal class Remark : ViewEnlisterBase<DTOVw.Remark, VwRemark>
    {
        protected override IQueryable<VwRemark> QueryOneSort(IQueryable<VwRemark> query, bool isFirstSort, DTOVw.ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnRemark.Id: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Id);
                case (int)EnRemark.ReportSubsectionNumber: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ReportSubsectionNumber);
                case (int)EnRemark.RemarkType: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.RemarkType);
                case (int)EnRemark.RemarkDescription: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.RemarkDescription);
                case (int)EnRemark.RevealedRemarkReason: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.RevealedRemarkReason);
                case (int)EnRemark.RevealedRemarkConsequences: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.RevealedRemarkConsequences);
                case (int)EnRemark.QuantitativeAssessmentLossesRealized: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.QuantitativeAssessmentLossesRealized);
                case (int)EnRemark.QuantitativeAssessmentPotentialLosses: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.QuantitativeAssessmentPotentialLosses);
                case (int)EnRemark.QuantitativeAssessmentTotalLoss: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.QuantitativeAssessmentTotalLoss);
                case (int)EnRemark.QualitativeAssessment: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.QualitativeAssessment);
                case (int)EnRemark.ResponsibleAuditor: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleAuditor);
                case (int)EnRemark.TotalAssessmentLevel: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.TotalAssessmentLevel);
                case (int)EnRemark.PersonCMRecommendations: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.PersonCMRecommendations);
                case (int)EnRemark.PageNumber: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.PageNumber);
                case (int)EnRemark.SectionAttachment: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.SectionAttachment);
                case (int)EnRemark.ViolationContent: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ViolationContent);
                case (int)EnRemark.ViolationValuation: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ViolationValuation);
                case (int)EnRemark.AuditObjectComments: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditObjectComments);
                case (int)EnRemark.AuditObjectFinalAssessment: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AuditObjectFinalAssessment);
                case (int)EnRemark.ViolationsAndDeficienciesCauses: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ViolationsAndDeficienciesCauses);
                case (int)EnRemark.ResponsibleAuditorId: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleAuditorId);
                case (int)EnRemark.ResponsibleAuditorFirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleAuditorFirstName);
                case (int)EnRemark.ResponsibleAuditorLastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleAuditorLastName);
                case (int)EnRemark.ResponsibleAuditorPatronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleAuditorPatronymic);
                case (int)EnRemark.ResponsibleControllerId: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleControllerId);
                case (int)EnRemark.ResponsibleControllerFirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleControllerFirstName);
                case (int)EnRemark.ResponsibleControllerLastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleControllerLastName);
                case (int)EnRemark.ResponsibleControllerPatronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ResponsibleControllerPatronymic);
                case (int)EnRemark.BusinessProcessPos: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.BusinessProcessPos);
                case (int)EnRemark.BusinessProcessName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.BusinessProcessName);
                case (int)EnRemark.TotalAssessmentLevelPos: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.TotalAssessmentLevelPos);
                case (int)EnRemark.TotalAssessmentLevelName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.TotalAssessmentLevelName);
                case (int)EnRemark.RemarkTypePos: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.RemarkTypePos);
                case (int)EnRemark.RemarkTypeName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.RemarkTypeName);
                default: throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.Remark.QueryOneSort()");
            };
        }
    }
}
