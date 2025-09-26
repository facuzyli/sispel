using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class PacienteException : Exception
    {

        // Constructor base
        public PacienteException(string message)
            : base(message) { }

        public PacienteException(string message, Exception innerException)
            : base(message, innerException) { }

        // Excepción para campos inválidos
        public static PacienteException CamposInvalidos()
        {
            return new PacienteException(TranslateMessageKey("Uno o más campos tienen datos no válidos. Verifique la información ingresada."));
        }

        // Excepción para correo electrónico no válido
        public static PacienteException CorreoInvalido()
        {
            return new PacienteException(TranslateMessageKey("El correo electrónico no es válido"));
        }

        // Excepción para número de teléfono no válido
        public static PacienteException TelefonoInvalido()
        {
            return new PacienteException(TranslateMessageKey("El número de teléfono no es válido"));
        }

        // Método para traducir los mensajes
        private static string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }





    }
}
