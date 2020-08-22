using System;
using System.Collections.Generic;
using Nmro.Shared.Extentions;
using Nmro.Security.IAM.Core.Dtos;
namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos
{
    public class ApiScope : Resource
    {
        public ApiScope(){}
        public ApiScope(string name): this(name, name, null){}
        public ApiScope(string name, string displayName): this(name, displayName, null){}
        public ApiScope(string name, IEnumerable<string> claimTypes): this(name, name, claimTypes){}
        public ApiScope(string name, string displayName, IEnumerable<string> claimTypes)
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
        /// Specifies whether the user can de-select the scope on the consent screen. Defaults to false.
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// Specifies whether the consent screen will emphasize this scope. Use this setting for sensitive or important scopes. Defaults to false.
        /// </summary>
        public bool Emphasize { get; set; } = false;
    }
}
