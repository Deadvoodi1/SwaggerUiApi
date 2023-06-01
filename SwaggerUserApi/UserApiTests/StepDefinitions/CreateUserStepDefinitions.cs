using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using UserApiTests.Support;

namespace UserApiTests.StepDefinitions
{
    [Binding]
    public class CreateUserStepDefinitions : CommonData
    {

        [Given(@"path ""([^""]*)""")]
        public void GivenPathHttps(string endpoint)
        {
            Url = _hostName + endpoint;
        }

        [Given(@"update user ""([^""]*)""")]
        public void GivenUpdateUser(string endpoint)
        {
            Regex regex = new Regex("{username}");

            if (regex.IsMatch(endpoint))
                endpoint = endpoint.Replace("{username}", searchingUsername);

            Url = _hostName + endpoint;
        }

        [Given(@"request body")]
        public void GivenRequestBody()
        {
            var userData = UserData.CreateUserForRequest();

            RequestBody = new StringContent(JsonConvert.SerializeObject(userData));
            RequestBody.Headers.ContentType.MediaType = "application/json";
        }

        [Given(@"request body for users array")]
        public void GivenRequestBodyForUsersArray()
        {
            var userData = UserData.CreateUserListForRequest();

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

        [When(@"method is PUT")]
        public async Task WhenMethodIsPUT()
        {
            try
            {
                response = await HttpClient.PutAsync(Url, RequestBody);
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

        [Then(@"users are created and response is correct")]
        public void ThenUsersAreCreatedAndResponseIsCorrect()
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

        [Then(@"username updated successfully and status code is correct")]
        public void ThenUsernameUpdatedSuccessfullyAndStatusCodeIsCorrect()
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
