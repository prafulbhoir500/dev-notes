# Steps to Scaffold Entity Classes in Specific Folders

Scaffold-DbContext -Connection name=DefaultConnection Microsoft.EntityFrameworkCore.SqlServer -OutputDir "../SSO.Domain/Entities" -Namespace SSO.Domain -ContextDir "Persistence" -Context "ApplicationDbContext" -ContextNamespace SSO.Infrastructure  -Project SSO.Infrastructure -StartupProject SSO.Web -Force


# Regenerate Without Overwriting Custom Modifications

Scaffold-DbContext "Your_Connection_String" Microsoft.EntityFrameworkCore.SqlServer `
    -ContextDir "Persistence" `
    -Context "ApplicationDbContext" `
    -Project SSO.Infrastructure `
    -StartupProject SSO.Web `
    -NoOnConfiguring `
    -NoPluralize `
    -Force

https://1drv.ms/o/c/e023ed817c66522b/EitSZnyB7SMggOBmRgAAAAAByAEKxc5wQzA83gem7b9vJw?e=cfEoPV
