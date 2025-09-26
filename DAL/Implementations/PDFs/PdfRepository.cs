using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Configuration;
using System.IO;
using DOMAIN;
using DAL.Contracts;
using DOMAIN.DTO;
using static System.Net.WebRequestMethods;
using Service.Facade;




namespace DAL.Implementations.PDFs
{
    /// <summary>
    /// Repositorio encargado de generar archivos PDF relacionados con los historiales de citas y horarios de profesionales.
    /// </summary>
    public class PdfRepository : IPdfRepository
    {
        /// <summary>
        /// Genera un archivo PDF con los detalles de citas de un paciente específico.
        /// </summary>
        /// <param name="detalles">Lista de detalles de las citas del paciente.</param>
        /// <param name="nombreCompletoPaciente">Nombre completo del paciente para personalizar el nombre del archivo PDF.</param>
        public void GenerarPDF(List<CitaDetalle> detalles, string nombreCompletoPaciente, string rutaArchivo)
        {
            // Leer la ruta desde app.config
            //string rutaCarpeta = ConfigurationManager.AppSettings["RutaCarpetaPDFHistoriales"];
            //string nombreArchivo = $"{TranslateMessageKey("HistorialPaciente")}_{nombreCompletoPaciente}.pdf";
            //string rutaArchivoPdf = Path.Combine(rutaCarpeta, nombreArchivo);
            string rutaCarpeta = Path.GetDirectoryName(rutaArchivo);

            // Asegúrate de que la carpeta exista, si no, créala
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // Crear el documento PDF
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 8); // Reducir el tamaño del texto
            XFont fontT = new XFont("Verdana", 10);
            XFont headerFont = new XFont("Verdana", 10); // Tamaño y estilo del encabezado

            // Definir el ancho de las columnas y altura de las filas
            int[] columnWidths = new int[] { 60, 45, 45, 80, 80, 40, 125, 125 }; // Anchos de columnas reducidos
            int rowHeight = 15; // Reducir la altura de las filas
            int yPosition = 40; // Posición inicial de la página

            // Agregar título
            gfx.DrawString(TranslateMessageKey("Historial del Paciente"), fontT, XBrushes.Black,
                new XRect(0, yPosition, page.Width, 20),
                XStringFormats.TopCenter);

            yPosition += 20; // Ajustar la posición después del título

            // Agregar nombre completo del paciente
            gfx.DrawString($"{TranslateMessageKey("Paciente")}: {nombreCompletoPaciente}", fontT, XBrushes.Black,
                new XRect(0, yPosition, page.Width, 20),
                XStringFormats.TopCenter);

            yPosition += 30; // Ajustar la posición después del nombre del paciente para crear espacio entre el nombre y la lista

            // Agregar encabezados de columnas
            string[] headers = {
                 TranslateMessageKey("Fecha"),
                 TranslateMessageKey("H.Inicio"),
                 TranslateMessageKey("H.Fin"),
                 TranslateMessageKey("Profesional"),
                 TranslateMessageKey("Tratamiento"),
                 TranslateMessageKey("Etapa"),
                 TranslateMessageKey("Observaciones"),
                 TranslateMessageKey("Recomendaciones")
            };
            int headerYPosition = yPosition;

            for (int i = 0; i < headers.Length; i++)
            {
                // Dibujar el encabezado
                gfx.DrawRectangle(XPens.Black, new XSolidBrush(XColors.LightGray), new XRect(columnWidths.Take(i).Sum(), headerYPosition, columnWidths[i], rowHeight));
                gfx.DrawString(headers[i], headerFont, XBrushes.Black,
                    new XRect(columnWidths.Take(i).Sum(), headerYPosition, columnWidths[i], rowHeight),
                    XStringFormats.Center);
            }

            // Dibujar una línea horizontal debajo del encabezado
            gfx.DrawLine(XPens.Black, 0, headerYPosition + rowHeight, page.Width, headerYPosition + rowHeight);

            yPosition = headerYPosition + rowHeight;

