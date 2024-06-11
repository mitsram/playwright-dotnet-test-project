using dotenv.net;
using Microsoft.Playwright;
using Allure.NUnit;
using Microsoft.Playwright.NUnit;
using Salesforce.CRM.UI.Tests.Framework.Drivers;

namespace Salesforce.CRM.UI.Tests.Framework.Base;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
public class WebTestBase
{
    protected IPage page;

    public WebTestBase()
    {
        string solutionRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../"));
        string envFilePath = Path.Combine(solutionRoot, ".env");
        DotEnv.Load(options: new DotEnvOptions(ignoreExceptions: false, envFilePaths: new[] {envFilePath}));

        page = Driver.Get();
    }

    [SetUp]
    public async Task Setup()
    {
        await page.GotoAsync("/");
    }

    [TearDown]
    public async Task Teardown()
    {
        await page.CloseAsync();
    }

}