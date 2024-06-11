using Microsoft.Playwright;

namespace Salesforce.CRM.UI.Tests.Framework.Drivers;

public class ApiDriver : IDisposable
{
    protected readonly Task<IAPIRequestContext> _apiRequestContext;

    public IAPIRequestContext APIRequestContext => _apiRequestContext.GetAwaiter().GetResult();


    public static Task<IAPIRequestContext> GetContext()
    {
        var apiDriver = new ApiDriver();
        return apiDriver._apiRequestContext;

    }

    public ApiDriver()
    {
        _apiRequestContext = InitializePlaywright();
    }
    
    public async Task<IAPIRequestContext> InitializePlaywright()
    {
        var playwright = await Playwright.CreateAsync();
        var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions() 
        {
            BaseURL = "https://petstore3.swagger.io",
            IgnoreHTTPSErrors = true
        });

        return requestContext;
    }

    public void Dispose()
    {
        _apiRequestContext.Dispose();
    }
}