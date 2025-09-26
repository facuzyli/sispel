using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class HorariosProfesionalesException : Exception
    {
        // Constructor base
        public HorariosProfesionalesException(string message)
            : base(message) { }

        public HorariosProfesionalesException(string message, Exception innerException)
            : base(message, innerException) { }

        // Excepción cuando no hay datos para exportar
        public static HorariosProfesionalesException NoHayDatosParaExportar()
        {
            return new HorariosProfesionalesException(TranslateMessageKey("No hay datos para exportar. Aprete el boton de buscar"));
        }

        // Excepción cuando el horario ya está ocupado
        public static HorariosProfesionalesException HorarioOcupado()
        {
            return new HorariosProfesionalesException(TranslateMessageKey("El horario ya está ocupado."));
        }

        // Método para traducir los mensajes
        private static string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
    }
}
