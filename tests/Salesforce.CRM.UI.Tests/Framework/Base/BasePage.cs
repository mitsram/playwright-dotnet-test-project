using Microsoft.Playwright;

namespace Salesforce.CRM.UI.Tests.Framework.Base;

public class BasePage(IPage page)
{
    protected IPage _page = page;
}