using BusinessLogicLayer.Infrastructure;
using System.Collections.Generic;
using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;
using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

namespace BusinessLogicLayer.Tools
{
    public class RemarkTool : IRemarkTool
    {
        private BLRep.Remark currCRUD1N = new BLRep.Remark();
        private BLVwEn.Remark currViewEnlister = new BLVwEn.Remark();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTOTbl.Remark> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTOTbl.Remark newDTO) { currCRUD1N.Create1(newDTO); }
        public DTOTbl.Remark Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTOTbl.Remark dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTOTbl.Remark> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount()
        {
            return currViewEnlister.GetItemsCount
                (
                    null
                );
        }
        public List<DTOVw.Remark> EnlistView(List<ViewEnlisterOrderItem4DTO> orderDescs, int? firstRowNumber, int? rowsCount )
        {
            return 
                currViewEnlister.Enlist
                (
                    null,
                    orderDescs,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
