using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao.Application.Utils
{
    public class CustomLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration config;
        public CustomLogger(string name, CustomLoggerProviderConfiguration _config)
        {
            loggerName = name;
            config = _config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = $"{DateTime.Now} - {logLevel.ToString()}: {eventId.Id} - {formatter(state,exception)}";
            WriteTextInFile(message);
        }

        private void WriteTextInFile(string message)
        {
            try
            {
                var today = DateTime.Now.ToString("yyyy-MM-dd");
                var path = Environment.GetEnvironmentVariable("LogPath");

                string fullPath = $"{path}/log{today}.txt";

                if (!File.Exists(fullPath))
                    File.Create(fullPath);

                using (StreamWriter streamWriter = new StreamWriter(fullPath, true))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
            catch (Exception e)
            {
                    Console.WriteLine(e);
            }
           
        }
    }
}
