﻿using LocadaoV3.Domain.Models;

namespace LocadaoV3.Infra.Repository.Agencias;

public interface IAgenciaRepository
{
    Task<Agencia> GetAgenciaByIdAsync(Guid id);

    Task<List<Agencia>> GetAllAgenciasAsync();

    Task<Agencia> AddAsync(Agencia agencia);

    Task DeleteAsync(Guid id);
    Task<int> CountVeiculosByAgenciaAsync(Guid agenciaId);
    Task<List<Aluguel>> GetAlugueisByAgenciaAsync(Guid agenciaId);
}
