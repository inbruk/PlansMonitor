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
        protected override IQueryable<VwUser> QueryOneSort(IQueryable<VwUser> query, ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnUser.Id:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Id);
                    else query = query.OrderByDescending(x => x.Id);
                    break;
                case (int)EnUser.FirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.FirstName);
                    else query = query.OrderByDescending(x => x.FirstName);
                    break;
                case (int)EnUser.LastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.LastName);
                    else query = query.OrderByDescending(x => x.LastName);
                    break;
                case (int)EnUser.Patronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Patronymic);
                    else query = query.OrderByDescending(x => x.Patronymic);
                    break;
                case (int)EnUser.Login:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Login);
                    else query = query.OrderByDescending(x => x.Login);
                    break;
                case (int)EnUser.PasswordSalt:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.PasswordSalt);
                    else query = query.OrderByDescending(x => x.PasswordSalt);
                    break;
                case (int)EnUser.PasswordHash:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.PasswordHash);
                    else query = query.OrderByDescending(x => x.PasswordHash);
                    break;
                case (int)EnUser.AccessGranted:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.AccessGranted);
                    else query = query.OrderByDescending(x => x.AccessGranted);
                    break;
                case (int)EnUser.EMail:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.EMail);
                    else query = query.OrderByDescending(x => x.EMail);
                    break;
                case (int)EnUser.VerificationObject:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.VerificationObject);
                    else query = query.OrderByDescending(x => x.VerificationObject);
                    break;
                case (int)EnUser.RoleId:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.RoleId);
                    else query = query.OrderByDescending(x => x.RoleId);
                    break;
                case (int)EnUser.RoleName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.RoleName);
                    else query = query.OrderByDescending(x => x.RoleName);
                    break;

                default:
                    throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.User.QueryOneSort()");
            };

            return query;
        }
    }
}
