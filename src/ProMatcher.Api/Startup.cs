using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using ProMatcher.Domain.FixedValues;
using ProMatcher.Domain.Repositories;
using ProMatcher.Domain.Services;
using ProMatcher.Infra.Repositories;

namespace ProMatcher.Api
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
            services.AddScoped<MatchProService>();
            services.AddScoped<IReferralCodeRepository, ReferralCodeRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pro Matcher API", Version = "v1" });
                //c.MapType<EEducationLevel>(() => new OpenApiSchema
                //{
                //    Type = "string",
                //    Enum = typeof(EEducationLevel).GetEnumNames().Select(name => new OpenApiString(name)).Cast<IOpenApiAny>().ToList()
                //});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pro Matcher API V1");
                c.RoutePrefix = string.Empty;
            });

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