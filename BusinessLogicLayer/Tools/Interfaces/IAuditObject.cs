using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IAuditObjectTool
    {
        int GetAllItemsCount();
        List<DTOTbl.AuditObject> ReadAll();
        void Create1(DTOTbl.AuditObject newDTO);
        DTOTbl.AuditObject Read1(int id);
        void Update1(DTOTbl.AuditObject dtoItem);
        void Delete1(int id);
    }
}
