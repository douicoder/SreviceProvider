using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Modules.User.UserInteface;
using Modules.User.UserManager;
using ServiceProvider.Server.Modules.Interface;
using ServiceProvider.Server.Modules.Manager;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DatabaseContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IServiceProviderDetailsManager, ServiceProviderDetailsManager>();
builder.Services.AddTransient<IPinCodeManager, PinCodeManager>();
builder.Services.AddTransient<IChatManager, ChatManager>();
builder.Services.AddTransient<IRequestManager, RequestManager>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
