using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTO = BusinessLogicLayer.DataTransferObjects.Dictionaries;

namespace BusinessLogicLayer.Tools.Interfaces
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    public interface IDictionaryValueTool
    {
        List<DTO.DictionaryValue> ReadSeveralByDicId(int dicId);
        DTO.DictionaryValue ReadByDicIdAndPos(int dicId, int pos);
        DTO.DictionaryValue ReadByItemId(int itemId);
    }
}
