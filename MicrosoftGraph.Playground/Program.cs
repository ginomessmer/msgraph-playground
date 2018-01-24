using CommandDotNet;
using CommandDotNet.Models;
using System;
using static System.Console;

namespace MicrosoftGraph.Playground
{
    class Program
    {
        static int Main(string[] args)
        {
            AppRunner<App> app = new AppRunner<App>(new AppSettings
            {
                Case = Case.KebabCase
            });

            return app.Run(args);
        }
    }
}
