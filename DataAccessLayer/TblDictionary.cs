using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblDictionary
    {
        public TblDictionary()
        {
            TblDictionaryValue = new HashSet<TblDictionaryValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EngName4Code { get; set; }

        public virtual ICollection<TblDictionaryValue> TblDictionaryValue { get; set; }
    }
}
