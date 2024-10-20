using LocadaoV3.Application.Commands;
using LocadaoV3.Application.Handlers;
using LocadaoV3.Application.Queries;
using LocadaoV3.Infra.Repository.Agencias;
using LocadaoV3.Infra.Repository.Alugueis;
using LocadaoV3.Infra.Repository.Clientes;
using LocadaoV3.Infra.Repository.Reservas;
using LocadaoV3.Infra.Repository.Veiculos;
using LocadaoV3.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddDbContext<LocadaoDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        //Cliente
        builder.Services.AddTransient<ICommandHandler<CreateClienteCommand>, CreateClienteCommandHandler>();
        builder.Services.AddTransient<ICommandHandler<UpdateClienteCommand>, UpdateClienteCommandHandler>();
        builder.Services.AddTransient<ICommandHandlerDelete<DeleteClienteCommand>, DeleteClienteCommandHandler>();
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        builder.Services.AddScoped<IClienteQueryService, ClienteQueryService>();

        //Veiculo
        builder.Services.AddTransient<ICommandHandler<CreateVeiculoCommand>, CreateVeiculoCommandHandler>();
        builder.Services.AddScoped<ICommandHandler<UpdateVeiculoCommand>, UpdateVeiculoCommandHandler>();
        builder.Services.AddScoped<ICommandHandlerDelete<DeleteVeiculoCommand>, DeleteVeiculoCommandHandler>();
        builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        builder.Services.AddScoped<IVeiculoQueryService, VeiculoQueryService>();

        //Agencia
        builder.Services.AddTransient<ICommandHandler<CreateAgenciaCommand>, CreateAgenciaCommandHandler>();
        builder.Services.AddTransient<ICommandHandlerDelete<DeleteAgenciaCommand>, DeleteAgenciaCommandHandler>();
        builder.Services.AddScoped<IAgenciaRepository, AgenciaRepository>();
        builder.Services.AddScoped<IAgenciaQueryService, AgenciaQueryService>();

        //aluguel
        builder.Services.AddTransient<ICommandHandler<CreateAluguelCommand>, CreateAluguelCommandHandler>();
        builder.Services.AddTransient<ICommandHandlerDelete<DeleteAluguelCommand>, DeleteAluguelCommandHandler>();
        builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();
        builder.Services.AddScoped<IAluguelQueryService, AluguelQueryService>();

        //Reserva
        builder.Services.AddTransient<ICommandHandler<CreateReservaCommand>, CreateReservaCommandHandler>();
        builder.Services.AddTransient<ICommandHandler<UpdateReservaCommand>, UpdateReservaCommandHandler>();
        builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
        builder.Services.AddScoped<IReservaQueryService, ReservaQueryService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        // Configuração do Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "LocadaoV3 API", Version = "v1" });
            c.AddServer(new OpenApiServer
            {
                Url = "https://locadaov3.onrender.com",
                Description = "Produção"
            });
        });

        // Remova ou ajuste a configuração de HTTPS redirection
        // builder.Services.AddHttpsRedirection(options =>
        // {
        //     options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
        //     options.HttpsPort = 44351;
        // });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors("AllowAllOrigins");

        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();

        app.Run();
    }
}
