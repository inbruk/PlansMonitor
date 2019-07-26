using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using BusinessLogicLayer.DataTransferObjects.Dictionaries;
using BusinessLogicLayer.DataTransferObjects.Views;
using BusinessLogicLayer.Tools;

namespace BusinessLogicLayer.Infrastructure
{
    public class EMailConverter
    {
        private readonly Audit _currentAudit;
        private readonly Remark _currentRemark;
        private readonly CorrectiveAction _correctiveAction;

        private readonly List<DictionaryValue> _tagDictionaryContent;

        public EMailConverter(Audit currAudit, Remark currRemark, CorrectiveAction currCorrAction)
        {
            _currentAudit = currAudit;
            _currentRemark = currRemark;
            _correctiveAction = currCorrAction;

            DictionaryValueTool dvTool = new DictionaryValueTool();
            _tagDictionaryContent = dvTool.ReadSeveralByDicId((int)EnDictionaryId.EMailTemplateTag);
        }
        private int ConvertString2TagId(string tagStr)
        {
            DictionaryValue dv = _tagDictionaryContent.SingleOrDefault(x => x.Name == tagStr);
            if (dv == null) throw new Exception("EMailConverter.ConvertString2TagId() строка не соответствует ни одному тегу.");
            int tag_id = dv.Position;
            return tag_id;
        }

        private string ConvertTagId2StringWithValue(int tagId)
        {
            switch (tagId)
            {
                case (int)EnDictionaryValueId.EMailTemplateTag4Audit_Name: return _currentAudit.Name;
                case (int)EnDictionaryValueId.EMailTemplateTag4Audit_Object: return _currentAudit.AuditObjectName;
                case (int)EnDictionaryValueId.EMailTemplateTag4Audit_Period: return _currentAudit.VerificationPeriod;
                case (int)EnDictionaryValueId.EMailTemplateTag4Audit_Ground: return _currentAudit.GroundForVerification;

                case (int)EnDictionaryValueId.EMailTemplateTag4RemarkInternalAudit_ReportSubsNum: return _currentRemark.ReportSubsectionNumber.ToString();
                case (int)EnDictionaryValueId.EMailTemplateTag4RemarkInternalAudit_Description: return _currentRemark.RemarkDescription;
                case (int)EnDictionaryValueId.EMailTemplateTag4RemarkExternalAudit_SectAttach: return _currentRemark.SectionAttachment.ToString();
                case (int)EnDictionaryValueId.EMailTemplateTag4RemarkExternalAudit_ViolaContent: return _currentRemark.ViolationContent;

                case (int)EnDictionaryValueId.EMailTemplateTag4CAInternalAudit_CA: return _correctiveAction.Name;
                case (int)EnDictionaryValueId.EMailTemplateTag4CAInternalAudit_PlanExeDate: return _correctiveAction.PlannedExecutionDate.ToString();
                case (int)EnDictionaryValueId.EMailTemplateTag4CAInternalAudit_ExecOfficer:
                    return _correctiveAction.ExecutiveOfficerFirstName + _correctiveAction.ExecutiveOfficerLastName + _correctiveAction.ExecutiveOfficerPatronymic;
                case (int)EnDictionaryValueId.EMailTemplateTag4CAInternalAudit_FactExePeriod: return _correctiveAction.FactPeriodOfCAExecution;
                case (int)EnDictionaryValueId.EMailTemplateTag4CAExternalAudit_CA: return _correctiveAction.Name;
                case (int)EnDictionaryValueId.EMailTemplateTag4CAExternalAudit_PlanExeDate: return _correctiveAction.PlannedExecutionDate.ToString();
                case (int)EnDictionaryValueId.EMailTemplateTag4CAExternalAudit_ExecOfficer:
                    return _correctiveAction.ExecutiveOfficerFirstName + _correctiveAction.ExecutiveOfficerLastName + _correctiveAction.ExecutiveOfficerPatronymic;
                case (int)EnDictionaryValueId.EMailTemplateTag4CAExternalAudit_FactExePeriod: return _correctiveAction.FactPeriodOfCAExecution;

                default: throw new Exception("EMailConverter.ConvertString2TagId() строка не соответствует ни одному тегу.");
            }
        }

        private enum EnControlSymbol
        {
            LeftCurlyBracket = 0,
            RightCurlyBracket = 1,
            Space = 2,
            EndOfLine = 3,
            EndOfMessage = 4
        }

        private struct NextControlSymbolAndPos
        {
            public EnControlSymbol NextControlSymbol;
            public int Position;
            public string BeforeSubstring;
            public string AfterSubstring;
        }

        private NextControlSymbolAndPos Scan4NextControlSymbol( string theRestOfTheMessage )
        {
            NextControlSymbolAndPos result = new NextControlSymbolAndPos();

            int i;
            int length = theRestOfTheMessage.Length;
            for (i=0; i<length-1; i++)
            {
                Char currChar = theRestOfTheMessage[i];
                switch (currChar)
                {
                    case '{': result.NextControlSymbol = EnControlSymbol.LeftCurlyBracket; break;
                    case '}': result.NextControlSymbol = EnControlSymbol.RightCurlyBracket; break;
                    case ' ': result.NextControlSymbol = EnControlSymbol.Space; break;
                    case '\n': result.NextControlSymbol = EnControlSymbol.EndOfLine; break;
                    default : break;
                }
            }
            if ( i == length-1 ) result.NextControlSymbol = EnControlSymbol.EndOfMessage;

            result.BeforeSubstring = theRestOfTheMessage.Substring(0, i-1);
            result.AfterSubstring = theRestOfTheMessage.Substring(i+1, length-(i+1) );

            return result;
        }

        public string ConvertTemplate2Mail(string template)
        {
            bool tagStarted = false;
            string result = "";
            while( true )
            {
                NextControlSymbolAndPos currItem = Scan4NextControlSymbol(template);


                // if( currItem.NextControlSymbol)


                if( currItem.NextControlSymbol==EnControlSymbol.EndOfLine )
                {
                    result += currItem.BeforeSubstring;
                    break;
                }
            }

            return result;
        }
    }
}
