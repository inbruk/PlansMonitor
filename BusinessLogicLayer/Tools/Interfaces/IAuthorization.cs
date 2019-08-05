using System.Collections.Generic;

using BusinessLogicLayer.Infrastructure;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;

namespace BusinessLogicLayer.Tools.Interfaces
{
    public interface IAuthorization
    {
        bool IsActionPermitted(int userRoleId, int businessObjectId, int actionId, int businessProcessId);
    }
}
