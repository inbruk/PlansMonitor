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

        protected List<DVO> EnlistView 
            (
                Expression<Func<VW, bool>> wherePredicate,
                List<ViewEnlisterOrderItem<VW>> orderDescriptions, 
                int? firstRowNumber,
                int? rowsCount
            )
        {
            var currDBCtx = PCAMonitorDBContextHolder.Get();
            var query = currDBCtx.Set<VW>().Select(x => x);

            if (wherePredicate != null)
                query = query.Where(wherePredicate);

            if (orderDescriptions != null)
                throw new Exception("EnlistView с поддержкой Не реализовано !");

            if (firstRowNumber != null)
                query = query.Skip( (int)firstRowNumber );

            if (firstRowNumber != null)
                query = query.Take((int)rowsCount);

            List<VW> vwList = query.ToList();
            List<DVO> result = mapper.Map<List<VW>, List<DVO>>(vwList);
            return result;
        }
    }
}
