using Newtonsoft.Json;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using UserApiTests.Support;

namespace UserApiTests.StepDefinitions
{
    [Binding]
    public class CreateUserStepDefinitions
    {

        private readonly string _hostName;
        public static HttpClient? HttpClient;
        public string Url;
        public StringContent RequestBody;
        public string ResponseBody;
        public HttpResponseMessage response;
        public CreateUserStepDefinitions()
        {
            _hostName = "https://petstore.swagger.io/v2";
            HttpClient = new HttpClient();

        }

        [Given(@"path ""([^""]*)""")]
        public void GivenPathHttps(string endpoint)
        {
               Url = _hostName + endpoint;
        }

        [Given(@"request body")]
        public void GivenRequestBody()
        {
            UserData userData = new UserData()
            {
                id = 1,
                username = "qwe",
                firstName = "qwe",
                lastName = "qwe",
                email = "qwe",
                password = "qwe",
                phone = "qwe",
                userStatus = 1
            };

            RequestBody = new StringContent(JsonConvert.SerializeObject(userData));
            RequestBody.Headers.ContentType.MediaType = "application/json";
        }

        [When(@"method is POST")]
        public async Task WhenMethodIsPOST()
        {
            try
            {
                response = await HttpClient.PostAsync(Url, RequestBody);
                ResponseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }


        [Then(@"user is created and response is correct")]
        public void ThenUserIsCreatedAndResponseIsCorrect()
        {
            try
            {
                Assert.IsTrue(response.IsSuccessStatusCode);
                if (!ResponseBody.Contains("type"))
                    Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }
    }
}
