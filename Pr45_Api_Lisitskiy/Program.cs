using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры
builder.Services.AddControllers();  // ← вместо AddRazorPages и AddMvc

// Настройка Swagger
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Запросы GET",
        Description = "GET запросы API"
    });

    option.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v2",
        Title = "Запросы POST",
        Description = "POST запросы API"
    });

    string PathFile = Path.Combine(System.AppContext.BaseDirectory, "Pr45_Api_Lisitskiy.xml");
    option.IncludeXmlComments(PathFile);

    // Добавляем аннотации для каждой версии
    option.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out var methodInfo)) return false;
        var versions = methodInfo.DeclaringType?.GetCustomAttributes(true)
            .OfType<ApiExplorerSettingsAttribute>().Select(attr => attr.GroupName);
        if (versions?.Any() == true)
            return versions.Contains(docName);
        return true;
    });
});

var app = builder.Build();

// Настройка конвейера
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
});

app.UseRouting();
app.MapControllers();  // ← вместо UseEndpoints

app.Run();