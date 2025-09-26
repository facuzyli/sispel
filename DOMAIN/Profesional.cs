using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa a un profesional en el sistema.
    /// </summary>
    public class Profesional
    {
        /// <summary>
        /// Obtiene o establece el identificador único del profesional.
        /// </summary>
        public Guid Id_Profesional { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del profesional.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del profesional.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del profesional.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del profesional.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del profesional.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece la especialización del profesional.
        /// </summary>
        public string Especializacion { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de actividad del profesional. Indica si el profesional está activo en el sistema.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de horarios disponibles para el profesional.
        /// </summary>
        public List<HorarioProfesional> Horarios { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Profesional"/> con un identificador único generado automáticamente y estado activo por defecto.
        /// </summary>
        public Profesional()
        {
            Id_Profesional = Guid.NewGuid(); // Genera un GUID automáticamente
            Activo = true;  // El profesional está activo por defecto
        }

        /// <summary>
        /// Obtiene el nombre completo del profesional, que es la combinación del nombre y apellido.
        /// </summary>
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }
    }

}
