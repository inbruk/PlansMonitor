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

namespace BusinessLogicLayer.CRUD
{
    internal abstract class CRUDWithMappingBase<DTO, TBL, TID>
         where DTO : class
         where TBL : class
    {
        private readonly IMapper mapper = null;
        public CRUDWithMappingBase()
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

        // получение значения автоинкрементного поля Id при создании одной записи 
        protected abstract TID GetLastCreatedId();

        // запись значения Id в DTO объект
        protected abstract void InsertIdInDTO(DTO dtoItem, TID idValue);

        protected List<DTO> ConvertTBL2DTO(List<TBL> listOfProxy)
        {
            List<DTO> result = new List<DTO>();
            foreach (TBL currProxy in listOfProxy)
            {
                DTO resDTO = mapper.Map<TBL, DTO>(currProxy);
                result.Add(resDTO);
            }
            return result;
        }

        public void Create(DTO newDTO)
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

        public void CreateSeveral(List<DTO> newDTOList)
        {
            try
            {
                foreach (DTO currItem in newDTOList)
                {
                    Create(currItem);
                }
            }
            catch (Exception ex)
            {
                throw ex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }
        }

        public void CreateSeveralFastWithoutIdsAquering(List<DTO> newDTOList)
        {
            try
            {
                foreach (DTO currItem in newDTOList)
                {
                    _lastCreatedItem = mapper.Map<DTO, TBL>(currItem);
                    CurrDBCtx.Set<TBL>().Add(_lastCreatedItem);
                }
                CurrDBCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            }
        }

        public List<DTO> ReadAll()
        {
            List<TBL> listOfProxy = CurrDBCtx.Set<TBL>().ToList();
            List<DTO> result = ConvertTBL2DTO(listOfProxy);
            return result;
        }

        protected List<DTO> ReadSeveral(Expression<Func<TBL, bool>> predicate)
        {
            List<TBL> listOfProxy = CurrDBCtx.Set<TBL>().Where(predicate).ToList();

            List<DTO> result = ConvertTBL2DTO(listOfProxy);
            return result;
        }

        protected DTO ReadOne(Expression<Func<TBL, bool>> predicate)
        {
            TBL dataProxyObject = CurrDBCtx.Set<TBL>().SingleOrDefault(predicate);

            DTO resDTO = mapper.Map<TBL, DTO>(dataProxyObject);
            return resDTO;
        }

        protected void UpdateOne(DTO upDTO, Expression<Func<TBL, bool>> predicate)
        {
            TBL dataProxyObject = CurrDBCtx.Set<TBL>().SingleOrDefault(predicate);
            mapper.Map<DTO, TBL>(upDTO, dataProxyObject);
            CurrDBCtx.SaveChanges();
        }

        protected void DeleteOne(Expression<Func<TBL, bool>> predicate)
        {
            TBL dataProxyObject = CurrDBCtx.Set<TBL>().SingleOrDefault(predicate);
            CurrDBCtx.Set<TBL>().Remove(dataProxyObject);
            CurrDBCtx.SaveChanges();
        }
        protected void DeleteSeveral(Expression<Func<TBL, bool>> predicate)
        {
            List<TBL> listOfProxy = CurrDBCtx.Set<TBL>().Where(predicate).ToList();
            foreach (TBL currProxy in listOfProxy)
            {
                CurrDBCtx.Set<TBL>().Remove(currProxy);
            }
            CurrDBCtx.SaveChanges();
        }
    }
}
