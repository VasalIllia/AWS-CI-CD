using NUnit.Framework;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;

[TestFixture]
public class TestAPI
{
    private HttpClient _client;
    private WebApplicationFactory<Program> _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }
    [TearDown]
    public void TearDown()
    {
        _factory.Dispose();
        _client.Dispose();
    }

    [Test]
    public async Task TestApi()
    {
        var response = await _client.GetAsync("/");
        var content = await response.Content.ReadFromJsonAsync<MessageResponse>();

        Assert.That(content.Message, Is.EqualTo("Hello, AWS CI/CD BEANSTALK!"));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    private record MessageResponse(string Message);
}
