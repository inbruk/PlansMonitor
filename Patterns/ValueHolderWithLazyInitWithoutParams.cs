using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class ValueHolderWithLazyInitWithoutParams<T>
        where T : class
    {
        private static T obj = null;

        public static T Get()
        {
            if (obj == null)
            {
                obj = (T)Activator.CreateInstance(typeof(T));
            }

            return obj;
        }
    }
}
