using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class ProfesionalException : Exception
    {

        // Constructor base
        public ProfesionalException(string message)
            : base(message) { }

        public ProfesionalException(string message, Exception innerException)
            : base(message, innerException) { }

        // Excepción para campos inválidos
        public static ProfesionalException CamposInvalidos()
        {
            return new ProfesionalException(TranslateMessageKey("Uno o más campos tienen datos no válidos. Verifique la información ingresada."));
        }

        // Excepción para correo electrónico no válido
        public static ProfesionalException CorreoInvalido()
        {
            return new ProfesionalException(TranslateMessageKey("El correo electrónico no es válido"));
        }

        // Excepción para número de teléfono no válido
        public static ProfesionalException TelefonoInvalido()
        {
            return new ProfesionalException(TranslateMessageKey("El número de teléfono no es válido"));
        }

        // Método para traducir los mensajes
        private static string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
    }
}
