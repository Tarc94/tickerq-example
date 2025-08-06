using DataExample;
using DataExample.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scheduler;
using Scheduler.Services;
using SchedulerEF;
using SchedulerEF.Repositories;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScopedServices();
builder.Services.AddRepositories();
builder.Services.AddTickerRepositories();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SchedulerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Scheduler")));
builder.Services.AddDbContext<DataExampleContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DataExample")));

builder.Services.AddTickerQ(opt =>
{
    opt.SetMaxConcurrency(4);
    opt.SetExceptionHandler<ExceptionHandler>();

    opt.AddOperationalStore<SchedulerContext>(efOpt =>
    {
        efOpt.UseModelCustomizerForMigrations();
    });

    opt.AddDashboard(basePath: "/tickerq-dashboard");
    opt.AddDashboardBasicAuth();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseTickerQ();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
