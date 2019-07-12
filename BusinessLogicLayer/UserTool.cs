using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    public class UserTool : IUserTool
    {
        private UserCrud1N currCRUD1N = new UserCrud1N();
        private UserViewEnlister currViewEnlister = new UserViewEnlister();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTO.User> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTO.User newDTO) { currCRUD1N.Create1(newDTO); }
        public DTO.User Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTO.User dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTO.User> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount( string filterUserName )
        {
            return currViewEnlister.GetItemsCount
                (
                    x => ((filterUserName == null) || (x.FirstName + " " + x.LastName + " " + x.Patronymic).Contains(filterUserName))
                );
        }
        public List<DTO.UserFull> EnlistView( string filterUserName, int? firstRowNumber, int? rowsCount )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (x.FirstName + " " + x.LastName + " " + x.Patronymic).Contains(filterUserName),
                    null,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
