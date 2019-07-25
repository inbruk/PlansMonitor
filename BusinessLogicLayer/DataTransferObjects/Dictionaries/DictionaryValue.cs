using System;
using System.Collections.Generic;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Dictionaries
{
    public partial class DictionaryValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EngName4Code { get; set; }
        public int Position { get; set; }
        public int Dictionary { get; set; }
        public string Description { get; set; }
    }
}
