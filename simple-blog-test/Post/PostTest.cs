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
        int id = 1;
        string title = "This is a title test";
        string body = "This is a body test";
        bool isDraft = true;
        DateTime createdAt = DateTime.Now;
        Post expected = new Post(id, title, body, isDraft, createdAt);

        // Assert
        Assert.AreEqual(expected.Id, id);
        Assert.AreEqual(expected.Title, title);
        Assert.AreEqual(expected.Body, body);
        Assert.AreEqual(expected.IsDraft, true);
        Assert.AreEqual(expected.CreatedAt, createdAt);


    }
}
