using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koy.Blog.Data;
using Koy.Blog.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Koy.Blog
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });
            services.AddTransient<ArticleRepository>();
            services.AddScoped<IDocumentSession>(s => DocumentStoreHolder.Store.OpenSession());
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
                    name: "random_article",
                    template: "Blog/RandomArticle",
                    defaults: new { controller = "Blog", action = "ReadRandomArticle" });
                routes.MapRoute(
                    name: "blog",
                    template: "Blog/{*article}",
                    defaults: new { controller = "Blog", action= "ReadArticle"}
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
