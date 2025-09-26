using DAL;
using DAL.Factory;
using DAL.Contracts;
using DOMAIN;
using DOMAIN.DTO;
using Service.DOMAIN;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.Implementations.SqlServer;
using DAL.Implementations.PDFs;
using BLL.Exceptions;

namespace BLL
{
    /// <summary>
    /// Clase de servicio para la gestión de tratamientos y sus etapas. Incluye métodos para
    /// agregar tratamientos, agregar etapas a un tratamiento, y obtener información sobre tratamientos y etapas.
    /// </summary>
    public class TratamientoService
    {
        private readonly ITratamientoRepository _tratamientoRepository;

        /// <summary>
        /// Constructor que inicializa el repositorio de tratamientos.
        /// </summary>
        public TratamientoService()
        {
            _tratamientoRepository = FactoryDAL.SqlTratamientoRepository;
        }

        /// <summary>
        /// Agrega un nuevo tratamiento, validando la duración total y la información proporcionada.
        /// </summary>
        /// <param name="tratamiento">El objeto tratamiento a agregar.</param>
        /// <param name="duracionTotalTexto">La duración total del tratamiento en formato texto.</param>
        /// <exception cref="ArgumentException">Se lanza si algún campo es inválido.</exception>
        public void AgregarTratamiento(Tratamiento tratamiento, string duracionTotalTexto)
        {
            if (!int.TryParse(duracionTotalTexto, out int duracionTotal) || duracionTotal <= 0)
            {
                throw TratamientoException.CamposInvalidos();
            }

            // Asignar DuracionTotal al tratamiento
            tratamiento.DuracionTotal = duracionTotal;

            ValidarTratamiento(tratamiento);
            _tratamientoRepository.AgregarTratamiento(tratamiento);
        }

        /// <summary>
        /// Valida la información de un tratamiento para asegurarse de que todos los campos necesarios estén completos y correctos.
        /// </summary>
        /// <param name="tratamiento">El objeto tratamiento a validar.</param>
        /// <exception cref="ArgumentException">Se lanza si algún campo es inválido.</exception>
        private void ValidarTratamiento(Tratamiento tratamiento)
        {
            if (string.IsNullOrWhiteSpace(tratamiento.Nombre) ||
                tratamiento.DuracionTotal <= 0 ||
                string.IsNullOrWhiteSpace(tratamiento.Descripcion))
            {
                throw TratamientoException.CamposInvalidos();
            }
        }

        /// <summary>
        /// Valida la información de una etapa de tratamiento para asegurar que esté completa y correcta.
        /// </summary>
        /// <param name="etapa">El objeto etapa de tratamiento a validar.</param>
        /// <exception cref="ArgumentException">Se lanza si algún campo es inválido.</exception>
        private void ValidarEtapa(EtapaTratamiento etapa)
        {
            if (string.IsNullOrWhiteSpace(etapa.NombreEtapa))
            {
                throw TratamientoException.NombreEtapaVacio();
            }

            if (etapa.Duracion != 1 && etapa.Duracion != 2)
            {
                throw TratamientoException.DuracionEtapaInvalida();
            }
        }

        /// <summary>
        /// Agrega una nueva etapa a un tratamiento existente, validando la duración total y la información de la etapa.
        /// </summary>
        /// <param name="tratamientoId">El ID del tratamiento al que se agregará la etapa.</param>
        /// <param name="etapa">El objeto etapa a agregar.</param>
        /// <param name="duracionTotalTexto">La duración total de la etapa en formato texto.</param>
        /// <exception cref="ArgumentException">Se lanza si algún campo es inválido.</exception>
        public void AgregarEtapaAlTratamiento(Guid tratamientoId, EtapaTratamiento etapa, string duracionTotalTexto)
        {
            if (!int.TryParse(duracionTotalTexto, out int duracionTotal) || duracionTotal <= 0)
            {

                throw TratamientoException.CamposInvalidos();
            }

            etapa.Duracion = duracionTotal;
            ValidarEtapa(etapa);
            _tratamientoRepository.AgregarEtapaAlTratamiento(tratamientoId, etapa);
        }

        /// <summary>
        /// Obtiene la duración de una etapa de tratamiento por su ID.
        /// </summary>
        /// <param name="etapaId">El ID de la etapa.</param>
        /// <returns>La duración de la etapa.</returns>
        public int ObtenerDuracionEtapa(Guid etapaId)
        {
            return _tratamientoRepository.ObtenerDuracionEtapa(etapaId);
        }

        /// <summary>
        /// Obtiene un tratamiento por su ID.
        /// </summary>
        /// <param name="id">El ID del tratamiento.</param>
        /// <returns>El objeto tratamiento.</returns>
        public Tratamiento ObtenerTratamientoPorId(Guid id)
        {
            return _tratamientoRepository.ObtenerTratamientoPorId(id);
        }

        /// <summary>
        /// Obtiene todos los tratamientos registrados.
        /// </summary>
        /// <returns>Una lista de tratamientos.</returns>
        public IEnumerable<Tratamiento> ObtenerTodosTratamientos()
        {
            return _tratamientoRepository.ObtenerTodosTratamientos();
        }

        /// <summary>
        /// Obtiene todos los tratamientos con sus respectivas etapas.
        /// </summary>
        /// <returns>Una lista de tratamientos con etapas.</returns>
        public List<TratamientoEtapaDto> ObtenerTratamientosConEtapas()
        {
            return _tratamientoRepository.ObtenerTratamientosConEtapas();
        }

        /// <summary>
        /// Obtiene todas las etapas asociadas a un tratamiento específico.
        /// </summary>
        /// <param name="tratamientoId">El ID del tratamiento.</param>
        /// <returns>Una lista de etapas del tratamiento.</returns>
        public List<EtapaDto> ObtenerEtapasPorTratamiento(Guid tratamientoId)
        {
            return _tratamientoRepository.ObtenerEtapasPorTratamiento(tratamientoId);
        }

        /// <summary>
        /// Obtiene una etapa de tratamiento por su ID.
        /// </summary>
        /// <param name="etapaId">El ID de la etapa.</param>
        /// <returns>El objeto etapa de tratamiento.</returns>
        public EtapaTratamiento ObtenerEtapaPorId(Guid etapaId)
        {
            return _tratamientoRepository.ObtenerEtapaPorId(etapaId);
        }

        /// <summary>
        /// Traduce una clave de mensaje a un texto en el idioma apropiado.
        /// </summary>
        /// <param name="messageKey">La clave del mensaje a traducir.</param>
        /// <returns>El mensaje traducido.</returns>
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
    }
}

