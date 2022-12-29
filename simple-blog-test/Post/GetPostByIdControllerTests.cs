using System.Net;
using simple_blog;
using simple_blog.Domain.Post.Model;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Assert = Xunit.Assert;
using System.Net.Http.Json;
using Microsoft.Extensions.Hosting;

namespace simple_blog_test.Controllers
{
    [Collection("GetPostByIdControllerTest")]
    public class GetPostByIdControllerTest
    {
        [Fact]
        public async void TestAPI()
        {
            // Crea una instancia de HttpClient
            var client = new HttpClient();

            // Realiza una solicitud HTTP a tu API
            var response = await client.GetAsync("http://localhost:5000/api/endpoint");

            // Valida el contenido de la respuesta
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Equal("Resultado esperado", responseContent);
        }
    }
}

