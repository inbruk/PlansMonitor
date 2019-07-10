using System;
using System.Collections.Generic;
using System.Text;

using Patterns;

namespace DataAccessLayer.Auxiliary
{
    public class PCAMonitorDBContextHolder : ValueHolderWithLazyInitWithoutParams<ActualPlansMonitorContext>
    {
        // Внимание !!! Класс не статический, так как статический нельзя наследовать от дженерика.
        // Но ! Все значимое содержимое в нем статическое, соответственно использовать его нужно как статический.
        // Создавать экземпляры не нужно.
    }
}
