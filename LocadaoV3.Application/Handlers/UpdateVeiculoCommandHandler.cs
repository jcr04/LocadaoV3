﻿using LocadaoV3.Application.Commands;
using LocadaoV3.Infra.Repository.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Handlers;

public class UpdateVeiculoCommandHandler : ICommandHandler<UpdateVeiculoCommand>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public UpdateVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<Guid> HandleAsync(UpdateVeiculoCommand command)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(command.Id);
        if (veiculo == null)
        {
            veiculo.Marca = command.Marca;
            veiculo.Modelo = command.Modelo;
            veiculo.AnoFabricacao = command.AnoFabricacao;
            veiculo.Placa = command.Placa;
            veiculo.Cor = command.Cor;

            await _veiculoRepository.UpdateAsync(veiculo);
        }
        else
        {
            throw new KeyNotFoundException("Veiculo não encontrado.");
        }

        return command.Id;
    }
}

