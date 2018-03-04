using System;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Data.Sqlite;
using Dapper;
using System.Data;
using working.Models.DataModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using working.Models.Repository;

namespace working
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
            //验证注入
            services.AddAuthentication(opts =>
            {
                opts.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
             {
                 opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/login");
                 opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/home/error");
                 opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/login");
             });

            //注入仓储
            AddRepository(services);
             
        }
        
        /// <summary>
        /// 注入仓储
        /// </summary>
        /// <param name="services">服务容器</param>
        void AddRepository(IServiceCollection services)
        {
            var conStr = string.Format(Configuration.GetConnectionString("DefaultConnection"), System.IO.Directory.GetCurrentDirectory());
            services.AddSingleton(conStr);//注入链接字符串
            services.AddScoped<IDbConnection,SqliteConnection>();//注入链接对象
            //注入用户仓储类
            services.AddScoped<IUserRepository,UserRepository>();//注入
            services.AddScoped<IDepartRepository, DepartRepository>();//注入部门仓储接口类
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();//启用验证中间键

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=department}/{id?}");
            });
        }
    }
}
