using System;
namespace Solucao.Application.Data.Entities
{
    public class History : BaseEntity
    {
        public string TableName { get; set; }
        public string Operation { get; set; }
        public DateTime OperationDate { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
}

