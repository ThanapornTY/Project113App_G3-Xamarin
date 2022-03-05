using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project113_G3_Xamarin.Model
{
    public class RegisterModel
    {
        //[PrimaryKey]
        public string UID { get; set; }

        public string Name { get; set; }

        public string Email_User { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Bd_User { get; set;}

        public string GenderUser { get; set; }

        //public string url { get; set; }
    }
}
