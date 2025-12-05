# OpenIddict SSO – Real-Time Logout with SignalR (Multi-Subdomain Support)

This document describes how to implement **real-time logout** across multiple ASP.NET Core applications using:

- **OpenIddict** (for authentication & token management)
- **SignalR** (for real-time logout notifications)
- **Dynamic CORS** with automatic **subdomain allowance**

This allows you to support **dozens or hundreds of client apps**, like:

- https://app1.example.com  
- https://app2.example.com  
- https://portal.example.com  
- https://admin.example.com  

…without configuring each origin manually.

---

## 🚀 Features

- Single Sign-On (SSO)
- Real-time logout from all applications
- Automatic CORS for all subdomains (`*.example.com`)
- Shared `signalr.min.js` and `logout.js` hosted at SSO server
- Back-channel logout support
- Cookie authentication on client applications

---

# 1️⃣ SSO Server Setup

## 1. Add CORS for All Subdomains

Add this to **Program.cs**:

# Option 1

```csharp
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SSO-CORS", policy =>
    {
        policy.SetIsOriginAllowed(origin =>
        {
            // Allow only known/registered client applications
            return allowedOrigins.Contains(origin);
        });

        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
```

# Option 2

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("SSO-CORS", policy =>
    {
        policy.SetIsOriginAllowed(origin =>
        {
            if (Uri.TryCreate(origin, UriKind.Absolute, out var uri))
            {
                return uri.Host.EndsWith(".example.com"); // allow all subdomains
            }
            return false;
        });

        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // required for SignalR
    });
});
```

# Option 3

**File:** `appsettings.json`
```json
"Cors": {
  "SubdomainRoot": ".example.com",
  "AllowedOrigins": [
    "https://client1.com",
    "https://client2.net"
  ]
}
```

**File:** `Program.cs`
```csharp
var corsConfig = builder.Configuration.GetSection("Cors");
var subdomainRoot = corsConfig.GetValue<string>("SubdomainRoot");
var allowedOrigins = corsConfig.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SSO-CORS", policy =>
    {
        policy.SetIsOriginAllowed(origin =>
        {
            if (Uri.TryCreate(origin, UriKind.Absolute, out var uri))
            {
                // Allow all subdomains from configuration
                if (!string.IsNullOrEmpty(subdomainRoot) && uri.Host.EndsWith(subdomainRoot))
                    return true;

                // Allow explicitly registered origins
                if (allowedOrigins != null && allowedOrigins.Contains(origin))
                    return true;
            }

            return false;
        });

        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Required for SignalR
    });
});


app.UseCors("SSO-CORS");
```