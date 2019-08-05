using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblAuthorization
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
