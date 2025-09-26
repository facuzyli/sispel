using DAL.Factory;
using DAL;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DOMAIN.DTO;
using Service.Facade;
using DAL.Implementations.SqlServer;
using DAL.Implementations.PDFs;
using BLL.Exceptions;
namespace BLL
{
    /// <summary>
    /// Servicio para gestionar las operaciones relacionadas con las citas.
    /// </summary>
    public class CitaService
    {
        // Repositorio para gestionar las operaciones de citas.
        private readonly ICitaRepository _citaRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CitaService"/>.
        /// </summary>
        public CitaService()
        {
            // Obtiene la implementación del repositorio de citas desde la fábrica de DAL.
            _citaRepository = FactoryDAL.SqlCitaRepository;
        }

        /// <summary>
        /// Crea una nueva cita y la guarda en la base de datos.
        /// </summary>
        /// <param name="cita">La cita a crear.</param>
        /// <exception cref="ArgumentException">Se lanza si la fecha de la cita es anterior a la fecha actual.</exception>
        public void CrearCita(Cita cita)
        {
            // Valida que la fecha de la cita no sea anterior al día actual.
            if (cita.Fecha.Date < DateTime.Today)
            {

                throw CitaException.FechaAnteriorHoy();
            }

            // Agrega la cita al repositorio.
            _citaRepository.Add(cita);
        }

        /// <summary>
        /// Marca una cita como finalizada en la base de datos.
        /// </summary>
        /// <param name="idCita">El ID de la cita a finalizar.</param>
        public void FinalizarCita(Guid idCita)
        {
            _citaRepository.FinalizarCita(idCita);
        }

        /// <summary>
        /// Modifica los datos de una cita existente.
        /// </summary>
        /// <param name="cita">La cita con los datos actualizados.</param>
        public void ModificarCita(Cita cita)
        {
            _citaRepository.Update(cita);
        }

        /// <summary>
        /// Elimina una cita de la base de datos por su ID.
        /// </summary>
        /// <param name="idCita">El ID de la cita a eliminar.</param>
        public void EliminarCita(Guid idCita)
        {
            // Método pendiente de implementación para eliminar citas.
        }

        /// <summary>
        /// Obtiene todas las citas de la base de datos.
        /// </summary>
        /// <returns>Una lista de todas las citas.</returns>
        public List<Cita> ObtenerTodasCitas()
        {
            return _citaRepository.GetAll();
        }

        /// <summary>
        /// Obtiene una cita por su ID.
        /// </summary>
        /// <param name="idCita">El ID de la cita a obtener.</param>
        /// <returns>La cita correspondiente al ID o null si no se encuentra.</returns>
        public Cita ObtenerCitaPorId(Guid idCita)
        {
            return _citaRepository.GetById(idCita);
        }

        /// <summary>
        /// Obtiene una lista de citas asociadas a un paciente específico.
        /// Solo se incluyen las citas no finalizadas ni canceladas.
        /// </summary>
        /// <param name="idPaciente">El ID del paciente.</param>
        /// <returns>Una lista de citas no finalizadas del paciente.</returns>
        public List<CitaRegistroDto> ObtenerCitasPorPaciente(Guid idPaciente)
        {
            List<CitaRegistroDto> citas = _citaRepository.GetCitasByPaciente(idPaciente);

            // Lista para almacenar las citas que no están finalizadas ni canceladas.
            List<CitaRegistroDto> citasNoFinalizadas = new List<CitaRegistroDto>();

            // Filtra las citas según su estado.
            foreach (var cita in citas)
            {
                EstadoCita estado = _citaRepository.ObtenerEstadoCita(cita.IdCita);

                if (estado != EstadoCita.Finalizada && estado != EstadoCita.Cancelada)
                {
                    citasNoFinalizadas.Add(cita);
                }
            }

            return citasNoFinalizadas;
        }

        /// <summary>
        /// Obtiene una lista de citas programadas para la fecha actual.
        /// </summary>
        /// <returns>Una lista de citas para la fecha actual.</returns>
        public List<CitaMainFormDto> ObtenerCitasByFechaActual()
        {
            return _citaRepository.GetCitasByFechaActual();
        }

        /// <summary>
        /// Obtiene una lista de citas programadas para una fecha específica.
        /// </summary>
        /// <param name="fechaSeleccionada">La fecha de las citas a obtener.</param>
        /// <returns>Una lista de citas para la fecha seleccionada.</returns>
        public List<CitaMainFormDto> ObtenerCitasByFechaSeleccionada(DateTime fechaSeleccionada)
        {
            return _citaRepository.GetCitasByFechaSeleccionada(fechaSeleccionada);
        }

        /// <summary>
        /// Traduce una clave de mensaje al idioma actual.
        /// </summary>
        /// <param name="messageKey">La clave del mensaje a traducir.</param>
        /// <returns>El mensaje traducido.</returns>
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
    }
}
