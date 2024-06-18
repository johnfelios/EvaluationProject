using BlazorApp1.Components;
using BlazorApp1.Data;
using BlazorApp1.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// Configure DbContext
builder.Services.AddDbContext<MyAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//DI
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRepositoryService, RepositoryService>();


//Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DI for username save through session
builder.Services.AddSingleton<IAppState, AppState>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
