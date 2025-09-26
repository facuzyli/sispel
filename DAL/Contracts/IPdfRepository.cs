using DOMAIN;
using DOMAIN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementations.SqlServer;
using DAL.Implementations.PDFs;
using iText.Commons.Utils;



namespace DAL.Contracts
{
    /// <summary>
    /// Interfaz para la generación y exportación de documentos PDF en el sistema.
    /// </summary>
    public interface IPdfRepository
    {
        /// <summary>
        /// Genera un archivo PDF con los detalles de la cita de un paciente.
        /// </summary>
        /// <param name="detalles">Lista de objetos <see cref="CitaDetalle"/> que representan los detalles de la cita que se incluirán en el PDF.</param>
        /// <param name="nombreCompletoPaciente">El nombre completo del paciente, que se utilizará en el documento PDF.</param>
        void GenerarPDF(List<CitaDetalle> detalles, string nombreCompletoPaciente , string rutaArchivo);

        /// <summary>
        /// Exporta una lista de horarios de profesionales a un archivo PDF.
        /// </summary>
        /// <param name="detalles">Lista de objetos <see cref="HorarioProfesionalDto"/> que contienen los detalles de los horarios del profesional.</param>
        /// <param name="nombreCompletoPaciente">El nombre completo del paciente que se utilizará en el documento PDF.</param>
        /// <param name="fechaSeleccionada">La fecha seleccionada que se incluirá en el documento PDF para contextualizar los horarios.</param>
        void ExportarListaAPdf(List<HorarioProfesionalDto> detalles, string nombreCompletoPaciente, DateTime fechaSeleccionada, string rutaArchivo);
    }
}
