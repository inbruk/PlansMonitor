using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;

using BLRep = BusinessLogicLayer.Repositories;
using BLVwEn = BusinessLogicLayer.ViewEnlisters;

namespace BusinessLogicLayer.Tools
{
    // тут будут только методы необходимые от БЛ (и доступные) в других слоях
    public class AuditObjectTool : IAuditObjectTool
    {
        private BLRep.AuditObject currCRUD1 = new BLRep.AuditObject();

        public int GetAllItemsCount() { return currCRUD1.GetAllItemsCount(); }
        public List<DTOTbl.AuditObject> ReadAll() { return currCRUD1.ReadAll(); }
        public void Create1(DTOTbl.AuditObject newDTO) { currCRUD1.Create1(newDTO); }
        public DTOTbl.AuditObject Read1(int id) { return currCRUD1.Read1(id); }
        public void Update1(DTOTbl.AuditObject dtoItem) { currCRUD1.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1.Delete1(id); }
    }
}
