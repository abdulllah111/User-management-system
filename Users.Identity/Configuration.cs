using IdentityServer4.Models;
using IdentityServer4;
using IdentityModel;

namespace Users.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>{
                new ApiScope("MyWebAPI", "Web API")
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>{
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>{
                new ApiResource("MyWebAPI", "Web API", new [] {JwtClaimTypes.Name}){
                    Scopes = {"MyWebAPI"}
                }
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>{
                new Client{
                    ClientId = "my-web-api",
                    ClientName = "MyWebAPI",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris = {
                        "http://.../signin-oidc"
                    },
                    AllowedCorsOrigins = {
                        "http://..."
                    },
                    PostLogoutRedirectUris = {
                        "http://.../signout-oidc"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "MyWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}