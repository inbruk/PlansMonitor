using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.DataTransferObjects.Dictionaries;
using BusinessLogicLayer.DataTransferObjects.Views;
using BusinessLogicLayer.Tools;

namespace BusinessLogicLayer.Infrastructure
{
    public static class MainObjectsHolder
    {
        private static Audit _currAudit = null;
        private static Remark _currRemark = null;
        private static CorrectiveAction _currCorrectiveAction = null;

        public static Audit CurrentAudit { get { return _currAudit; } }
        public static Remark CurrentRemark { get { return _currRemark; } }
        public static CorrectiveAction CurrentCorrectiveAction { get { return _currCorrectiveAction; } } 

        private static AuditTool _aTool = new AuditTool();
        private static RemarkTool _rTool = new RemarkTool();
        private static CorrectiveActionTool _caTool = new CorrectiveActionTool();
        
        public static void UpdateAuditById( int id) 
        {
            _currAudit = _aTool.Enlist1(id);
        }
        public static void UpdateRemarkById(int id)
        {
            _currRemark = _rTool.Enlist1(id);
        }
        public static void UpdateCorrectiveActionById(int id)
        {
            _currCorrectiveAction = _caTool.Enlist1(id);
        }
    }
}
