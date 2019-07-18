using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class EmailTemplate
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }
    }
}
