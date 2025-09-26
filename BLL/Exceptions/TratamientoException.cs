using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class TratamientoException : Exception
    {

        // Constructor base
        public TratamientoException(string message)
            : base(message) { }

        public TratamientoException(string message, Exception innerException)
            : base(message, innerException) { }

        // Excepción para campos inválidos
        public static TratamientoException CamposInvalidos()
        {
            return new TratamientoException(TranslateMessageKey("Uno o más campos tienen datos no válidos. Verifique la información ingresada."));
        }

        // Excepción para nombre de etapa vacío
        public static TratamientoException NombreEtapaVacio()
        {
            return new TratamientoException(TranslateMessageKey("El nombre de la etapa no puede estar vacío."));
        }

        // Excepción para duración de etapa inválida
        public static TratamientoException DuracionEtapaInvalida()
        {
            return new TratamientoException(TranslateMessageKey("La duración de la etapa debe ser 1 o 2."));
        }

        // Método para traducir los mensajes
        private static string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }

    }
}
