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
using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using BusinessLogicLayer.Infrastructure;

namespace BusinessLogicLayer.Repositories
{
    internal class UserRole : CRUD1Base<DTOTbl.UserRole, TblUserRole, int>
    {
        protected override int GetLastCreatedId() { return _lastCreatedItem.Id;  }
        protected override void InsertIdInDTO(DTOTbl.UserRole dtoItem, int idValue) { dtoItem.Id = idValue; }
        protected override int GetIdFromDTO(DTOTbl.UserRole dtoItem) { return dtoItem.Id; }
        protected override List<int> GetIdListFromDTOList(List<DTOTbl.UserRole> dtoList) { return dtoList.Select( x => x.Id ).ToList(); }
        protected override Expression<Func<TblUserRole, bool>> GetPredicate_WhereXEqId(int idValue) { return x => x.Id == idValue; }
        protected override Expression<Func<TblUserRole, bool>> GetPredicate_WhereXInIdList(List<int> idList) { return x => idList.Contains(x.Id); }
    }
}
