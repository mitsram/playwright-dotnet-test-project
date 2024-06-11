using System.Text.Json;
using FluentAssertions;
using Microsoft.Playwright;
using Salesforce.CRM.UI.Tests.Data;

namespace Salesforce.CRM.UI.Tests.Specs.PetstoreApi;

public class StoreApiTests : ApiTestBase
{
    [Test]
    public async Task Store_GetInventory_ReturnsInventoryByStatus()
    {
        var response = await requestContext.GetAsync("/api/v3/store/inventory");
        var jsonResponse = await response.JsonAsync();
        
        var jsonData = jsonResponse.Value.Deserialize<Inventory>(new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });
        
        jsonData?.Ordered.Should().Be(-443740524);        
    }
    
}