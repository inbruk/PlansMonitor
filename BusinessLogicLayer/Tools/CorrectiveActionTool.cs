using System;
using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;

using BusinessLogicLayer.Tools.Interfaces;

namespace BusinessLogicLayer.Tools
{
    public class CorrectiveActionTool : ICorrectiveActionTool
    {
        private BLRep.CorrectiveAction currCRUD1N = new BLRep.CorrectiveAction();
        private BLVwEn.CorrectiveAction currViewEnlister = new BLVwEn.CorrectiveAction();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTOTbl.CorrectiveAction> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTOTbl.CorrectiveAction newDTO) { currCRUD1N.Create1(newDTO); }
        public DTOTbl.CorrectiveAction Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTOTbl.CorrectiveAction dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTOTbl.CorrectiveAction> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount(int? correctivaActionState, DateTime? startOfActionPeriod, DateTime? endOfActionPeriod)
        {
            return currViewEnlister.GetItemsCount
                (
                    x => x.CorrectiveActionState == correctivaActionState &&
                        (startOfActionPeriod == null || x.PlannedExecutionDate > startOfActionPeriod) &&
                        (endOfActionPeriod == null || x.PlannedExecutionDate < endOfActionPeriod)
                );
        }
        public DTOVw.CorrectiveAction Enlist1(int id)
        {
            return currViewEnlister.Enlist1(id);
        }
        public List<DTOVw.CorrectiveAction> EnlistView
            (
                int? correctiveActionState, DateTime? startOfActionPeriod, DateTime? endOfActionPeriod,
                List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs,
                int? firstRowNumber, int? rowsCount
            )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (correctiveActionState == null || x.CorrectiveActionState == correctiveActionState) &&
                        (startOfActionPeriod == null || x.PlannedExecutionDate > startOfActionPeriod) &&
                        (endOfActionPeriod == null || x.PlannedExecutionDate < endOfActionPeriod),
                    orderDescs,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
