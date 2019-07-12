using System;
using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IAuditLogTool
    {
        int GetAllItemsCount();
        List<DTO.AuditLog> ReadAll();
        void Create1(DTO.AuditLog newDTO);
        DTO.AuditLog Read1(int id);
        void Update1(DTO.AuditLog dtoItem);
        void Delete1(int id);

        void UpdateN(List<DTO.AuditLog> dtoList);
        void DeleteN(List<int> idList);

        int GetViewItemsCount(int? userId, DateTime? startTime, DateTime? endTime);
        List<DTO.AuditLogFull> EnlistView(
            int? userId, DateTime? startTime, DateTime? endTime, 
            int? firstRowNumber, int? rowsCount
        );
    }
}
