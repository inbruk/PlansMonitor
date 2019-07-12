using System;
using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IAuditTool
    {
        int GetAllItemsCount();
        List<DTO.Audit> ReadAll();
        void Create1(DTO.Audit newDTO);
        DTO.Audit Read1(int id);
        void Update1(DTO.Audit dtoItem);
        void Delete1(int id);

        int GetViewItemsCount(int? bussProc, int? auditObject, string verifPeriond);
        List<DTO.AuditFull> EnlistView(
            int? bussProc, int? auditObject, string verifPeriond, 
            int? firstRowNumber, int? rowsCount
        );
    }
}
