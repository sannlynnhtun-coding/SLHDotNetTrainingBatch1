using SLHDotNetTrainingBatch1.EmailExample.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//string email = builder.Configuration["FromEmail"]!;
string email = builder.Configuration["EmailSetting:Email"]!;
string emailAppPassword = builder.Configuration["EmailSetting:Password"]!;
builder.Services.AddFluentEmail(email)
    .AddSmtpSender("smtp.gmail.com", 587, email, emailAppPassword);

//builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailService, EmailV2Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
