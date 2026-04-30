using Microsoft.OpenApi.Models;

namespace Pr45_Api_Lisitskiy
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Запросы GET",
                    Description = "Полное руководство для GET запросов"
                });

                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Запросы POST",
                    Description = "Полное руководство для POST запросов"
                });

                c.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3",
                    Title = "Запросы PUT",
                    Description = "Полное руководство для PUT запросов"
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "ASP_GET.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "Запросы PUT");
            });
        }
    }
}
