using System.Collections.Generic;
using System.Linq;
using System;

namespace Nmro.Common.Models
{
    public class PageResult<T> where T: class
    {
        public PageResult(int total, int offset, int limit, IEnumerable<T> items){
            Total = total;
            Litmit = Math.Min(limit, items.Count());
            Offset = offset.ClampOffset(Total, Litmit);
            Data = items;
        }

        public int Total { get; set; }
        public int Offset { get; set; }
        public int Litmit { get; set; }
        public IEnumerable<T> Data { get; set; }
    }

    public static class IntExtensions
    {
        public static int ClampOffset(this int offset, int total, int limit) =>  total > limit ? Math.Min(offset, total - limit) : 0 ;
    }
}
