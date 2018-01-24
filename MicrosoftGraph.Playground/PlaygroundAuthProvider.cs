using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;
using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace MicrosoftGraph.Playground
{
    internal class PlaygroundAuthProvider : IAuthenticationProvider
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string Authority { get; set; }


        public PlaygroundAuthProvider(string clientID, string clientSecret, string authority)
        {
            ClientID = clientID;
            ClientSecret = clientSecret;
            Authority = authority;
        }


        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            WriteLine("Attempting to perform sign-in...");
            AuthenticationContext authContext = new AuthenticationContext(Authority);
            ClientCredential credential = new ClientCredential(ClientID, ClientSecret);
            AuthenticationResult result = await authContext.AcquireTokenAsync("https://graph.microsoft.com/", credential);
            request.Headers.Add("Authorization", $"Bearer {result.AccessToken}");
        }
    }
}