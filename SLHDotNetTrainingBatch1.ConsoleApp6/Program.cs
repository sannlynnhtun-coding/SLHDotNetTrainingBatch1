// See https://aka.ms/new-console-template for more information
using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

string fromEmail = "sannlynnhtun.ace@gmail.com";

var services = new ServiceCollection();
services.AddScoped<TestService>();
services.AddScoped<Test2Service>();
services
    .AddFluentEmail(fromEmail)
    .AddSmtpSender("smtp.gmail.com", 587, fromEmail, "vkfh lfxz rcfy fvnp");
services.AddScoped<EmailService>();

var provider = services.BuildServiceProvider();

Console.Write("Enter Email Address: ");
var email = Console.ReadLine()!;
Console.Write("Enter Subject: ");
var subject = Console.ReadLine()!;
Console.Write("Enter Body: ");
var body = Console.ReadLine()!;

//var testService = provider.GetRequiredService<Test2Service>();
var emailService = provider.GetRequiredService<EmailService>();
var result = await emailService.SendAsync(email, subject, body);

Console.WriteLine($"Email sent successfully: {result.Successful}");

//testService.DoSomethingElse();

public class EmailService
{
    private IFluentEmail _fluentEmail;

    public EmailService(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }

    public async Task<SendResponse> SendAsync(string toEmail, string subject, string body)
    {
        var response = await _fluentEmail
               .To(toEmail)
               .Subject(subject)
               .Body(body)
               .SendAsync();
        return response;
    }
}

public class TestService
{
    public void DoSomething()
    {
        Console.WriteLine("Doing something...");
    }
}

public class Test2Service
{
    private readonly TestService _testService;

    public Test2Service(TestService testService)
    {
        _testService = testService;
    }

    public void DoSomethingElse()
    {
        _testService.DoSomething();
    }
}