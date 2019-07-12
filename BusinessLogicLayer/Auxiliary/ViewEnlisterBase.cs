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
    internal abstract class ViewEnlisterBase<DVO, VW, TID>         
            where DVO : class
            where VW : class
    {
        protected readonly IMapper mapper = null;
        public ViewEnlisterBase()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<VW, DVO>();
                    cfg.CreateMap<DVO, VW>();
                }
            );
            mapper = config.CreateMapper();
        }

        protected ActualPlansMonitorContext CurrDBCtx
        {
            get
            {
                return PCAMonitorDBContextHolder.Get();
            }
        }

        public const int MaximumAcceptablePerformedRowsCount = 100;

        protected void CheckPerformedRowsCountAndThrowException(int rowsCount)
        {
            if (rowsCount > MaximumAcceptablePerformedRowsCount)
            {
                throw new Exception("Превышено количество строк, обрабатываемых за 1 запрос. См. MaximumAcceptablePerformedRowsCount");
            }
        }

        private IQueryable<VW> GetQuery
            (
                Expression<Func<VW, bool>> wherePredicate,
                List<ViewEnlisterOrderItem<VW>> orderDescriptions,
                int? firstRowNumber,
                int? rowsCount
            )
        {
            var query = CurrDBCtx.Set<VW>().Select(x => x);

            if (wherePredicate != null)
                query = query.Where(wherePredicate);

            if (orderDescriptions != null)
                throw new Exception("EnlistView с поддержкой многих сортировок возр./убыв. пока не реализован !");

            if (firstRowNumber != null)
                query = query.Skip((int)firstRowNumber);

            if (rowsCount != null)
                query = query.Take((int)rowsCount);

            return query;
        }

        public int GetItemsCount( Expression<Func<VW, bool>> wherePredicate )
        {
            var query = GetQuery
                (
                    wherePredicate,
                    null,
                    null,
                    null
                );

            int count = query.Count();
            return count;
        }

        public List<DVO> Enlist
            (
                Expression<Func<VW, bool>> wherePredicate,
                List<ViewEnlisterOrderItem<VW>> orderDescriptions, 
                int? firstRowNumber,
                int? rowsCount
            )
        {
            var query = GetQuery
                (
                    wherePredicate,
                    orderDescriptions,
                    firstRowNumber,
                    rowsCount
                );

            List<VW> vwList = query.ToList();

            // пока предполагаем, что это не вызовет ошибок, надо тестить
            // CheckPerformedRowsCountAndThrowException( vwList.Count() );            

            List<DVO> result = mapper.Map<List<VW>, List<DVO>>(vwList);
            return result;
        }
    }
}
