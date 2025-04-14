
using AutoMapper;
using Hangfire;
using IntegracaoPrintWayyBling.API.Controllers;
using IntegracaoPrintWayyBling.API.Interfaces;
using IntegracaoPrintWayyBling.API.Interfaces.PrintWayy.Clientes;
using IntegracaoPrintWayyBling.API.Interfaces.PrintWayy.Fechamentos;
using IntegracaoPrintWayyBling.API.Mappings;
using IntegracaoPrintWayyBling.API.Rest;
using IntegracaoPrintWayyBling.API.Services;
using IntegracaoPrintWayyBling.API.Services.Autentication;
using Microsoft.Extensions.Configuration;

namespace IntegracaoPrintWayyBling.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

       
            builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("databaseUrl")));
            builder.Services.Configure<AutenticationPrintWayyService>(builder.Configuration.GetSection("ApiPrintWayySettings"));
       

           // builder.Services.AddHangfireServer();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IFechamentoService, FechamentoService>();
            builder.Services.AddScoped<IClientesService, ClientesService>();
            builder.Services.AddAutoMapper(typeof(FechamentosMapping));
            builder.Services.AddAutoMapper(typeof(ClientesMapping));
            builder.Services.AddSingleton<IPrintWayyApiFinanceiro, PrintWayyRest>();
            builder.Services.AddSingleton<IPrintWayyApiClientes, PrintWayyRest>();


            var app = builder.Build();

            //app.UseHangfireDashboard("/hangfire");
            //app.MapGet("/", () => "API rodando...");
            //app.MapHangfireDashboard();



            //BackgroundJob.Schedule<IFechamentoService>(
            //RecurringJob.AddOrUpdate<IFechamentoService>(
            //"create-contratos", // ID do job
               //f => f.CreateTransformarStatusBling(),
            //Cron.Minutely()
               //TimeSpan.FromHours(360)
               //);

          

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
