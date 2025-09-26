using Service.DOMAIN;
using Service.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Facade
{
    public static class LoggerService
    {
        public static void WriteLog(Log log, Exception ex = null)
        {
            LoggerLogic.WriteLog(log, ex);
        }

        public static void WriteLog(string message, TraceLevel level = TraceLevel.Info)
        {
            LoggerLogic.WriteLog(new Log(message, level));
        }

        public static void WriteException(Exception ex)
        {
            LoggerLogic.WriteLog(new Log(ex.Message, TraceLevel.Error), ex);
        }
    }
}
