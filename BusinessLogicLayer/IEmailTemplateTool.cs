using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IEmailTemplateTool
    {
        int GetAllItemsCount();
        List<DTO.EmailTemplate> ReadAll();
        void Create1(DTO.EmailTemplate newDTO);
        DTO.EmailTemplate Read1(int id);
        void Update1(DTO.EmailTemplate dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTO.EmailTemplate> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount();
        List<DTO.EmailTemplateFull> EnlistView(int? firstRowNumber, int? rowsCount);
    }
}
