using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public interface IRepositoryN<DTO, TID>
    {
        void CreateN(List<DTO> newDTOList);
        void CreateNFastWithoutIdsAquering(List<DTO> newDTOList);
        List<DTO> ReadN(List<TID> idList);
        void UpdateN(List<DTO> dtoList); // подразумевается, что id-ы при update не изменяются !!!
        void DeleteN(List<TID> idList);
    }
}
