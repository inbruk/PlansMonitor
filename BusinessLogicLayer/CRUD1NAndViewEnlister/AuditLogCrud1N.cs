using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;
using DTO = BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Auxiliary;

namespace BusinessLogicLayer.CRUD1NAndViewEnlister
{
    internal class AuditLogCrud1N : CRUD1NBase<DTO.AuditLog, TblAuditLog, int>
    {
        protected override int GetLastCreatedId() { return _lastCreatedItem.Id; }
        protected override void InsertIdInDTO(DTO.AuditLog dtoItem, int idValue) { dtoItem.Id = idValue; }
        protected override int GetIdFromDTO(DTO.AuditLog dtoItem) { return dtoItem.Id; }
        protected override List<int> GetIdListFromDTOList(List<DTO.AuditLog> dtoList) { return dtoList.Select(x => x.Id).ToList(); }
        protected override Expression<Func<TblAuditLog, bool>> GetPredicate_WhereXEqId(int idValue) { return x => x.Id == idValue; }
        protected override Expression<Func<TblAuditLog, bool>> GetPredicate_WhereXInIdList(List<int> idList) { return x => idList.Contains(x.Id); }
    }
}
