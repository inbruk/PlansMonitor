using System;
using System.Collections.Generic;
using System.Text;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Views
{
    public class EmailTemplate : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }
        public int TypePos { get; set; }
        public string TypeName { get; set; }
    }
}
