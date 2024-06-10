
using Microsoft.Playwright;

namespace Salesforce.CRM.UI.Tests.Drivers;

public class Driver
{
    private readonly Task<IPage> _page;
    private IBrowserContext? context;
    public IPage Page => _page.Result;


    public static IPage Get()
    {
        var driver = new Driver();
        return driver.Page;
    }

    public Driver()
    {
        _page = InitializePlaywright();
    }


    public async Task<IPage> InitializePlaywright()
    { 
        var factory = new DriverFactory(GetBrowserTypeFromEnv());
        var driver = await factory.CreateDriver();

        var browser = await driver.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });

        context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            BaseURL = Environment.GetEnvironmentVariable("BASE_URL")
        });

        return await context.NewPageAsync();
    }

    public static BrowserType GetBrowserTypeFromEnv()
    {
        string? envBrowserType = Environment.GetEnvironmentVariable("BROWSER_TYPE");
        string browserType = string.IsNullOrEmpty(envBrowserType) ? "Chrome" : envBrowserType;

        if (!Enum.TryParse(browserType, true, out BrowserType type))
            throw new ArgumentException($"Invalid browser type: {browserType}");
        return type;
    }

    public void Dispose()
    {
        context?.CloseAsync();
    }

}