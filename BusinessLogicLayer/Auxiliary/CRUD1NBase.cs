using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;
using DTO = BusinessLogicLayer.DataTransferObjects;
using System.Linq;

namespace BusinessLogicLayer.Auxiliary
{
    internal abstract class CRUD1NBase<DTO, TBL, TID> : CRUD1Base<DTO, TBL, TID>
         where DTO : class
         where TBL : class
    {
        public CRUD1NBase()
            : base()
        {
        }

        public void CreateN(List<DTO> newDTOList)
        {
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
            Expression<Func<TBL, bool>> predicate = GetPredicate_WhereXInIdList(idList);
            List<DTO> result = ReadN(predicate);
            return result;
        }

        // подразумевается что id-ы при update не изменяются !!!
        public void UpdateN(List<DTO> dtoList)
        {
            List<TID> idList = GetIdListFromDTOList(dtoList);
            Expression<Func<TBL, bool>> predicate = GetPredicate_WhereXInIdList(idList);
            UpdateN(dtoList, predicate);
        }

        public void DeleteN(List<TID> idList)
        {
            Expression<Func<TBL, bool>> predicate = GetPredicate_WhereXInIdList(idList);
            DeleteN(predicate);
        }
    }
}
