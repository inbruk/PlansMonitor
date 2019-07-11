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
using DTO = BusinessLogicLayer.DataTransferObjects;

namespace BusinessLogicLayer.Auxiliary
{
    public class ViewEnlisterOrderItem<VW>
    {
        public bool Descending { set; get; }
        public Expression< Func<VW, bool> > OrderPredicate { set; get; }
    }
}
