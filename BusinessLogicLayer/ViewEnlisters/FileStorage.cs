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
    internal class FileStorage : ViewEnlisterBase<DTOVw.FileStorage, VwFileStorage, int>
    {

        protected override IQueryable<VwFileStorage> QueryOneSort(IQueryable<VwFileStorage> query, ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnFileStorage.Id:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Id);
                    else query = query.OrderByDescending(x => x.Id);
                    break;

                case (int)EnFileStorage.Name:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Name);
                    else query = query.OrderByDescending(x => x.Name);
                    break;

                case (int)EnFileStorage.Extention:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Extention);
                    else query = query.OrderByDescending(x => x.Extention);
                    break;

                case (int)EnFileStorage.LoadingTime:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.LoadingTime);
                    else query = query.OrderByDescending(x => x.LoadingTime);
                    break;

                case (int)EnFileStorage.PathToPreview:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.PathToPreview);
                    else query = query.OrderByDescending(x => x.PathToPreview);
                    break;

                case (int)EnFileStorage.PathToFile:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.PathToFile);
                    else query = query.OrderByDescending(x => x.PathToFile);
                    break;

                case (int)EnFileStorage.Audit:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Audit);
                    else query = query.OrderByDescending(x => x.Audit);
                    break;

                case (int)EnFileStorage.UserId:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UserId);
                    else query = query.OrderByDescending(x => x.UserId);
                    break;

                case (int)EnFileStorage.UserFirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UserFirstName);
                    else query = query.OrderByDescending(x => x.UserFirstName);
                    break;

                case (int)EnFileStorage.UserLastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UserLastName);
                    else query = query.OrderByDescending(x => x.UserLastName);
                    break;

                case (int)EnFileStorage.UserPatronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UserPatronymic);
                    else query = query.OrderByDescending(x => x.UserPatronymic);
                    break;

                default:
                    throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.FileStorage.QueryOneSort()");
            };

            return query;
        }
    }
}
