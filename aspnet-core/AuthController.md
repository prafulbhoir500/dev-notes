#Config
```csharp

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace YourApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // === LOGIN ===
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // TODO: Validate user and generate JWT token
            var requestId = HttpContext.TraceIdentifier;
            var token = "mock.jwt.token";

            return Ok(ApiResponse<string>.SuccessResponse(token, "Login successful", requestId: requestId));
        }

        // === REGISTER ===
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            // TODO: Register user, hash password
            var requestId = HttpContext.TraceIdentifier;

            return Ok(ApiResponse<string>.SuccessResponse(null, "User registered successfully", requestId));
        }

        // === REFRESH TOKEN ===
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] RefreshTokenRequest request)
        {
            // TODO: Validate refresh token and issue new JWT
            var requestId = HttpContext.TraceIdentifier;

            return Ok(ApiResponse<string>.SuccessResponse("new.jwt.token", "Token refreshed", requestId));
        }

        // === LOGOUT (Single Session) ===
        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // TODO: Invalidate refresh token or session
            var requestId = HttpContext.TraceIdentifier;

            return Ok(ApiResponse<string>.SuccessResponse(null, "Logged out successfully", requestId));
        }

        // === LOGOUT ALL SESSIONS ===
        [Authorize]
        [HttpPost("logout-all")]
        public IActionResult LogoutAll()
        {
            // TODO: Invalidate all tokens for user
            var requestId = HttpContext.TraceIdentifier;

            return Ok(ApiResponse<string>.SuccessResponse(null, "Logged out from all sessions", requestId));
        }

        // === CURRENT USER ===
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            // TODO: Return user info from token
            var requestId = HttpContext.TraceIdentifier;

            var user = new
            {
                Id = 1,
                Username = User.Identity.Name,
                Email = "user@example.com"
            };

            return Ok(ApiResponse<object>.SuccessResponse(user, "User data retrieved", requestId));
        }

        // === FORGOT PASSWORD ===
        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            // TODO: Send password reset email/SMS
            var requestId = HttpContext.TraceIdentifier;

            return Ok(ApiResponse<string>.SuccessResponse(null, "Password reset link sent", requestId));
        }

        // === RESET PASSWORD ===
        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            // TODO: Verify token and reset password
            var requestId = HttpContext.TraceIdentifier;

            return Ok(ApiResponse<string>.SuccessResponse(null, "Password reset successful", requestId));
        }
    }
}


```
