using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Data;
var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<QuizAppContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("QuizAppContext"))
    );
}
else
{
    builder.Services.AddDbContext<QuizAppContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ProductionQuizAppContext"))
    );
}

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<QuizAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("QuizAppContext") ?? throw new InvalidOperationException("Connection string 'QuizAppContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
