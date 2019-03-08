using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Dave.IdentityProvider
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",//唯一标识
                    Username = "Nike",
                    Password = "password",

                    Claims = new List<Claim>//用户信息
                    {
                        new Claim("given_name","Nike"),
                        new Claim("family_name","Carter"),
                        new Claim("nationality","China"),
                        new Claim("gender","female")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Dave",
                    Password = "password",

                    Claims = new List<Claim>()
                    {
                        new Claim("given_name","Dave"),
                        new Claim("family_name","Mustaine")
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("restapi","RESTful API",new List<string>()
                {
                    "nationality",
                    "gender"
                })
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("nationality","国籍",new List<string>("nationality"))
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "mvcclient",
                    ClientName = "MVC 客户端",
                    AllowedGrantTypes = GrantTypes.Hybrid,

                    RedirectUris =
                    {
                        "https://localhost:5002/signin-oidc"
                    },
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "restapi",
                        "nationality"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}
