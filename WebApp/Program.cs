using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApp.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<VnPayment>(builder.Configuration.GetSection("Payment:VnPayment"));
builder.Services.AddScoped<VnPaymentServices>();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100MB
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(p => {
        p.LoginPath = "/auth/login";
        p.LogoutPath = "/auth/logout";
        p.AccessDeniedPath = "/auth/denied";
    })
    .AddGoogle(p =>
    {
        p.ClientId = builder.Configuration["Authentication:Google:ClientId"] 
          ?? throw new Exception("Not found ClientId");
        p.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] 
          ?? throw new Exception("Not found ClientSecret");
    });





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

app.UseStaticFiles(); // Cho phép sử dụng các file tĩnh trong wwwroot


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "dashboard", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
