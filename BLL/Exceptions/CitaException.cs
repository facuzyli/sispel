using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class CitaException : Exception
    {
        // Constructor base
        public CitaException(string message)
            : base(message) { }

        public CitaException(string message, Exception innerException)
            : base(message, innerException) { }

        // Mensajes predefinidos
        public static CitaException FechaAnteriorHoy()
        {
            return new CitaException(TranslateMessageKey("La fecha de la cita no puede ser un día anterior al día de hoy."));
        }

        // Método de traducción
        private static string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
    }
}
