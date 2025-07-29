# 📧 C# Email Template Sender

A simple, reusable service in C# to send templated HTML emails using SMTP.

---

## ✨ Features

- ✅ Load HTML templates from file
- ✅ Send styled HTML emails
- ✅ Follows good coding practices
- ✅ Supports Gmail, Outlook, etc.

---

## 📦 Installation

Add this class to your project or turn it into a library.

---

## 🛠️ Usage

```csharp
var emailSender = new EmailService.EmailTemplateSender(
    smtpHost: "smtp.gmail.com",
    smtpPort: 587,
    fromEmail: "your-email@gmail.com",
    password: "your-app-password"
);

string html = emailSender.LoadHtmlTemplate("Templates/Welcome.html");

emailSender.SendEmail(
    toAddress: "recipient@example.com",
    subject: "Welcome to Our Service",
    htmlContent: html
);
