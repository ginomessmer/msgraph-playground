using Microsoft.Graph;
using MicrosoftGraph.Playground.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

namespace MicrosoftGraph.Playground
{
    public static class AppHelper
    {
        public static void SerializeToFile(object target, string path)
        {
            string json = JsonConvert.SerializeObject(target, Formatting.Indented);
            System.IO.File.WriteAllText(path, json);

            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"Result serialized to: {path}");
            ResetColor();
        }

        public static T DeserializeFromFile<T>(string path)
        {
            if(System.IO.File.Exists(path))
            {
                var json = System.IO.File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
                return default(T);
        }

        public static void WriteObject(object target)
        {
            WriteLine(JsonConvert.SerializeObject(target, Formatting.Indented));
        }

        public static GraphServiceClient GetGraphServiceClient()
        {
            var credentials = DeserializeFromFile<ApiCredentials>("credentials.json");

            if(credentials != null)
            {
                var graphClient = new GraphServiceClient(new PlaygroundAuthProvider(credentials.ClientId, credentials.ClientSecret, credentials.AuthorityUrl));

                return graphClient;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Consider to run \"set-credentials [--help]\" first before running any commands which require authentication.");
                ResetColor();
                Environment.Exit(-1);
                return null;
            }
        }
    }
}
