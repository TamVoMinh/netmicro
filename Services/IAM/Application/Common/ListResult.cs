using System.Collections.Generic;
using System.Linq;

namespace Nmro.IAM.Application
{
    public class PageResult<T> where T: class
    {
        public PageResult(int total, int offset, int limit, IEnumerable<T> items){
            Total = total;
            Offset = offset.ClaimOffset(total, limit);
            Litmit = limit.ClaimLimit(items.Count());
            Data = items;
        }

        public int Total { get; set; }
        public int Offset { get; set; }
        public int Litmit { get; set; }
        public IEnumerable<T> Data { get; set; }
    }

    public static class IntExtensions
    {
        public static int ClaimOffset(this int offset, int total, int limit) => offset < total - limit ? offset : total;

        public static int ClaimLimit(this int limit, int size) => size < limit ? size : limit;

    }
}
