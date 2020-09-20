using System.Collections.Generic;
using Nmro.Shared.Models;


namespace Nmro.Security.IAM.Core.UseCases.IdentityResources.Dtos
{
    public class PageIdentityResource: PageResult<IdentityResource>{
        public PageIdentityResource(int total, int offset, int limit, IEnumerable<IdentityResource> items): base(total, offset, limit, items){}

    }
}
