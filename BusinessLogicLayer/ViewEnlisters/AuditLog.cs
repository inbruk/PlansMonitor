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
    internal class AuditLog : ViewEnlisterBase<DTOVw.AuditLog, VwAuditLog>
    {
        protected override IQueryable<VwAuditLog> QueryOneSort(IQueryable<VwAuditLog> query, bool isFirstSort, DTOVw.ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnAuditLog.Id: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Id );
                case (int)EnAuditLog.Time: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Time );
                case (int)EnAuditLog.UserId: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UserId);
                case (int)EnAuditLog.UserFirstName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UserFirstName);
                case (int)EnAuditLog.UserLastName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UserLastName);
                case (int)EnAuditLog.UserPatronymic: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.UserPatronymic);
                case (int)EnAuditLog.ScreenPos: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ScreenPos);
                case (int)EnAuditLog.ScreenName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ScreenName);
                case (int)EnAuditLog.ActionPos: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ActionPos);
                case (int)EnAuditLog.ActionName: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.ActionName);
                case (int)EnAuditLog.Description: return GenerateSortQuery(query, isFirstSort, orderDesc.Descending, x => x.Description);
                default: throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.AuditLog.QueryOneSort()");
            };
        }
    }
}
