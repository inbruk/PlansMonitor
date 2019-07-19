using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;

using Patterns;

namespace BusinessLogicLayer.Infrastructure
{
    internal abstract class UseCtxGenericWithMapping<DTO, TBL>
         where DTO : class, IObjectWithIdProperty<int>
         where TBL : class, IObjectWithIdProperty<int>
    {
        protected readonly IMapper mapper = null;
        public UseCtxGenericWithMapping()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<TBL, DTO>();
                    cfg.CreateMap<DTO, TBL>();
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

        protected TBL _lastCreatedItem = null;

        // это относится к обработке ошибок 

        public const int MaximumAcceptablePerformedRowsCount = 100;

        public int GetAllItemsCount()
        {
            int count = CurrDBCtx.Set<TBL>().Count();
            return count;
        }

        protected void CheckPerformedRowsCountAndThrowException(int rowsCount)
        {
            if (rowsCount > MaximumAcceptablePerformedRowsCount)
            {
                throw new Exception("Превышено количество строк, обрабатываемых за 1 запрос. См. MaximumAcceptablePerformedRowsCount");
            }
        }
    }
}
