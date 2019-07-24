using System;
using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

namespace BusinessLogicLayer.Tools.Interfaces
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IAuditLogTool
    {
        int GetAllItemsCount();
        List<DTOTbl.AuditLog> ReadAll();
        void Create1(DTOTbl.AuditLog newDTO);
        DTOTbl.AuditLog Read1(int id);
        void Update1(DTOTbl.AuditLog dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTOTbl.AuditLog> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount(int? userId, DateTime? startTime, DateTime? endTime);
        List<DTOVw.AuditLog> EnlistView(
            int? userId, DateTime? startTime, DateTime? endTime,
            List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs,
            int? firstRowNumber, int? rowsCount
        );
    }
}
