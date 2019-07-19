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
        protected override IQueryable<VwAuditLog> QueryOneSort(IQueryable<VwAuditLog> query, ViewEnlisterOrderItem4DTO orderDesc)
        {
            switch (orderDesc.ColumnId)
            {
                case (int)EnAuditLog.Id:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Id);
                    else query = query.OrderByDescending(x => x.Id);
                    break;
                case (int)EnAuditLog.Time:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Time);
                    else query = query.OrderByDescending(x => x.Time);
                    break;
                case (int)EnAuditLog.UserId:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UserId);
                    else query = query.OrderByDescending(x => x.UserId);
                    break;
                case (int)EnAuditLog.UserFirstName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UserFirstName);
                    else query = query.OrderByDescending(x => x.UserFirstName);
                    break;
                case (int)EnAuditLog.UserLastName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UserLastName);
                    else query = query.OrderByDescending(x => x.UserLastName);
                    break;
                case (int)EnAuditLog.UserPatronymic:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.UserPatronymic);
                    else query = query.OrderByDescending(x => x.UserPatronymic);
                    break;
                case (int)EnAuditLog.ScreenPos:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ScreenPos);
                    else query = query.OrderByDescending(x => x.ScreenPos);
                    break;
                case (int)EnAuditLog.ScreenName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ScreenName);
                    else query = query.OrderByDescending(x => x.ScreenName);
                    break;
                case (int)EnAuditLog.ActionPos:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ActionPos);
                    else query = query.OrderByDescending(x => x.ActionPos);
                    break;
                case (int)EnAuditLog.ActionName:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.ActionName);
                    else query = query.OrderByDescending(x => x.ActionName);
                    break;
                case (int)EnAuditLog.Description:
                    if (orderDesc.Descending == false) query = query.OrderBy(x => x.Description);
                    else query = query.OrderByDescending(x => x.Description);
                    break;
                default:
                    throw new Exception("Такая колонка не поддерживается в BusinessLogicLayer.ViewEnlisters.AuditLog.QueryOneSort()");
            };

            return query;
        }
    }
}
