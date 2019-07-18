using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;
using DTO = BusinessLogicLayer.DataTransferObjects.Dictionaries;
using System.Linq;

namespace BusinessLogicLayer.Tools
{
    // Лениво грузит все данные при любом первом запросе. И хранит их на случай повторного использования.
    //  Подразумевается, что словари неизменны.
    public class DictionaryTool : IDictionaryTool
    {
        private IMapper _mapper;
        private List<DTO.Dictionary> _dicData;

        public DictionaryTool()
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

        private void CheckAndLoadData()
        {
            if (_dicData == null)
            {
                var ctx = PCAMonitorDBContextHolder.Get();
                var tempList = ctx.TblDictionary.OrderBy(x => x.Name).ToList();
                _dicData = _mapper.Map<List<TblDictionary>, List<DTO.Dictionary>>(tempList);
            }
        }

        public List<DTO.Dictionary> ReadAll()
        {
            CheckAndLoadData();
            return _dicData;
        }

        public DTO.Dictionary Read(int Id)
        {
            CheckAndLoadData();
            DTO.Dictionary result = _dicData.SingleOrDefault(x => x.Id == Id);
            return result;
        }
    }
}
