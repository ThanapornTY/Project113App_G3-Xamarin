using Newtonsoft.Json;
using Project113_G3_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Project113_G3_Xamarin.APIs
{
    class ApiService
    {
        HttpClient client;

        public ApiService()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<GamesModel>> GetGameModel()
        {
            ObservableCollection<GamesModel> Item = null;

            try
            {
                var response = await client.GetAsync("http://10.0.2.2:61813/api/DatagamesAPI_xamarin");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<ObservableCollection<GamesModel>>(content);
                    return Item;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return null;
        }

        public async Task<bool> Register(RegisterModel Item)
        {
            try
            {

                string json = JsonConvert.SerializeObject(Item);
                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");

                /* รันได้ แต่ข้อมูลไม่เข้า */
                //var response = await client.PostAsync("http://10.0.2.2:49343/api/Account/Register", sContent);

                var response = await client.GetAsync("http://10.0.2.2:49343/api/UserDatasAPI");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> Login(LoginModel login)
        {
            User Item = null;

            try
            {
                var dict = new Dictionary<string, string>();
                dict.Add("Content-Type", "application/x-www-form-urlencode");
                dict.Add("grant_type", "password");
                dict.Add("username", login.Email);
                dict.Add("password", login.Password);

                //var response = await client.PostAsync("http://10.0.2.2:53619/token", new FormUrlEncodedContent(dict));

                var response = await client.PostAsync("http://10.0.2.2:49343/api/UserDatasAPI", new FormUrlEncodedContent(dict));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<User>(content);
                    Preferences.Set("username", Item.userName);
                    Preferences.Set("token_type", Item.token_type);
                    Preferences.Set("access_token", Item.access_token);

                    return response.IsSuccessStatusCode;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return false;
        }


        public async Task<bool> Logout()
        {

            try
            {
                var access_token = Preferences.Get("access_token", "");
                var token_type = Preferences.Get("token_type", "");

                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token_type + " " + access_token);

                client.DefaultRequestHeaders.Add("Authorization", "Beare" + access_token);

                //var response = await client.PostAsync("http://10.0.2.2:53619/api/Account/Logout", null);

                var response = await client.PostAsync("http://10.0.2.2:53619/api/UserDatasAPI", null);

                return response.IsSuccessStatusCode;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        /*
        public async Task<bool> GetRegister(Register_Model Item)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Item);
                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://10.0.2.2:49343/api/Account/Register", sContent);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

           
        }*/



        public async Task<ObservableCollection<NotificationModel>> GetNotificationModel()
        {
            ObservableCollection<NotificationModel> Item = null;

            try
            {
                //var response = await client.GetAsync("http://10.0.2.2:61533/api/NotificationAPI_xamarin");
                var response = await client.GetAsync("http://10.0.2.2:61813/api/NotificationAPI_xamarin"); 
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<ObservableCollection<NotificationModel>>(content);
                    return Item;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return null;
        }


        public async Task<bool> GetReportUser(ReportUserModel Item)
        {
            try
            {

                string json = JsonConvert.SerializeObject(Item);
                StringContent sContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://10.0.2.2:53780/api/ReportAPI_xamarin", sContent);

                //var response = await client.GetAsync("http://10.0.2.2:49343/api/UserDatasAPI");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        
    }


}
