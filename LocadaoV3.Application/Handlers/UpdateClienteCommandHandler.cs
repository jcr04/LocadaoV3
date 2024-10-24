﻿using LocadaoV3.Application.Commands;
using LocadaoV3.Infra.Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Handlers;

public class UpdateClienteCommandHandler : ICommandHandler<UpdateClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Guid> HandleAsync(UpdateClienteCommand command)
    {
        var cliente = await _clienteRepository.GetByIdAsync(command.Id);

        if (cliente != null)
        {
            cliente.Nome = command.Nome;
            cliente.DataNascimento = command.DataNascimento.ToUniversalTime();
            cliente.Idade = command.idade;
            cliente.Email = command.Email;
            cliente.Telefone = command.Telefone;

            if (command.ValidadeCNH.HasValue)
            {
                cliente.ValidadeCNH = command.ValidadeCNH.Value.ToUniversalTime();
            }

            await _clienteRepository.UpdateAsync(cliente);
        }
        else
        {
            throw new KeyNotFoundException("Cliente não encontrado.");
        }

        return command.Id;
    }

}
