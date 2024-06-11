
using Microsoft.Playwright;
using Salesforce.CRM.UI.Tests.Framework.Drivers;

public class ApiTestBase
{
    protected IAPIRequestContext requestContext;


    public ApiTestBase()
    {        
        requestContext = new ApiDriver().APIRequestContext;
    }

    // [SetUp]
    // public async Task Setup()
    // {
    //     requestContext = await ApiDriver.GetContext();
    // }
}