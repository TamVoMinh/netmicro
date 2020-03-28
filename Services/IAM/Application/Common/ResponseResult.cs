using System.Collections.Generic;
namespace Nmro.IAM.Application
{
    public class ResponseResult<T> where T: new()
    {
        public int Total { get; set; }
        public T Data { get; set; }
    }
     public class ResponseListResult<T> where T: class
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
