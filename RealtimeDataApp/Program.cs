using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;
using RealtimeDataApp.Data;
using RealtimeDataApp.Hubs;
using RealtimeDataApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Adding the Job Service as a singleton
builder.Services.AddSingleton<JobsService>();

//Adding Response Compression to make SignalR work.
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

var app = builder.Build();

//Adding Response Compression to the project
app.UseResponseCompression();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

//Creating an endpoint for the Job Hub
app.MapHub<JobHub>("/jobhub");

app.MapFallbackToPage("/_Host");

app.Run();
