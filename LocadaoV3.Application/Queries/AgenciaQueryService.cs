﻿using LocadaoV3.Infra.Repository.Agencias;
using LocadaoV3.Infra.Repository.Alugueis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Application.Queries
{
    public class AgenciaQueryService : IAgenciaQueryService
    {
        private readonly IAgenciaRepository _agenciaRepository;
        private readonly IAluguelRepository _aluguelRepository;

        public AgenciaQueryService(IAgenciaRepository agenciaRepository, IAluguelRepository aluguelRepository)
        {
            _agenciaRepository = agenciaRepository;
            _aluguelRepository = aluguelRepository;
        }

        public async Task<AgenciaDTO> GetAgenciaByIdAsync(Guid id)
        {
            var agencia = await _agenciaRepository.GetAgenciaByIdAsync(id);
            if (agencia == null)
            {
                return null;
            }

            var numeroVeiculos = await _agenciaRepository.CountVeiculosByAgenciaAsync(id);
            var alugueis = await _aluguelRepository.GetAlugueisByAgenciaAsync(id);

            var agenciaDto = new AgenciaDTO
            {
                Id = agencia.Id,
                Nome = agencia.Nome,
                Endereco = agencia.Endereco,
                Telefone = agencia.Telefone,
                NumeroVeiculos = numeroVeiculos,
                Alugueis = alugueis.Select(a => new AluguelDTO
                {
                    Id = a.Id,
                    DataInicio = a.DataInicio,
                    DataFim = a.DataFim,
                    Valor = a.Valor,
                    Status = a.Status
                }).ToList()
            };

            return agenciaDto;
        }

        public async Task<List<AgenciaDTO>> GetAllAgenciasAsync()
        {
            var agencias = await _agenciaRepository.GetAllAgenciasAsync();

            return agencias.Select(agencia => new AgenciaDTO
            {
                Id = agencia.Id,
                Nome = agencia.Nome,
                Endereco = agencia.Endereco,
                Telefone = agencia.Telefone,
                NumeroVeiculos = agencia.Veiculos.Count,
                Alugueis = agencia.Alugueis.Select(a => new AluguelDTO
                {
                    Id = a.Id,
                    DataInicio = a.DataInicio,
                    DataFim = a.DataFim,
                    Valor = a.Valor,
                    Status = a.Status
                }).ToList()
            }).ToList();
        }

        public async Task<int> CountVeiculosByAgenciaAsync(Guid agenciaId)
        {
            // conta o número de veículos na agência
            return await _agenciaRepository.CountVeiculosByAgenciaAsync(agenciaId);
        }

        public async Task<List<Aluguel>> GetAlugueisByAgenciaAsync(Guid agenciaId)
        {
            // retorna todos os aluguéis da agência
            return await _aluguelRepository.GetAlugueisByAgenciaAsync(agenciaId);
        }
    }
}