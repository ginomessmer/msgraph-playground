using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosoftGraph.Playground.Data
{
    public class ApiCredentials
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorityUrl { get; set; } // In most cases: https://login.windows.net/ + <azuredomain> + /oauth2/token
    }
}
