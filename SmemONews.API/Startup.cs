using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmemONews.BLL.Interfaces;
using SmemONews.BLL.Services;
using SmemONews.DAL.EF;
using SmemONews.DAL.Interfaces;
using SmemONews.DAL.Repositories;

namespace SmemONews.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmemONews.API", Version = "v1" });
            });

            string connectionString = Configuration.GetConnectionString("myconn");

            services.AddDbContext<DataContext>(option => option.UseSqlServer(connectionString));
            
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<ICommentPublishService, CommentPublishService>();
            services.AddScoped<INewsViewService, NewsViewService>();
            services.AddScoped<IEditNewsService, EditNewsService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<INewsModeratorService, NewsModeratorService>();
            services.AddScoped<INewsPublishService, NewsPublishService>();
            services.AddScoped<INewsFilterService, NewsFilterService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmemONews.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
