
using Microsoft.Playwright;
using Salesforce.CRM.UI.Tests.Framework.Drivers;

public class ApiBuilder
{
    private IAPIRequestContext? requestContext;

    public async Task<ApiBuilder> Create()
    {
        requestContext = await ApiDriver.GetContext();
        return this;
    }

    public async Task<ApiBuilder> WithRequest(string endpoint)
    {
        await requestContext!.GetAsync(endpoint);
        return this;
    }


}