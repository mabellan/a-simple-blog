namespace simple_blog_test;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

[TestClass]
public class GetPostByIdControllerTests : IClassFixture<WebApplicationFactory<simple_blog.Startup>>
{
    readonly HttpClient _client;
    public GetPostByIdControllerTests(WebApplicationFactory<simple_blog.Startup> application)
    {
        _client = application.CreateClient();
    }

    [Fact]
    public async Task GET_retrieves_a_post_by_id()
    {
        int id = 1;
        var response = await _client.GetAsync($"/api/posts/{id}");

        response.StatusCode.Equals(HttpStatusCode.OK);
    }
}
