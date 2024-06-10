using Salesforce.CRM.UI.Tests.Framework.Base;
using Salesforce.CRM.UI.Tests.Pages;


public class LoginTests : WebTestBase
{
    [Test]
    public async Task Authentication_ValidCredentials_ReturnSuccessful()
    {
        // Arrange      
        string? username = Environment.GetEnvironmentVariable("USERNAME");
        string? password = Environment.GetEnvironmentVariable("PASSWORD");

        // Act        
        var loginPage = new LoginPage(page);
        await loginPage.LoginAs(username!, password!);

        // Assert
    }

}