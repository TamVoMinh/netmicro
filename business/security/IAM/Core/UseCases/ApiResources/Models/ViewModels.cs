using System.Collections.Generic;
using Nmro.Shared.Models;

namespace Nmro.Security.IAM.Core.UseCases.ApiResources.Dtos
{
    public class PageApiResource: PageResult<ApiResource>{
        public PageApiResource(int total, int offset, int limit, IEnumerable<ApiResource> items): base(total, offset, limit, items){}

    }
}
