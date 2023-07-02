﻿using Serilog;
using Serilog.Events;

namespace FilterSerilog.SerilogConfiguration
{
    public static class ConfigurationSerilog
    {
        public static Serilog.ILogger ConfigureSerilog(IConfiguration configuration)
        {
            bool serilogEnabled = configuration.GetValue<bool>("Serilog:Enabled");

            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext();
               

            if (serilogEnabled)
            {
                // Configuração para logs completos
                var completeLogsPath = "../logs/complete-log.log";
                loggerConfiguration.WriteTo.File(completeLogsPath,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {CorrelationId} {Level:u3}] {Username} {Message:lj}{NewLine}{Exception}");
            }

            // Configuração para logs resumidos
            var summaryLogsPath = "../logs/filter-log.log";
            loggerConfiguration.WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(evt => IsMinimumLogLevel(evt))
                .WriteTo.File(summaryLogsPath,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {Message}{NewLine}{Exception}",
                    fileSizeLimitBytes: null, // Definido como nulo para permitir que o arquivo cresça sem limite
                    shared: true)); // compartilhar o arquivo com outros loggers


            Log.Logger = loggerConfiguration.CreateLogger();


            Log.Information("Logging configured successfully.");

            return Log.Logger;
        }
        /// <summary>
        /// Definindo o tipo mínimo a ser lido no log
        /// </summary>
        /// <param name="logEvent"></param>
        /// <returns></returns>
        private static bool IsMinimumLogLevel(LogEvent logEvent)
        {
            var minimumLevels = new[] { LogEventLevel.Warning, LogEventLevel.Error, LogEventLevel.Fatal };

            if (logEvent.Level == LogEventLevel.Error || logEvent.Level == LogEventLevel.Fatal)
            {
                var exception = logEvent.Exception;
                return exception != null;
            }

            return minimumLevels.Contains(logEvent.Level);
        }
    }
}
