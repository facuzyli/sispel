using BLL;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class HistorialForm : Form
    {
        private readonly PacienteService _pacienteService;
        private readonly CitaDetalleService _citaDetalleService;
        public HistorialForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _pacienteService = new PacienteService();
            _citaDetalleService = new CitaDetalleService();

            CargarPacientesEnComboBox();
            this.KeyPreview = true;
            this.KeyDown += HistorialForm_KeyDown;
        }


        private void CargarPacientesEnComboBox()
        {
            var pacientes = _pacienteService.ObtenerTodosPacientes();
            // Filtrar solo pacientes activos para mostrar
            pacientes = pacientes.Where(p => p.Activo).ToList();

            // Cargar en el SfComboBox
            sfComboBoxPatient.DataSource = pacientes;
            sfComboBoxPatient.DisplayMember = "NombreCompleto"; // Mostrar Nombre y Apellido
            sfComboBoxPatient.ValueMember = "Id_Paciente"; // Usar el Id como valor interno
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {

            try
            {
                Guid idPaciente = (Guid)sfComboBoxPatient.SelectedValue;
               

                ValidarCitasPaciente(idPaciente);
                var citas = _citaDetalleService.ObtenerCitasPorPaciente(idPaciente);
                var nombreCompletoPaciente = _pacienteService.ObtenerNombreCompletoPorId(idPaciente);

                // Asignar la lista de citas directamente como el DataSource del DataGridView
                sfDataGridHistorial.DataSource = citas;

                // Refrescar el DataGridView para asegurarse de que se muestren los datos actualizados
                sfDataGridHistorial.Refresh();

                LoggerService.WriteLog($"Se mostro el historial de {nombreCompletoPaciente}", System.Diagnostics.TraceLevel.Info);

            }

            catch (ArgumentException ex)
            {
                string messageKey = "Error al cargar las citas";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage + ex.Message);
                LoggerService.WriteLog($"Se genero un error al listar el paciente" + ex.Message, System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");

                LoggerService.WriteException(ex);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (sfComboBoxPatient.SelectedValue == null)
                {
                    // Lanzamos explícitamente una excepción para capturar el error en el bloque catch
                    throw new ArgumentException(TranslateMessageKey("No se ha seleccionado ningún paciente."));
                }
                // Obtener el ID del paciente seleccionado
                Guid idPaciente = (Guid)sfComboBoxPatient.SelectedValue;

                // Validar que existan citas para el paciente seleccionado
                ValidarCitasPaciente(idPaciente);

                var nombreCompletoPaciente = _pacienteService.ObtenerNombreCompletoPorId(idPaciente);

                // Mostrar un diálogo para que el usuario elija la ubicación de guardado
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = $"{TranslateMessageKey("Guardar PDF")}";
                    saveFileDialog.FileName = $"{TranslateMessageKey("HistorialPaciente")}_{nombreCompletoPaciente}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaSeleccionada = saveFileDialog.FileName;

                        // Llamar al servicio BLL para generar el PDF en la ruta seleccionada
                        _citaDetalleService.GenerarHistorialPdf(idPaciente, nombreCompletoPaciente, rutaSeleccionada);

                        LoggerService.WriteLog($"Se creó un PDF con el historial del paciente {nombreCompletoPaciente} por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);

                        string messageKey = "PDF generado exitosamente.";
                        string translatedMessage = TranslateMessageKey(messageKey);
                        MessageBox.Show(translatedMessage, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                string messageKey = "Error al generar el PDF";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage + "  :"+ ex.Message);
                LoggerService.WriteLog($"Se genero un error al crear el PDF" + ex.Message, System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }
        }
        private void ValidarCitasPaciente(Guid idPaciente)
        {
            // Obtener las citas para el paciente seleccionado
            var citas = _citaDetalleService.ObtenerCitasPorPaciente(idPaciente);

            if (citas == null || !citas.Any())
            {
                string messageKey = "No se encontraron citas para este paciente.";
                string translatedMessage = TranslateMessageKey(messageKey);
                
                throw new ArgumentException(translatedMessage); // Lanza excepción para detener la ejecución
            }
        }

        private void HistorialForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
            UpdateColumnHeaders();
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        private void UpdateColumnHeaders()
        {
            // Actualiza los encabezados del sfDataGridHistorial
            sfDataGridHistorial.Columns[0].HeaderText = TranslateMessageKey("Fecha");
            sfDataGridHistorial.Columns[1].HeaderText = TranslateMessageKey("Hora Inicio");
            sfDataGridHistorial.Columns[2].HeaderText = TranslateMessageKey("Hora Fin");
            sfDataGridHistorial.Columns[3].HeaderText = TranslateMessageKey("Nombre Profesional");
            sfDataGridHistorial.Columns[4].HeaderText = TranslateMessageKey("Nombre Tratamiento");
            sfDataGridHistorial.Columns[5].HeaderText = TranslateMessageKey("Etapa ");
            sfDataGridHistorial.Columns[6].HeaderText = TranslateMessageKey("Observaciones");
            sfDataGridHistorial.Columns[7].HeaderText = TranslateMessageKey("Recomendaciones");
        }
        
        private void HistorialForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaHistorial();
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
