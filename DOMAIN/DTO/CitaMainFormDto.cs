using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Contiene los objetos de transferencia de datos (DTO) que son utilizados para representar datos que se transfieren entre las capas de la aplicación,
/// especialmente entre la capa de lógica de negocios (BLL) y la capa de presentación (UI). Estos DTOs son versiones simplificadas de las entidades del dominio.
/// </summary>
namespace DOMAIN.DTO
{
    /// <summary>
    /// Representa un DTO (Data Transfer Object) para la visualización de la cita en el formulario principal.
    /// </summary>
    public class CitaMainFormDto
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
        /// Obtiene o establece la hora de inicio de la cita.
        /// </summary>
        public TimeSpan HoraInicio { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del paciente asociado a la cita.
        /// </summary>
        public string NombrePaciente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del profesional que atenderá la cita.
        /// </summary>
        public string NombreProfesional { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tratamiento que se realizará en la cita.
        /// </summary>
        public string NombreTratamiento { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la etapa del tratamiento que se llevará a cabo en la cita.
        /// </summary>
        public string NombreEtapa { get; set; }
    }

}
