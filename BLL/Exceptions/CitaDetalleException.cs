using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Exceptions
{
    public class CitaDetalleException : Exception
    {
        // Constructor base
        public CitaDetalleException(string message)
            : base(message) { }

        public CitaDetalleException(string message, Exception innerException)
            : base(message, innerException) { }

        // Mensajes predefinidos
        public static CitaDetalleException CamposInvalidos()
        {
            return new CitaDetalleException(TranslateMessageKey("Uno o más campos tienen datos no válidos. Verifique la información ingresada."));
        }
        public static CitaDetalleException FechaInvalida()
        {
            return new CitaDetalleException(TranslateMessageKey("La fecha de la cita no puede ser posterior a la fecha actual."));
        }
        private static string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
    }
    
}
