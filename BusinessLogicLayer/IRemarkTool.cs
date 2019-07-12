using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IRemarkTool
    {
        int GetAllItemsCount();
        List<DTO.Remark> ReadAll();
        void Create1(DTO.Remark newDTO);
        DTO.Remark Read1(int id);
        void Update1(DTO.Remark dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTO.Remark> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount();
        List<DTO.RemarkFull> EnlistView(int? firstRowNumber, int? rowsCount);
    }
}
