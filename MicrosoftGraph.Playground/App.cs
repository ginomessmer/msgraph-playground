using CommandDotNet.Attributes;
using Microsoft.Graph;
using MicrosoftGraph.Playground.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var users = await AppHelper.GetGraphServiceClient().Users.Request().GetAsync();

            WriteObject(users);
            SerializeToFile(users, "users.playground.json");
        }

        public async Task GetGroups()
        {
            var groups = await AppHelper.GetGraphServiceClient().Groups.Request().GetAsync();

            WriteObject(groups);
            SerializeToFile(groups, "groups.playground.json");
        }

        public async Task GetExtensionsByUser(string principalName)
        {
            var extensions = await AppHelper.GetGraphServiceClient().Users[principalName].Extensions.Request().GetAsync();

            WriteObject(extensions);
            SerializeToFile(extensions, "extensions.playground.json");
        }

        public async Task AddExtensionToUser(string principalName, string extensionName, string key, string value)
        {
            var extension = new OpenTypeExtension
            {
                ExtensionName = extensionName,
                AdditionalData = new Dictionary<string, object>()
                {
                    { key, value }
                }
            };

            await AppHelper.GetGraphServiceClient().Users[principalName].Extensions.Request().AddAsync(extension);

            ForegroundColor = ConsoleColor.Green;
            WriteLine($"Successfully added extension {key}.");
            ResetColor();
        }
    }
}
