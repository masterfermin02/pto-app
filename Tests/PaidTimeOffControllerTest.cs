using System.Diagnostics;
using PtoAppTest;
using Xunit;

namespace Tests;
internal record PaidTimeOff(int Id, string FirstName, string LastName, long Type, DateTime PtoDate);

public class PaidTimeOffControllerTest : IDisposable
{
    private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7142/api") };

    [Fact]
    public async Task GivenARequest_WhenCallingGetPaidTimeOff_ThenTheAPIReturnsExpectedResponse()
    {
        var expectedStatusCode = System.Net.HttpStatusCode.OK;
        var expectedContent = new[]
        {
            new PaidTimeOff(1, "Test first name", "LastName", 1, new DateTime())
        };
        var stopwatch = Stopwatch.StartNew();
        // Act.
        var response = await _httpClient.GetAsync("/PaidTimeOff");
        // Assert.
        await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
    }

    public void Dispose()
    {
        _httpClient.DeleteAsync("/state").GetAwaiter().GetResult();
    }
}
