// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using Microsoft.OpenApi.Writers;
using System.Collections.Generic;

namespace ApiGateway.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        // NOTE: These are resourcs that needs to be used in each Microservice Audience Field when registering JWT token
        // in AddJwtBearer
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("usersAPiResource","Users API Resource")
                {
                    Scopes = { "usersApi.addUpdate", "usersApi.delete"}
                },

                new ApiResource("weatherAPiResource","Weather API Resource")
                {
                    Scopes = { "weatherApi.addUpdate", "weatherApi.delete" }
                }
                ,
                new ApiResource("apiQueryResource","Enable Querying API resources")
                {
                    Scopes = {"apiQuery" }
                }
            };

        // These are the scopes that needs to be used to query the Identity token. This will appear in the Scope array of JWT token

        // https://localhost:5001/connect/token
        //{
        //"nbf": 1596427171,
        //"exp": 1596430771,
        //"iss": "https://localhost:5001",
        //"aud": [
        //  "apiQueryResource",
        //  "https://localhost:5001/resources"
        //],
        //"client_id": "m2m.client",
        //"jti": "40A97F6862A6444C19F6B8626019037C",
        //"iat": 1596427171,
        //"scope": [
        //  "apiQuery"
        //]
        //  }
        public static IEnumerable<ApiScope> ApiScopes =>
                new ApiScope[]
                {
                    new ApiScope("scope1"),
                    new ApiScope("apiQuery"),
                    new ApiScope("usersApi"),
                    new ApiScope("weatherApi"),
                };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    // Scopes needs to be added to list to be enabled to access the resource
                    AllowedScopes = { "apiQuery", "weatherApi", "usersApi" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "mvc", // ID of the MVC client as defined in start up
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    // URL of the MVC client where the login and logout will happen
                    RedirectUris = { "http://localhost:11172/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:11172/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:11172/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "apiQuery", "weatherApi", "usersApi" }
                },

            };
    }
}