using Service.Context;
using Service.DAL.FactoryServices;
using Service.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Logic
{
    public static class LoggerLogic
    {
        private static LoggerContext _loggerContext = new LoggerContext();

        // Inicializa con la estrategia por defecto
        static LoggerLogic()
        {
            _loggerContext.SetLoggerStrategy(LoggerFactory.CreateLogger());
        }

        public static void WriteLog(Log log, Exception ex = null)
        {
            // Si es un error crítico, podrías hacer alguna acción extra aquí, como enviar una notificación

            // Escribir el log utilizando la estrategia configurada
            _loggerContext.WriteLog(log, ex);
        }
    }
}
