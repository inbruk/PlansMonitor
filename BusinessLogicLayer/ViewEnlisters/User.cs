using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.DataTransferObjects.ViewColumns;

namespace BusinessLogicLayer.ViewEnlisters
{
    internal class User : ViewEnlisterBase<DTOVw.User, VwUser>
    {
        protected override IQueryable<VwUser> QueryOneSort(IQueryable<VwUser> query, bool isFirstSort, DTOVw.ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnUser.Id: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Id);
                case (int)EnUser.FirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.FirstName);
                case (int)EnUser.LastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.LastName);
                case (int)EnUser.Patronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Patronymic);
                case (int)EnUser.Login: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Login);
                case (int)EnUser.PasswordSalt: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.PasswordSalt);
                case (int)EnUser.PasswordHash: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.PasswordHash);
                case (int)EnUser.AccessGranted: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.AccessGranted);
                case (int)EnUser.EMail: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.EMail);
                case (int)EnUser.VerificationObject: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.VerificationObject);
                case (int)EnUser.RoleId: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.RoleId);
                case (int)EnUser.RoleName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.RoleName);
                default: throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.User.QueryOneSort()");
            };
        }
    }
}
