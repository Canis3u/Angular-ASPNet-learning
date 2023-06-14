using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using week3.Models;
using week3.Service;
using week3.Service.Interface;
using week3.Repositories;

namespace week3
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "week3", Version = "v1" });
            });
            /// Scaffold-DbContext "Server=LAPTOP-D0C7EI0R;Database=Weatherforecast;Trusted_Connection=True;TrustServerCertificate=True;User ID=sa;Password=qqqqqqqqqqqqqqq" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
            services.AddDbContext<WeatherforecastContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WeatherforecastDatabase")));
            services.AddScoped<IWeatherforecastService, WeatherforecastService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<WeatherforecastRepostory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "week2 v1"));
            }
            app.UseCors("CorsPolicy");
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