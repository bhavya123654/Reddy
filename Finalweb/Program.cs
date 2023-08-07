var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

// Your custom logic to display the database access message
app.Use(async (context, next) =>
{
    // Display the database access message
    string currentDate = DateTime.Now.ToString("08 07, 2023");
    string message = $"Database access has already been done on 2023-08-07 by Bhavitha Penaka"; 
    await context.Response.WriteAsync(message);

    // Call the next middleware in the pipeline
    await next();
});

app.Run();
