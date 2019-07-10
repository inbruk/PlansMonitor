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
    // Лениво грузит по одному словарю (если этот словарь не загружен) при любом первом запросе данных из этого словаря. 
    // И хранит все загруженные словари на случай повторного использования. Подразумевается, что словари неизменны.
    public static class DictionaryValueTool
    {
        private static IMapper _mapper;
        private static List<int> _loadedDicIds;
        private static List<DTO.DictionaryValue> _perItemData;

        static DictionaryValueTool()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<TblDictionaryValue, DTO.DictionaryValue>();
                }
            );

            _mapper = config.CreateMapper();
            _loadedDicIds = new List<int>();
            _perItemData = new List<DTO.DictionaryValue>();
        }

        private static void CheckAndLoadOneDictionaryValues(int dicId)
        {
            if ( _loadedDicIds.Contains(dicId)==false )
            {
                var ctx = PCAMonitorDBContextHolder.Get();
                var tempList = ctx.TblDictionaryValue.Where( x => x.Dictionary==dicId ).ToList();
                if (tempList.Count > 0)
                {
                    var tempDTOList = _mapper.Map<List<TblDictionaryValue>, List<DTO.DictionaryValue>>(tempList);
                    _loadedDicIds.Add(dicId);
                    _perItemData.AddRange(tempDTOList);
                }
            }
        }
        public static List<DTO.DictionaryValue> ReadSeveralByDicId(int dicId)
        {
            CheckAndLoadOneDictionaryValues(dicId);
            List<DTO.DictionaryValue> result = _perItemData.Where( x => x.Dictionary==dicId ).OrderBy( x => x.Position ).ToList();
            return result;
        }

        public static DTO.DictionaryValue ReadByDicIdAndPos(int dicId, int pos)
        {
            var result = _perItemData.SingleOrDefault(x => x.Dictionary == dicId && x.Position == pos);
            return result;
        }

        public static DTO.DictionaryValue ReadByItemId(int itemId)
        {
            var result = _perItemData.SingleOrDefault(x => x.Id == itemId);
            return result;
        }
    }
}
