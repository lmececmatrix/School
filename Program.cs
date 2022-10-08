using KinderGarten.Data;
using KinderGarten.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<KinderGartenContext>(options =>
{
    options.UseSqlServer("Data Source=.;Initial Catalog=KinderGarten;Integrated Security=True");
});

builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<KinderGartenContext>();

builder.Services.AddScoped<BookRepository, BookRepository>();
builder.Services.AddScoped<ClassRepository, ClassRepository>();
builder.Services.AddScoped<BlogRepository, BlogRepository>();
builder.Services.AddScoped<TeacherRepository, TeacherRepository>();
builder.Services.AddScoped<AccountRepository, AccountRepository>();

#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Routing 
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine( new string[] { Directory.GetCurrentDirectory(), "Areas", "Admin", "Static" })),
    RequestPath = "/Static"
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

// Runing App
app.Run();
