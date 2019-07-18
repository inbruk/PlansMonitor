using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;

using System.Linq;

namespace BusinessLogicLayer.Infrastructure
{
    internal abstract class UseCtxGenericWithMapping<DTO, TBL, TID>
         where DTO : class
         where TBL : class
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

        // все что дальше должно переопределяться в потомках ----------------------------------------------------------------------------------------

        // получение значения автоинкрементного поля Id при создании одной записи 
        protected abstract TID GetLastCreatedId();

        // запись значения Id в DTO объект
        protected abstract void InsertIdInDTO(DTO dtoItem, TID idValue);

        // получить значения Id из DTO объекта
        protected abstract TID GetIdFromDTO(DTO dtoItem);

        // получить список значений Id из списка DTO объектов
        protected abstract List<TID> GetIdListFromDTOList(List<DTO> dtoList);

        // получение предиката для выражения .Where( x=> x.Id==idValue )
        protected abstract Expression<Func<TBL, bool>> GetPredicate_WhereXEqId(TID idValue);

        // получение предиката для выражения .Where( x=> x.Id==idValue() )
        protected abstract Expression<Func<TBL, bool>> GetPredicate_WhereXInIdList(List<TID> idList);
    }
}
