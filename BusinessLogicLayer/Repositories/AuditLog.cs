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
using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using BusinessLogicLayer.Infrastructure;

namespace BusinessLogicLayer.Repositories
{
    internal class AuditLog : CRUD1NBase<DTOTbl.AuditLog, TblAuditLog>
    {
    }
}
