using FluentAssertions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Salesforce.CRM.UI.Tests.Specs.PetstoreApi;

public class UserApiTests : ApiTestBase
{
    [Test]
    public async Task User_Login_Returns_Successful()
    {
        var response = await requestContext.GetAsync("/api/v3/user/login", new APIRequestContextOptions()
        {
            DataObject = new 
            {
                Username = "test",
                Password = "default"
            }
        });
        response.Status.Should().Be(200);
    }

}