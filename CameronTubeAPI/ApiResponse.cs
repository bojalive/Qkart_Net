using System.Net;

namespace CameronTubeAPI
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public bool isSuccess { get; set; } = true;
        public object Result { get; set; }
    }
}
