namespace Nmro.Landing.Settings
{
    internal class OidcOptions
    {
        public string Authority {get;set;}
        public string SignedOutRedirectUri {get;set;}
        public string ClientId { get; set;}
        public string ClientSecret { get; set;}
        public string[] Scopes {get; set;}
    }
}
