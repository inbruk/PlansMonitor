using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    public class RemarkTool : IRemarkTool
    {
        private RemarkCrud1N currCRUD1N = new RemarkCrud1N();
        private RemarkViewEnlister currViewEnlister = new RemarkViewEnlister();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTO.Remark> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTO.Remark newDTO) { currCRUD1N.Create1(newDTO); }
        public DTO.Remark Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTO.Remark dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTO.Remark> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount()
        {
            return currViewEnlister.GetItemsCount
                (
                    null
                );
        }
        public List<DTO.RemarkFull> EnlistView( int? firstRowNumber, int? rowsCount )
        {
            return 
                currViewEnlister.Enlist
                (
                    null,
                    null,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
