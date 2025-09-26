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
    public partial class ModPacienteForm : Form
    {
        private readonly PacienteService _pacienteService;
        private Paciente _pacienteSeleccionado;

        public ModPacienteForm()
        {
            InitializeComponent();
            //string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            //var repository = PacienteRepositoryFactory.CrearRepositorio("SQL", connectionString);
            //_pacienteService = new PacienteService(repository);
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cargar los pacientes en el ComboBox
            _pacienteService = new PacienteService();
            CargarPacientes();
            this.KeyPreview = true;
            this.KeyDown += ModPacienteForm_KeyDown;
        }
        private void CargarPacientes()
        {
            var pacientes = _pacienteService.ObtenerTodosPacientes();
            comboBoxPatients.DataSource = pacientes.Where(p => p.Activo).ToList(); // Solo pacientes activos
            comboBoxPatients.DisplayMember = "NombreCompleto"; // Concatenar Nombre y Apellido
            comboBoxPatients.ValueMember = "Id_Paciente";
        }
        private void buttonModPatient_Click(object sender, EventArgs e)
        {
            if (_pacienteSeleccionado != null)
            {
                // Actualizar los datos del paciente con la información del formulario
                _pacienteSeleccionado.Nombre = textBoxName.Text;
                _pacienteSeleccionado.Apellido = textBoxLastName.Text;
                _pacienteSeleccionado.Direccion = textBoxAddress.Text;
                _pacienteSeleccionado.Mail = textBoxEmail.Text;
                _pacienteSeleccionado.Telefono = textBoxPhone.Text;
                _pacienteSeleccionado.Alergias = textBoxAllergies.Text;
                _pacienteSeleccionado.Medicamentos = textBoxMedications.Text;

               
                try
                {
                    // Guardar el paciente
                    _pacienteService.ModificarPaciente(_pacienteSeleccionado);
                    LoggerService.WriteLog($"Se modifco el paciente {textBoxName.Text}  {textBoxLastName.Text} Por el usuario {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                    string messageKey = "Paciente modificado correctamente.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);

                    textBoxName.Text = "";
                    textBoxLastName.Text = "";
                    textBoxAddress.Text = "";
                    textBoxEmail.Text = "";
                    textBoxPhone.Text = "";
                    textBoxAllergies.Text = "";
                    textBoxMedications.Text = "";
                }
                catch (ArgumentException ex)
                {
                    string messageKey = "Error al Modificar paciente";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show( translatedMessage + ex.Message);
                    LoggerService.WriteLog($"Se geneto un error al intentar modificar el paciente:{textBoxName.Text}  {textBoxLastName.Text} " + ex.Message, System.Diagnostics.TraceLevel.Info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message, "Error");
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

        private void comboBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pacienteSeleccionado = (Paciente)comboBoxPatients.SelectedItem;
            if (_pacienteSeleccionado != null)
            {
                // Mostrar los datos del paciente en los campos de texto
                textBoxName.Text = _pacienteSeleccionado.Nombre;
                textBoxLastName.Text = _pacienteSeleccionado.Apellido;
                textBoxAddress.Text = _pacienteSeleccionado.Direccion;
                textBoxEmail.Text = _pacienteSeleccionado.Mail;
                textBoxAllergies.Text = _pacienteSeleccionado.Alergias;
                textBoxMedications.Text = _pacienteSeleccionado.Medicamentos;
                textBoxPhone.Text = _pacienteSeleccionado.Telefono;
            }
        }

        private void ModPacienteForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        private void ModPacienteForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaModPaciente();
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
