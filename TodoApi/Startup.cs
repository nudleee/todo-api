using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TodoApi.DAL;
using Newtonsoft.Json.Serialization;

namespace TodoApi
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

            // Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IColumnRepository, ColumnRepository>();


            var builder = new SqlConnectionStringBuilder(
                Configuration.GetConnectionString("TodoApp"));

            services.AddDbContext<KanbanBoardContext>(opt =>
               opt.UseSqlServer(builder.ConnectionString));

            services.AddControllers();

            services.AddControllersWithViews().AddNewtonsoftJson(opt =>
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable CORS
            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
