# EnterpriseSSOApp Solution Structure

## 📁 **EnterpriseSSOApp/**
- **📁 EnterpriseSSOApp.WebAPI/** (API Layer)
  - **📁 Controllers/** (Handles HTTP Requests)
    - `AuthController.cs`
    - `UserController.cs`
    - `CompanyController.cs`
    - `AuditLogController.cs`
    - `NotificationController.cs`
  - **📁 Middleware/** (Custom Middleware)
    - `TenantMiddleware.cs`
  - **Configuration Files:**  
    - `appsettings.json`
    - `Startup.cs`
    - `Program.cs`

- **📁 EnterpriseSSOApp.Domain/** (Core Domain Layer)
  - **📁 Entities/** (Core Entities for Business Logic)
    - `UserInfo.cs`
    - `Company.cs`
    - `Firm.cs`
    - `AuditLog.cs`
  - **📁 Enums/** (Enum Definitions)
  - **📁 Interfaces/** (Interfaces for Repositories, Services)
  - **📁 Common/** (Shared Utility/Helper Classes)

- **📁 EnterpriseSSOApp.Application/** (Business Logic Layer)
  - **📁 Services/** (Business Services)
    - `UserService.cs`
    - `AuthService.cs`
    - `AuditLogService.cs`
    - `NotificationService.cs`
  - **📁 DTOs/** (Data Transfer Objects)
  - **📁 Features/** (Business Features)
  - **📁 Interfaces/** (Service Interfaces)

- **📁 EnterpriseSSOApp.Infrastructure/** (Infrastructure Layer)
  - **📁 Persistence/** (Database Context and Seed Data)
    - `ApplicationDbContext.cs`
    - `SeedData.cs`
  - **📁 Repositories/** (Database Repositories)
    - `UserRepository.cs`
    - `AuditLogRepository.cs`
  - **📁 Security/** (Security Setup and JWT Service)
    - `IdentitySetup.cs`
    - `JwtTokenService.cs`
  - **📁 SignalR/** (Real-Time Notifications)
    - `NotificationHub.cs`

- **📁 EnterpriseSSOApp.Web/** (Frontend Layer - MVC / Blazor)
  - **📁 Pages/** (UI Pages)
    - `Login.cshtml`
    - `Register.cshtml`
    - `Dashboard.cshtml`
  - **📁 Components/** (UI Components)
  - **📁 wwwroot/** (Static Files)

- **📁 EnterpriseSSOApp.Tests/** (Unit & Integration Tests)
  - **📁 UnitTests/** (Unit Tests for Services and Repositories)
  - **📁 IntegrationTests/** (Integration Tests)

- **📁 EnterpriseSSOApp.Reports/** (Reporting Layer)
  - **📁 SSRS/** (SQL Server Reporting Services Reports)
  - **📁 CustomReports/** (Custom Report Implementations)

- **📁 EnterpriseSSOApp.Migrations/** (Database Migrations)
  - **📁 Scripts/** (SQL Migration Scripts)
    - `InitialCreate.sql`

- **📁 EnterpriseSSOApp.Docs/** (Documentation & API Specifications)
  - `API-Specs.md`
  - `Architecture.md`

---

## Getting Started

To get started with the project, clone the repository and follow the instructions in the respective layers to set up your local development environment.

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
