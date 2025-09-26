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
    /// Interfaz para la capa de acceso a datos de los horarios de los profesionales. Hereda de IGenericServiceDAL para operaciones básicas.
    /// </summary>
    public interface IHorarioProfesional : IGenericServiceDAL<HorarioProfesional>
    {
        /// <summary>
        /// Obtiene una lista de horarios ocupados por un profesional en una fecha específica.
        /// </summary>
        /// <param name="profesionalId">El ID del profesional cuyo horario ocupado se desea obtener.</param>
        /// <param name="fecha">La fecha para la cual se desea obtener los horarios ocupados.</param>
        /// <returns>Una lista de objetos <see cref="HorarioProfesional"/> que representan los horarios ocupados por el profesional en la fecha especificada.</returns>
        List<HorarioProfesional> ObtenerHorariosOcupadosPorProfesional1(Guid profesionalId, DateTime fecha);

        /// <summary>
        /// Obtiene una lista de horas específicas (sin detalles) ocupadas por un profesional en una fecha determinada.
        /// </summary>
        /// <param name="profesionalId">El ID del profesional cuyo horario ocupado se desea obtener.</param>
        /// <param name="fecha">La fecha para la cual se desean obtener las horas ocupadas.</param>
        /// <returns>Una lista de objetos <see cref="TimeSpan"/> que representan las horas ocupadas por el profesional en la fecha especificada.</returns>
        List<TimeSpan> ObtenerHorariosOcupadosPorProfesional(Guid profesionalId, DateTime fecha);

        /// <summary>
        /// Obtiene los detalles de las citas programadas para un profesional en una fecha específica.
        /// </summary>
        /// <param name="profesionalId">El ID del profesional cuyas citas se desean obtener.</param>
        /// <param name="fecha">La fecha para la cual se desean obtener los detalles de las citas programadas.</param>
        /// <returns>Una lista de objetos <see cref="HorarioProfesionalDto"/> con la información detallada sobre las citas de ese profesional en la fecha seleccionada.</returns>
        List<HorarioProfesionalDto> ObtenerDetallesCitaPorProfesional(Guid profesionalId, DateTime fecha);
    }

}
