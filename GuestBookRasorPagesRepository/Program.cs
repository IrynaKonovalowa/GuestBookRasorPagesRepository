using GuestBookRasorPagesRepository.Models;
using GuestBookRasorPagesRepository.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ClassContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connection));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
