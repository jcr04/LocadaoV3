using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Queries
{
    public interface IAgenciaQueryService
    {
        Task<AgenciaDTO> GetAgenciaByIdAsync(Guid id);

        Task<List<AgenciaDTO>> GetAllAgenciasAsync();
        Task<int> CountVeiculosByAgenciaAsync(Guid agenciaId);
        Task<List<Aluguel>> GetAlugueisByAgenciaAsync(Guid agenciaId);
    }
}
