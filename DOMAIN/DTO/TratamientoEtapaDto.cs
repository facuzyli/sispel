using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa un DTO (Data Transfer Object) para los detalles de un tratamiento y su etapa.
    /// </summary>
    public class TratamientoEtapaDto
    {
        /// <summary>
        /// Obtiene o establece el nombre del tratamiento.
        /// </summary>
        public string NombreTratamiento { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la etapa del tratamiento.
        /// </summary>
        public string Etapa { get; set; }

        /// <summary>
        /// Obtiene o establece la duración de la etapa en minutos.
        /// </summary>
        public int Duracion { get; set; }

        /// <summary>
        /// Obtiene o establece la duración total del tratamiento en minutos.
        /// </summary>
        public int DuracionTotal { get; set; }
    }

}
