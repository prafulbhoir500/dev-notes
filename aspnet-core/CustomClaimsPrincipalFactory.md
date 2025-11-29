# CustomClaimsPrincipalFactory Implementation Guide

## Step 1: Create the Custom Claims Principal Factory Class
Create a new class that inherits from `UserClaimsPrincipalFactory<TUser>` (or `UserClaimsPrincipalFactory<TUser, TRole>` if using roles):

```csharp
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomClaimsPrincipalFactory<TUser> : UserClaimsPrincipalFactory<TUser>
    where TUser : class
{
    public CustomClaimsPrincipalFactory(
        UserManager<TUser> userManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsPrincipal> GenerateClaimsAsync(TUser user)
    {
        // Generate base claims
        var principal = await base.GenerateClaimsAsync(user);
        var identity = (ClaimsIdentity)principal.Identity;

        // Add custom claims here
        identity.AddClaim(new Claim("CustomClaimType", "CustomValue"));
        
        // Example: Add user-specific claim
        identity.AddClaim(new Claim("UserId", await UserManager.GetUserIdAsync(user)));
        
        // Example: Add role-based claim
        var roles = await UserManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            identity.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        return principal;
    }
}

```

# Example for `SessionId`

```csharp


 /// <summary>
 /// Indicates whether the user can have multiple concurrent sessions
 /// </summary>
 public required bool AllowMultipleSessions { get; set; }


  builder.Entity<ApplicationUser>(entity =>
 {
     entity.Property(u => u.AllowMultipleSessions)
         .HasDefaultValue(false) // SQL default
         .IsRequired();          // NOT NULL
 });
 
using AuthServer.Web.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace AuthServer.Web.Services
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public CustomClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            // Add your custom claim here
            identity.AddClaim(new Claim("sessionId", Guid.NewGuid().ToString()));

             // Add multi-session claim
            identity.AddClaim(new Claim("allowMultipleSessions", user.AllowMultipleSessions.ToString()));

            return identity;
        }
    }

}

```

## Step 2: Register the Custom Factory in DI Container

```csharp
 // Register Identity with custom ApplicationUser and ApplicationRole
 services.AddDefaultIdentity<ApplicationUser>(options =>
 {
     options.SignIn.RequireConfirmedAccount = false;
 })
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<ApplicationDbContext>()
 .AddDefaultTokenProviders()
 .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();


  // Register custom ClaimsPrincipalFactory
services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsPrincipalFactory>();
```


## Step 3: Verify Claim Generation

```csharp
 var customClaim = User.FindFirst("CustomClaimType")?.Value;
 var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
 var sessionId = User.FindFirst("sessionId")?.Value;
```