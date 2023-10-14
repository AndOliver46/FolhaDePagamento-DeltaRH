
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Desativa a proteção contra CSRF
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});

var provider = builder.Services.BuildServiceProvider();
var _configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddLogging(config =>
{
    config.AddConfiguration(_configuration.GetSection("Logging"));
    config.AddConsole(); // Adiciona o provedor de log do console
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=LoginUsuario}/{id?}");

app.UseAuthorization();

app.Run();
