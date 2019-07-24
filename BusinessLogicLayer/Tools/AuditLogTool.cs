using System;
using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;

using BusinessLogicLayer.Tools.Interfaces;

namespace BusinessLogicLayer.Tools
{
    public class AuditLogTool : IAuditLogTool
    {
        private BLRep.AuditLog currCRUD1N = new BLRep.AuditLog();
        private BLVwEn.AuditLog currViewEnlister = new BLVwEn.AuditLog();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTOTbl.AuditLog> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTOTbl.AuditLog newDTO) { currCRUD1N.Create1(newDTO); }
        public DTOTbl.AuditLog Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTOTbl.AuditLog dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTOTbl.AuditLog> dtoList) { currCRUD1N.UpdateN(dtoList); } 
        public void DeleteN(List<int> idList) { currCRUD1N.DeleteN(idList); }

        public int GetViewItemsCount(int? userId, DateTime? startTime, DateTime? endTime)
        {
            return currViewEnlister.GetItemsCount
                (
                    x => (userId == null || x.UserId==userId) &&
                        (startTime == null || x.Time > startTime) &&
                        (endTime == null || x.Time < endTime)
                );
        }
        public List<DTOVw.AuditLog> EnlistView
            (
                int? userId, DateTime? startTime, DateTime? endTime,
                List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs,
                int? firstRowNumber, int? rowsCount
            )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (userId == null || x.UserId == userId) &&
                        (startTime == null || x.Time > startTime) &&
                        (endTime == null || x.Time < endTime),
                    orderDescs,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
