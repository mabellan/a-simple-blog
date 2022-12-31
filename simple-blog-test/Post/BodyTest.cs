namespace simple_blog_test;
using simple_blog;
using simple_blog.Domain.Post.Model;


[TestClass]
public class BodyTest
{
    [TestMethod]
    public void Creates_New_Body_Pass_Test()
	{
        // Arrange
        string body = "This is a body test";
        Body expected = new Body(body);

        // Assert
        Assert.AreEqual(expected.aBody, body);
    }
}


