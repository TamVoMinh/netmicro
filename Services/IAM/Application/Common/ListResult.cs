using System.Collections.Generic;
namespace Nmro.IAM.Application
{
     public class ListResult<T> where T: class
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
