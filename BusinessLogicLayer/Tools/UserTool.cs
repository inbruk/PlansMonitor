using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Tools.Interfaces;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;

namespace BusinessLogicLayer.Tools
{
    public class UserTool : IUserTool
    {
        private BLRep.User currCRUD1N = new BLRep.User();
        private BLVwEn.User currViewEnlister = new BLVwEn.User();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTOTbl.User> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTOTbl.User newDTO) { currCRUD1N.Create1(newDTO); }
        public DTOTbl.User Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTOTbl.User dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTOTbl.User> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount( string filterUserName )
        {
            return currViewEnlister.GetItemsCount
                (
                    x => ((filterUserName == null) || (x.FirstName + " " + x.LastName + " " + x.Patronymic).Contains(filterUserName))
                );
        }
        public List<DTOVw.User> EnlistView( string filterUserName, List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs, int? firstRowNumber, int? rowsCount )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (x.FirstName + " " + x.LastName + " " + x.Patronymic).Contains(filterUserName),
                    orderDescs,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
