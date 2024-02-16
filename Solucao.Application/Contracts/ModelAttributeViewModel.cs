
using System;
using Solucao.Application.Data.Entities;

namespace Solucao.Application.Contracts
{
	public class ModelAttributeViewModel
	{
        public Guid? Id { get; set; }
        public string FileAttribute { get; set; }
        public string TechnicalAttribute { get; set; }
        public string AttributeType { get; set; }

    }
}

