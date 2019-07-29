using System;
using System.Collections.Generic;
using System.Text;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Views
{
    public class CorrectiveAction : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public int Audit { get; set; }
        public string Name { get; set; }
        public string ExecutiveOfficerFirstName { get; set; }
        public string ExecutiveOfficerLastName { get; set; }
        public string ExecutiveOfficerPatronymic { get; set; }
        public string PlannedResultOfCorrectiveAction { get; set; }
        public string CADevelopmentEvaluation { get; set; }
        public string NotDevelopmentCAComment { get; set; }
        public string EvaluationAccordRecomForPrepOfCA { get; set; }
        public string EvalAccordRecomForPrepOfCAComment { get; set; }
        public string CAInAccordOrderOfVerifObject { get; set; }
        public string FactPeriodOfCAExecution { get; set; }
        public int EvaluationCheckMarkOnCA { get; set; }
        public string ReportImplementOfTheApprovedCA { get; set; }
        public int CorrectiveActionState { get; set; }
        public string CorrectiveActionStateComment { get; set; }
        public string ConclusionCorrectiveActionEffectEvaluation { get; set; }
        public int CorrectiveActionEffectEvaluation { get; set; }
        public bool UsedRecommendationInPCA { get; set; }
        public string CommentOnUsedRecommendationInPCA { get; set; }
        public string EvaluationOfPostControlNeed { get; set; }
        public string MonitoringOfficerFirstName { get; set; }
        public string MonitoringOfficerLastName { get; set; }
        public string MonitoringOfficerPatronymic { get; set; }
        public string Note { get; set; }
        public DateTime PlannedExecutionDate { get; set; }
        public int CorrectiveActionType { get; set; }
    }
}
