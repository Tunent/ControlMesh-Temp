

using ControlMesh.Database;
using ControlMesh.Repository;
using ControlMesh.Services;
using Microsoft.Extensions.Azure;

namespace ControlMesh.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var sbConnString = builder.Configuration.GetConnectionString("ServiceBus");

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            builder.Services.AddSwaggerGen();
            builder.Services.RegisterDataServices();
            builder.Services.AddScoped<IMessageRepo, MessageRepo>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.RegisterDataServices();
            builder.Services.AddDbContext<ControlMeshDataContext>();
            builder.Services.AddScoped<IMessageServiceMapper, MessageServiceMapper>();
            builder.Services.AddAzureClients(builder =>
            {
                builder.AddServiceBusClient(sbConnString);
                builder.AddServiceBusAdministrationClient(sbConnString);
            });
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}