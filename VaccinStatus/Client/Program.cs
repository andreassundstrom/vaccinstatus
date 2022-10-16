using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VaccinStatus.Client;
using VaccinStatus.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<VaccinStatusClient>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
);


await builder.Build().RunAsync();
