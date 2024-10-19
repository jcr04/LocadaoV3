using LocadaoV3.Domain.Models.DTOs;
using LocadaoV3.Infra.Repository.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Queries
{
    public class VeiculoQueryService : IVeiculoQueryService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoQueryService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<VeiculoDTO> GetVeiculoByIdAsync(Guid id)
        {
            var veiculo = await _veiculoRepository.GetByIdAsync(id);
            if (veiculo == null) return null;

            return new VeiculoDTO
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                AnoFabricacao = veiculo.AnoFabricacao,
                Placa = veiculo.Placa,
                Cor = veiculo.Cor,
                AdaptadoParaPCD = veiculo.AdaptadoParaPCD
                // Mapeie outras propriedades conforme necessário
            };
        }
        public async Task<IEnumerable<VeiculoDTO>> GetVeiculosDisponiveisAsync()
        {
            var veiculos = await _veiculoRepository.GetVeiculosDisponiveisAsync();
            return veiculos.Select(veiculo => new VeiculoDTO
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                AnoFabricacao = veiculo.AnoFabricacao,
                Placa = veiculo.Placa,
                Cor = veiculo.Cor,
                AdaptadoParaPCD = veiculo.AdaptadoParaPCD
            }).ToList();
        }
    }
}
