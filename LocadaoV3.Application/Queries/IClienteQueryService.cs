using LocadaoV3.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Queries
{
    public interface IClienteQueryService
    {
        Task<ClienteDTO> GetClienteByIdAsync(Guid id);
        Task<IEnumerable<ClienteDTO>> GetClientesDisponiveisAsync();
    }
}
