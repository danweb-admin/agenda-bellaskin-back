using System;
using System.Collections.Generic;

namespace Solucao.Application.Data.Entities
{
	public class Model
	{
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
		public string ModelFileName { get; set; }
		public Guid EquipamentId { get; set; }
		public Equipament Equipament { get; set; }
		public List<ModelAttributes> ModelAttributes { get; set; }
	}
}

