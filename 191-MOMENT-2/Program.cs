var builder = WebApplication.CreateBuilder(args);

//add services to the container, activate MVC
builder.Services.AddControllersWithViews();
//use session/cookies
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //100 seconds until destruction
    options.IdleTimeout = TimeSpan.FromSeconds(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//wwwroot files
app.UseStaticFiles();
app.UseRouting();

//use session cookies
app.UseSession();


app.UseAuthorization();

//routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
