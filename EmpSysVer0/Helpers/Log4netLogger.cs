using log4net.Config;
using log4net;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TrainEMPDB.Models;

namespace EmpSysVer0.Helpers
{
    public class Log4netLogger : ILogger
    {
        private readonly ILog _logger;
        public Log4netLogger(ILog logger)
        {
            _logger = logger;
        }
        public Log4netLogger(string name, FileInfo fileInfo)
        {
            var repository = LogManager.CreateRepository(
                    Assembly.GetEntryAssembly(),
                    typeof(log4net.Repository.Hierarchy.Hierarchy)
                );
            XmlConfigurator.Configure(repository, fileInfo);
            _logger = LogManager.GetLogger(repository.Name, name);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical: return _logger.IsFatalEnabled;
                case LogLevel.Debug:
                case LogLevel.Trace: return _logger.IsDebugEnabled;
                case LogLevel.Error: return _logger.IsErrorEnabled;
                case LogLevel.Information: return _logger.IsInfoEnabled;
                case LogLevel.Warning: return _logger.IsWarnEnabled;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel));
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            string message = null;
            if (null != formatter)
            {
                message = formatter(state, exception);
            }
            if (!string.IsNullOrEmpty(message) || exception != null)
            {
                switch (logLevel)
                {
                    case LogLevel.Critical: _logger.Fatal(message); break;
                    case LogLevel.Debug:
                    case LogLevel.Trace: _logger.Debug(message); break;
                    case LogLevel.Error: _logger.Error(message); break;
                    case LogLevel.Information: _logger.Info(message); break;
                    case LogLevel.Warning: _logger.Warn(message); break;
                    default:
                        _logger.Warn($"Unknown log level {logLevel}.\r\n{message}");
                        break;
                }
            }
        }
    }

}
