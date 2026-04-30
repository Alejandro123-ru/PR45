using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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

    option.SwaggerDoc("v3", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v3",
        Title = "Запросы PUT",
        Description = "PUT запросы API"
    });

    string PathFile = Path.Combine(System.AppContext.BaseDirectory, "Pr45_Api_Lisitskiy.xml");
    option.IncludeXmlComments(PathFile);

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
    c.SwaggerEndpoint("/swagger/v3/swagger.json", "Запросы PUT");
});

app.UseRouting();
app.MapControllers(); 

app.Run();