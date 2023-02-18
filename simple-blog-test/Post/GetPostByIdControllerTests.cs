namespace simple_blog_test;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using simple_blog.Domain.Post.Model;
using simple_blog.Domain.Post.Query;
using simple_blog.Infrastructure.Delivery.Configuration;
using simple_blog.Infrastructure.Delivery.Controllers.Posts;
using Xunit;
using Moq;

[TestClass]
public class GetAllPostsControllerTest
{
    private readonly Mock<QueryBus> _mockQueryBus;
    private readonly GetAllPostsController _controller;

    public GetAllPostsControllerTest()
    {
        _mockQueryBus = new Mock<QueryBus>();
        _controller = new GetAllPostsController(_mockQueryBus.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkObjectResult_WithPostsList()
    {
        // Arrange
        string titleFilter = "example";
        int page = 1;
        var query = new GetPostsQuery(titleFilter, page);
        var posts = new List<Post>() { new Post(), new Post() };
        _mockQueryBus.Setup(x => x.Execute(query)).Returns(posts);

        // Act
        var result = await _controller.GetAll(titleFilter, page);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(posts, okResult.Value);
    }

    [Fact]
    public async Task GetAll_ReturnsBadRequestObjectResult_WithExceptionMessage()
    {
        // Arrange
        string titleFilter = "example";
        int page = 1;
        var query = new GetPostsQuery(titleFilter, page);
        var exception = new Exception("An error occurred.");
        _mockQueryBus.Setup(x => x.Execute(query)).Throws(exception);

        // Act
        var result = await _controller.GetAll(titleFilter, page);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;
        Assert.Equal(exception.Message, badRequestResult.Value);
    }
}
