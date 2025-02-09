# ASP.NET Clean Architecture Example

This repository demonstrates the use of Clean Architecture for an ASP.NET application. Clean Architecture promotes separation of concerns and helps make the application easier to maintain, test, and scale.

## Overview of Layers

Clean Architecture consists of several layers that are independent of each other. The key idea is that higher layers depend on lower layers, but lower layers should not depend on higher layers.

### Layers:

1. **Presentation Layer (UI)**:
   - **Responsibilities**: Manages user interaction, takes input from the user, and sends requests to the application layer.
   - **Examples**: ASP.NET MVC Controllers, API Controllers, Razor Pages.
   - **Dependencies**: References the Application Layer.
   
2. **Application Layer**:
   - **Responsibilities**: Contains business logic, application use cases, and service interfaces.
   - **Examples**: Use case services, DTOs, application-specific interfaces.
   - **Dependencies**: References the Domain Layer for entities and business logic.
   
3. **Infrastructure Layer**:
   - **Responsibilities**: Implements external systems such as databases, logging, email services, file systems, and third-party APIs.
   - **Examples**: Data repositories, email services, file handling.
   - **Dependencies**: References the Application Layer to implement the service interfaces.
   
4. **Domain Layer**:
   - **Responsibilities**: Contains business entities and domain logic, representing the core business rules.
   - **Examples**: Entities, Value Objects, Domain Events.
   - **Dependencies**: This layer is independent of all other layers.

### Layer Dependencies:
- **Presentation Layer** references **Application Layer**.
- **Application Layer** references **Domain Layer**.
- **Infrastructure Layer** implements interfaces defined by the **Application Layer**.
- **Domain Layer** is independent of all other layers.

## Architecture Diagram

# SSO Solution Architecture

| **Web Project (UI Layer)**  | **Application Layer**         | **Infrastructure Layer**  |
| --------------------------- | ----------------------------- | ------------------------- |
| 🔄 **Controllers**           | 📋 **Use Cases**              | 🗄️ **Repositories**       |
| 🌐 **Views / API**           | ⏩ **Commands**               | 🛠️ **Services**           |
|                             | 📦 **DTOs**                   |                           |
|                             |                               |                           |
| **Domain Layer**             |                               |                           |
| 🏢 **Entities**              |                               |                           |
| 🎯 **Value Objects**         |                               |                           |
| 🧠 **Domain Logic**          |                               |                           |


**Arrows:**
- `Web Project (UI Layer)` → `Application Layer`
- `Application Layer` → `Infrastructure Layer`
- `Application Layer` → `Domain Layer`
