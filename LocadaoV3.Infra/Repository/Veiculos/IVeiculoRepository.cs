using LocadaoV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Infra.Repository.Veiculos
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(Guid id);
        Task<Veiculo> AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task DeleteAsync(Guid id);
        Task<Veiculo> GetByPlacaAsync(string placa);
        Task<bool> PlacaExistsAsync(string placa);
        Task<Veiculo> GetVeiculoAdaptadoDisponivelAsync(Guid agenciaId);
        Task<bool> VerificarDisponibilidadeAsync(Guid veiculoId, DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Veiculo>> GetVeiculosDisponiveisAsync();
    }
}
