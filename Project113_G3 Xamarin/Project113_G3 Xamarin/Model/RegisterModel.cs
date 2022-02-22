using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project113_G3_Xamarin.Model
{
    public class RegisterModel
    {
        [PrimaryKey]
        public string UID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string DOB { get; set;}

        public string Gender { get; set; }

        public string Ima_User { get; set; }
    }
}
