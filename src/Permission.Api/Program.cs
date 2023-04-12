
using System.Reflection;
using Permissions.Api.Application.IntegrationEvents;
using Permissions.Api.HostedService;
using Permissions.Infrastructure;
using Serilog;

namespace Permissions.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((hostContext, services, configuration) => {
                configuration.WriteTo.Console();
                configuration.Enrich.FromLogContext();
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //MetiatR DependencyInjection
            builder.Services.AddMediatR(config => {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            //builder.Services.AddSingleton<IHostedService, ApacheKafkaConsumerService>();
            builder.Services.AddHostedService<ApacheKafkaConsumerService>();
            builder.Services.AddScoped<IRequestIntegrationEventService,RequestIntegrationEventService>();
            builder.Services.AddInfrastructure(builder.Configuration, builder.Environment.IsDevelopment());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
