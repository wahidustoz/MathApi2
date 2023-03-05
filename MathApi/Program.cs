using MathApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<IMathService, MathService>();

var app = builder.Build();
app.MapControllers();
app.Run();