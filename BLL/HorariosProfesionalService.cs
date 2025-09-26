using DAL;
using DAL.Contracts;
using DAL.Factory;
using DOMAIN;
using DOMAIN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementations.SqlServer;
using DAL.Implementations.PDFs;
using BLL.Exceptions;

namespace BLL
{
    /// <summary>
    /// Servicio para gestionar los horarios de los profesionales y realizar operaciones como agregar horarios ocupados y exportar datos.
    /// </summary>
    public class HorariosProfesionalService
    {
        private readonly IHorarioProfesional _horariosProfesionalesRepository;
        private readonly IPdfRepository _pdfRepository;

        /// <summary>
        /// Constructor que inicializa los repositorios necesarios.
        /// </summary>
        public HorariosProfesionalService()
        {
            _horariosProfesionalesRepository = FactoryDAL.SqlHorarioProfesionalRepository;
            _pdfRepository = FactoryDAL.PdfRepository;
        }

        /// <summary>
        /// Agrega un horario ocupado a la lista de horarios de un profesional.
        /// </summary>
        /// <param name="horarioOcupado">El horario a agregar.</param>
        /// <exception cref="Exception">Lanzada si el horario ya está ocupado.</exception>
        public void AgregarHorarioOcupado(HorarioProfesional horarioOcupado)
        {
            if (EsHorarioDisponible(horarioOcupado.Id_Profesional, horarioOcupado.Fecha, horarioOcupado.HoraInicio))
            {
                _horariosProfesionalesRepository.Add(horarioOcupado);
            }
            else
            {
                throw HorariosProfesionalesException.HorarioOcupado();
            }
        }

        /// <summary>
        /// Verifica si un horario específico está disponible.
        /// </summary>
        /// <param name="idProfesional">El ID del profesional.</param>
        /// <param name="fecha">La fecha a verificar.</param>
        /// <param name="horaInicio">La hora de inicio a verificar.</param>
        /// <returns><c>true</c> si la hora está disponible; de lo contrario, <c>false</c>.</returns>
        public bool EsHorarioDisponible(Guid idProfesional, DateTime fecha, TimeSpan horaInicio)
        {
            var horariosOcupados = _horariosProfesionalesRepository.ObtenerHorariosOcupadosPorProfesional(idProfesional, fecha);
            return !horariosOcupados.Contains(horaInicio);
        }

        /// <summary>
        /// Obtiene una lista de horas disponibles para un profesional en una fecha dada y con una duración de etapa específica.
        /// </summary>
        /// <param name="idProfesional">El ID del profesional.</param>
        /// <param name="fecha">La fecha para la que se buscan horas disponibles.</param>
        /// <param name="duracionEtapa">La duración de la etapa en horas.</param>
        /// <returns>Una lista de horas disponibles.</returns>
        public List<TimeSpan> ObtenerHorasDisponibles(Guid idProfesional, DateTime fecha, int duracionEtapa)
        {
            var horasOcupadas = _horariosProfesionalesRepository.ObtenerHorariosOcupadosPorProfesional(idProfesional, fecha);
            var horasOcupadasSet = new HashSet<TimeSpan>(horasOcupadas);

            if (duracionEtapa == 2)
            {
                var horarios2Horas = new List<TimeSpan>
            {
                new TimeSpan(8, 0, 0),
                new TimeSpan(10, 0, 0),
                new TimeSpan(13, 0, 0),
                new TimeSpan(15, 0, 0)
            };

                return FiltrarIntervalosFijos(horarios2Horas, horasOcupadasSet, 2);
            }
            else
            {
                var horasValidas = ObtenerHorasValidas();
                return FiltrarHorasDisponibles(horasValidas, horasOcupadasSet, 1);
            }
        }

        /// <summary>
        /// Filtra los intervalos de tiempo fijos y devuelve aquellos que estén disponibles.
        /// </summary>
        /// <param name="horariosFijos">Lista de horarios fijos a filtrar.</param>
        /// <param name="horasOcupadas">Conjunto de horas ocupadas.</param>
        /// <param name="duracion">Duración de los intervalos en horas.</param>
        /// <returns>Una lista de horarios disponibles.</returns>
        private List<TimeSpan> FiltrarIntervalosFijos(List<TimeSpan> horariosFijos, HashSet<TimeSpan> horasOcupadas, int duracion)
        {
            var intervalosDisponibles = new List<TimeSpan>();

            foreach (var horaInicio in horariosFijos)
            {
                var horaFin = horaInicio.Add(TimeSpan.FromHours(duracion));
                if (IntervaloLibre(horaInicio, horaFin, horasOcupadas))
                {
                    intervalosDisponibles.Add(horaInicio);
                    for (var hora = horaInicio; hora < horaFin; hora = hora.Add(TimeSpan.FromHours(1)))
                    {
                        horasOcupadas.Add(hora);
                    }
                }
            }

            return intervalosDisponibles;
        }

