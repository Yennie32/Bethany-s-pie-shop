// applies settings contained in appsettings.json file
// makes sure that Kestrel is included and set up IIS integration
// makes sure that www.root is the folder to look for static content
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore; // adding EF Core

var builder = WebApplication.CreateBuilder(args); 

// SERVICE REGISTRATION
// 'AddScoped' = create a Singleton while the request is being handled
// Links interface with repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

/*builder.Services.AddTransient //create a request every time
builder.Services.AddSingleton // create a single request that last*/


// adding ASP.NET Core MVC
builder.Services.AddControllersWithViews();

// add DbContext extension method
builder.Services.AddDbContext<BethanysPieShopDbContext>(options => {
    options.UseSqlServer(
        // retrieves the connection string from appsettings.json
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]); 
});

var app = builder.Build();

// middleware component that listens for incoming request from root of application
// must be placed after builder and before app.Run()

app.UseStaticFiles(); // returns static files

if (app.Environment.IsDevelopment()){ // defines the dev environment
    app.UseDeveloperExceptionPage(); // diagnostic middleware component, shows errors
}

// middleware component for routing
// placed at the end. Let MVC handle incoming requets from controllers
app.MapDefaultControllerRoute();
// Calling the Seed datas
try
{
    DbInitializer.Seed(app);
}
catch (Exception ex)
{
    // Log the error (you can also log this to a file, etc.)
    Console.WriteLine($"An error occurred during seeding: {ex.Message}");
}
app.Run();
