﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadaoV3.Domain.Models.DTOs
{
    public class VeiculoDTO
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }

        public bool AdaptadoParaPCD { get; set; }
        // Outros detalhes que você deseja expor
    }
}