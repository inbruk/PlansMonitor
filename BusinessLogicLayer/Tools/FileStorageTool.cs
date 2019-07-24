using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;

using BusinessLogicLayer.Tools.Interfaces;

namespace BusinessLogicLayer.Tools
{
    public class FileStorageTool : IFileStorageTool
    {
        private BLRep.FileStorage currCRUD1N = new BLRep.FileStorage();
        private BLVwEn.FileStorage currViewEnlister = new BLVwEn.FileStorage();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTOTbl.FileStorage> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTOTbl.FileStorage newDTO) { currCRUD1N.Create1(newDTO); }
        public DTOTbl.FileStorage Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTOTbl.FileStorage dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTOTbl.FileStorage> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount( string filterFullFileName)
        {
            return currViewEnlister.GetItemsCount( x => (x.Name + "." + x.Extention).Contains(filterFullFileName) );
        }
        public List<DTOVw.FileStorage> EnlistView( string filterFullFileName, List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs, int? firstRowNumber, int? rowsCount )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (x.Name + "." + x.Extention).Contains(filterFullFileName),
                    orderDescs,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
