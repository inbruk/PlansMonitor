using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public interface IRepository1<DTO, TID>
    {
        List<DTO> ReadAll();
        void Create1(DTO newDTO);
        DTO Read1(TID id);
        void Update1(DTO dtoItem); // подразумевается, что id-ы при update не изменяются !!!
        void Delete1(TID id);
    }
}
