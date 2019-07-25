using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblDictionaryValue
    {
        public string Name { get; set; }
        public string EngName4Code { get; set; }
        public int Position { get; set; }
        public int Dictionary { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual TblDictionary DictionaryNavigation { get; set; }
    }
}
