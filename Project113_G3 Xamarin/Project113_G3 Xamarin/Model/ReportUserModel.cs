using System;
using System.Collections.Generic;
using System.Text;

namespace Project113_G3_Xamarin.Model
{
    public class ReportUserModel
    {
        public int RQrp_Id { get; set; }

        public string RQrp_ByUsername { get; set; }

        public string RQrp_ToUserName { get; set; }

        public string RQrp_Toppic { get; set; }
        public DateTime RQrp_Date { get; set; }

        public string RQrp_Note { get; set; }
    }
}
