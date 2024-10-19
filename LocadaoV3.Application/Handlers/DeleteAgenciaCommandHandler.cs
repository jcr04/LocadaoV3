using LocadaoV3.Application.Commands;
using LocadaoV3.Infra.Repository.Agencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Handlers;
public class DeleteAgenciaCommandHandler : ICommandHandlerDelete<DeleteAgenciaCommand>
{
    private readonly IAgenciaRepository _agenciaRepository;

    public DeleteAgenciaCommandHandler(IAgenciaRepository agenciaRepository)
    {
        _agenciaRepository = agenciaRepository;
    }

    public async Task HandleAsync(DeleteAgenciaCommand command)
    {
        await _agenciaRepository.DeleteAsync(command.Id);
    }
}
