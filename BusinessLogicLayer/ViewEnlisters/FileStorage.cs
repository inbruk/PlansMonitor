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
    internal class FileStorage : ViewEnlisterBase<DTOVw.FileStorage, VwFileStorage>
    {
        protected override IQueryable<VwFileStorage> QueryOneSort(IQueryable<VwFileStorage> query, bool isFirstSort, DTOVw.ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnFileStorage.Id: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Id);
                case (int)EnFileStorage.Name: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Name);
                case (int)EnFileStorage.Extention: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Extention);
                case (int)EnFileStorage.LoadingTime: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.LoadingTime);
                case (int)EnFileStorage.PathToPreview: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.PathToPreview);
                case (int)EnFileStorage.PathToFile: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.PathToFile);
                case (int)EnFileStorage.Audit: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Audit);
                case (int)EnFileStorage.UserId: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UserId);
                case (int)EnFileStorage.UserFirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UserFirstName);
                case (int)EnFileStorage.UserLastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UserLastName);
                case (int)EnFileStorage.UserPatronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UserPatronymic);
                default: throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.FileStorage.QueryOneSort()");
            };
        }
    }
}
