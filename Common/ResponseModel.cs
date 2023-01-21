namespace IoTBackend.Common
{
    public class ResponseModel
    {
        public int StatusCode { get; set; } 
        public string StatusMessage { get; set; }
        public object Data { get; set; }
    }
}
