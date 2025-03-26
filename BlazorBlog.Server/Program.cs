using BlazorBlog.Server.Persistence;
using BlazorBlog.Shared.Blogs.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<BlogDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDataContext"));
});

builder.Services.AddValidatorsFromAssemblyContaining<AddOrUpdateBlogValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseWebAssemblyDebugging();
}

app.MapScalarApiReference();
app.UseHttpsRedirection();


app.UseStaticFiles();
app.UseBlazorFrameworkFiles();
app.MapFallbackToFile("index.html");

app.MapControllers();

app.Run();