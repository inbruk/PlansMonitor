using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using BusinessLogicLayer;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Tools;
using BusinessLogicLayer.Tools.Interfaces;
using BusinessLogicLayer.Tools.Holders;

namespace Test_Authorization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check for authorization works properly. Permissions hard stored in Database.----------------------");

            IAuthorization tool = AuthorizationToolHolder.Get();
            bool result1  = tool.IsActionPermitted(1, 1, 2, 1);
            bool result2  = tool.IsActionPermitted(1, 1, 2, 2);
            bool result11 = tool.IsActionPermitted(2, 1, 2, 1);
            bool result22 = tool.IsActionPermitted(2, 1, 2, 2);
            bool result33 = tool.IsActionPermitted(1, 1, 1, 1);
            bool result34 = tool.IsActionPermitted(1, 1, 3, 2);
            
            bool result3 = tool.IsActionPermitted(1, 2, 1, 1);
            bool result4 = tool.IsActionPermitted(1, 2, 2, 1);
            bool result5 = tool.IsActionPermitted(1, 2, 1, 2);
            bool result6 = tool.IsActionPermitted(1, 2, 2, 2);

            bool result7  = tool.IsActionPermitted(2, 2, 1, 1);
            bool result8  = tool.IsActionPermitted(2, 2, 2, 1);
            bool result9  = tool.IsActionPermitted(2, 2, 1, 2);
            bool result10 = tool.IsActionPermitted(2, 2, 2, 2);
        }
    }
}
