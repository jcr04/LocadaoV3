using LocadaoV3.Application.Commands;
using LocadaoV3.Infra.Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Handlers;

public class DeleteClienteCommandHandler : ICommandHandlerDelete<DeleteClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task HandleAsync(DeleteClienteCommand command)
    {
        await _clienteRepository.DeleteAsync(command.Id);
    }
}

