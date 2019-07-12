using System;
using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    public class CorrectiveActionTool : ICorrectiveActionTool
    {
        private CorrectiveActionCrud1N currCRUD1N = new CorrectiveActionCrud1N();
        private CorrectiveActionViewEnlister currViewEnlister = new CorrectiveActionViewEnlister();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTO.CorrectiveAction> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTO.CorrectiveAction newDTO) { currCRUD1N.Create1(newDTO); }
        public DTO.CorrectiveAction Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTO.CorrectiveAction dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTO.CorrectiveAction> dtoList) { currCRUD1N.UpdateN(dtoList); } 
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
        public List<DTO.CorrectiveActionFull> EnlistView
            (
                int? correctiveActionState, DateTime? startOfActionPeriod, DateTime? endOfActionPeriod,
                int? firstRowNumber, int? rowsCount
            )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (correctiveActionState == null || x.CorrectiveActionState == correctiveActionState) &&
                        (startOfActionPeriod == null || x.PlannedExecutionDate > startOfActionPeriod) &&
                        (endOfActionPeriod == null || x.PlannedExecutionDate < endOfActionPeriod),
                    null,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
