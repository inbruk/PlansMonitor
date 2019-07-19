using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public interface IObjectWithIdProperty <TID>
    {
        TID Id { get; set; }
    }
}
