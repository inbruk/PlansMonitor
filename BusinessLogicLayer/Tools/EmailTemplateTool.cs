using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;
using BusinessLogicLayer.DataTransferObjects.Views;
using BusinessLogicLayer.Tools.Interfaces;

namespace BusinessLogicLayer.Tools
{
    public class EmailTemplateTool : IEmailTemplateTool
    {
        private BLRep.EmailTemplate currCRUD1N = new BLRep.EmailTemplate();
        private BLVwEn.EmailTemplate currViewEnlister = new BLVwEn.EmailTemplate();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTOTbl.EmailTemplate> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTOTbl.EmailTemplate newDTO) { currCRUD1N.Create1(newDTO); }
        public DTOTbl.EmailTemplate Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTOTbl.EmailTemplate dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTOTbl.EmailTemplate> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount()
        {
            return currViewEnlister.GetItemsCount
                (
                    null
                );
        }
        public List<DTOVw.EmailTemplate> EnlistView(List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs, int? firstRowNumber, int? rowsCount )
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
