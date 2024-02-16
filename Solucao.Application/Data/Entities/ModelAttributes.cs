using System;
namespace Solucao.Application.Data.Entities
{
	public class ModelAttributes
	{
        public Guid Id { get; set; }
        public string FileAttribute { get; set; }
		public string TechnicalAttribute { get; set; }
		public string AttributeType { get; set; }
	}
}

