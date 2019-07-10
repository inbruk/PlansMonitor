using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;
using DTO = BusinessLogicLayer.DataTransferObjects;
using System.Linq;

namespace BusinessLogicLayer
{
    // Лениво грузит все данные при любом первом запросе. И хранит их на случай повторного использования.
    //  Подразумевается, что словари неизменны.
    public static class DictionaryTool
    {
        private static IMapper _mapper;
        private static List<DTO.Dictionary> _dicData;

        static DictionaryTool()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<TblDictionary, DTO.Dictionary>();
                }
            );

            _mapper = config.CreateMapper();
            _dicData = null;
        }

        private static void CheckAndLoadData()
        {
            if (_dicData == null)
            {
                var ctx = PCAMonitorDBContextHolder.Get();
                var tempList = ctx.TblDictionary.OrderBy(x => x.Name).ToList();
                _dicData = _mapper.Map<List<TblDictionary>, List<DTO.Dictionary>>(tempList);
            }
        }

        public static List<DTO.Dictionary> ReadAll()
        {
            CheckAndLoadData();
            return _dicData;
        }

        public static DTO.Dictionary Read(int Id)
        {
            CheckAndLoadData();
            DTO.Dictionary result = _dicData.SingleOrDefault(x => x.Id == Id);
            return result;
        }
    }
}
