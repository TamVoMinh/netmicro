using System.Collections.Generic;
using Nmro.Common.Models;


namespace Nmro.IAM.Core.UseCases.IdentityResources.Dtos
{
    public class PageIdentityResource: PageResult<IdentityResource>{
        public PageIdentityResource(int total, int offset, int limit, IEnumerable<IdentityResource> items): base(total, offset, limit, items){}

    }
}
