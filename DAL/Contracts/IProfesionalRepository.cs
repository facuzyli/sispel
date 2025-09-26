using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementations.SqlServer;
using DAL.Implementations.PDFs;



namespace DAL.Contracts
{
    /// <summary>
    /// Interfaz para la gestión de operaciones relacionadas con los profesionales del sistema.
    /// </summary>
    public interface IProfesionalRepository : IGenericServiceDAL<Profesional>
    {
        /// <summary>
        /// Obtiene un profesional mediante su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del profesional.</param>
        /// <returns>Un objeto <see cref="Profesional"/> que representa al profesional asociado con el identificador proporcionado.</returns>
        Profesional ObtenerProfesionalPorId(Guid id);

        /// <summary>
        /// Obtiene el nombre completo de un profesional utilizando su identificador único.
        /// </summary>
        /// <param name="idProfesional">El identificador único del profesional.</param>
        /// <returns>Una cadena de texto que representa el nombre completo del profesional asociado con el identificador proporcionado.</returns>
        string ObtenerNombreCompletoPorId(Guid idProfesional);
    }


}
