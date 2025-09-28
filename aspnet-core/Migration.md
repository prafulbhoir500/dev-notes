# Auto Migration
## Apply Migrations Programmatically on Startup
Modify your Program.cs or Startup.cs to apply migrations automatically when the app starts:
```
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<YourDbContext>();
    db.Database.Migrate();
}

app.Run();

```
