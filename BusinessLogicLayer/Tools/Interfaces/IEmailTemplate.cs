using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IEmailTemplateTool
    {
        int GetAllItemsCount();
        List<DTOTbl.EmailTemplate> ReadAll();
        void Create1(DTOTbl.EmailTemplate newDTO);
        DTOTbl.EmailTemplate Read1(int id);
        void Update1(DTOTbl.EmailTemplate dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTOTbl.EmailTemplate> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount();
        List<DTOVw.EmailTemplate> EnlistView(List<ViewEnlisterOrderItem4DTO> orderDescs, int? firstRowNumber, int? rowsCount);
    }
}
