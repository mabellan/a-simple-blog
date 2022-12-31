using simple_blog.Domain.Post.Command;
using simple_blog.Domain.Post.Model;
using simple_blog.Domain.Post.Query;
namespace simple_blog_test;

[TestClass]
public class GetPostByIdQueryTest
{
    [TestMethod]
    public void Creates_New_Get_Post_By_Id_Query()
    {
        // Arrange
        int id = 1;
        GetPostByIdQuery expected = new GetPostByIdQuery(id);

        // Assert
        Assert.AreEqual(expected.Id, id);
    }
}
