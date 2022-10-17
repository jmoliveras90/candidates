using Candidates.Application.Services.Interfaces;
using Candidates.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Candidates.Application.Services;
using Candidates.Domain.Interfaces;
using MediatR;
using System.Reflection;
using Candidates.Application.Queries.Candidates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CandidatesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var assembly = Assembly.GetAssembly(typeof(GetCandidateQuery));

if (assembly != null)
{
    builder.Services.AddMediatR(assembly);
}


builder.Services.AddScoped<ICandidatesService, CandidatesService>();
builder.Services.AddScoped<ICandidateExperiencesService, CandidateExperiencesService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
