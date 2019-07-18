using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects.ViewColumns
{
    public enum EnUser
    {
        Id = 1,
        FirstName = 2,
        LastName = 3,
        Patronymic = 4,
        Login = 5,
        PasswordSalt = 6,
        PasswordHash = 7,
        AccessGranted = 8,
        EMail = 9,
        VerificationObject = 10,
        RoleId = 11,
        RoleName = 12
    }
}
