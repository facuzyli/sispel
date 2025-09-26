using BLL;
using DOMAIN;
using DOMAIN.DTO;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class HorariosForm : Form
    {
        private readonly ProfesionalService _profesionalService;
        private readonly HorariosProfesionalService _horariosProfesionalService;
        private Profesional _profesionalSeleccionado;
        private HorarioService _horarioBll;

        public HorariosForm()
        {
            InitializeComponent();
            _profesionalService = new ProfesionalService();
            _horarioBll = new HorarioService();
            _horariosProfesionalService = new HorariosProfesionalService();
            this.StartPosition = FormStartPosition.CenterScreen;

            CargarProfesionales();
            this.KeyPreview = true;
            this.KeyDown += HorariosForm_KeyDown;


        }
        private void CargarProfesionales()
        {
            var profesionales = _profesionalService.ObtenerTodosProfesionales();
            sfComboBoxProfessional.DataSource = profesionales.Where(p => p.Activo).ToList(); // Solo profesionales activos
            sfComboBoxProfessional.DisplayMember = "NombreCompleto"; // Concatenar Nombre y Apellido
            sfComboBoxProfessional.ValueMember = "Id_Profesional";
        }

        private void ConfigurarDataGrid()
        {

            string translatedMessage = TranslateMessageKey("Hora");
            string translatedMessage1 = TranslateMessageKey("Paciente");
            string translatedMessage2 = TranslateMessageKey("Teléfono");
            string translatedMessage3 = TranslateMessageKey("Tratamiento");

            // Asignar el DataSource con las horas predeterminadas
            dataGridViewHistorial.Rows.Clear();
            dataGridViewHistorial.Columns.Clear();
            dataGridViewHistorial.Columns.Add("Hora", translatedMessage);
            dataGridViewHistorial.Columns.Add("Paciente", translatedMessage1);
            dataGridViewHistorial.Columns.Add("Telefono", translatedMessage2);
            dataGridViewHistorial.Columns.Add("Tratamiento", translatedMessage3);


        }
        private void sfDataGridHistorial_Click(object sender, EventArgs e)
        {

        }

        private void HorariosForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
            UpdateColumnHeaders();
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        private void sfComboBoxProfessional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var profesionalId = (Guid)sfComboBoxProfessional.SelectedValue;
                var fechaSeleccionada = dateTimePicker.Value.Date;
                var nombreCompletoProfesional = _profesionalService.ObetenerNombrePorId(profesionalId);

                var detalles = _horariosProfesionalService.ObtenerDetallesCitaPorProfesional(profesionalId, fechaSeleccionada);


                // Mostrar los datos en el DataGridView
                MostrarHorarios(detalles);
                LoggerService.WriteLog($"Se mostro los horarios del profesional {nombreCompletoProfesional} en la fecha {fechaSeleccionada} Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                // Manejar la excepción, puedes loguearla o mostrar un mensaje al usuario
                MessageBox.Show($"Error: {ex.Message}");
                LoggerService.WriteException(ex);
            }

        }
        private void MostrarHorarios(List<HorarioProfesionalDto> detalles)
        {
            try
            {
                ConfigurarDataGrid(); // Configura las columnas antes de agregar filas

                // Limpiar las filas existentes
                dataGridViewHistorial.Rows.Clear();

                // Obtener las horas predeterminadas
                var horasFijas = _horarioBll.GenerarHorasFijas();
               

                // Variable para controlar el salto de horas si la etapa dura 2 horas
                int saltarHoras = 0;

                foreach (var hora in horasFijas)
                {
                    // Si necesitamos saltar la hora actual debido a una etapa de 2 horas, continuar con la siguiente iteración
                    if (saltarHoras > 0)
                    {
                        saltarHoras--;
                        continue;
                    }

                    var horaTimeSpan = hora.Hora; // Asume que hora.Hora es de tipo TimeSpan
                    var detalle = detalles.FirstOrDefault(d => d.HoraInicio == horaTimeSpan);

                    if (detalle != null)
                    {
                        // Añadir el registro correspondiente para la duración de la etapa
                        dataGridViewHistorial.Rows.Add(
                            horaTimeSpan.ToString(@"hh\:mm"),
                            detalle.NombrePaciente ?? "", // Usar el operador de fusión nula para evitar valores nulos
                            detalle.TelefonoPaciente ?? "",
                            detalle.NombreTratamiento ?? ""
                        );

                        if (detalle.DuracionEtapa == 2)
                        {
                            // Marcar la siguiente hora como ocupada también
                            var siguienteHora = horaTimeSpan.Add(TimeSpan.FromHours(1)); // Hora siguiente (por ejemplo, 9:00 si la hora es 8:00)

                            // Asegurarse de que la siguiente hora exista en la lista de horas fijas
                            if (horasFijas.Any(h => h.Hora == siguienteHora))
                            {
                                // Actualizar la siguiente fila (en vez de crear una nueva fila) con la misma información
                                dataGridViewHistorial.Rows.Add(
                                    siguienteHora.ToString(@"hh\:mm"),
                                    detalle.NombrePaciente ?? "",
                                    detalle.TelefonoPaciente ?? "",
                                    detalle.NombreTratamiento ?? ""
                                );

                                // Indicar que debemos saltar la siguiente hora en el bucle
                                saltarHoras = 1;
                            }
                        }
                    }
                    else
                    {
                        // Si no hay detalle, añadir una fila con la hora y celdas vacías
                        dataGridViewHistorial.Rows.Add(
                            horaTimeSpan.ToString(@"hh\:mm"), // Formatear TimeSpan para mostrar
                            "",
                            "",
                            ""
                        );
                    }
                }

                dataGridViewHistorial.Refresh();
                string messageKey = "Número de filas en DataGridView:";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage + $"{dataGridViewHistorial.Rows.Count}");
             
            }
            catch (Exception ex)
            {
                // Manejar la excepción, puedes loguearla o mostrar un mensaje al usuario
                MessageBox.Show($"Error: {ex.Message}");
                LoggerService.WriteException(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfComboBoxProfessional.SelectedValue == null)
                {
                    throw new ArgumentNullException(TranslateMessageKey("El profesional seleccionado no es válido."));
                }
                // Obtener los datos del DataGridView
                List<HorarioProfesionalDto> detalles = new List<HorarioProfesionalDto>();



                foreach (DataGridViewRow fila in dataGridViewHistorial.Rows)
                {
                    if (fila.Cells[0].Value != null) // Asegurarse de que no esté vacía
                    {
                        // Si la celda ya contiene un TimeSpan
                        TimeSpan horaInicio;
                        if (fila.Cells[0].Value is TimeSpan)
                        {
                            horaInicio = (TimeSpan)fila.Cells[0].Value;
                        }
                        else
                        {
                            // Si el valor es un string y necesitas convertirlo a TimeSpan
                            TimeSpan.TryParse(fila.Cells[0].Value.ToString(), out horaInicio);
                        }

                        // Crear el objeto HorarioProfesionalDto con la hora y otros detalles
                        detalles.Add(new HorarioProfesionalDto
                        {
                            HoraInicio = horaInicio,
                            NombrePaciente = fila.Cells[1].Value?.ToString() ?? "",
                            TelefonoPaciente = fila.Cells[2].Value?.ToString() ?? "",
                            NombreTratamiento = fila.Cells[3].Value?.ToString() ?? ""
                        });
                    }
                }
                DateTime fechaSeleccionada = dateTimePicker.Value;

                Guid Id = (Guid)sfComboBoxProfessional.SelectedValue;
                var nombreCompletoProfesional = _profesionalService.ObetenerNombrePorId(Id);

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = $"{TranslateMessageKey("Guardar PDF")}";
                    saveFileDialog.FileName = $"{TranslateMessageKey("Horarios")}_{nombreCompletoProfesional}_{fechaSeleccionada:yyyyMMdd}.pdf"; // Nombre de archivo dinámico

                    // Si el usuario selecciona una ubicación para guardar el archivo
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaSeleccionada = saveFileDialog.FileName;

                        // Llamar al servicio para generar el PDF en la ruta seleccionada
                        _horariosProfesionalService.ExportarHorarios(detalles, nombreCompletoProfesional, fechaSeleccionada, rutaSeleccionada);

                        // Mensaje de éxito
                        string messageKey = "PDF generado exitosamente";
                        string translatedMessage = TranslateMessageKey(messageKey);
                        MessageBox.Show(translatedMessage);

                        // Registrar la acción en los logs
                        LoggerService.WriteLog($"Se creó un PDF con los horarios del profesional {nombreCompletoProfesional} por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción, puedes loguearla o mostrar un mensaje al usuario
                MessageBox.Show($"Error: {ex.Message}");
                LoggerService.WriteException(ex);
            }
        }
        private void UpdateColumnHeaders()
        {
            // Asegúrate de que los encabezados se establezcan en este método
            dataGridViewHistorial.Columns[0].HeaderText = TranslateMessageKey("Hora");
            dataGridViewHistorial.Columns[1].HeaderText = TranslateMessageKey("Nombre Paciente");
            dataGridViewHistorial.Columns[2].HeaderText = TranslateMessageKey("Teléfono Paciente");
            dataGridViewHistorial.Columns[3].HeaderText = TranslateMessageKey("Nombre Tratamiento");
        }

        private void HorariosForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaHorarios();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }

        }
    }
}

