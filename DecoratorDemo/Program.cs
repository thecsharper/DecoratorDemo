using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

using DecoratorDemo.Decorated;
using DecoratorDemo.Decorator;

static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Disabled);
});

var logger = loggerFactory.CreateLogger<LoggingMemberRepository>();
var builder = CreateHostBuilder(args);
var app = builder.Build();

var decorator = new LoggingMemberRepository(new MemberRepository(), logger);

decorator.GetById(1);
decorator.GetById(2);
decorator.GetById(3);

app.Run();