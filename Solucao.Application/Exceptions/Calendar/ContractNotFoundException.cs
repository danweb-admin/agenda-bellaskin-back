using System;
namespace Solucao.Application.Exceptions.Calendar
{
	public class ContractNotFoundException : Exception
	{
		public ContractNotFoundException()
		{
		}

		public ContractNotFoundException(string message)
			:base(message)
		{

		}
	}
}

