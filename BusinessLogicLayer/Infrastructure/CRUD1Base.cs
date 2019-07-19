using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Patterns;

namespace BusinessLogicLayer.Infrastructure
{
    internal abstract class CRUD1Base<DTO, TBL> 
        : UseCtxGenericWithMapping<DTO, TBL>, IRepository1<DTO, int>
             where DTO : class, IObjectWithIdProperty<int>
             where TBL : class, IObjectWithIdProperty<int>
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

            int lastCreatedId = _lastCreatedItem.Id;
            newDTO.Id = lastCreatedId;
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

        public DTO Read1(int id)
        {
            Expression<Func<TBL, bool>> predicat = ( x => x.Id==id );
            DTO result = Read1(predicat);
            return result;
        }

        // подразумевается что id-ы при update не изменяются !!!
        public void Update1(DTO dtoItem)
        {
            Update1(dtoItem, x => x.Id == dtoItem.Id);
        }

        public void Delete1(int id)
        {
             DTO result = Read1( x => x.Id==id );
        }
    }
}
