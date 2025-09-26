using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.DTO
{
    /// <summary>
    /// Representa un DTO (Data Transfer Object) para una etapa de tratamiento.
    /// </summary>
    public class EtapaDto
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la etapa.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la etapa de tratamiento.
        /// </summary>
        public string Nombre { get; set; }
    }

}
