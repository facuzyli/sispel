using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa una etapa específica de un tratamiento en el sistema.
    /// </summary>
    public class EtapaTratamiento
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la etapa del tratamiento.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tratamiento al que pertenece esta etapa.
        /// </summary>
        public Guid TratamientoId { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la etapa del tratamiento.
        /// </summary>
        public string NombreEtapa { get; set; }

        /// <summary>
        /// Obtiene o establece la duración de la etapa en minutos.
        /// </summary>
        public int Duracion { get; set; } // Duración en minutos

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EtapaTratamiento"/> con un identificador único generado automáticamente.
        /// </summary>
        public EtapaTratamiento()
        {
            Id = Guid.NewGuid(); // Genera un GUID automáticamente
        }
    }

}
