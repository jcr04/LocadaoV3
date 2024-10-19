using LocadaoV3.Domain.Models.DTOs;
using LocadaoV3.Infra.Repository.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Queries
{
    public class ReservaQueryService : IReservaQueryService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaQueryService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<ReservaDTO> GetReservaByIdAsync(Guid id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null) return null;

            return new ReservaDTO
            {
                Id = reserva.Id,
                ClienteId = reserva.ClienteId,
                ClienteNome = reserva.Cliente.Nome,
                VeiculoId = reserva.VeiculoId,
                VeiculoDescricao = $"{reserva.Veiculo.Marca} {reserva.Veiculo.Modelo}",
                DataInicio = reserva.DataInicio,
                DataFim = reserva.DataFim,
                Status = reserva.Status
            };
        }

        public async Task<IEnumerable<ReservaDTO>> GetReservasByClienteIdAsync(Guid clienteId)
        {
            var reservas = await _reservaRepository.GetByClienteIdAsync(clienteId);
            return reservas.Select(reserva => new ReservaDTO
            {
                Id = reserva.Id,
                ClienteId = reserva.ClienteId,
                ClienteNome = reserva.Cliente.Nome,
                VeiculoId = reserva.VeiculoId,
                VeiculoDescricao = $"{reserva.Veiculo.Marca} {reserva.Veiculo.Modelo}",
                DataInicio = reserva.DataInicio,
                DataFim = reserva.DataFim,
                Status = reserva.Status
            }).ToList();
        }
        public async Task<IEnumerable<ReservaDTO>> GetReservasDisponiveisAsync()
        {
            var reservas = await _reservaRepository.GetReservasDisponiveisAsync();
            return reservas.Select(reserva => new ReservaDTO
            {
                Id = reserva.Id,
                ClienteId = reserva.ClienteId,
                ClienteNome = reserva.Cliente.Nome,
                VeiculoId = reserva.VeiculoId,
                VeiculoDescricao = $"{reserva.Veiculo.Marca} {reserva.Veiculo.Modelo}",
                DataInicio = reserva.DataInicio,
                DataFim = reserva.DataFim,
                Status = reserva.Status
            }).ToList();
        }
    }
}