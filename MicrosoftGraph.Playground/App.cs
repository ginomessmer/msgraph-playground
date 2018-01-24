using CommandDotNet.Attributes;
using Microsoft.Graph;
using MicrosoftGraph.Playground.Data;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using static MicrosoftGraph.Playground.AppHelper;
using static System.Console;

namespace MicrosoftGraph.Playground
{
    public class App
    {
        [DefaultMethod]
        public void Default()
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Use \"dotnet MicrosoftGraph.Playground.dll --help\"");
            ReadLine();
        }

        public async Task SetCredentials(string clientId, string clientSecret, string authority)
        {
            var credentials = new ApiCredentials
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                AuthorityUrl = authority
            };

            SerializeToFile(credentials, "credentials.json");
        }

        public async Task GetUsers()
        {
            GraphServiceClient graphClient = AppHelper.GetGraphServiceClient();
            var users = await graphClient.Users.Request().GetAsync();

            WriteLine(JsonConvert.SerializeObject(users, Formatting.Indented));
            SerializeToFile(users, "users.json");
            
            ResetColor();
        }
    }
}
