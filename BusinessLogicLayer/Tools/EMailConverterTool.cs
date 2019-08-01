using System;
using System.Collections.Generic;
using System.Text;

using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.DataTransferObjects.Views;
using BI = BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Tools.Interfaces;
using BusinessLogicLayer.Tools.Holders;

namespace BusinessLogicLayer.Tools
{
    public class EMailConverterTool : IEMailConverter
    {
        private BI.EMailConverter _eMailConverter = null;

        private void UpdateLowlevelByMainObjects()
        {
            Audit _currentAudit = MainObjectsHolder.CurrentAudit;
            Remark _currentRemark = MainObjectsHolder.CurrentRemark;
            CorrectiveAction _currentCorrectiveAction = MainObjectsHolder.CurrentCorrectiveAction;

            if (_currentAudit == null || _currentRemark == null || _currentCorrectiveAction == null)
            {
                throw new Exception(
                    "EMailConverterTool.EMailConverterTool() до вызова этого конструктора MainObjectsHolder должен быть уже настроен и все внутренние объекты заданы."
                );
            }

            if (_eMailConverter==null)
            {
                _eMailConverter = new BI.EMailConverter(_currentAudit, _currentRemark, _currentCorrectiveAction);
            }
            else
            {
                _eMailConverter.UpdateMainObjects(_currentAudit, _currentRemark, _currentCorrectiveAction);
            }
        }

        public EMailConverterResult ConvertTemplate2Mail(string template)
        {
            UpdateLowlevelByMainObjects(); // обновим на случай изменения осн. объектов
            return _eMailConverter.ConvertTemplate2Mail(template);
        }
    }
}
