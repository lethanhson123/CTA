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
        pattern: "contact.html",
        defaults: new { controller = "Home", action = "Contact" });

    endpoints.MapControllerRoute(
        name: "Subscribe",
        pattern: "subscribe.html",
        defaults: new { controller = "Home", action = "Subscribe" });

    endpoints.MapControllerRoute(
        name: "Thank",
        pattern: "thank.html",
        defaults: new { controller = "Home", action = "Thank" });

    endpoints.MapControllerRoute(
     name: "Product",
     pattern: "product.html",
     defaults: new { controller = "Home", action = "Product" });

    endpoints.MapControllerRoute(
       name: "About",
       pattern: "about.html",
       defaults: new { controller = "Home", action = "About" });

    endpoints.MapControllerRoute(
       name: "AboutDetail",
       pattern: "About/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "AboutDetail" });

    endpoints.MapControllerRoute(
       name: "Team",
       pattern: "team.html",
       defaults: new { controller = "Home", action = "Team" });

    endpoints.MapControllerRoute(
       name: "TeamDetail",
       pattern: "Team/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "TeamDetail" });

    endpoints.MapControllerRoute(
      name: "Project",
      pattern: "project.html",
      defaults: new { controller = "Home", action = "Project" });

    endpoints.MapControllerRoute(
       name: "ProjectDetail",
       pattern: "Project/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "ProjectDetail" });

    endpoints.MapControllerRoute(
      name: "News",
      pattern: "news.html",
      defaults: new { controller = "Home", action = "News" });

    endpoints.MapControllerRoute(
       name: "NewsDetail",
       pattern: "News/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "NewsDetail" });

    endpoints.MapControllerRoute(
     name: "Service",
     pattern: "service.html",
     defaults: new { controller = "Home", action = "Service" });

    endpoints.MapControllerRoute(
       name: "ServiceDetail",
       pattern: "Service/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "ServiceDetail" });

    endpoints.MapControllerRoute(
     name: "Career",
     pattern: "career.html",
     defaults: new { controller = "Home", action = "Career" });

    endpoints.MapControllerRoute(
       name: "CareerDetail",
       pattern: "Career/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "CareerDetail" });

    endpoints.MapControllerRoute(
     name: "Ideas",
     pattern: "ideas.html",
     defaults: new { controller = "Home", action = "Ideas" });

    endpoints.MapControllerRoute(
       name: "IdeasDetail",
       pattern: "Ideas/{Code}-{ID}.html",
       defaults: new { controller = "Home", action = "IdeasDetail" });

    endpoints.MapControllerRoute(
      name: "CategoryIdeas",
      pattern: "CategoryIdeas/{Code}-{ID}.html",
      defaults: new { controller = "Home", action = "CategoryIdeas" });

    endpoints.MapControllerRoute(
       name: "Tag",
       pattern: "tag/{searchString}",
       defaults: new { controller = "Home", action = "Tag" });

    endpoints.MapControllerRoute(
       name: "Search",
       pattern: "search/{searchString}",
       defaults: new { controller = "Home", action = "Search" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("vi-VN"),
});
app.Run();
