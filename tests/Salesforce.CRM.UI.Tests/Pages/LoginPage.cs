using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using Salesforce.CRM.UI.Tests.Framework.Base;

namespace Salesforce.CRM.UI.Tests.Pages;

public class LoginPage(IPage page) : BasePage(page)
{
    // private readonly IPage _page = page;

    private ILocator _txtUsername => _page.Locator("#username");
    private ILocator _txtPassword => _page.Locator("#password");
    private ILocator _btnSignIn => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Log In"});
    
    [AllureStep("Log in as {0}")]
    public async Task LoginAs(string username, string password)
    {        
        await _txtUsername.FillAsync(username);
        await _txtPassword.FillAsync(password);
        await _btnSignIn.ClickAsync();
    }
}
