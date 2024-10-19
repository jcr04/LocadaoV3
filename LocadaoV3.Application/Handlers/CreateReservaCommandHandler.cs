using LocadaoV3.Application.Commands;
using LocadaoV3.Domain.Models;
using LocadaoV3.Infra.Repository.Reservas;
using LocadaoV3.Infra.Repository.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Handlers
{
    public class CreateReservaCommandHandler : ICommandHandler<CreateReservaCommand>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        public CreateReservaCommandHandler(IReservaRepository reservaRepository, IVeiculoRepository veiculoRepository)
        {
            _reservaRepository = reservaRepository;
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Guid> HandleAsync(CreateReservaCommand command)
        {
            // Verificar se o veículo existe
            var veiculo = await _veiculoRepository.GetByIdAsync(command.VeiculoId);
            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
            }

            // Verificar a disponibilidade do veículo para as datas solicitadas
            bool isDisponivel = await _veiculoRepository.VerificarDisponibilidadeAsync(command.VeiculoId, command.DataInicio, command.DataFim);
            if (!isDisponivel)
            {
                throw new Exception("Veículo não está disponível para as datas solicitadas.");
            }

            // Criar e salvar a reserva
            var reserva = new Reserva
            {
                ClienteId = command.ClienteId,
                VeiculoId = command.VeiculoId,
                DataInicio = command.DataInicio,
                DataFim = command.DataFim,
                Status = "Confirmada" // Ou outro status inicial, conforme sua lógica de negócio
            };

            await _reservaRepository.AddAsync(reserva);

            return reserva.Id;
        }
    }
}
