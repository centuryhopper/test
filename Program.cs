/*

paste inside client proj
<ItemGroup>
    <PackageReference Include="Blazored.LocalStorage" Version="4.5.0" />                                                     
    <PackageReference Include="Microsoft.AspNetCore.Components.Authorization" Version="8.0.7" />                             
    <PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly" Version="8.0.7" />                               
    <PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly.DevServer" Version="8.0.7" PrivateAssets="all" /> 
    <PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" Version="8.0.7" />                                 
    <PackageReference Include="Microsoft.Extensions.Http" Version="8.0.0" />                                                 
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />                                                          
    <PackageReference Include="Radzen.Blazor" Version="5.0.3" />                                                             
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Shared\Shared.csproj" />
  </ItemGroup>

*/


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

if (!builder.Environment.IsDevelopment())
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
    builder.WebHost.UseUrls($"http://*:{port}");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");


app.Run();
