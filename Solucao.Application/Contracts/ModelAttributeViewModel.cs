
using System;
using Solucao.Application.Data.Entities;

namespace Solucao.Application.Contracts
{
	public class ModelAttributeViewModel
	{
        public Guid? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string FileAttribute { get; set; }
        public string TechnicalAttribute { get; set; }
        public string AttributeType { get; set; }
        public Guid ModelId { get; set; }
        public Model Model { get; set; }

    }
}

