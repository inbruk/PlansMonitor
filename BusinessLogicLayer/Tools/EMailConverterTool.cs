using System;
using System.Collections.Generic;
using System.Text;

using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.DataTransferObjects.Views;
using BI = BusinessLogicLayer.Infrastructure;

namespace BusinessLogicLayer.Tools
{
    public class EMailConverterTool
    {
        private BI.EMailConverter _eMailConverter;

        public EMailConverterTool()
        {
            Audit _currentAudit = BI.MainObjectsHolder.CurrentAudit;
            Remark _currentRemark = BI.MainObjectsHolder.CurrentRemark;
            CorrectiveAction _currentCorrectiveAction = BI.MainObjectsHolder.CurrentCorrectiveAction;

            if( _currentAudit==null || _currentRemark==null || _currentCorrectiveAction == null )
            {
                throw new Exception(
                    "EMailConverterTool.EMailConverterTool() до вызова этого конструктора MainObjectsHolder должен быть уже настроен и все внутренние объекты заданы."
                );
            }

            _eMailConverter = new BI.EMailConverter(_currentAudit, _currentRemark, _currentCorrectiveAction);
        }

        public EMailConverterResult ConvertTemplate2Mail(string template)
        {
            return _eMailConverter.ConvertTemplate2Mail(template);
        }
    }
}
