using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IUserTool
    {
        int GetAllItemsCount();
        List<DTOTbl.User> ReadAll();
        void Create1(DTOTbl.User newDTO);
        DTOTbl.User Read1(int id);
        void Update1(DTOTbl.User dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTOTbl.User> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount(string filterUserName);
        List<DTOVw.User> EnlistView(string filterUserName, List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs, int? firstRowNumber, int? rowsCount);
    }
}
