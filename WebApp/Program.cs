using Microsoft.EntityFrameworkCore;
using WebApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SimpleEatryDbContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Auto Migrate when the application starts
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SimpleEatryDbContext>();
    // db.Database.Migrate();
}

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();