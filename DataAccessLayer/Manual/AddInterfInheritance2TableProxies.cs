using System;
using System.Collections.Generic;
using System.Text;

using Patterns;

namespace DataAccessLayer
{
    public partial class TblAudit : IObjectWithIdProperty<int> { }
    public partial class TblAuditLog : IObjectWithIdProperty<int> { }
    public partial class TblAuditObject : IObjectWithIdProperty<int> { }
    public partial class TblCorrectiveAction : IObjectWithIdProperty<int> { }
    public partial class TblDictionary : IObjectWithIdProperty<int> { }
    public partial class TblDictionaryValue : IObjectWithIdProperty<int> { }
    public partial class TblEmailTemplate : IObjectWithIdProperty<int> { }
    public partial class TblFileStorage : IObjectWithIdProperty<int> { }
    public partial class TblRemark : IObjectWithIdProperty<int> { }
    public partial class TblUser : IObjectWithIdProperty<int> { }
    public partial class TblUserRole : IObjectWithIdProperty<int> { }
}
