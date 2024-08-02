using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CRUDModals.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoBD")));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura o pipeline de solicitações HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS value is 30 days by default, can be adjusted in production.
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pessoas}/{action=Index}/{id?}");

app.Run();