## 1. Logger Class
```csharp
using System;
using System.IO;

public static class Logger
{
    private static readonly string logFilePath = "error_log.txt";

    public static void LogError(Exception ex)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true)) // Append mode
            {
                writer.WriteLine("========== ERROR ==========");
                writer.WriteLine($"Date: {DateTime.Now}");
                writer.WriteLine($"Message: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    writer.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                writer.WriteLine();
            }
        }
        catch
        {
            // If logging fails, avoid crashing the app
        }
    }
}

```

## 2. Use It in Your Code

```csharp
try
{
    // Your code that might throw an exception
}
catch (Exception ex)
{
    Logger.LogError(ex);
}

```
