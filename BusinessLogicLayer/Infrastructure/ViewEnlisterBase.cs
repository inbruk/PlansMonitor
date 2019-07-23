using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;

using Patterns;
using BusinessLogicLayer.DataTransferObjects.Views;

namespace BusinessLogicLayer.Infrastructure
{
    internal abstract class ViewEnlisterBase<DVO, VW>
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

        protected IQueryable<VW> GenerateSortQuery<VW, PT>(IQueryable<VW> query, bool firstTime, bool desc, Expression<Func<VW, PT>> keySelector)
        {
            if (firstTime == true)
            {
                if (desc == false) query = query.OrderBy(keySelector);
                else query = query.OrderByDescending(keySelector);
            }
            else
            {
                IOrderedQueryable<VW> orderedQuery = (IOrderedQueryable<VW>)query;
                if (desc == false) query = orderedQuery.ThenBy(keySelector);
                else query = orderedQuery.ThenByDescending(keySelector);
            }

            return query;
        }

        protected abstract IQueryable<VW> QueryOneSort(IQueryable<VW> query, bool isFirstSort, ViewEnlisterOrderItem4DTO orderDesc);

        private IQueryable<VW> GetQuery
            (
                Expression<Func<VW, bool>> wherePredicate,
                List<ViewEnlisterOrderItem4DTO> orderDescs,
                int? firstRowNumber,
                int? rowsCount
            )
        {
            var query = CurrDBCtx.Query<VW>().Select(x => x);

            if (wherePredicate != null)
                query = query.Where(wherePredicate);

            if (orderDescs != null)
            {
                bool firstTime = true;
                foreach (var item in orderDescs)
                {
                    query = QueryOneSort(query, firstTime, item);
                    firstTime = false;
                }
            }

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
                List<ViewEnlisterOrderItem4DTO> orderDescs, 
                int? firstRowNumber,
                int? rowsCount
            )
        {

            var query = GetQuery
                (
                    wherePredicate,
                    orderDescs,
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
