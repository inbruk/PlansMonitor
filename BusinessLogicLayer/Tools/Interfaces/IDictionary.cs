using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTO = BusinessLogicLayer.DataTransferObjects.Dictionaries;

namespace BusinessLogicLayer
{
    // Внимание !!! Тут должны быть только те методы, которые нужны по ТЗ
    interface IDictionaryTool
    {
        List<DTO.Dictionary> ReadAll();
        DTO.Dictionary Read(int Id);
    }
}
