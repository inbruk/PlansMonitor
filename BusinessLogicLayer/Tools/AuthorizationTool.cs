using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Auxiliary;
using DTO = BusinessLogicLayer.DataTransferObjects.Tables;
using BLRep = BusinessLogicLayer.Repositories;

using BusinessLogicLayer.Tools.Interfaces;

namespace BusinessLogicLayer.Tools
{
    public class AuthorizationTool : IAuthorization
    {
        private BLRep.Authorization _repo;

        public AuthorizationTool()
        {
            _repo = new BLRep.Authorization();
        }

        public bool IsActionPermitted(int userRoleId, int businessObjectId, int actionId, int businessProcessId)
        {
            DTO.Authorization currItem = _repo.ReadN // с точно заданным бизнес процессом
            (
                x => x.BusinessObject == businessObjectId &&
                     x.Action == actionId &&
                     x.BusinessProcess == businessProcessId
            )
            .SingleOrDefault();

            if( currItem==null) // для случая, когда оба бизнес процесса одинаковые разрешения имеют (спец. значение - null)
            {
                currItem = _repo.ReadN 
                (
                    x => x.BusinessObject == businessObjectId &&
                            x.Action == actionId &&
                            x.BusinessProcess == null
                )
                .SingleOrDefault();
            }

            if( currItem==null ) // если совсем нет строк, для любых БП, то интерпретируем как запрет всем ролям (спец. значение)
            {
                return false;
            }

            switch (userRoleId)
            {
                case 1: return currItem.Permit4Ur1admin;
                case 2: return currItem.Permit4Ur2intOperator;
                case 3: return currItem.Permit4Ur3extOperator;
                case 4: return currItem.Permit4Ur4auditSuperviser;
                case 5: return currItem.Permit4Ur5auditor;
                case 6: return currItem.Permit4Ur6controller;
                case 7: return currItem.Permit4Ur7respEmployee;
                default: throw new Exception("Не поддерживаемое значение ид роли при вызове AuthorizationTool.IsActionPermitted()");
            }
        }
    }
}
