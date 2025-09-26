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
    /// Interfaz para la gestión de operaciones relacionadas con los tratamientos en el sistema.
    /// </summary>
    public interface ITratamientoRepository  : IGenericServiceDAL<Tratamiento>
    {
        /// <summary>
        /// Agrega un nuevo tratamiento al repositorio.
        /// </summary>
        /// <param name="tratamiento">El objeto <see cref="Tratamiento"/> que representa el tratamiento que se va a agregar.</param>
        void AgregarTratamiento(Tratamiento tratamiento);

        /// <summary>
        /// Obtiene un tratamiento mediante su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del tratamiento.</param>
        /// <returns>Un objeto <see cref="Tratamiento"/> que representa el tratamiento asociado al identificador proporcionado.</returns>
        Tratamiento ObtenerTratamientoPorId(Guid id);

        /// <summary>
        /// Agrega una etapa a un tratamiento existente.
        /// </summary>
        /// <param name="tratamientoId">El identificador único del tratamiento al que se le agregará la etapa.</param>
        /// <param name="etapa">El objeto <see cref="EtapaTratamiento"/> que representa la etapa a agregar al tratamiento.</param>
        void AgregarEtapaAlTratamiento(Guid tratamientoId, EtapaTratamiento etapa);

        /// <summary>
        /// Obtiene todos los tratamientos almacenados en el repositorio.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Tratamiento"/> que representan todos los tratamientos almacenados.</returns>
        IEnumerable<Tratamiento> ObtenerTodosTratamientos();

        /// <summary>
        /// Obtiene los tratamientos junto con sus etapas asociadas.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="TratamientoEtapaDto"/> que representa los tratamientos y sus etapas.</returns>
        List<TratamientoEtapaDto> ObtenerTratamientosConEtapas();

        /// <summary>
        /// Obtiene todas las etapas asociadas a un tratamiento específico.
        /// </summary>
        /// <param name="tratamientoId">El identificador único del tratamiento.</param>
        /// <returns>Una lista de objetos <see cref="EtapaDto"/> que representa las etapas asociadas al tratamiento.</returns>
        List<EtapaDto> ObtenerEtapasPorTratamiento(Guid tratamientoId);

        /// <summary>
        /// Obtiene la duración de una etapa específica.
        /// </summary>
        /// <param name="etapaId">El identificador único de la etapa.</param>
        /// <returns>Un valor entero que representa la duración de la etapa en unidades de tiempo.</returns>
        int ObtenerDuracionEtapa(Guid etapaId);

        /// <summary>
        /// Obtiene una etapa específica mediante su identificador único.
        /// </summary>
        /// <param name="etapaId">El identificador único de la etapa.</param>
        /// <returns>Un objeto <see cref="EtapaTratamiento"/> que representa la etapa asociada al identificador proporcionado.</returns>
        EtapaTratamiento ObtenerEtapaPorId(Guid etapaId);
    }

}
