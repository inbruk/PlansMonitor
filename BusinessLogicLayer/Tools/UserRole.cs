using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;

namespace BusinessLogicLayer.Tools
{
    // тут будут только методы необходимые от БЛ (и доступные) в других слоях
    public class UserRoleTool : IUserRoleTool
    {
        private BLRep.UserRole currCRUD1 = new BLRep.UserRole();

        public int GetAllItemsCount() { return currCRUD1.GetAllItemsCount(); }
        public List<DTOTbl.UserRole> ReadAll() { return currCRUD1.ReadAll(); }
        public DTOTbl.UserRole Read1(int id) { return currCRUD1.Read1(id); }
    }
}
