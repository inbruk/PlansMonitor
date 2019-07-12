using System;
using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    public class AuditLogTool : IAuditLogTool
    {
        private AuditLogCrud1N currCRUD1N = new AuditLogCrud1N();
        private AuditLogViewEnlister currViewEnlister = new AuditLogViewEnlister();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTO.AuditLog> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTO.AuditLog newDTO) { currCRUD1N.Create1(newDTO); }
        public DTO.AuditLog Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTO.AuditLog dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public void UpdateN(List<DTO.AuditLog> dtoList) { currCRUD1N.UpdateN(dtoList); } 
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
        public List<DTO.AuditLogFull> EnlistView
            (
                int? userId, DateTime? startTime, DateTime? endTime,
                int? firstRowNumber, int? rowsCount
            )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (userId == null || x.UserId == userId) &&
                        (startTime == null || x.Time > startTime) &&
                        (endTime == null || x.Time < endTime),
                    null,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
