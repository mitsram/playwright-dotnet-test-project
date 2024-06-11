using Microsoft.Playwright;

namespace Salesforce.CRM.UI.Tests.Framework.Drivers;

public class DriverFactory(BrowserType browserType)
{
    private readonly BrowserType _browserType = browserType;

    public async Task<IBrowserType> CreateDriver()
    {        
        var playwright = await Playwright.CreateAsync();

        return _browserType switch
        {
            BrowserType.Chrome => playwright.Chromium,
            BrowserType.Safari => playwright.Webkit,
            BrowserType.Firefox => playwright.Firefox,
            _ => throw new ArgumentException("Invalid browser type"),
        };
    }
}

public enum BrowserType
{
    Chrome,
    Firefox,
    Safari
}
