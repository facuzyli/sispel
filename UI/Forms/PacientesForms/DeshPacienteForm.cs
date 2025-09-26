using BLL;
using DOMAIN;
using Service.DOMAIN;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class DeshPacienteForm : Form
    {
        private readonly PacienteService _pacienteService;
        public DeshPacienteForm()
        {
            InitializeComponent();
            //string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            //var repository = PacienteRepositoryFactory.CrearRepositorio("SQL", connectionString);
            //_pacienteService = new PacienteService(repository);
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cargar los pacientes en el ComboBox
            _pacienteService = new PacienteService();
            CargarPacientesEnComboBox();
            this.KeyPreview = true;
            this.KeyDown += DeshPacienteForm_KeyDown;
        }
        private void CargarPacientesEnComboBox()
        {
            var pacientes = _pacienteService.ObtenerTodosPacientes();
            // Filtrar solo pacientes activos para mostrar
            pacientes = pacientes.Where(p => p.Activo).ToList();

            // Cargar en el SfComboBox
            sfComboBoxPaciente.DataSource = pacientes;
            sfComboBoxPaciente.DisplayMember = "NombreCompleto"; // Mostrar Nombre y Apellido
            sfComboBoxPaciente.ValueMember = "Id_Paciente"; // Usar el Id como valor interno
        }
        private void buttonDeshabilitar_Click(object sender, EventArgs e)
        {
            if (sfComboBoxPaciente.SelectedItem != null)
            {
                Guid idPaciente = (Guid)sfComboBoxPaciente.SelectedValue;
                var pacienteSeleccionado = (Paciente)sfComboBoxPaciente.SelectedItem;
                // Deshabilitar el paciente seleccionado
                try
                {
                    _pacienteService.DeshabilitarPaciente(idPaciente);
                    sfComboBoxPaciente.DataSource = null;
                    string messageKey = "Paciente deshabilitado correctamente.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                    LoggerService.WriteLog($"Se deshabilito exitosamente el paciente:{pacienteSeleccionado.NombreCompleto} Por el usuario: {SesionService.UsuarioLogueado.UserName}" , System.Diagnostics.TraceLevel.Info);
                    CargarPacientesEnComboBox(); // Recargar la lista para mostrar solo activos
                }
                catch (ArgumentException ex)
                {
                    string messageKey = "Error al deshabilitar paciente";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage + ex.Message);
                    LoggerService.WriteLog($"Se geneto un error al intetar deshabilitar el paciente:{pacienteSeleccionado.NombreCompleto} " + ex.Message, System.Diagnostics.TraceLevel.Info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error");
                    LoggerService.WriteException(ex);
                }
                
            }
            else
            {
                string messageKey = "Por favor, seleccione un paciente.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
            }
        }

        private void DeshPacienteForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        private void DeshPacienteForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaDeshPaciente();
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
