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
    internal class EmailTemplateCrud1 : CRUD1Base<DTO.EmailTemplate, TblEmailTemplate, int>
    {
        protected override int GetLastCreatedId() { return _lastCreatedItem.Id; }
        protected override void InsertIdInDTO(DTO.EmailTemplate dtoItem, int idValue) { dtoItem.Id = idValue; }
        protected override int GetIdFromDTO(DTO.EmailTemplate dtoItem) { return dtoItem.Id; }
        protected override List<int> GetIdListFromDTOList(List<DTO.EmailTemplate> dtoList) { return dtoList.Select(x => x.Id).ToList(); }
        protected override Expression<Func<TblEmailTemplate, bool>> GetPredicate_WhereXEqId(int idValue) { return x => x.Id == idValue; }
        protected override Expression<Func<TblEmailTemplate, bool>> GetPredicate_WhereXInIdList(List<int> idList) { return x => idList.Contains(x.Id); }
    }

}
