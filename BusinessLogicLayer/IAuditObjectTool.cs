using System.Collections.Generic;
using DTO = BusinessLogicLayer.DataTransferObjects;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IAuditObjectTool
    {
        int GetAllItemsCount();
        List<DTO.AuditObject> ReadAll();
        void Create1(DTO.AuditObject newDTO);
        DTO.AuditObject Read1(int id);
        void Update1(DTO.AuditObject dtoItem);
        void Delete1(int id);
    }
}
