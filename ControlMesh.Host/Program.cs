using Microsoft.AspNetCore.Builder;

namespace ControlMesh.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureServices();

            var app = builder.Build();

            app.Run();
        }
    }
}