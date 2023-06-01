using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApiTests.Support
{
    public class CommonData
    {
        protected readonly string? _hostName;
        public static HttpClient? HttpClient;
        public string? Url;
        public StringContent? RequestBody;
        public string? ResponseBody;
        public HttpResponseMessage? response;
        
        public CommonData() 
        {
            _hostName = "https://petstore.swagger.io/v2";
            HttpClient = new HttpClient();

        }
    }
}
