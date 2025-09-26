using DAL.Factory;
using DAL.Implementations.SqlServer;
using DAL.Implementations.PDFs;
using DAL;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;

using Service.DOMAIN;
using Service.Facade;
using Service.Logic;
using BLL.Exceptions;

namespace BLL
{
    /// <summary>
    /// Servicio para gestionar los detalles de las citas.
    /// </summary>
    public class CitaDetalleService
    {
        // Dependencias de repositorios necesarias para la gestión de detalles de citas, citas, y la generación de PDFs.
        private readonly ICitaDetalleRepository _citaDetalleRepository;
        private readonly ICitaRepository _citaRepository;
        private readonly IPdfRepository _pdfRepository;

        private static DVHLogic _dvhLogic = new DVHLogic();

        /// <summary>
        /// Constructor de <see cref="CitaDetalleService"/> que inicializa los repositorios usando una fábrica de DAL.
        /// </summary>
        public CitaDetalleService()
        {
            _citaDetalleRepository = FactoryDAL.SqlCitaDetalleRepository;
            _citaRepository = FactoryDAL.SqlCitaRepository;
            _pdfRepository = FactoryDAL.PdfRepository;
        }

        /// <summary>
        /// Crea un nuevo detalle de cita y lo guarda en el repositorio.
        /// </summary>
        /// <param name="idCita">ID de la cita asociada.</param>
        /// <param name="observaciones">Observaciones de la cita.</param>
        /// <param name="recomendaciones">Recomendaciones de la cita.</param>
        /// <param name="DateCita">Fecha de la cita.</param>
        /// <exception cref="ArgumentException">Lanzada si los datos de la cita son inválidos.</exception>
        public void CrearCitaDetalle(Guid idCita, string observaciones, string recomendaciones, DateTime DateCita)
        {
            // Crea un objeto CitaDetalle con las observaciones y recomendaciones proporcionadas.
            CitaDetalle citaDetalle = new CitaDetalle
            {
                Observaciones = observaciones,
                Recomendaciones = recomendaciones
            };

            // Valida los datos de la cita antes de guardar.
            ValidarCitaDetalle(citaDetalle, DateCita);


            // Agrega el detalle de la cita al repositorio y finaliza la cita.
            
            _citaDetalleRepository.Add1(idCita, observaciones, recomendaciones);
            _citaRepository.FinalizarCita(idCita);
            VerificarYGenerarDVHCitaDetalle();

        }
        public void VerificarYGenerarDVHCitaDetalle()
        {
            // Obtener los CitaDetalle sin DVH
            var citaDetallesSinDVH = _citaDetalleRepository.ListarCitaDetallesSinDVH();

            // Verificar si hay CitaDetalles sin DVH
            if (citaDetallesSinDVH != null && citaDetallesSinDVH.Count > 0)
            {
                // Recorrer cada CitaDetalle sin DVH
                foreach (var citaDetalle in citaDetallesSinDVH)
                {
                    // Generar DVH para el CitaDetalle
                    _dvhLogic.DVHCitaDetalle(citaDetalle);
                }
            }
            
        }
        public void VerificarDVHDeCitaDetalles()
        {
            HashSet<string> erroresRegistrados = new HashSet<string>(); // Usamos un HashSet para evitar duplicados

            // Obtener todos los CitaDetalle
            List<CitaDetalle> citaDetalles = _citaDetalleRepository.ListarCitaDetalles();

            foreach (var citaDetalle in citaDetalles)
            {
                if (citaDetalle == null)
                {
                    // Si el CitaDetalle es nulo, continuamos con el siguiente
                    continue;
                }

                // Verificar el DVH para cada CitaDetalle
                bool esValido = _dvhLogic.VerificarDVHCitaDetalle(citaDetalle);

                if (!esValido)
                {
                    // Crear el mensaje de error
                    string mensajeError = $"Hay inconsistencias en la base de datos, En la Tabla CitaDetalle, En la CitaDetalle con Id: {citaDetalle.IdCitaDetalle}";

                    // Verificar si el error ya ha sido registrado
                    if (!erroresRegistrados.Contains(mensajeError))
                    {
                        // Si no se ha registrado, agregarlo al HashSet
                        erroresRegistrados.Add(mensajeError);

                        // Llamar al método para escribir en la bitácora
                        LoggerService.WriteLog(mensajeError, System.Diagnostics.TraceLevel.Error);
                    }
                }
            }
        }
            /// <summary>
            /// Valida los datos de un detalle de cita.
            /// </summary>
            /// <param name="citaDetalle">El detalle de la cita a validar.</param>
            /// <param name="DateCita">La fecha de la cita.</param>
            /// <exception cref="ArgumentException">Lanzada si algún campo es inválido o si la fecha es posterior a la actual.</exception>
        private void ValidarCitaDetalle(CitaDetalle citaDetalle, DateTime DateCita)
        {
            // Verifica si las observaciones y recomendaciones están vacías o contienen solo espacios.
            if (string.IsNullOrWhiteSpace(citaDetalle.Observaciones) ||
                string.IsNullOrWhiteSpace(citaDetalle.Recomendaciones))
            {
                
              
                throw CitaDetalleException.CamposInvalidos(); 
            }

            // Verifica si la fecha de la cita es posterior a la fecha actual.
            if (DateCita.Date > DateTime.Today)
            {
             
             
                throw CitaDetalleException.FechaInvalida(); 
            }
        }

        /// <summary>
        /// Cancela una cita específica.
        /// </summary>
        /// <param name="idCita">ID de la cita a cancelar.</param>
        public void CancelarCita(Guid idCita)
        {
            _citaRepository.CancelarCita(idCita);
        }

        /// <summary>
        /// Obtiene una lista de detalles de citas para un paciente específico.
        /// </summary>
        /// <param name="idPaciente">ID del paciente.</param>
        /// <returns>Lista de detalles de citas asociadas al paciente.</returns>
        public List<CitaDetalle> ObtenerCitasPorPaciente(Guid idPaciente)
        {
            return _citaDetalleRepository.ObtenerCitasPorPaciente(idPaciente);
        }

        /// <summary>
        /// Genera un historial en PDF de las citas de un paciente.
        /// </summary>
        /// <param name="idPaciente">ID del paciente.</param>
        /// <param name="nombreCompletoPaciente">Nombre completo del paciente para el título del PDF.</param>
        public void GenerarHistorialPdf(Guid idPaciente, string nombreCompletoPaciente ,string rutaArchivo)
        {
            // Obtiene los detalles de las citas del paciente.
            var detalles = ObtenerCitasPorPaciente(idPaciente);

            // Genera el PDF con los detalles obtenidos.
            _pdfRepository.GenerarPDF(detalles, nombreCompletoPaciente , rutaArchivo);
        }

        /// <summary>
        /// Traduce una clave de mensaje a su mensaje correspondiente en el idioma actual.
        /// </summary>
        /// <param name="messageKey">Clave del mensaje a traducir.</param>
        /// <returns>El mensaje traducido.</returns>
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
    }
}
    

