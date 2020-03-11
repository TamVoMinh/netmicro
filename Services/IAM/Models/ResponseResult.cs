namespace Nmro.IAM.Models
{
    public class ResponseResult<T> where T: new()
    {
        public int Total { get; set; }

        public T Data { get; set; }
    }
}
