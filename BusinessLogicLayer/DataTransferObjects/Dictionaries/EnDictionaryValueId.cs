using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects.Dictionaries
{
    public enum EnDictionaryValueId
    {
        Action4AuditLog_Create = 28,
        Action4AuditLog_Read = 29,
        Action4AuditLog_Update = 30,
        Action4AuditLog_Delete = 47,
        Action4AuditLog_List = 51,
        Action4AuditLog_ViewHistory = 27,
        Action4AuditLog_Export = 52,
        Action4AuditLog_ChangePassword = 53,
        Action4AuditLog_DataLoading = 10,
        Action4AuditLog_CancelDataLoading = 11,
        Action4AuditLog_Import = 37,
        Action4AuditLog_Send = 12,
        Action4AuditLog_Lock = 13,
        Action4AuditLog_Unlock = 14,
        Action4AuditLog_Restore = 15,
        Action4AuditLog_Unload = 16,
        Action4AuditLog_FileView = 31,
        Action4AuditLog_Find = 54,
        Action4AuditLog_ViewingFiles = 55,
        Action4AuditLog_CreateNewAccount = 56,

        Screen4AuditLog_AuthorizationScreen = 25,
        Screen4AuditLog_MainScreen = 26,
        Screen4AuditLog_MainScreenHistoryOfChanges = 18,
        Screen4AuditLog_GlobalSearch = 57,
        Screen4AuditLog_AuditFormNotificationSendLogging = 20,
        Screen4AuditLog_CAFormCommonInfo = 19,
        Screen4AuditLog_AuditFormFileStorage = 24,
        Screen4AuditLog_AuditFormFileStoragePreview = 23,
        Screen4AuditLog_AuditFormMainScreen = 22,
        Screen4AuditLog_AuditFormStatistics = 21,
        Screen4AuditLog_RemarkForm = 17,
        Screen4AuditLog_CorrectiveActionForm = 58,
        Screen4AuditLog_CAFormComments = 61,
        Screen4AuditLog_CAFormFileList = 60,
        Screen4AuditLog_AdminUserManagement = 64,
        Screen4AuditLog_AdminAuditLog = 63,
        Screen4AuditLog_AdminTemplateTuning = 62,

        AuditSubject_SVA = 1,
        AuditSubject_DkIUr = 36,

        MonitoringProgressStatus_Formation = 48,
        MonitoringProgressStatus_PCAIsFormed = 49,
        MonitoringProgressStatus_PrimaryVerification = 50,
        MonitoringProgressStatus_SecondaryVerification = 34,
        MonitoringProgressStatus_Revision = 59,
        MonitoringProgressStatus_Completed = 32,

        BusinessProcess_PostControl4InternalAudits = 3,
        BusinessProcess_PostControl4ExternalAudits = 2,

        TotalAssessmentLevel_Moderate = 4,
        TotalAssessmentLevel_Significant = 5,
        TotalAssessmentLevel_Critical = 38,

        RemarkType_Violation = 6,
        RemarkType_Disadvantage = 39,

        EvaluationCheckMarkOnCA_Done = 7,
        EvaluationCheckMarkOnCA_NotDone = 41,
        EvaluationCheckMarkOnCA_InProgress = 40,

        CorrectiveActionEffectEvaluation_Effectively = 43,
        CorrectiveActionEffectEvaluation_Inefficient = 33,
        CorrectiveActionState_Execution = 35,
        CorrectiveActionState_Expired = 65,
        CorrectiveActionState_PrimaryVerification = 66,
        CorrectiveActionState_SecondaryVerification = 67,
        CorrectiveActionState_Revision = 68,
        CorrectiveActionState_ExecutedOnTime = 69,
        CorrectiveActionState_ExecutedInDeadlineViolation = 70,
        CorrectiveActionState_Missing = 71,
        CorrectiveActionState_NotPerformed = 72,

        EMailTemplateType_Request4AddRemarks = 42,
        EMailTemplateType_Req2RespPersonSubjectAuditor = 44,
        EMailTemplateType_NotificationApproachingDateOfCAPreformance = 45,
        EMailTemplateType_NotificationAboutMaturityDateOfCAPreformance = 46,
        EMailTemplateType_NotificationExpirationTermOfCAPreformance = 8,
        EMailTemplateType_NotificationAboutDnldQuarterlyReportOnPCAPerform = 9,

        EMailTemplateTag4Audit_Name	    =73,
        EMailTemplateTag4Audit_Object	=74,
        EMailTemplateTag4Audit_Period	=75,
        EMailTemplateTag4Audit_Ground	=76,
        EMailTemplateTag4RemarkInternalAudit_ReportSubsNum	=77,
        EMailTemplateTag4RemarkInternalAudit_Description	=79,
        EMailTemplateTag4RemarkExternalAudit_SectAttach	    =80,
        EMailTemplateTag4RemarkExternalAudit_ViolaContent	=81,
        EMailTemplateTag4CAInternalAudit_CA	             =82,
        EMailTemplateTag4CAInternalAudit_PlanExeDate	=83,
        EMailTemplateTag4CAInternalAudit_ExecOfficer	=84,
        EMailTemplateTag4CAInternalAudit_FactExePeriod	=85,
        EMailTemplateTag4CAExternalAudit_CA	=87,
        EMailTemplateTag4CAExternalAudit_PlanExeDate	=88,
        EMailTemplateTag4CAExternalAudit_ExecOfficer	=89,
        EMailTemplateTag4CAExternalAudit_FactExePeriod	=90,

        EMailConverterError_TagNotFound	                =91,
        EMailConverterError_TagNotFinishedProperly	    =92,
        EMailConverterError_TagTerminatedBySpaceOrEof	=93,

    }
}
