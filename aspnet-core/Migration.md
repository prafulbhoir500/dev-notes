# Auto Migration
## Apply Migrations Programmatically on Startup **`(in Program.cs)`**
Modify your Program.cs or Startup.cs to apply migrations automatically when the app starts:
```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<YourDbContext>();
    db.Database.Migrate();
}

app.Run();
```

# Migration Script

```csharp
Add-Migration {MigrationName}

Update-Database

OR Update-Database -Migration {Name} - Connection {Name}
    
```
---
# Generate the Migration Script (Option 1)

**Description:**  
Generates an idempotent SQL script that includes **all EF Core migrations** from the initial migration up to the latest.  
When executed, the script will **safely apply only the migrations that have not yet been applied**.


## Command

```powershell
Script-Migration  -Idempotent
```

## Notes
- Although the script contains all migrations, the `-Idempotent` flag ensures that only **pending migrations** will be applied when the script is executed.  
- Ideal for deployment environments where the full migration history is needed in a single script.  
- Use this option when you do **not** need to specify a starting migration.

---
# Generate the Migration Script (Option 2)

**Description:**  
Generates an idempotent SQL script that includes only the migrations created **after the specified migration** (`LastMigrationName`).  
Use this option when your database is already at a known migration level and you want to script **only the remaining pending migrations** required to reach the latest state.
 


## Command

```powershell
Script-Migration LastMigrationName -Idempotent
```

## Notes
- Replace **`LastMigrationName`** with the name of the most recently applied migration in the target database.  
- Only migrations created **after** `LastMigrationName` will be included in the generated script.  
- The `-Idempotent` flag ensures the script can be executed multiple times without causing errors.  
- Use this option when the database is already at a known migration state (e.g., during staged or incremental deployments).  
- Helpful when you want to script only the pending migrations rather than all migrations from the beginning.
