using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;

using DTODic = BusinessLogicLayer.DataTransferObjects.Dictionaries;
using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;
using DTOVw = BusinessLogicLayer.DataTransferObjects.Views;
using DTOCol = BusinessLogicLayer.DataTransferObjects.ViewColumns;

using BusinessLogicLayer.Tools;

namespace TestDLLAndBLL4SimpleWorking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test for Dictionary ---------------------------------------------------------------------------------");
            DictionaryTool dicTool = new DictionaryTool();
            List<DTODic.Dictionary> dics = dicTool.ReadAll();
            DTODic.Dictionary currDic = dicTool.Read(11);

            Console.WriteLine("Test for Dictionary Values --------------------------------------------------------------------------");
            DictionaryValueTool dicValTool = new DictionaryValueTool();
            List<DTODic.DictionaryValue> dicValList = dicValTool.ReadSeveralByDicId(11);
            DTODic.DictionaryValue dicVal1 = dicValTool.ReadByDicIdAndPos(8, 1);
            DTODic.DictionaryValue dicVal2 = dicValTool.ReadByItemId(63);

            Console.WriteLine("Test for Tables -----------------------------------------------------------------------------------");
            UserRoleTool usrRoleTool = new UserRoleTool();
            int userRolesCount = usrRoleTool.GetAllItemsCount();
            List<DTOTbl.UserRole> allRoles = usrRoleTool.ReadAll();
            DTOTbl.UserRole currRole = usrRoleTool.Read1(5);

            Console.WriteLine("Test for Views -----------------------------------------------------------------------------------");
            AuditLogTool audLogTool = new AuditLogTool();
            audLogTool.Create1(new DTOTbl.AuditLog() { Screen=4, Action=1, User=1, Time=DateTime.Now, Description="555"  });
            audLogTool.Create1(new DTOTbl.AuditLog() { Screen = 4, Action = 2, User = 1, Time = DateTime.Now, Description = "444" });
            audLogTool.Create1(new DTOTbl.AuditLog() { Screen = 4, Action = 3, User = 1, Time = DateTime.Now, Description = "333" });
            audLogTool.Create1(new DTOTbl.AuditLog() { Screen = 4, Action = 4, User = 1, Time = DateTime.Now, Description = "222" });
            audLogTool.Create1(new DTOTbl.AuditLog() { Screen = 4, Action = 5, User = 1, Time = DateTime.Now, Description = "111" });

            List<DTOVw.AuditLog> audLogList1 = audLogTool.EnlistView(null, null, null, null, null, null);
            List<DTOVw.AuditLog> audLogList2 = audLogTool.EnlistView(null, null, null, null, 2, 3);
            List<DTOVw.AuditLog> audLogList3 = audLogTool.EnlistView(null, new DateTime(2019, 07, 04), new DateTime(2019, 07, 05), null, null, null);

            List<DTOVw.AuditLog> audLogList4 = audLogTool.EnlistView(null, null, null,
                new List <DTOVw.ViewEnlisterOrderItem4DTO >()
                {
                    new DTOVw.ViewEnlisterOrderItem4DTO() {  ColumnId=(int)DTOCol.EnAuditLog.ScreenPos, Descending=false  },
                    new DTOVw.ViewEnlisterOrderItem4DTO() {  ColumnId=(int)DTOCol.EnAuditLog.ActionPos, Descending=true  },
                    new DTOVw.ViewEnlisterOrderItem4DTO() {  ColumnId=(int)DTOCol.EnAuditLog.Description, Descending=false  }
                }
                , null, null);

            List<DTOVw.AuditLog> audLogList5 = audLogTool.EnlistView(null, null, null,
                new List<DTOVw.ViewEnlisterOrderItem4DTO>()
                {
                    new DTOVw.ViewEnlisterOrderItem4DTO() {  ColumnId=(int)DTOCol.EnAuditLog.Time, Descending=true  },
                    new DTOVw.ViewEnlisterOrderItem4DTO() {  ColumnId=(int)DTOCol.EnAuditLog.ScreenPos, Descending=false  }
                }
                , null, null);

            List<int> delIdList = audLogList5.Where( x => x.Id > 3 ).Select(x => x.Id).ToList();

            audLogTool.DeleteN(delIdList);

            List<DTOVw.AuditLog> audLogList6 = audLogTool.EnlistView(null, null, null, null, null, null);

        }
    }
}
