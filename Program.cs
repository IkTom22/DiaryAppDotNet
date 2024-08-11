using Diary.Database; // Namespace for DatabaseService
using Diary.Models;   // Namespace for DiaryContext and DiaryEntry
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Register the DatabaseService and DbContext
builder.Services.AddSingleton<DatabaseService>();
// Register the DiaryContext with the dependency injection container
builder.Services.AddDbContext<DiaryContext>(options =>
    options.UseSqlite("Data Source=database.db"));

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Test the database connection
var dbService = app.Services.GetRequiredService<DatabaseService>();
dbService.TestConnection();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


// using Diary.Models;

// var builder = WebApplication.CreateBuilder(args);
// // analogy - DI (Dependency injection) is like ordering ingredients from grocery delivery service instead of growing them yourself n the backyard.

// // DI container
// // Add services to the container.
// // registers services required by the application
// // Common services: Controllers: Handle HTTP requests and generate responses, Views: render HTML pages, RAZOR Pages: simplify model for creating web pages
// builder.Services.AddControllersWithViews();
// // Add services to the container.
// builder.Services.AddSingleton<DatabaseService>();
// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<DiaryContext>();
//     db.Database.EnsureCreated();

//     //Create a new DiaryEntry
//     var entry = new DiaryEntry
//     {
//         Title = "My First Entry",
//         Content = "Hello, this is my dirst content",
//         Created = DateTime.Now
//     };
//     db.DiaryEntries.Add(entry);
//     db.SaveChanges();
//     Console.WriteLine("First diary entry saved");
// }

// var dbService = app.Services.GetRequiredService<DatabaseService>();
// dbService.TestConnection();

// app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

// app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

// app.Run();
