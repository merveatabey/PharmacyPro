using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // React uygulamanýzýn adresi
               .AllowAnyHeader()
               .AllowAnyMethod()    
               .AllowCredentials();
    });
});
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();


var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseMigrationsEndPoint(); // Bu satýrý kaldýrýn veya yorum satýrýna alýn
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("ReactPolicy");


app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
