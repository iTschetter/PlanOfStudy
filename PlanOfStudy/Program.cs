using Microsoft.EntityFrameworkCore;
using PlanOfStudy.Models;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<POSDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:PlanOfStudyConnection"]);
});
builder.Services.AddScoped<IPOSRepository, EFPOSRepository>();
builder.Services.AddScoped<ISavedPlanRepository, EFSavedPlanRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Plan>(sp => SessionPlan.GetPlan(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:IdentityConnection"]));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute("catpage",
    "{category}/Page{coursePage:int}",
    new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{coursePage:int}",
    new { Controller = "Home", action = "Index", coursePage = 1 });
app.MapControllerRoute("category", "{category}",
    new { Controller = "Home", action = "Index", coursePage = 1 });
app.MapControllerRoute("pagination",
    "Courses/Page{coursePage}",
    new { Controller = "Home", action = "Index", coursePage = 1 });
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);
app.Run();