using System;
using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;

namespace BusinessLogicLayer.Tools
{
    public class AuditTool : IAuditTool
    {
        private BLRep.Audit currCRUD1N = new BLRep.Audit();
        private BLVwEn.Audit currViewEnlister = new BLVwEn.Audit();

        public int GetAllItemsCount() { return currCRUD1N.GetAllItemsCount(); }
        public List<DTOTbl.Audit> ReadAll() { return currCRUD1N.ReadAll(); }
        public void Create1(DTOTbl.Audit newDTO) { currCRUD1N.Create1(newDTO); }
        public DTOTbl.Audit Read1(int id) { return currCRUD1N.Read1(id); }
        public void Update1(DTOTbl.Audit dtoItem) { currCRUD1N.Update1(dtoItem); }
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
        public List<DTOVw.Audit> EnlistView
            (
                int? bussProc, int? auditObject, string verifPeriond,
                List<DTOVw.ViewEnlisterOrderItem4DTO> orderDescs,
                int? firstRowNumber, int? rowsCount
            )
        {
            return 
                currViewEnlister.Enlist
                (
                    x => (bussProc == null || x.BusinessProcess == bussProc) &&
                        (auditObject == null || x.AuditObjectId == auditObject) &&
                        (verifPeriond == null || x.VerificationPeriod.Contains(verifPeriond)),
                    orderDescs,
                    firstRowNumber,
                    rowsCount
                );
        }
    }
}
