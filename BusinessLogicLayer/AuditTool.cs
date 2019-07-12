using System;
using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    public class AuditTool : IAuditTool
    {
        private AuditCrud1 currCRUD1N = new AuditCrud1();
        private AuditViewEnlister currViewEnlister = new AuditViewEnlister();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTO.Audit> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTO.Audit newDTO) { currCRUD1N.Create1(newDTO); }
        public DTO.Audit Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTO.Audit dtoItem) { currCRUD1N.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1N.Delete1(id); }

        public int GetViewItemsCount(int? bussProc, int? auditObject, string verifPeriond)
        {
            return currViewEnlister.GetItemsCount
                (
                    x => (bussProc == null || x.BusinessProcess == bussProc) &&
                        (auditObject == null || x.AuditObjectId == auditObject) &&
                        (verifPeriond == null || x.VerificationPeriod.Contains(verifPeriond) )
                );
        }
        public List<DTO.AuditFull> EnlistView
            (
                int? bussProc, int? auditObject, string verifPeriond,
                int? firstRowNumber, int? rowsCount
            )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (bussProc == null || x.BusinessProcess == bussProc) &&
                        (auditObject == null || x.AuditObjectId == auditObject) &&
                        (verifPeriond == null || x.VerificationPeriod.Contains(verifPeriond)),
                    null,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
