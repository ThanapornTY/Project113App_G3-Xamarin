using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project113_G3_Xamarin.Model
{
    public class CreateRoomModel
    {
        [PrimaryKey]
        public string Id_Room { get; set; }
        public string Room_Name { get; set; }
        public string GameName { get; set; }
        public string Rank_Game { get; set; }
        public string Level_Game { get; set; }
        public string TimeToPlay { get; set; }
        public string Deseription_Room { get; set; }
    }
}
