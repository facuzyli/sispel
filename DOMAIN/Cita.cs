using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Contiene las entidades del dominio de la aplicación, que representan objetos clave del sistema como Paciente, Profesional, Tratamiento, etc.
/// Estas entidades son usadas por el acceso a datos (DAL) y la lógica de negocios (BLL).
/// </summary>
namespace DOMAIN
{
    /// <summary>
    /// Representa una cita en el sistema de gestión de citas.
    /// </summary>
    public class Cita
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la cita.
        /// </summary>
        public Guid Id_Cita { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora de la cita.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del paciente asociado a la cita.
        /// </summary>
        public Guid Id_Paciente { get; set; } // Mejor usar ID en lugar de objeto completo

        /// <summary>
        /// Obtiene o establece el identificador único del profesional asociado a la cita.
        /// </summary>
        public Guid Id_Profesional { get; set; } // Mejor usar ID en lugar de objeto completo

        /// <summary>
        /// Obtiene o establece el identificador único del tratamiento asociado a la cita.
        /// </summary>
        public Guid Id_Tratamiento { get; set; } // Mejor usar ID en lugar de objeto completo

        /// <summary>
        /// Obtiene o establece el identificador único de la etapa del tratamiento asociada a la cita.
        /// </summary>
        public Guid Id_EtapaTratamiento { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la cita.
        /// </summary>
        public EstadoCita Estado { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Cita"/> con un identificador único y un estado predeterminado.
        /// </summary>
        public Cita()
        {
            Id_Cita = Guid.NewGuid();
            Estado = EstadoCita.Programada;  // Estado predeterminado
        }
    }

}
