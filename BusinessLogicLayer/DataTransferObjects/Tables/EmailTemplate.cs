using System;
using System.Collections.Generic;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class EmailTemplate : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }
    }
}
