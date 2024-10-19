using LocadaoV3.Application.Commands;
using LocadaoV3.Domain.Models;
using LocadaoV3.Infra.Repository.Agencias;


namespace LocadaoV3.Application.Handlers;
public class CreateAgenciaCommandHandler : ICommandHandler<CreateAgenciaCommand>
{
    private readonly IAgenciaRepository _agenciaRepository;

    public CreateAgenciaCommandHandler(IAgenciaRepository agenciaRepository)
    {
        _agenciaRepository = agenciaRepository;
    }

    public async Task<Guid> HandleAsync(CreateAgenciaCommand command)
    {
        var agencia = new Agencia
        {
            Nome = command.Nome,
            Endereco = command.Endereco,
            Telefone = command.Telefone,
        };

        await _agenciaRepository.AddAsync(agencia);
        return agencia.Id;
    }
}
