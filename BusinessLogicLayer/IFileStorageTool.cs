using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IFileStorageTool
    {
        int GetAllItemsCount();
        List<DTO.FileStorage> ReadAll();
        void Create1(DTO.FileStorage newDTO);
        DTO.FileStorage Read1(int id);
        void Update1(DTO.FileStorage dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTO.FileStorage> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount(string filterFullFileName);
        List<DTO.FileStorageFull> EnlistView(string filterFullFileName, int? firstRowNumber, int? rowsCount);
    }
}
