using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class AuditLogFull
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPatronymic { get; set; }
        public int ScreenPos { get; set; }
        public string ScreenName { get; set; }
        public int ActionPos { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
    }
}
