using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects.Views
{
    public class Remark
    {
        public int Id { get; set; }
        public int ReportSubsectionNumber { get; set; }
        public int RemarkType { get; set; }
        public string RemarkDescription { get; set; }
        public string RevealedRemarkReason { get; set; }
        public string RevealedRemarkConsequences { get; set; }
        public int QuantitativeAssessmentLossesRealized { get; set; }
        public int QuantitativeAssessmentPotentialLosses { get; set; }
        public int QuantitativeAssessmentTotalLoss { get; set; }
        public string QualitativeAssessment { get; set; }
        public int ResponsibleAuditor { get; set; }
        public int TotalAssessmentLevel { get; set; }
        public string PersonCMRecommendations { get; set; }
        public int PageNumber { get; set; }
        public int SectionAttachment { get; set; }
        public string ViolationContent { get; set; }
        public int ViolationValuation { get; set; }
        public string AuditObjectComments { get; set; }
        public string AuditObjectFinalAssessment { get; set; }
        public string ViolationsAndDeficienciesCauses { get; set; }
        public int ResponsibleAuditorId { get; set; }
        public string ResponsibleAuditorFirstName { get; set; }
        public string ResponsibleAuditorLastName { get; set; }
        public string ResponsibleAuditorPatronymic { get; set; }
        public int ResponsibleControllerId { get; set; }
        public string ResponsibleControllerFirstName { get; set; }
        public string ResponsibleControllerLastName { get; set; }
        public string ResponsibleControllerPatronymic { get; set; }
        public int BusinessProcessPos { get; set; }
        public string BusinessProcessName { get; set; }
        public int TotalAssessmentLevelPos { get; set; }
        public string TotalAssessmentLevelName { get; set; }
        public int RemarkTypePos { get; set; }
        public string RemarkTypeName { get; set; }
    }
}
