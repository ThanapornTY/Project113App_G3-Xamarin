using System;
using System.Collections.Generic;
using System.Text;

namespace Project113_G3_Xamarin.Model
{
    class NotificationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime? Date_Noti { get; set; }
    }
}
