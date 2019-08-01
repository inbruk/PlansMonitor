using System;
using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

namespace BusinessLogicLayer.Tools.Interfaces
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface ICorrectiveActionTool
    {
        int GetAllItemsCount();
        List<DTOTbl.CorrectiveAction> ReadAll();
        void Create1(DTOTbl.CorrectiveAction newDTO);
        DTOTbl.CorrectiveAction Read1(int id);
        void Update1(DTOTbl.CorrectiveAction dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTOTbl.CorrectiveAction> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount(int? correctivaActionState, DateTime? startOfActionPeriod, DateTime? endOfActionPeriod);
        DTOVw.CorrectiveAction Enlist1(int id);
        List<DTOVw.CorrectiveAction> EnlistView(
            int? correctiveActionState, DateTime? startOfActionPeriod, DateTime? endOfActionPeriod,
            List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs,
            int? firstRowNumber, int? rowsCount
        );
    }
}
