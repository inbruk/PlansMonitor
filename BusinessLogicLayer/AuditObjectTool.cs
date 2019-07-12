using System.Collections.Generic;

using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.CRUD1NAndViewEnlister;

namespace BusinessLogicLayer
{
    // тут будут только методы необходимые от БЛ (и доступные) в других слоях
    public class AuditObjectTool : IAuditObjectTool
    {
        private AuditObjectCrud1 currCRUD1 = new AuditObjectCrud1();

        public int GetAllItemsCount() { return currCRUD1.GetAllItemsCount(); }
        public List<DTO.AuditObject> ReadAll() { return currCRUD1.ReadAll(); }
        public void Create1(DTO.AuditObject newDTO) { currCRUD1.Create1(newDTO); }
        public DTO.AuditObject Read1(int id) { return currCRUD1.Read1(id); }
        public void Update1(DTO.AuditObject dtoItem) { currCRUD1.Update1(dtoItem); }
        public void Delete1(int id) { currCRUD1.Delete1(id); }
    }
}