            // Agregar filas de datos
            foreach (var detalle in detalles)
            {
                gfx.DrawString(detalle.Fecha.ToString("dd/MM/yyyy"), font, XBrushes.Black,
                    new XRect(0, yPosition, columnWidths[0], rowHeight),
                    XStringFormats.TopLeft);
                gfx.DrawString(detalle.HoraInicio.ToString(@"hh\:mm"), font, XBrushes.Black,
                    new XRect(columnWidths[0], yPosition, columnWidths[1], rowHeight),
                    XStringFormats.TopLeft);
                gfx.DrawString(detalle.HoraFin.ToString(@"hh\:mm"), font, XBrushes.Black,
                    new XRect(columnWidths[0] + columnWidths[1], yPosition, columnWidths[2], rowHeight),
                    XStringFormats.TopLeft);
                gfx.DrawString(detalle.NombreProfesional, font, XBrushes.Black,
                    new XRect(columnWidths[0] + columnWidths[1] + columnWidths[2], yPosition, columnWidths[3], rowHeight),
                    XStringFormats.TopLeft);
                gfx.DrawString(detalle.NombreTratamiento, font, XBrushes.Black,
                    new XRect(columnWidths[0] + columnWidths[1] + columnWidths[2] + columnWidths[3], yPosition, columnWidths[4], rowHeight),
                    XStringFormats.TopLeft);
                gfx.DrawString(detalle.EtapaTratamiento, font, XBrushes.Black,
                    new XRect(columnWidths[0] + columnWidths[1] + columnWidths[2] + columnWidths[3] + columnWidths[4], yPosition, columnWidths[5], rowHeight),
                    XStringFormats.TopLeft);

                // Ajustar texto largo en observaciones y recomendaciones
                gfx.DrawString(detalle.Observaciones, font, XBrushes.Black,
                    new XRect(columnWidths[0] + columnWidths[1] + columnWidths[2] + columnWidths[3] + columnWidths[4] + columnWidths[5], yPosition, columnWidths[6], rowHeight * 2),
                    XStringFormats.TopLeft);
                gfx.DrawString(detalle.Recomendaciones, font, XBrushes.Black,
                    new XRect(columnWidths[0] + columnWidths[1] + columnWidths[2] + columnWidths[3] + columnWidths[4] + columnWidths[5] + columnWidths[6], yPosition, columnWidths[7], rowHeight * 2),
                    XStringFormats.TopLeft);

                yPosition += rowHeight * 2; // Aumentar la altura de la fila para separación adicional

                // Agregar una línea horizontal entre filas
                gfx.DrawLine(XPens.LightGray, 0.5, yPosition, page.Width, yPosition);

                // Agregar salto de página si es necesario
                if (yPosition + rowHeight * 2 > page.Height)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPosition = 40;
                }
            }

