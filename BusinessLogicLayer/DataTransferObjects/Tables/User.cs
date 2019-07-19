using System;
using System.Collections.Generic;

using Patterns;

namespace BusinessLogicLayer.DataTransferObjects.Tables
{
    public partial class User : IObjectWithIdProperty<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool AccessGranted { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public int? VerificationObject { get; set; }
    }
}
