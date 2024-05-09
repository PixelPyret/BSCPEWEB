using BSCPEWEB.Models;

var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.json");
    builder.Services.AddControllersWithViews();
    builder.Services.AddTransient<Dbcontext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new Dbcontext(connectionString);
});
builder.Services.AddTransient<StudentContext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new StudentContext(connectionString);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<StudentContext>();
        bool isConnected = context.TestConnection();
        if (isConnected)
        {
            Console.WriteLine("Successfully connected to datababse");
        }
        else
        {
            Console.WriteLine("Failed to connect to the database.");
            return;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Enrollment}/{action=EnrollmentForm}/{id?}");

app.Run();
