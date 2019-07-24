using System;
using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;

namespace BusinessLogicLayer.Tools.Interfaces
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IAuditTool
    {
        int GetAllItemsCount();
        List<DTOTbl.Audit> ReadAll();
        void Create1(DTOTbl.Audit newDTO);
        DTOTbl.Audit Read1(int id);
        void Update1(DTOTbl.Audit dtoItem);
        void Delete1(int id);

        int GetViewItemsCount(int? bussProc, int? auditObject, string verifPeriond);
        List<DTOVw.Audit> EnlistView(
            int? bussProc, int? auditObject, string verifPeriond,
            List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs,
            int? firstRowNumber, int? rowsCount
        );
    }
}
