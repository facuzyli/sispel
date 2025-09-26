using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.DTO
{
    /// <summary>
    /// Representa un DTO (Data Transfer Object) para los detalles de un horario profesional.
    /// </summary>
    public class HorarioProfesionalDto
    {
        /// <summary>
        /// Obtiene o establece la hora de inicio del horario profesional.
        /// </summary>
        public TimeSpan HoraInicio { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del paciente asociado al horario profesional.
        /// </summary>
        public string NombrePaciente { get; set; }

        /// <summary>
        /// Obtiene o establece la duración de la etapa del tratamiento en minutos.
        /// </summary>
        public int DuracionEtapa { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del paciente asociado al horario profesional.
        /// </summary>
        public string TelefonoPaciente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tratamiento asociado al horario profesional.
        /// </summary>
        public string NombreTratamiento { get; set; }
    }

}
