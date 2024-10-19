using LocadaoV3.Domain.models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Queries
{
    public interface IReservaQueryService
    {
        Task<ReservaDTO> GetReservaByIdAsync(Guid id);
        Task<IEnumerable<ReservaDTO>> GetReservasByClienteIdAsync(Guid clienteId);
        Task<IEnumerable<ReservaDTO>> GetReservasDisponiveisAsync();
    }
}