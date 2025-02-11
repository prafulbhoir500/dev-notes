# Steps to Scaffold Entity Classes in Specific Folders

 Scaffold-DbContext -Connection "Your_Connection_String" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "../SSO.Domain/Entities"-ContextDir "Persistence" -Context "ApplicationDbContext" -Project SSO.Infrastructure -StartupProject SSO.Web -NoPluralize -Force


# Regenerate Without Overwriting Custom Modifications

Scaffold-DbContext "Your_Connection_String" Microsoft.EntityFrameworkCore.SqlServer `
    -ContextDir "Persistence" `
    -Context "ApplicationDbContext" `
    -Project SSO.Infrastructure `
    -StartupProject SSO.Web `
    -NoOnConfiguring `
    -NoPluralize `
    -Force
