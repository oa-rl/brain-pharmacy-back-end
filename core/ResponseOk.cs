namespace Core
{
    public class ResponseOk<T>
    {
        public int StatusCode { get; set; } = 0;
        public bool Ok { get; set; } = false;
        public T Data { get; set; } = default!;
        public ResponseOk(int statusCode, bool ok, T data) { 
            StatusCode = statusCode;
            Ok = ok;
            Data = data;
        }
    }
}
