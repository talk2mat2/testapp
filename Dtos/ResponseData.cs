namespace testapp.Dtos
{
    public class ResponseData<T>
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}