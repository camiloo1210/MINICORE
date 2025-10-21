using Microsoft.EntityFrameworkCore;
using MINICORE.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<minicore>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("minicore") ??
    throw new InvalidOperationException("Connection string 'minicore' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Comition/Index");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Comition}/{action=Index}/{id?}");

app.Run();