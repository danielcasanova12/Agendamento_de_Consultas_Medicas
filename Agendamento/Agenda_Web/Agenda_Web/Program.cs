using Agenda_Web.ApiUrl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ApiUrls>();
builder.Services.AddSingleton(new ApiUrls("https://localhost:7018")); 
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
