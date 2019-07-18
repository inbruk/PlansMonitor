using System.Collections.Generic;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;
using DTO = BusinessLogicLayer.DataTransferObjects.Dictionaries;
using System.Linq;

namespace BusinessLogicLayer.Tools
{
    // Лениво грузит по одному словарю (если этот словарь не загружен) при любом первом запросе данных из этого словаря. 
    // И хранит все загруженные словари на случай повторного использования. Подразумевается, что словари неизменны.
    public class DictionaryValueTool : IDictionaryValueTool
    {
        private IMapper _mapper;
        private List<int> _loadedDicIds;
        private List<DTO.DictionaryValue> _perItemData;

        public DictionaryValueTool()
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

        private void CheckAndLoadOneDictionaryValues(int dicId)
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
        public List<DTO.DictionaryValue> ReadSeveralByDicId(int dicId)
        {
            CheckAndLoadOneDictionaryValues(dicId);
            List<DTO.DictionaryValue> result = _perItemData.Where( x => x.Dictionary==dicId ).OrderBy( x => x.Position ).ToList();
            return result;
        }

        public DTO.DictionaryValue ReadByDicIdAndPos(int dicId, int pos)
        {
            var result = _perItemData.SingleOrDefault(x => x.Dictionary == dicId && x.Position == pos);
            return result;
        }

        public DTO.DictionaryValue ReadByItemId(int itemId)
        {
            var result = _perItemData.SingleOrDefault(x => x.Id == itemId);
            return result;
        }
    }
}
