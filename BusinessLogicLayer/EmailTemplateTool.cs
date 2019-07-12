using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    public class EmailTemplateTool : IEmailTemplateTool
    {
        private EmailTemplateCrud1N currCRUD1N = new EmailTemplateCrud1N();
        private EmailTemplateViewEnlister currViewEnlister = new EmailTemplateViewEnlister();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTO.EmailTemplate> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTO.EmailTemplate newDTO) { currCRUD1N.Create1(newDTO); }
        public DTO.EmailTemplate Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTO.EmailTemplate dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTO.EmailTemplate> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount()
        {
            return currViewEnlister.GetItemsCount
                (
                    null
                );
        }
        public List<DTO.EmailTemplateFull> EnlistView( int? firstRowNumber, int? rowsCount )
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
