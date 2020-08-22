using System;
using System.Collections.Generic;
using Nmro.Shared.Extentions;
using Nmro.Security.IAM.Core.Dtos;

namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos
{
    /// <summary>
    /// Models a user identity resource.
    /// </summary>
    public class IdentityResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityResource"/> class.
        /// </summary>
        public IdentityResource(){}
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityResource"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="claimTypes">The claim types.</param>
        public IdentityResource(string name, IEnumerable<string> claimTypes): this(name, name, claimTypes){}
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityResource"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="claimTypes">The claim types.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        /// <exception cref="System.ArgumentException">Must provide at least one claim type - claimTypes</exception>
        public IdentityResource(string name, string displayName, IEnumerable<string> claimTypes)
        {
            if (name.IsMissing()) throw new ArgumentNullException(nameof(name));
            if (claimTypes.IsNullOrEmpty()) throw new ArgumentException("Must provide at least one claim type", nameof(claimTypes));
            Name = name;
            DisplayName = displayName;
            foreach(var type in claimTypes)
            {
                UserClaims.Add(type);
            }
        }
        /// <summary>
        /// Specifies whether the user can de-select the scope on the consent screen (if the consent screen wants to implement such a feature). Defaults to false.
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// Specifies whether the consent screen will emphasize this scope (if the consent screen wants to implement such a feature).
        /// Use this setting for sensitive or important scopes. Defaults to false.
        /// </summary>
        public bool Emphasize { get; set; } = false;
    }
}