            // Guardar el documento
            document.Save(rutaArchivo);
        }
        /// <summary>
        /// Exporta una lista de horarios de un profesional a un archivo PDF.
        /// </summary>
        /// <param name="detalles">Lista de objetos que contienen detalles de los horarios.</param>
        /// <param name="nombreCompletoProfesional">Nombre completo del profesional para personalizar el archivo PDF.</param>
        /// <param name="fechaSeleccionada">Fecha seleccionada para mostrar los horarios de un día específico.</param>
        public void ExportarListaAPdf(List<HorarioProfesionalDto> detalles, string nombreCompletoProfesional, DateTime fechaSeleccionada, string rutaArchivo)
        {
            // Leer la ruta desde app.config
            //string rutaCarpeta = ConfigurationManager.AppSettings["RutaCarpetaPDFHorarios"];
            //string nombreArchivo = $"{TranslateMessageKey("Horarios")}_{nombreCompletoProfesional}_{fechaSeleccionada:yyyyMMdd}.pdf";
            //string rutaArchivoPdf = Path.Combine(rutaCarpeta, nombreArchivo);
           
            string rutaCarpeta = rutaArchivo;
            // Crear un nuevo documento PDF
            PdfDocument documento = new PdfDocument();
            documento.Info.Title = TranslateMessageKey("Reporte de Horarios");

            // Crear una página
            PdfPage pagina = documento.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(pagina);

            // Establecer las fuentes
            XFont fontTitulo = new XFont("Verdana", 16);
            XFont fontSubtitulo = new XFont("Verdana", 12);
            XFont fontHeader = new XFont("Verdana", 12);
            XFont fontCell = new XFont("Verdana", 10);

            // Coordenadas iniciales para el texto
            double yPoint = 40;
            double xPoint = 50;
            double cellHeight = 20;
            double columnWidth = 120; // Ancho de las columnas
            double tableWidth = 4 * columnWidth; // Ancho total de la tabla (suma de todos los anchos de columna)

            // Escribir título
            gfx.DrawString(TranslateMessageKey("Historial de Horarios"), fontTitulo, XBrushes.Black,
                new XRect(0, yPoint, pagina.Width, pagina.Height),
                XStringFormats.TopCenter);

            yPoint += 50; // Aumentar separación para la fecha

            // Escribir la fecha seleccionada
            gfx.DrawString($"{TranslateMessageKey("Fecha")}: {fechaSeleccionada:dd/MM/yyyy}", fontSubtitulo, XBrushes.Black,
                new XRect(0, yPoint, pagina.Width, pagina.Height),
                XStringFormats.TopCenter);

            yPoint += 30; // Aumentar separación para el nombre del profesional

            // Escribir nombre del profesional
            gfx.DrawString($"{TranslateMessageKey("Profesional")}: {nombreCompletoProfesional}", fontSubtitulo, XBrushes.Black,
                new XRect(0, yPoint, pagina.Width, pagina.Height),
                XStringFormats.TopCenter);

            yPoint += 40; // Aumentar separación para las cabeceras de la tabla

            // Dibujar las cabeceras con fondo gris
            XSolidBrush brushHeader = new XSolidBrush(XColor.FromArgb(211, 211, 211)); // Gris claro
            gfx.DrawRectangle(brushHeader, xPoint, yPoint, tableWidth, cellHeight);

            // Dibujar las cabeceras
            gfx.DrawString(TranslateMessageKey("Hora"), fontHeader, XBrushes.Black,
                new XRect(xPoint, yPoint, columnWidth, cellHeight),
                XStringFormats.TopLeft);
            gfx.DrawString(TranslateMessageKey("Paciente"), fontHeader, XBrushes.Black,
                new XRect(xPoint + columnWidth, yPoint, columnWidth, cellHeight),
                XStringFormats.TopLeft);
            gfx.DrawString(TranslateMessageKey("Teléfono"), fontHeader, XBrushes.Black,
                new XRect(xPoint + 2 * columnWidth, yPoint, columnWidth, cellHeight),
                XStringFormats.TopLeft);
            gfx.DrawString(TranslateMessageKey("Tratamiento"), fontHeader, XBrushes.Black,
                new XRect(xPoint + 3 * columnWidth, yPoint, columnWidth, cellHeight),
                XStringFormats.TopLeft);

            // Dibujar líneas horizontales para las cabeceras
            gfx.DrawLine(XPens.Black, xPoint, yPoint + cellHeight, xPoint + tableWidth, yPoint + cellHeight);

            yPoint += cellHeight; // Mover hacia abajo para las filas

            // Dibujar las filas con los datos de la lista
            foreach (var detalle in detalles)
            {
                string horaInicio = detalle.HoraInicio.ToString(@"hh\:mm");

                gfx.DrawString(horaInicio, fontCell, XBrushes.Black,
                    new XRect(xPoint, yPoint, columnWidth, cellHeight),
                    XStringFormats.TopLeft);
                gfx.DrawString(detalle.NombrePaciente ?? "", fontCell, XBrushes.Black,
                    new XRect(xPoint + columnWidth, yPoint, columnWidth, cellHeight),
                    XStringFormats.TopLeft);

                gfx.DrawString(detalle.TelefonoPaciente ?? "", fontCell, XBrushes.Black,
                    new XRect(xPoint + 2 * columnWidth, yPoint, columnWidth, cellHeight),
                    XStringFormats.TopLeft);

                gfx.DrawString(detalle.NombreTratamiento ?? "", fontCell, XBrushes.Black,
                    new XRect(xPoint + 3 * columnWidth, yPoint, columnWidth, cellHeight),
                    XStringFormats.TopLeft);

                yPoint += cellHeight; // Mover hacia abajo para la siguiente fila

                // Dibujar línea horizontal después de cada fila
                gfx.DrawLine(XPens.Black, xPoint, yPoint, xPoint + tableWidth, yPoint);
            }

            // Dibujar línea horizontal al final de la tabla
            gfx.DrawLine(XPens.Black, xPoint, yPoint, xPoint + tableWidth, yPoint);

            // Dibujar un borde alrededor de toda la tabla
            gfx.DrawRectangle(XPens.Black, xPoint, yPoint - (detalles.Count + 1) * cellHeight - cellHeight, tableWidth, (detalles.Count + 1) * cellHeight + cellHeight);

            // Guardar el documento en la ruta especificada
            documento.Save(rutaArchivo);
            documento.Close();
        }
        private string SanitizeFileName(string fileName)
        {
            // Reemplaza caracteres no válidos para nombres de archivos
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }
            return fileName;
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }

    }
}
