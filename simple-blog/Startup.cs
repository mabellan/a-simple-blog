using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using simple_blog.Domain.Post;
using simple_blog.Domain.Post.Command;
using simple_blog.Domain.Post.Model;
using simple_blog.Domain.Post.Query;
using simple_blog.Infrastructure.Delivery.Configuration;
using simple_blog.Infrastructure.Domain.Posts;
using simple_blog.Infrastructure.Persistance.Database;
using Microsoft.OpenApi.Models;

namespace simple_blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AddSwagger(services);

            services.AddDbContext<SimpleBlogDatabase>(options =>
                                                         options.UseNpgsql(Configuration.GetConnectionString("Database")));
            services.AddCors();
            services.AddSingleton<ICommandBus, CommandBus>();
            services.AddScoped<IPostRepository, NpgsqlPostRepository>();

            services.AddTransient<IQueryHandler<GetPostByIdQuery, Post>, GetPostByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetPostsQuery, List<Post>>, GetPostsQueryHandler>();

            services.AddTransient<QueryBus>();


            services.AddControllers();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"A simple blog API {groupName}",
                    Version = groupName,
                    Description = "A simple blog API",
                    Contact = new OpenApiContact
                    {
                        Name = "Miguel's Project",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "A simple blog API V1");
            });

            app.UseCors(x => x
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials()); 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}
