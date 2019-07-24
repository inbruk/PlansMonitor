using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

namespace BusinessLogicLayer.Tools.Interfaces
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IFileStorageTool
    {
        int GetAllItemsCount();
        List<DTOTbl.FileStorage> ReadAll();
        void Create1(DTOTbl.FileStorage newDTO);
        DTOTbl.FileStorage Read1(int id);
        void Update1(DTOTbl.FileStorage dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTOTbl.FileStorage> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount(string filterFullFileName);
        List<DTOVw.FileStorage> EnlistView(string filterFullFileName, List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs, int? firstRowNumber, int? rowsCount);
    }
}
