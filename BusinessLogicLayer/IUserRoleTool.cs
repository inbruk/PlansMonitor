using System.Collections.Generic;
using DTO = BusinessLogicLayer.DataTransferObjects;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IUserRoleTool
    {
        int GetAllItemsCount();
        List<DTO.UserRole> ReadAll();
        DTO.UserRole Read1(int id);
    }
}
