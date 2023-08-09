namespace testapp.Dtos
{
    public class ResponseData<T>
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
        public List<T>? Data { get; set; } = null;
    }
}