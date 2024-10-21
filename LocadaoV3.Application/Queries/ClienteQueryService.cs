using LocadaoV3.Domain.Models.DTOs;
using LocadaoV3.Infra.Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Queries
{
    public class ClienteQueryService : IClienteQueryService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteQueryService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> GetClienteByIdAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return null;
            }

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Cpf = cliente.Cpf,
                TemCNH = cliente.TemCNH,
                IsPCD = cliente.IsPCD,
                DataNascimento = cliente.DataNascimento,
                ValidadeCNH = cliente.ValidadeCNH
            };
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesDisponiveisAsync()
        {
            var clientes = await _clienteRepository.GetClientesDisponiveisAsync();
            return clientes.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Cpf = cliente.Cpf,
                TemCNH = cliente.TemCNH,
                IsPCD = cliente.IsPCD,
                DataNascimento = cliente.DataNascimento,
                ValidadeCNH = cliente.ValidadeCNH
            }).ToList();
        }
    }
}
