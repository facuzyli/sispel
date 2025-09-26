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
    /// Interfaz para la capa de acceso a datos de los detalles de citas. Hereda de IGenericServiceDAL para operaciones básicas.
    /// </summary>
    public interface ICitaDetalleRepository : IGenericServiceDAL<CitaDetalle>
    {
        /// <summary>
        /// Agrega un nuevo detalle de cita a un tratamiento con las observaciones y recomendaciones proporcionadas.
        /// </summary>
        /// <param name="idCita">El ID de la cita a la que se le añadirá el detalle.</param>
        /// <param name="observaciones">Observaciones sobre la cita.</param>
        /// <param name="recomendaciones">Recomendaciones del profesional para la cita.</param>
        /// <returns>El objeto <see cref="CitaDetalle"/> creado.</returns>
        CitaDetalle Add1(Guid idCita, string observaciones, string recomendaciones);

        /// <summary>
        /// Obtiene una lista de los detalles de las citas asociadas a un paciente específico.
        /// </summary>
        /// <param name="idPaciente">El ID del paciente cuyas citas se desean obtener.</param>
        /// <returns>Una lista de objetos <see cref="CitaDetalle"/> asociados al paciente.</returns>
        List<CitaDetalle> ObtenerCitasPorPaciente(Guid idPaciente);

        List<CitaDetalle> ListarCitaDetallesSinDVH();

        List<CitaDetalle> ListarCitaDetalles();

    }
}
