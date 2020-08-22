namespace Nmro.Foundation.Backbone.ApiGateway.Extentions
{
    public class Oauth2Options
    {
        public string SchemeName {get;set;} = "Authorization";
        public string ApiName {get;set;} = Program.AppName;
        public string Authority {get;set;}
        public string ApiSecret {get;set;}
        public bool RequireHttps {get;set;} = true;
    }
}
