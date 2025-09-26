using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa el horario asignado a un profesional para una cita en el sistema.
    /// </summary>
    public class HorarioProfesional
    {
        /// <summary>
        /// Obtiene o establece el identificador único del horario asignado al profesional.
        /// </summary>
        public Guid IdHorario { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del profesional asociado a este horario.
        /// </summary>
        public Guid Id_Profesional { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha del horario asignado.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Obtiene o establece la hora de inicio del horario asignado.
        /// </summary>
        public TimeSpan HoraInicio { get; set; }

        /// <summary>
        /// Obtiene o establece la hora de finalización del horario asignado.
        /// </summary>
        public TimeSpan HoraFin { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único de la cita asociada a este horario.
        /// </summary>
        public Guid Id_Cita { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del horario (Disponible, Ocupado, etc.).
        /// </summary>
        public EstadoHorarios Estado { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HorarioProfesional"/> con un identificador único generado automáticamente.
        /// </summary>
        public HorarioProfesional()
        {
            IdHorario = Guid.NewGuid(); // Genera un GUID automáticamente
        }
    }


}
