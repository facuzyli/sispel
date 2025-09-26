using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa un tratamiento en el sistema, que puede tener varias etapas.
    /// </summary>
    public class Tratamiento
    {
        /// <summary>
        /// Obtiene o establece el identificador único del tratamiento.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tratamiento.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la duración total del tratamiento en minutos.
        /// </summary>
        public int DuracionTotal { get; set; } // Duración total en minutos, por ejemplo

        /// <summary>
        /// Obtiene o establece la descripción detallada del tratamiento.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de etapas asociadas a este tratamiento.
        /// </summary>
        public List<EtapaTratamiento> Etapas { get; set; } // Lista de etapas asociadas al tratamiento
    }

}
