using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa a un paciente en el sistema.
    /// </summary>
    public class Paciente
    {
        /// <summary>
        /// Obtiene o establece el identificador único del paciente.
        /// </summary>
        public Guid Id_Paciente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del paciente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del paciente.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del paciente.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del paciente.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del paciente.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece las alergias conocidas del paciente.
        /// </summary>
        public string Alergias { get; set; }

        /// <summary>
        /// Obtiene o establece los medicamentos que toma el paciente.
        /// </summary>
        public string Medicamentos { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de actividad del paciente. Indica si el paciente está activo en el sistema.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Paciente"/> con un identificador único generado automáticamente y estado activo por defecto.
        /// </summary>
        public Paciente()
        {
            Id_Paciente = Guid.NewGuid(); // Genera un GUID automáticamente
            Activo = true;  // El paciente está activo por defecto
        }

        /// <summary>
        /// Obtiene el nombre completo del paciente, que es la combinación del nombre y apellido.
        /// </summary>
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }
    }

}
