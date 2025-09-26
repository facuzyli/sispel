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
    /// Interfaz para la capa de acceso a datos de los pacientes. Hereda de IGenericServiceDAL para operaciones básicas.
    /// </summary>
    public interface IPacienteRepository : IGenericServiceDAL<Paciente>
    {
        /// <summary>
        /// Agrega un nuevo paciente al sistema.
        /// </summary>
        /// <param name="paciente">El objeto <see cref="Paciente"/> que representa al paciente a agregar.</param>
        void Add(Paciente paciente);

        /// <summary>
        /// Actualiza la información de un paciente en el sistema.
        /// </summary>
        /// <param name="paciente">El objeto <see cref="Paciente"/> con la información actualizada del paciente.</param>
        void Update(Paciente paciente);

        /// <summary>
        /// Deshabilita un paciente en el sistema. Esto puede significar que el paciente ya no está activo o no puede ser consultado.
        /// </summary>
        /// <param name="idPaciente">El ID único del paciente a deshabilitar.</param>
        void Disable(Guid idPaciente);

        /// <summary>
        /// Obtiene todos los pacientes del sistema.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Paciente"/> que representan todos los pacientes en el sistema.</returns>
        new List<Paciente> GetAll();

        /// <summary>
        /// Obtiene el nombre completo de un paciente por su ID.
        /// </summary>
        /// <param name="idPaciente">El ID único del paciente.</param>
        /// <returns>Un string que representa el nombre completo del paciente.</returns>
        string GetNombreCompletoById(Guid idPaciente);
    }

}