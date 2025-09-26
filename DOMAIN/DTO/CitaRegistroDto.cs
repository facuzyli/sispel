using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.DTO
{
    /// <summary>
    /// Representa un DTO (Data Transfer Object) utilizado para el registro de citas.
    /// </summary>
    public class CitaRegistroDto
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la cita.
        /// </summary>
        public Guid IdCita { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la cita.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del profesional asociado a la cita.
        /// </summary>
        public string NombreProfesional { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tratamiento asociado a la cita.
        /// </summary>
        public string NombreTratamiento { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la etapa del tratamiento asociada a la cita.
        /// </summary>
        public string NombreEtapa { get; set; }
    }

}
