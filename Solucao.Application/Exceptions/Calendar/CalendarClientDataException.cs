using System;
namespace Solucao.Application.Exceptions.Calendar
{
	public class CalendarClientDataException : Exception
    {
		public CalendarClientDataException()
		{
		}

        public CalendarClientDataException(string message)
            : base(message)
        {

        }
    }
}

