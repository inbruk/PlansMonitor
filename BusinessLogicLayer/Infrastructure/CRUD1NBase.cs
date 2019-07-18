using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Patterns;

namespace BusinessLogicLayer.Infrastructure
{
    internal abstract class CRUD1NBase<DTO, TBL, TID> : CRUD1Base<DTO, TBL, TID>, IRepositoryN<DTO, TID>
         where DTO : class
         where TBL : class
    {
        public CRUD1NBase()
            : base()
        {
        }

        public void CreateN(List<DTO> newDTOList)
        {
            CheckPerformedRowsCountAndThrowException(newDTOList.Count());

            try
            {
                foreach (DTO currItem in newDTOList)
                {
                    Create1(currItem);
                }
            }
            catch (Exception ex)
            {
                throw ex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }
        }

        public void CreateNFastWithoutIdsAquering(List<DTO> newDTOList)
        {
            CheckPerformedRowsCountAndThrowException(newDTOList.Count());

            try
            {
                List<TBL> tblList = mapper.Map<List<DTO>, List<TBL>>(newDTOList);
                CurrDBCtx.Set<TBL>().AddRange(tblList);
                CurrDBCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }
        }

        protected List<DTO> ReadN(Expression<Func<TBL, bool>> predicate)
        {
            List<TBL> listOfProxy = CurrDBCtx.Set<TBL>().Where(predicate).ToList();
            List<DTO> result = mapper.Map<List<TBL>, List<DTO>>(listOfProxy);
            return result;
        }

        // подразумевается что id-ы при update не изменяются !!!
        private void UpdateN(List<DTO> updDTOList, Expression<Func<TBL, bool>> predicate)
        {
            try
            {
                List<TBL> dataProxyList = CurrDBCtx.Set<TBL>().Where(predicate).ToList<TBL>();
                mapper.Map< List<DTO>, List<TBL> >(updDTOList, dataProxyList);
                CurrDBCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }
        }

        public void DeleteN(Expression<Func<TBL, bool>> predicate)
        {
            List<TBL> listOfProxy = CurrDBCtx.Set<TBL>().Where(predicate).ToList();
            CurrDBCtx.Set<TBL>().RemoveRange(listOfProxy);
            CurrDBCtx.SaveChanges();
        }

        public List<DTO> ReadN(List<TID> idList)
        {
            CheckPerformedRowsCountAndThrowException(idList.Count());

            Expression<Func<TBL, bool>> predicate = GetPredicate_WhereXInIdList(idList);
            List<DTO> result = ReadN(predicate);
            return result;
        }

        // подразумевается что id-ы при update не изменяются !!!
        public void UpdateN(List<DTO> dtoList)
        {
            CheckPerformedRowsCountAndThrowException(dtoList.Count());

            List<TID> idList = GetIdListFromDTOList(dtoList);
            Expression<Func<TBL, bool>> predicate = GetPredicate_WhereXInIdList(idList);
            UpdateN(dtoList, predicate);
        }

        public void DeleteN(List<TID> idList)
        {
            CheckPerformedRowsCountAndThrowException(idList.Count());

            Expression<Func<TBL, bool>> predicate = GetPredicate_WhereXInIdList(idList);
            DeleteN(predicate);
        }
    }
}
