﻿using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace AuthServer.Configuration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("socialnetwork", "社交网络")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "socialnetwork",
                    ClientSecrets = new [] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new [] { "socialnetwork" }
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "mail@qq.com",
                    Password = "password"
                }
            };
        }
    }
}