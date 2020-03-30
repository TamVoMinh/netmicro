using System.Collections.Generic;
using Nmro.Common.Models;


namespace Nmro.IAM.Application.UseCases.Resources.Models
{
    public class PageApiResource: PageResult<ApiResource>{
        public PageApiResource(int total, int offset, int limit, IEnumerable<ApiResource> items): base(total, offset, limit, items){}

    }

    public class PageIdentityResource: PageResult<IdentityResource>{
        public PageIdentityResource(int total, int offset, int limit, IEnumerable<IdentityResource> items): base(total, offset, limit, items){}

    }
}
