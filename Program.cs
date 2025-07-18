﻿using my_razor_project.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// ✅ Add this line:
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Users.db")); // This is your SQLite file

// ✅ Required for Session
builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession();               
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();  

app.UseAuthorization();

app.MapRazorPages();

app.Run();
