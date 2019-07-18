using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class CorrectiveAction
    {
        public int Id { get; set; }
        public int Audit { get; set; }
        public string Name { get; set; }
        public string ExecutiveOfficerFirstName { get; set; }
        public string ExecutiveOfficerLastName { get; set; }
        public string ExecutiveOfficerPatronymic { get; set; }
        public string PlannedResultOfCorrectiveAction { get; set; }
        public string CadevelopmentEvaluation { get; set; }
        public string NotDevelopmentCacomment { get; set; }
        public string EvaluationAccordRecomForPrepOfCa { get; set; }
        public string EvalAccordRecomForPrepOfCacomment { get; set; }
        public string CainAccordOrderOfVerifObject { get; set; }
        public string FactPeriodOfCaexecution { get; set; }
        public int? EvaluationCheckMarkOnCa { get; set; }
        public string ReportImplementOfTheApprovedCa { get; set; }
        public int? CorrectiveActionState { get; set; }
        public string CorrectiveActionStateComment { get; set; }
        public string ConclusionCorrectiveActionEffectEvaluation { get; set; }
        public int? CorrectiveActionEffectEvaluation { get; set; }
        public bool? UsedRecommendationInPca { get; set; }
        public string CommentOnUsedRecommendationInPca { get; set; }
        public string EvaluationOfPostControlNeed { get; set; }
        public string MonitoringOfficerFirstName { get; set; }
        public string MonitoringOfficerLastName { get; set; }
        public string MonitoringOfficerPatronymic { get; set; }
        public string Note { get; set; }
        public DateTime PlannedExecutionDate { get; set; }
        public int CorrectiveActionType { get; set; }
    }
}
