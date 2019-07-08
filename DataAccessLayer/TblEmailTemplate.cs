using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public partial class TblEmailTemplate
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }
    }
}
