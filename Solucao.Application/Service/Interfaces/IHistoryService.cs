using System;
using Solucao.Application.Contracts;
using System.Threading.Tasks;

namespace Solucao.Application.Service.Interfaces
{
	public interface IHistoryService
	{
        Task Add(string tableName, string operation, string userName, string message);

    }
}

