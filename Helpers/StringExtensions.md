# ToTitleCase String Extension - Usage Guide

This guide explains how to use the `ToTitleCase()` string extension method in your C# project.

---

## ✅ Step 1: Add the Extension Method

Create a file called `StringExtensions.cs` and add the following code:

```csharp
using System.Globalization;

public static class StringExtensions
{
    public static string ToTitleCase(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }
}
```

## ✅ Step 2: How to use Extension Method
```csharp
using System;

class Program
{
    static void Main()
    {
        string example = "hello world";
        string titleCase = example.ToTitleCase();
        Console.WriteLine(titleCase); // Output: Hello World
    }
}

```
