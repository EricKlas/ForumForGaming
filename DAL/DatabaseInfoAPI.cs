using ForumForGaming.Models;
using System.Text.Json;

namespace ForumForGaming.DAL
{
    public class DatabaseInfoAPI
    {
        private static Uri BaseAddress = new Uri("https://snackisforumforgamesapi.azurewebsites.net/");

        public static async Task<DatabaseInfo> GetDatabaseInfo()
        {
            var dbInfo = new DatabaseInfo();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/DatabaseInfoCount");
                if(response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    dbInfo = JsonSerializer.Deserialize<DatabaseInfo>(responseString);
                }
                return dbInfo;
            }
        }
    }
}
