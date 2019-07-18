using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects.Views
{
    public class FileStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public DateTime LoadingTime { get; set; }
        public string PathToPreview { get; set; }
        public string PathToFile { get; set; }
        public int Audit { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPatronymic { get; set; }
    }
}
