using BlazorRenderModes.Components;
   using BlazorRenderModes.Services;
   
   var builder = WebApplication.CreateBuilder(args);
   
   // Add services to the container.
   builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents()
       .AddInteractiveWebAssemblyComponents();
   
   builder.Services.AddControllers();
   builder.Services.AddSingleton<TodoService>();
   builder.Services.AddScoped(sp => 
{
    var httpClient = new HttpClient();
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["ApiBaseUrl"] ?? "https://localhost:7108"; // Default from launchSettings
    httpClient.BaseAddress = new Uri(baseUrl);
    return httpClient;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorRenderModes.Client._Imports).Assembly);

app.Run();
