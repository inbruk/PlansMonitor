using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DataTransferObjects
{
    public partial class FileStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public DateTime LoadingTime { get; set; }
        public int User { get; set; }
        public string PathToPreview { get; set; }
        public string PathToFile { get; set; }
        public int Audit { get; set; }
    }
}
