using System;
using System.Collections.Generic;
using Nmro.IAM.Core.Dtos;
using Nmro.Common.Extentions;

namespace Nmro.IAM.Core.UseCases.ApiResources.Dtos
{
    public class ApiResource : Resource
    {
        public ApiResource(){}
        public ApiResource(string name): this(name, name, null){ }
        public ApiResource(string name, string displayName) : this(name, displayName, null){ }
        public ApiResource(string name, IEnumerable<string> claimTypes) : this(name, name, claimTypes){}
        public ApiResource(string name, string displayName, IEnumerable<string> claimTypes)
        {
            if (name.IsMissing()) throw new ArgumentNullException(nameof(name));
            Name = name;
            DisplayName = displayName;
            if (!claimTypes.IsNullOrEmpty())
            {
                foreach (var type in claimTypes)
                {
                    UserClaims.Add(type);
                }
            }
        }
        /// <summary>
        /// The API secret is used for the introspection endpoint. The API can authenticate with introspection using the API name and secret.
        /// </summary>
        public ICollection<Secret> ApiSecrets { get; set; } = new HashSet<Secret>();
        /// <summary>
        /// Models the scopes this API resource allows.
        /// </summary>
        public ICollection<string> Scopes { get; set; } = new HashSet<string>();
        /// <summary>
        /// Signing algorithm for access token. If empty, will use the server default signing algorithm.
        /// </summary>
        public ICollection<string> AllowedAccessTokenSigningAlgorithms { get; set; } = new HashSet<string>();
    }
}
