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
    internal abstract class ViewEnlister<DVO, VW, TID>         
            where DVO : class
            where VW : class
    {
        protected readonly IMapper mapper = null;
        public ViewEnlister()
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
        public int GetAllItemsCount()
        {
            int count = CurrDBCtx.Set<VW>().Count();
            return count;
        }

        protected void CheckPerformedRowsCountAndThrowException(int rowsCount)
        {
            if (rowsCount > MaximumAcceptablePerformedRowsCount)
            {
                throw new Exception("Превышено количество строк, обрабатываемых за 1 запрос. См. MaximumAcceptablePerformedRowsCount");
            }
        }

        protected List<DVO> EnlistView 
            (
                Expression<Func<VW, bool>> wherePredicate,
                List<ViewEnlisterOrderItem<VW>> orderDescriptions, 
                int? firstRowNumber,
                int? rowsCount
            )
        {
            // пока предполагаем, что это не вызовет ошибок, надо тестить
            // на случай вытаскивания всех записей из представления
            //if (wherePredicate == null && orderDescriptions == null && firstRowNumber == null && rowsCount == null)
            //{
            //    int allItemsCount = GetAllItemsCount();
            //    CheckPerformedRowsCountAndThrowException(allItemsCount);
            //}

            var query = CurrDBCtx.Set<VW>().Select(x => x);

            if (wherePredicate != null)
                query = query.Where(wherePredicate);

            if (orderDescriptions != null)
                throw new Exception("EnlistView с поддержкой многих сортировок возр./убыв. пока не реализован !");

            if (firstRowNumber != null)
                query = query.Skip( (int)firstRowNumber );

            if (rowsCount != null)
            {
                // пока предполагаем, что это не вызовет ошибок, надо тестить
                //CheckPerformedRowsCountAndThrowException( (int)rowsCount );
                query = query.Take( (int)rowsCount );
            }

            List<VW> vwList = query.ToList();
            List<DVO> result = mapper.Map<List<VW>, List<DVO>>(vwList);
            return result;
        }
    }
}
