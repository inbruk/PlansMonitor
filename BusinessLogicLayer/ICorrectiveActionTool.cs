using System;
using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface ICorrectiveActionTool
    {
        int GetAllItemsCount();
        List<DTO.CorrectiveAction> ReadAll();
        void Create1(DTO.CorrectiveAction newDTO);
        DTO.CorrectiveAction Read1(int id);
        void Update1(DTO.CorrectiveAction dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTO.CorrectiveAction> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount(int? correctivaActionState, DateTime? startOfActionPeriod, DateTime? endOfActionPeriod);
        List<DTO.CorrectiveActionFull> EnlistView(
            int? correctivaActionState, DateTime? startOfActionPeriod, DateTime? endOfActionPeriod, 
            int? firstRowNumber, int? rowsCount
        );
    }
}
