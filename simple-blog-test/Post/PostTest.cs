namespace simple_blog_test;
using simple_blog;
using simple_blog.Domain.Post.Model;

[TestClass]
public class PostTest
{
    [TestMethod]
    public void Creates_New_Post_And_Validates()
    {
        // Arrange
        string title = "This is a title test";
        string body = "This is a body test";
        Post expected = new Post(title, body);

        // Assert
        Assert.AreEqual(expected.Title, title);
        Assert.AreEqual(expected.Body, body);
        Assert.AreEqual(expected.IsDraft, true);

    }
}
