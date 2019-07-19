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
        protected override IQueryable<VwCorrectiveAction> QueryOneSort(IQueryable<VwCorrectiveAction> query, ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnCorrectiveAction.Id:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Id);
                    else query = query.OrderByDescending(x => x.Id);
                    break;
                case (int)EnCorrectiveAction.Audit:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Audit);
                    else query = query.OrderByDescending(x => x.Audit);
                    break;

                case (int)EnCorrectiveAction.Name:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Name);
                    else query = query.OrderByDescending(x => x.Name);
                    break;

                case (int)EnCorrectiveAction.ExecutiveOfficerFirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ExecutiveOfficerFirstName);
                    else query = query.OrderByDescending(x => x.ExecutiveOfficerFirstName);
                    break;

                case (int)EnCorrectiveAction.ExecutiveOfficerLastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ExecutiveOfficerLastName);
                    else query = query.OrderByDescending(x => x.ExecutiveOfficerLastName);
                    break;

                case (int)EnCorrectiveAction.ExecutiveOfficerPatronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ExecutiveOfficerPatronymic);
                    else query = query.OrderByDescending(x => x.ExecutiveOfficerPatronymic);
                    break;

                case (int)EnCorrectiveAction.PlannedResultOfCorrectiveAction:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.PlannedResultOfCorrectiveAction);
                    else query = query.OrderByDescending(x => x.PlannedResultOfCorrectiveAction);
                    break;

                case (int)EnCorrectiveAction.CADevelopmentEvaluation:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CADevelopmentEvaluation);
                    else query = query.OrderByDescending(x => x.CADevelopmentEvaluation);
                    break;

                case (int)EnCorrectiveAction.NotDevelopmentCAComment:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.NotDevelopmentCAComment);
                    else query = query.OrderByDescending(x => x.NotDevelopmentCAComment);
                    break;

                case (int)EnCorrectiveAction.EvaluationAccordRecomForPrepOfCA:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.EvaluationAccordRecomForPrepOfCA);
                    else query = query.OrderByDescending(x => x.EvaluationAccordRecomForPrepOfCA);
                    break;

                case (int)EnCorrectiveAction.EvalAccordRecomForPrepOfCAComment:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.EvalAccordRecomForPrepOfCAComment);
                    else query = query.OrderByDescending(x => x.EvalAccordRecomForPrepOfCAComment);
                    break;

                case (int)EnCorrectiveAction.CAInAccordOrderOfVerifObject:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CAInAccordOrderOfVerifObject);
                    else query = query.OrderByDescending(x => x.CAInAccordOrderOfVerifObject);
                    break;

                case (int)EnCorrectiveAction.FactPeriodOfCAExecution:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.FactPeriodOfCAExecution);
                    else query = query.OrderByDescending(x => x.FactPeriodOfCAExecution);
                    break;

                case (int)EnCorrectiveAction.EvaluationCheckMarkOnCA:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.EvaluationCheckMarkOnCA);
                    else query = query.OrderByDescending(x => x.EvaluationCheckMarkOnCA);
                    break;

                case (int)EnCorrectiveAction.ReportImplementOfTheApprovedCA:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ReportImplementOfTheApprovedCA);
                    else query = query.OrderByDescending(x => x.ReportImplementOfTheApprovedCA);
                    break;

                case (int)EnCorrectiveAction.CorrectiveActionState:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CorrectiveActionState);
                    else query = query.OrderByDescending(x => x.CorrectiveActionState);
                    break;

                case (int)EnCorrectiveAction.CorrectiveActionStateComment:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CorrectiveActionStateComment);
                    else query = query.OrderByDescending(x => x.CorrectiveActionStateComment);
                    break;

                case (int)EnCorrectiveAction.ConclusionCorrectiveActionEffectEvaluation:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ConclusionCorrectiveActionEffectEvaluation);
                    else query = query.OrderByDescending(x => x.ConclusionCorrectiveActionEffectEvaluation);
                    break;

                case (int)EnCorrectiveAction.CorrectiveActionEffectEvaluation:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CorrectiveActionEffectEvaluation);
                    else query = query.OrderByDescending(x => x.CorrectiveActionEffectEvaluation);
                    break;

                case (int)EnCorrectiveAction.UsedRecommendationInPCA:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UsedRecommendationInPCA);
                    else query = query.OrderByDescending(x => x.UsedRecommendationInPCA);
                    break;

                case (int)EnCorrectiveAction.CommentOnUsedRecommendationInPCA:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CommentOnUsedRecommendationInPCA);
                    else query = query.OrderByDescending(x => x.CommentOnUsedRecommendationInPCA);
                    break;

                case (int)EnCorrectiveAction.EvaluationOfPostControlNeed:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.EvaluationOfPostControlNeed);
                    else query = query.OrderByDescending(x => x.EvaluationOfPostControlNeed);
                    break;

                case (int)EnCorrectiveAction.MonitoringOfficerFirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.MonitoringOfficerFirstName);
                    else query = query.OrderByDescending(x => x.MonitoringOfficerFirstName);
                    break;

                case (int)EnCorrectiveAction.MonitoringOfficerLastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.MonitoringOfficerLastName);
                    else query = query.OrderByDescending(x => x.MonitoringOfficerLastName);
                    break;

                case (int)EnCorrectiveAction.MonitoringOfficerPatronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.MonitoringOfficerPatronymic);
                    else query = query.OrderByDescending(x => x.MonitoringOfficerPatronymic);
                    break;

                case (int)EnCorrectiveAction.Note:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Note);
                    else query = query.OrderByDescending(x => x.Note);
                    break;

                case (int)EnCorrectiveAction.PlannedExecutionDate:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.PlannedExecutionDate);
                    else query = query.OrderByDescending(x => x.PlannedExecutionDate);
                    break;

                case (int)EnCorrectiveAction.CorrectiveActionType:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.CorrectiveActionType);
                    else query = query.OrderByDescending(x => x.CorrectiveActionType);
                    break;

                default:
                    throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.CorrectiveAction.QueryOneSort()");
            };

            return query;
        }
    }
}
