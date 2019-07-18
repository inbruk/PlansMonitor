using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IUserRoleTool
    {
        int GetAllItemsCount();
        List<DTOTbl.UserRole> ReadAll();
        DTOTbl.UserRole Read1(int id);
    }
}
