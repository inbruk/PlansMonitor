using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects.ViewColumns
{
    public enum EnCorrectiveAction
    {
        Id = 1,
        Audit = 2,
        Name = 3,
        ExecutiveOfficerFirstName = 4,
        ExecutiveOfficerLastName = 5,
        ExecutiveOfficerPatronymic = 6,
        PlannedResultOfCorrectiveAction = 7,
        CADevelopmentEvaluation = 8,
        NotDevelopmentCAComment = 9,
        EvaluationAccordRecomForPrepOfCA = 10,
        EvalAccordRecomForPrepOfCAComment = 11,
        CAInAccordOrderOfVerifObject = 12,
        FactPeriodOfCAExecution = 13,
        EvaluationCheckMarkOnCA = 14,
        ReportImplementOfTheApprovedCA = 15,
        CorrectiveActionState = 16,
        CorrectiveActionStateComment = 17,
        ConclusionCorrectiveActionEffectEvaluation = 18,
        CorrectiveActionEffectEvaluation = 19,
        UsedRecommendationInPCA = 20,
        CommentOnUsedRecommendationInPCA = 21,
        EvaluationOfPostControlNeed = 22,
        MonitoringOfficerFirstName = 23,
        MonitoringOfficerLastName = 24,
        MonitoringOfficerPatronymic = 25,
        Note = 26,
        PlannedExecutionDate = 27,
        CorrectiveActionType = 28
    }
}
