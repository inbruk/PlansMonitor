using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblRemark
    {
        public int Id { get; set; }
        public int? ReportSubsectionNumber { get; set; }
        public int BusinessProcess { get; set; }
        public int RemarkType { get; set; }
        public string RemarkDescription { get; set; }
        public string RevealedRemarkReason { get; set; }
        public string RevealedRemarkConsequences { get; set; }
        public long? QuantitativeAssessmentLossesRealized { get; set; }
        public long? QuantitativeAssessmentPotentialLosses { get; set; }
        public long? QuantitativeAssessmentTotalLoss { get; set; }
        public string QualitativeAssessment { get; set; }
        public int? ResponsibleAuditor { get; set; }
        public int? TotalAssessmentLevel { get; set; }
        public string PersonCmrecommendations { get; set; }
        public int? PageNumber { get; set; }
        public int? SectionAttachment { get; set; }
        public string ViolationContent { get; set; }
        public int? ViolationValuation { get; set; }
        public int? ResponsibleController { get; set; }
        public string AuditObjectComments { get; set; }
        public string AuditObjectFinalAssessment { get; set; }
        public string ViolationsAndDeficienciesCauses { get; set; }

        public virtual TblUser ResponsibleAuditorNavigation { get; set; }
        public virtual TblUser ResponsibleControllerNavigation { get; set; }
    }
}
