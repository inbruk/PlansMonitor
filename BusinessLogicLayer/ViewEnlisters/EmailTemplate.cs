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
    internal class EmailTemplate : ViewEnlisterBase<DTOVw.EmailTemplate, VwEmailTemplate>
    {
        protected override IQueryable<VwEmailTemplate> QueryOneSort(IQueryable<VwEmailTemplate> query, bool isFirstSort, DTOVw.ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnEmailTemplate.Id: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Id);
                case (int)EnEmailTemplate.Template: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Template);
                case (int)EnEmailTemplate.Description: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Description);
                case (int)EnEmailTemplate.TypePos: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.TypePos);
                case (int)EnEmailTemplate.TypeName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.TypeName);
                default: throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.EmailTemplate.QueryOneSort()");
            };
        }
    }
}
