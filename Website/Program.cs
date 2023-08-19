var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddBusinessService();
builder.Services.AddContextService();
builder.Services.AddRepositoryService();

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "Contact",
        pattern: "lien-he.html",
        defaults: new { controller = "Home", action = "Contact" });

    endpoints.MapControllerRoute(
        name: "Subscribe",
        pattern: "dang-ky.html",
        defaults: new { controller = "Home", action = "Subscribe" });

    endpoints.MapControllerRoute(
        name: "Thank",
        pattern: "loi-cam-on.html",
        defaults: new { controller = "Home", action = "Thank" });

    endpoints.MapControllerRoute(
       name: "About",
       pattern: "gioi-thieu.html",
       defaults: new { controller = "Home", action = "About" });

    endpoints.MapControllerRoute(
       name: "AboutDetail",
       pattern: "About/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "AboutDetail" });

    endpoints.MapControllerRoute(
       name: "Team",
       pattern: "doi-ngu.html",
       defaults: new { controller = "Home", action = "Team" });

    endpoints.MapControllerRoute(
       name: "TeamDetail",
       pattern: "Team/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "TeamDetail" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("vi-VN"),
});
app.Run();
