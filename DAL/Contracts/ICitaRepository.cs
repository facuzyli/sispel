using DOMAIN;
using DOMAIN.DTO;
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
    /// Interfaz para la capa de acceso a datos de las citas. Hereda de IGenericServiceDAL para operaciones básicas.
    /// </summary>
    public interface ICitaRepository : IGenericServiceDAL<Cita>
    {
        /// <summary>
        /// Obtiene una lista de citas asociadas a un paciente específico.
        /// </summary>
        /// <param name="idPaciente">El ID del paciente cuyas citas se desean obtener.</param>
        /// <returns>Una lista de objetos <see cref="CitaRegistroDto"/> con información relevante sobre las citas del paciente.</returns>
        List<CitaRegistroDto> GetCitasByPaciente(Guid idPaciente);

        /// <summary>
        /// Obtiene una lista de citas para la fecha actual.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="CitaMainFormDto"/> con información sobre las citas programadas para el día de hoy.</returns>
        List<CitaMainFormDto> GetCitasByFechaActual();

        /// <summary>
        /// Obtiene una lista de citas para una fecha seleccionada.
        /// </summary>
        /// <param name="fechaSeleccionada">La fecha para la que se desean obtener las citas.</param>
        /// <returns>Una lista de objetos <see cref="CitaMainFormDto"/> con información sobre las citas programadas para la fecha especificada.</returns>
        List<CitaMainFormDto> GetCitasByFechaSeleccionada(DateTime fechaSeleccionada);

        /// <summary>
        /// Finaliza una cita específica, actualizando su estado.
        /// </summary>
        /// <param name="idCita">El ID de la cita a finalizar.</param>
        void FinalizarCita(Guid idCita);

        /// <summary>
        /// Cancela una cita específica, actualizando su estado.
        /// </summary>
        /// <param name="idCita">El ID de la cita a cancelar.</param>
        void CancelarCita(Guid idCita);

        /// <summary>
        /// Obtiene el estado actual de una cita específica.
        /// </summary>
        /// <param name="idCita">El ID de la cita cuya estado se desea obtener.</param>
        /// <returns>El estado actual de la cita, representado por el valor de <see cref="EstadoCita"/>.</returns>
        EstadoCita ObtenerEstadoCita(Guid idCita);
    }
}
