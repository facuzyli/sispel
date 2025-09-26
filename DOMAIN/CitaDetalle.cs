using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa los detalles de una cita en el sistema.
    /// </summary>
    public class CitaDetalle
    {
        /// <summary>
        /// Obtiene o establece el identificador único del detalle de la cita.
        /// </summary>
        public Guid IdCitaDetalle { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único de la cita asociada.
        /// </summary>
        public Guid IdCita { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la cita.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Obtiene o establece la hora de inicio de la cita.
        /// </summary>
        public TimeSpan HoraInicio { get; set; }

        /// <summary>
        /// Obtiene o establece la hora de finalización de la cita.
        /// </summary>
        public TimeSpan HoraFin { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del profesional que atiende la cita.
        /// </summary>
        public string NombreProfesional { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tratamiento asociado a la cita.
        /// </summary>
        public string NombreTratamiento { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la etapa del tratamiento asociado a la cita.
        /// </summary>
        public string EtapaTratamiento { get; set; }

        /// <summary>
        /// Obtiene o establece las observaciones registradas para la cita.
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Obtiene o establece las recomendaciones proporcionadas durante la cita.
        /// </summary>
        public string Recomendaciones { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del paciente asociado a la cita.
        /// </summary>
        public Guid IdPaciente { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CitaDetalle"/> con un identificador único generado automáticamente.
        /// </summary>
        public CitaDetalle()
        {
            IdCitaDetalle = Guid.NewGuid(); // Genera un GUID automáticamente
        }
    }
}
