using BalabolaBot.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();
await app.Services.ConfigureBotAsync(app.Configuration);

app.UseRouting();
app.MapControllers();

app.Run();