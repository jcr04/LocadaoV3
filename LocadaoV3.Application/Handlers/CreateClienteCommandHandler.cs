using LocadaoV3.Application.Commands;
using LocadaoV3.Domain.Models;
using LocadaoV3.Infra.Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Handlers;

public class CreateClienteCommandHandler : ICommandHandler<CreateClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public CreateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Guid> HandleAsync(CreateClienteCommand command)
    {
        var cliente = new Cliente
        {
            Nome = command.Nome,
            Idade = command.Idade,
            Email = command.Email,
            Telefone = command.Telefone,
            Cpf = command.Cpf,
            TemCNH = command.TemCNH,
            IsPCD = command.IsPCD
        };

        await _clienteRepository.AddAsync(cliente);
        return cliente.Id;
    }
}
