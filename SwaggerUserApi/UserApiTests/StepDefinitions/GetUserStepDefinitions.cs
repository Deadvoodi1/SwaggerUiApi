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

        [Given(@"user ""([^""]*)""")]
        public void GivenPathHttps(string endpoint)
        {
            Regex regex = new Regex("{username}");

            if (regex.IsMatch(endpoint))
                endpoint = endpoint.Replace("{username}", searchingUsername);

            Url = _hostName + endpoint;
        }

        [Given(@"deleting user ""([^""]*)""")]
        public void GivenDeletingUser(string endpoint)
        {
            Regex regex = new Regex("{username}");

            if (regex.IsMatch(endpoint))
                endpoint = endpoint.Replace("{username}", usernameForDeleting);

            Url = _hostName + endpoint;
        }

        [Given(@"login path ""([^""]*)""")]
        public void GivenLoginPath(string endpoint)
        {
            Regex regex = new Regex("login");

            if (regex.IsMatch(endpoint))
                endpoint = $"{endpoint}?username={searchingUsername}&password={searchingPassword}";

            Url = _hostName + endpoint;
        }

        [Given(@"logout path ""([^""]*)""")]
        public void GivenLogoutPath(string endpoint)
        {
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

        [When(@"method is DELETE")]
        public async Task WhenMethodIsDELETE()
        {
            try
            {
                response = await HttpClient.DeleteAsync(Url);
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

        [Then(@"logout is successfull and status code is correct")]
        public void ThenLogoutIsSuccessfullAndStatusCodeIsCorrect()
        {
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Then(@"logins is successfull and status code is correct")]
        public void ThenLoginsIsSuccessfullAndStatusCodeIsCorrect()
        {
            try
            {
                Assert.IsTrue(response.IsSuccessStatusCode);
                if (!ResponseBody.Contains("logged in user session"))
                    Assert.Fail();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }

        [Then(@"user deleted successfully and status code is correct")]
        public void ThenUserDeletedSuccessfullyAndStatusCodeIsCorrect()
        {
            try
            {
                Assert.IsTrue(response.IsSuccessStatusCode);
                if (!ResponseBody.Contains($"\"message\":\"{usernameForDeleting}\""))
                    Assert.Fail();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
        }
    }
}
