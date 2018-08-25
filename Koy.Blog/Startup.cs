using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koy.Blog.Core.Interfaces;
using Koy.Blog.Data;
using Koy.Blog.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Raven.Identity;

namespace Koy.Blog
{
    public class Startup
    {
        public IConfiguration Configuration { get;  }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var documentStore = new DocumentStore()
            {
                Urls = new string[] { "http://127.0.0.1:8081" },
                Database = "Koy"
            }.Initialize();
            services.AddRavenDbAsyncSession(documentStore)
                .AddRavenDbIdentity<IdentityUser>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(name: "version", template: "version");
                routes.MapRoute(
                    name: "random_BlogPost",
                    template: "Blog/RandomArticle",
                    defaults: new { controller = "Blog", action = "ReadRandomBlogPost" });
                routes.MapRoute(
                    name: "blog",
                    template: "Blog/{*BlogPost}",
                    defaults: new { controller = "Blog", action= "ReadBlogPost"}
                    );
                routes.MapRoute(
                    name: "default", 
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

         //app.Run(async (context) =>
        //{
        //    await context.Response.WriteAsync("Hello World!");
        //});
    }
}
