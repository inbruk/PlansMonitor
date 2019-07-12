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

using Patterns;

namespace BusinessLogicLayer.Auxiliary
{
    internal abstract class CRUD1Base<DTO, TBL, TID> : UseCtxGenericWithMapping<DTO, TBL, TID>, IRepository1<DTO, TID>
         where DTO : class
         where TBL : class
    {
        public CRUD1Base()
            : base()
        {
        }

        public List<DTO> ReadAll()
        {   
            // пока предполагаем, что это не вызовет ошибок, надо тестить
            //int allItemsCount = GetAllItemsCount();
            //CheckPerformedRowsCountAndThrowException(allItemsCount);

            List<TBL> listOfProxy = CurrDBCtx.Set<TBL>().ToList();
            List<DTO> result = mapper.Map< List<TBL>, List<DTO> >(listOfProxy);
            return result;
        }

        public void Create1(DTO newDTO)
        {
            _lastCreatedItem = mapper.Map<DTO, TBL>(newDTO);

            try
            {
                CurrDBCtx.Set<TBL>().Add(_lastCreatedItem);
                CurrDBCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }

            TID lastCreatedId = GetLastCreatedId();
            InsertIdInDTO(newDTO, lastCreatedId);
        }

        protected DTO Read1(Expression<Func<TBL, bool>> predicate)
        {
            TBL dataProxyObject = CurrDBCtx.Set<TBL>().SingleOrDefault(predicate);
            DTO resDTO = mapper.Map<TBL, DTO>(dataProxyObject);
            return resDTO;
        }

        // подразумевается что id-ы при update не изменяются !!!
        protected void Update1(DTO upDTO, Expression<Func<TBL, bool>> predicate)
        {
            TBL dataProxyObject = CurrDBCtx.Set<TBL>().SingleOrDefault(predicate);
            mapper.Map<DTO, TBL>(upDTO, dataProxyObject);
            CurrDBCtx.SaveChanges();
        }

        protected void Delete1(Expression<Func<TBL, bool>> predicate)
        {
            TBL dataProxyObject = CurrDBCtx.Set<TBL>().SingleOrDefault(predicate);
            CurrDBCtx.Set<TBL>().Remove(dataProxyObject);
            CurrDBCtx.SaveChanges();
        }

        public DTO Read1(TID id)
        {
            Expression<Func<TBL, bool>> predicat = GetPredicate_WhereXEqId(id);
            DTO result = Read1(predicat);
            return result;
        }

        // подразумевается что id-ы при update не изменяются !!!
        public void Update1(DTO dtoItem)
        {
            TID id = GetIdFromDTO(dtoItem);
            Expression<Func<TBL, bool>> predicat = GetPredicate_WhereXEqId(id);
            Update1(dtoItem, predicat);
        }

        public void Delete1(TID id)
        {
            Expression<Func<TBL, bool>> predicat = GetPredicate_WhereXEqId(id);
            DTO result = Read1(predicat);
        }
    }
}
