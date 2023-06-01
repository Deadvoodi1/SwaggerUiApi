using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using UserApiTests.Support;

namespace UserApiTests.StepDefinitions
{
    [Binding]
    public class GetUserStepDefinitions : CommonData
    {
        private string searchingUsername = "Faker";


        [Given(@"user ""([^""]*)""")]
        public void GivenPathHttps(string endpoint)
        {
            Regex regex = new Regex("{username}");

            if (regex.IsMatch(endpoint))
                endpoint = endpoint.Replace("{username}", searchingUsername);

            Url = _hostName + endpoint;
        }

        [When(@"method is GET")]
        public async Task WhenMethodIsGET()
        {
            try
            {
                response = await HttpClient.GetAsync(Url);
                ResponseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }

        [Then(@"user found and status code is correct")]
        public void ThenUserFoundAndStatusCodeIsCorrect()
        {
            try
            {
                Assert.IsTrue(response.IsSuccessStatusCode);
                if (!ResponseBody.Contains($"\"username\":\"{searchingUsername}\""))
                    Assert.Fail();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }
    }
}
