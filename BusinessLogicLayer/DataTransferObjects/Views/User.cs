﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects.Views
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool AccessGranted { get; set; }
        public string EMail { get; set; }
        public int VerificationObject { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}