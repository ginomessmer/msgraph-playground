using CommandDotNet.Attributes;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using Newtonsoft.Json;

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

        public async Task GetUsers(string clientId, string clientSecret, string authority)
        {
            var graphClient = new GraphServiceClient(new PlaygroundAuthProvider(clientId, clientSecret, authority));
            var users = await graphClient.Users.Request().GetAsync();

            WriteLine(JsonConvert.SerializeObject(users, Formatting.Indented));
            
            ResetColor();
        }
    }
}
