using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    public class FileStorageTool : IFileStorageTool
    {
        private FileStorageCrud1N currCRUD1N = new FileStorageCrud1N();
        private FileStorageViewEnlister currViewEnlister = new FileStorageViewEnlister();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTO.FileStorage> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTO.FileStorage newDTO) { currCRUD1N.Create1(newDTO); }
        public DTO.FileStorage Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTO.FileStorage dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTO.FileStorage> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount( string filterFullFileName)
        {
            return currViewEnlister.GetItemsCount( x => (x.Name + "." + x.Extention).Contains(filterFullFileName) );
        }
        public List<DTO.FileStorageFull> EnlistView( string filterFullFileName, int? firstRowNumber, int? rowsCount )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (x.Name + "." + x.Extention).Contains(filterFullFileName),
                    null,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
