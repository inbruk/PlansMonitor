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
        protected override IQueryable<VwEmailTemplate> QueryOneSort(IQueryable<VwEmailTemplate> query, ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnEmailTemplate.Id:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Id);
                    else query = query.OrderByDescending(x => x.Id);
                    break;

                case (int)EnEmailTemplate.Template:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Template);
                    else query = query.OrderByDescending(x => x.Template);
                    break;

                case (int)EnEmailTemplate.Description:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Description);
                    else query = query.OrderByDescending(x => x.Description);
                    break;

                case (int)EnEmailTemplate.TypePos:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.TypePos);
                    else query = query.OrderByDescending(x => x.TypePos);
                    break;

                case (int)EnEmailTemplate.TypeName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.TypeName);
                    else query = query.OrderByDescending(x => x.TypeName);
                    break;


                default:
                    throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.EmailTemplate.QueryOneSort()");
            };

            return query;
        }
    }
}
