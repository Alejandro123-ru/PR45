var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(option => option.EnableEndpointRouting = true);
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Пробая версия"
    });

    string PathFile = Path.Combine(System.AppContext.BaseDirectory, "WebApplication2.xml");
    option.IncludeXmlComments(PathFile);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Пробая версия");
});

app.Run();