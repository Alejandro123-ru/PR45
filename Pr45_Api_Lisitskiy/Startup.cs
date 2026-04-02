using Microsoft.OpenApi.Models;

namespace Pr45_Api_Lisitskiy
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Отключаем маршрутизацию по конечным точкам, говоря о том что будем использовать
            // устаревшую технологию
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // Сообщаем что будем использовать swagger, со следующими настройками
            services.AddSwaggerGen(c =>
            {
                // Прописываем документацию для версии 1
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    // Указываем версию документации
                    Version = "v1",
                    // Указываем заголовок документации
                    Title = "Руководство для использования запросов",
                    // Указываем описание документации
                    Description = "Полное руководство для использования запросов находящихся в проекте"
                });
                // Получаем путь до XML комментариев
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "ASP_GET.xml");
                // Подключаем XML комментарии для swagger
                c.IncludeXmlComments(filePath);
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
            });
        }
    }
}
