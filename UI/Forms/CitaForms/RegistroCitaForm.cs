using BLL;
using DOMAIN;
using DOMAIN.DTO;
using Service.Facade;
using Syncfusion.WinForms.DataGrid;
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
    public partial class RegistroCitaForm : Form
    {
        private readonly CitaDetalleService _citaDetalleService;
        private readonly PacienteService _pacienteService;
        private Paciente _pacienteSeleccionado;
        public RegistroCitaForm()
        {
            InitializeComponent();
            _pacienteService = new PacienteService();
            _citaDetalleService = new CitaDetalleService();
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarPacientes();
            this.KeyPreview = true;
            this.KeyDown += RegistroCitaForm_KeyDown;
        }
        private void CargarPacientes()
        {
            var pacientes = _pacienteService.ObtenerTodosPacientes();
            sfComboBoxPaciente.DataSource = pacientes.Where(p => p.Activo).ToList(); // Solo pacientes activos
            sfComboBoxPaciente.DisplayMember = "NombreCompleto"; // Concatenar Nombre y Apellido
            sfComboBoxPaciente.ValueMember = "Id_Paciente";
        }

        private void buttonCrearRegistro_Click(object sender, EventArgs e)
        {
            if (sfDataGridCitas.SelectedItems.Count > 0)
            {
                var selectedCita = sfDataGridCitas.SelectedItem as CitaRegistroDto;
                Guid idCita = selectedCita.IdCita;
                DateTime DateCita = selectedCita.Fecha;
                try
                {
                    // Obtener el item seleccionado
                    // Asegúrate de que `IdCita` está en tu DTO

                    // Obtener observaciones y recomendaciones desde los controles del formulario
                    string observaciones = textBoxObservaciones.Text;
                    string recomendaciones = textBoxRecomendacion.Text;

                    // Llamar al servicio para crear el detalle de la cita
                    _citaDetalleService.CrearCitaDetalle(idCita, observaciones, recomendaciones, DateCita);

                    // Cargar de nuevo las citas en el grid
                    CargarCitas();
                    sfDataGridCitas.Refresh();

                    // Mostrar mensaje de éxito si es necesario
                    string messageKey = "Registro creado correctamente.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);

                    LoggerService.WriteLog($"Se creo una detalle de la cita con id {selectedCita.IdCita} Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                    textBoxObservaciones.Clear();
                    textBoxRecomendacion.Clear();

                }
                catch (ArgumentException ex)
                {
                    LoggerService.WriteLog($"Se creo genero un error al crear el detalle de la cita {selectedCita.IdCita} Por el usuario: {SesionService.UsuarioLogueado.UserName}  " + ex.Message, System.Diagnostics.TraceLevel.Info);
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier otra excepción
                    MessageBox.Show($"Error {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerService.WriteException(ex);
                }
            }
            else
            {
                string messageKey = "Por favor, seleccione una cita.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CargarCitas()
        {
            if (sfComboBoxPaciente.SelectedValue != null)
            {
                // Obtener el ID del paciente seleccionado
                Guid idPaciente = (Guid)sfComboBoxPaciente.SelectedValue;

                // Llamar al servicio para obtener las citas del paciente
                var citaService = new CitaService();
                List<CitaRegistroDto> citas = citaService.ObtenerCitasPorPaciente(idPaciente);

                // Mostrar las citas en el DataGridView
                MostrarCitas(citas ,mostrarMensajeSinCitas: false);
            }
        }
        private void MostrarCitas(List<CitaRegistroDto> citas, bool mostrarMensajeSinCitas = true)
        {

            sfDataGridCitas.DataSource = null;

            // Si hay datos, los asignamos al DataSource del DataGridView
            if (citas.Any())
            {
                sfDataGridCitas.DataSource = citas;
            }
            else if (mostrarMensajeSinCitas)
            {
                string messageKey = "No se encontraron citas para este paciente.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
            }
        }

        private void sfComboBoxPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sfDataGridCitas.SelectedItems.Count > 0)
            {
                try
                {
                    // Obtener el item seleccionado
                    var selectedCita = sfDataGridCitas.SelectedItem as CitaRegistroDto;
                    Guid idCita = selectedCita.IdCita; // Asegúrate de que `IdCita` está en tu DTO
                    _citaDetalleService.CancelarCita(idCita);
                    string messageKey = "La cancelacion de la cita fue exitosa";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);

                    LoggerService.WriteLog($"Se cancelo la cita con id: {selectedCita.IdCita} Por el usuario: {SesionService.UsuarioLogueado.UserName}  ", System.Diagnostics.TraceLevel.Info);



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error");
                    LoggerService.WriteException(ex);
                }


            }
            else
            {
                string messageKey = "Por favor, seleccione una cita.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void RegistroCitaForm_Load(object sender, EventArgs e)
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
            // Asegúrate de que los encabezados se establezcan en este método
            sfDataGridCitas.Columns[0].HeaderText = TranslateMessageKey("IdCita");
            sfDataGridCitas.Columns[1].HeaderText = TranslateMessageKey("Fecha");
            sfDataGridCitas.Columns[2].HeaderText = TranslateMessageKey("Nombre Profesional");
            sfDataGridCitas.Columns[3].HeaderText = TranslateMessageKey("Nombre Tratamiento");
            sfDataGridCitas.Columns[4].HeaderText = TranslateMessageKey("Nombre Etapa");
        }
    

        private void RegistroCitaForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaRegistroCita();
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
