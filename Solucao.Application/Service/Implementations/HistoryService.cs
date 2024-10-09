using System;
using System.Threading.Tasks;
using AutoMapper;
using Solucao.Application.Data.Repositories;
using Solucao.Application.Service.Interfaces;

namespace Solucao.Application.Service.Implementations
{
	public class HistoryService : IHistoryService
	{
        private readonly HistoryRepository repository;

        public HistoryService(HistoryRepository _repository)
		{
            repository = _repository;
		}

        public async Task Add(string tableName, string operation, string userName, string message)
        {
            await repository.Add(tableName, operation, userName, message);
        }
    }
}

