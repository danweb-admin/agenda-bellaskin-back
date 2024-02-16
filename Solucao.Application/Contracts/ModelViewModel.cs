using System;
using System.Collections.Generic;

namespace Solucao.Application.Contracts
{
	public class ModelViewModel
	{
        public Guid? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string ModelFileName { get; set; }
        public Guid EquipamentId { get; set; }
        public EquipamentViewModel Equipament { get; set; }

    }
}

