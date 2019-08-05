using System;
using System.Collections.Generic;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class Authorization : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public int BusinessObject { get; set; }
        public int Action { get; set; }
        public int? BusinessProcess { get; set; }
        public bool Permit4Ur1admin { get; set; }
        public bool Permit4Ur2intOperator { get; set; }
        public bool Permit4Ur3extOperator { get; set; }
        public bool Permit4Ur4auditSuperviser { get; set; }
        public bool Permit4Ur5auditor { get; set; }
        public bool Permit4Ur6controller { get; set; }
        public bool Permit4Ur7respEmployee { get; set; }
    }
}
