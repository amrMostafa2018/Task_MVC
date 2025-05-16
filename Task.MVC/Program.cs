using Serilog;
using System.Diagnostics;
using Task.Application;
using Task.Infrastructure;
using Task.MVC;
using Serilog.Enricher.ClientInfo;
using Serilog.Enrichers.Sensitive;
using Serilog.Enrichers.Span;
using Serilog.Exceptions;
using Serilog.Extensions;
using Task.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddProblemDetails(options =>
        options.CustomizeProblemDetails = ctx =>
        {
            ctx.ProblemDetails.Extensions.TryAdd("traceId", Activity.Current?.TraceId.ToString() ?? ctx.HttpContext.TraceIdentifier);
        });

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();



builder.Host.UseSerilog((context, conf) =>
{
    conf.ReadFrom.Configuration(context.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .Enrich.WithProperty("ApplicationName", context.HostingEnvironment.ApplicationName)
    .Enrich.WithExceptionDetails()
    .Enrich.With<ActivityEnricher>()
    .Enrich.WithSensitiveDataMasking(
        options =>
        {
            options.ExcludeProperties.Add("ParentId");
            options.Mode = MaskingMode.Globally;
            options.MaskingOperators = new List<IMaskingOperator>
            {
                new CreditCardMaskingOperator()
            };
        })
    .Enrich.WithClientIp()
    .Enrich.WithClientAgent()
    .WriteTo.Seq(builder.Configuration["SeqConfiguration:Url"]!)

    .WriteTo.File($"Logs/{context.HostingEnvironment.ApplicationName}.txt", rollingInterval: RollingInterval.Day);
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    await app.InitialiseDatabaseAsync();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseExceptionHandler(options => { });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=Index}/{id?}");

app.Run();
