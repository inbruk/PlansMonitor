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
    internal class CorrectiveAction : ViewEnlisterBase<DTOVw.CorrectiveAction, VwCorrectiveAction>
    {
        protected override IQueryable<VwCorrectiveAction> QueryOneSort(IQueryable<VwCorrectiveAction> query, bool isFirstSort, DTOVw.ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnCorrectiveAction.Id: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Id);
                case (int)EnCorrectiveAction.Audit: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Audit);
                case (int)EnCorrectiveAction.Name: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Name);
                case (int)EnCorrectiveAction.ExecutiveOfficerFirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ExecutiveOfficerFirstName);
                case (int)EnCorrectiveAction.ExecutiveOfficerLastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ExecutiveOfficerLastName);
                case (int)EnCorrectiveAction.ExecutiveOfficerPatronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ExecutiveOfficerPatronymic);
                case (int)EnCorrectiveAction.PlannedResultOfCorrectiveAction: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.PlannedResultOfCorrectiveAction);
                case (int)EnCorrectiveAction.CADevelopmentEvaluation: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CADevelopmentEvaluation);
                case (int)EnCorrectiveAction.NotDevelopmentCAComment: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.NotDevelopmentCAComment);
                case (int)EnCorrectiveAction.EvaluationAccordRecomForPrepOfCA: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.EvaluationAccordRecomForPrepOfCA);
                case (int)EnCorrectiveAction.EvalAccordRecomForPrepOfCAComment: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.EvalAccordRecomForPrepOfCAComment);
                case (int)EnCorrectiveAction.CAInAccordOrderOfVerifObject: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CAInAccordOrderOfVerifObject);
                case (int)EnCorrectiveAction.FactPeriodOfCAExecution: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.FactPeriodOfCAExecution);
                case (int)EnCorrectiveAction.EvaluationCheckMarkOnCA: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.EvaluationCheckMarkOnCA);
                case (int)EnCorrectiveAction.ReportImplementOfTheApprovedCA: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ReportImplementOfTheApprovedCA);
                case (int)EnCorrectiveAction.CorrectiveActionState: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CorrectiveActionState);
                case (int)EnCorrectiveAction.CorrectiveActionStateComment: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CorrectiveActionStateComment);
                case (int)EnCorrectiveAction.ConclusionCorrectiveActionEffectEvaluation: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ConclusionCorrectiveActionEffectEvaluation);
                case (int)EnCorrectiveAction.CorrectiveActionEffectEvaluation: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CorrectiveActionEffectEvaluation);
                case (int)EnCorrectiveAction.UsedRecommendationInPCA: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UsedRecommendationInPCA);
                case (int)EnCorrectiveAction.CommentOnUsedRecommendationInPCA: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CommentOnUsedRecommendationInPCA);
                case (int)EnCorrectiveAction.EvaluationOfPostControlNeed: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.EvaluationOfPostControlNeed);
                case (int)EnCorrectiveAction.MonitoringOfficerFirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.MonitoringOfficerFirstName);
                case (int)EnCorrectiveAction.MonitoringOfficerLastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.MonitoringOfficerLastName);
                case (int)EnCorrectiveAction.MonitoringOfficerPatronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.MonitoringOfficerPatronymic);
                case (int)EnCorrectiveAction.Note: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Note);
                case (int)EnCorrectiveAction.PlannedExecutionDate: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.PlannedExecutionDate);
                case (int)EnCorrectiveAction.CorrectiveActionType: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.CorrectiveActionType);
                default: throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.CorrectiveAction.QueryOneSort()");
            };
        }
    }
}
