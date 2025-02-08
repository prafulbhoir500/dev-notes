/EnterpriseSSOApp
│── /EnterpriseSSOApp.sln  # Solution file
│
├── /EnterpriseSSOApp.Domain
│   ├── Entities/
│   │   ├── UserInfo.cs
│   │   ├── Company.cs
│   │   ├── Firm.cs
│   │   ├── AuditLog.cs
│   ├── Enums/
│   ├── Interfaces/
│   ├── Common/
│
├── /EnterpriseSSOApp.Application
│   ├── Services/
│   │   ├── UserService.cs
│   │   ├── AuthService.cs
│   │   ├── AuditLogService.cs
│   │   ├── NotificationService.cs
│   ├── DTOs/
│   ├── Features/
│   ├── Interfaces/
│
├── /EnterpriseSSOApp.Infrastructure
│   ├── Persistence/
│   │   ├── ApplicationDbContext.cs
│   │   ├── SeedData.cs
│   ├── Repositories/
│   │   ├── UserRepository.cs
│   │   ├── AuditLogRepository.cs
│   ├── Security/
│   │   ├── IdentitySetup.cs
│   │   ├── JwtTokenService.cs
│   ├── SignalR/
│   │   ├── NotificationHub.cs
│
├── /EnterpriseSSOApp.WebAPI
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── UserController.cs
│   │   ├── CompanyController.cs
│   │   ├── AuditLogController.cs
│   │   ├── NotificationController.cs
│   ├── Middleware/
│   │   ├── TenantMiddleware.cs
│   ├── appsettings.json
│   ├── Startup.cs
│   ├── Program.cs
│
├── /EnterpriseSSOApp.Web
│   ├── Pages/
│   │   ├── Login.cshtml
│   │   ├── Register.cshtml
│   │   ├── Dashboard.cshtml
│   ├── Components/
│   ├── wwwroot/
│
├── /EnterpriseSSOApp.Tests
│   ├── UnitTests/
│   ├── IntegrationTests/
│
├── /EnterpriseSSOApp.Reports
│   ├── SSRS/
│   ├── CustomReports/
│
