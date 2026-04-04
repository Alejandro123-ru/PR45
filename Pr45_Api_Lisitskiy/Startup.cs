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
                // Версия 1
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Запросы GET",
                    Description = "Полное руководство для GET запросов"
                });

                // Версия 2
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Запросы POST",
                    Description = "Полное руководство для POST запросов"
                });

                // Подключаем XML комментарии для каждой версии
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "ASP_GET.xml");
                c.IncludeXmlComments(xmlPath);

                // Если есть отдельный XML для POST запросов, добавьте его:
                // var xmlPath2 = Path.Combine(AppContext.BaseDirectory, "ASP_POST.xml");
                // c.IncludeXmlComments(xmlPath2);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Отображаем страницу с ошибками
            app.UseDeveloperExceptionPage();
            // Отображаем коды ошибок
            app.UseStatusCodePages();
            // Включаем отслеживание URL адресов
            app.UseMvcWithDefaultRoute();
            // Сообщаем что используем swagger
            app.UseSwagger();
            // Задаём настройки для отображения
            app.UseSwaggerUI(c =>
            {
                // Устанавливаем использование конечной точки для первой версии
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
            });
        }
    }
}
