using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IRemarkTool
    {
        int GetAllItemsCount();
        List<DTOTbl.Remark> ReadAll();
        void Create1(DTOTbl.Remark newDTO);
        DTOTbl.Remark Read1(int id);
        void Update1(DTOTbl.Remark dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTOTbl.Remark> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount();
        List<DTOVw.Remark> EnlistView(List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs, int? firstRowNumber, int? rowsCount);
    }
}
