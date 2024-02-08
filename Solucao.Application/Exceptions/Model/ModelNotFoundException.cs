using System;
namespace Solucao.Application.Exceptions.Model
{
	public class ModelNotFoundException : Exception
    {
		public ModelNotFoundException()
		{
		}

		public ModelNotFoundException(string message)
			:base(message)
		{

		}
	}
}

