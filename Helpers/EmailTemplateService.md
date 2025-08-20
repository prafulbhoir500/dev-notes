## ✅ Step 1: Add the  File

```csharp
/// <summary>
/// 
/// </summary>
/// <param name="templateName"></param>
/// <param name="placeholders"></param>
/// <returns></returns>
public async Task<string> GetEmailBodyAsync(string templateName, Dictionary<string, string> placeholders)
{
    string template = await GetTemplateAsync(templateName);

    foreach (var placeholder in placeholders)
    {
        template = template.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
    }

    return template;
}


public async Task<string> GetTemplateAsync(string templateName)
{
    try
    {
        var assembly = typeof(EmailTemplateService).Assembly;
        // Use full resource name from the debug output
        var resourcePath = $"AuthServer.Infrastructure.EmailTemplates.{templateName}.html";

        using var stream = assembly.GetManifestResourceStream(resourcePath);
        if (stream == null)
            throw new FileNotFoundException($"Template not found: {resourcePath}");

        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
    catch (Exception)
    {
        throw;
    }
}
```

## ✅ Step 2: How to use
```csharp
var placeholders = new Dictionary<string, string>
{
    ["SSOName"] = CompanyViewModel.SSOName,
    ["SSOCompany"] = CompanyViewModel.CompanyName,
    ["UserName"] = result.Data.DisplayName,
    ["VerificationLink"] = callbackUrl,
    ["Year"] = DateTime.Now.Year.ToString()
};

EmailRequestDto emailRequest = new EmailRequestDto
{
    To = new List<string> { createUser.Email },
    Subject = $"Welcome to {CompanyViewModel.SSOName} – Verify your email to continue",
    Body = await emailTemplateService.GetEmailBodyAsync("UserRegistrationVerification", placeholders),
    IsHtml = true,
};
```
