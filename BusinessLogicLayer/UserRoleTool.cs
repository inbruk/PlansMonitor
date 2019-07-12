using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // тут будут только методы необходимые от БЛ (и доступные) в других слоях
    public class UserRoleTool : IUserRoleTool
    {
        private UserRoleCrud1 currCRUD1 = new UserRoleCrud1();

        public int GetAllItemsCount() { return currCRUD1.GetAllItemsCount(); }
        public List<DTO.UserRole> ReadAll() { return currCRUD1.ReadAll(); }
        public DTO.UserRole Read1(int id) { return currCRUD1.Read1(id); }
    }
}
