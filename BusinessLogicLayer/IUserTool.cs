using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IUserTool
    {
        int GetAllItemsCount();
        List<DTO.User> ReadAll();
        void Create1(DTO.User newDTO);
        DTO.User Read1(int id);
        void Update1(DTO.User dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTO.User> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount(string filterUserName);
        List<DTO.UserFull> EnlistView(string filterUserName, int? firstRowNumber, int? rowsCount);
    }
}
