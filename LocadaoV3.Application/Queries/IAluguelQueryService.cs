﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Queries
{
    public interface IAluguelQueryService
    {
        Task<AluguelDTO> GetAluguelByIdAsync(Guid id);
        Task<List<AluguelDTO>> GetAlugueisDisponiveisAsync();
    }
}