        /// <summary>
        /// Filtra las horas válidas y devuelve aquellas que estén disponibles.
        /// </summary>
        /// <param name="horasValidas">Lista de horas válidas.</param>
        /// <param name="horasOcupadas">Conjunto de horas ocupadas.</param>
        /// <param name="duracionEtapa">Duración de la etapa en horas.</param>
        /// <returns>Una lista de horas disponibles.</returns>
        private List<TimeSpan> FiltrarHorasDisponibles(List<TimeSpan> horasValidas, HashSet<TimeSpan> horasOcupadas, int duracionEtapa)
        {
            var intervalosDisponibles = new List<TimeSpan>();

            foreach (var horaInicio in horasValidas)
            {
                var horaFin = horaInicio.Add(TimeSpan.FromHours(duracionEtapa));
                if (horaFin <= new TimeSpan(16, 0, 0) && IntervaloLibre(horaInicio, horaFin, horasOcupadas))
                {
                    intervalosDisponibles.Add(horaInicio);
                }
            }

            return intervalosDisponibles;
        }

        /// <summary>
        /// Verifica si un intervalo de tiempo está completamente libre.
        /// </summary>
        /// <param name="horaInicio">La hora de inicio del intervalo.</param>
        /// <param name="horaFin">La hora de fin del intervalo.</param>
        /// <param name="horasOcupadas">Conjunto de horas ocupadas.</param>
        /// <returns><c>true</c> si el intervalo está libre; de lo contrario, <c>false</c>.</returns>
        private bool IntervaloLibre(TimeSpan horaInicio, TimeSpan horaFin, HashSet<TimeSpan> horasOcupadas)
        {
            for (var hora = horaInicio; hora < horaFin; hora = hora.Add(TimeSpan.FromHours(1)))
            {
                if (horasOcupadas.Contains(hora))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Obtiene una lista de horas válidas dentro del horario laboral.
        /// </summary>
        /// <returns>Una lista de horas válidas.</returns>
        public List<TimeSpan> ObtenerHorasValidas()
        {
            var horasValidas = new List<TimeSpan>();

            for (int hour = 8; hour < 12; hour++)
            {
                horasValidas.Add(new TimeSpan(hour, 0, 0));
            }

            for (int hour = 13; hour <= 16; hour++)
            {
                horasValidas.Add(new TimeSpan(hour, 0, 0));
            }

            return horasValidas;
        }

        /// <summary>
        /// Obtiene los detalles de citas para un profesional específico en una fecha dada.
        /// </summary>
        /// <param name="profesionalId">El ID del profesional.</param>
        /// <param name="fecha">La fecha de las citas.</param>
        /// <returns>Una lista de detalles de citas.</returns>
        public List<HorarioProfesionalDto> ObtenerDetallesCitaPorProfesional(Guid profesionalId, DateTime fecha)
        {
            return _horariosProfesionalesRepository.ObtenerDetallesCitaPorProfesional(profesionalId, fecha);
        }

        /// <summary>
        /// Exporta los detalles de los horarios a un archivo PDF.
        /// </summary>
        /// <param name="detalles">Lista de detalles de horarios.</param>
        /// <param name="nombreCompletoPaciente">El nombre completo del paciente.</param>
        /// <param name="fechaSeleccionada">La fecha de los detalles a exportar.</param>
        /// <exception cref="ArgumentException">Lanzada si no hay datos para exportar.</exception>
        public void ExportarHorarios(List<HorarioProfesionalDto> detalles, string nombreCompletoPaciente, DateTime fechaSeleccionada , string rutaArchivo)
        {
            if (detalles == null || !detalles.Any())
            {
                throw HorariosProfesionalesException.NoHayDatosParaExportar();
            }

            _pdfRepository.ExportarListaAPdf(detalles, nombreCompletoPaciente, fechaSeleccionada, rutaArchivo);
        }
    }




}






