using BLL;
using DOMAIN;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    public partial class AgregarPacienteForm : Form
    {

        private readonly PacienteService _pacienteService;
        public AgregarPacienteForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _pacienteService = new PacienteService();
            this.KeyPreview = true;
            this.KeyDown += AgregarPacienteForm_KeyDown;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddPatient_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente()
            {
                Nombre = textBoxName.Text,
                Apellido = textBoxLastName.Text,
                Direccion = textBoxAddress.Text,
                Mail = textBoxEmail.Text,
                Telefono = textBoxPhone.Text,
                Alergias = textBoxAllergies.Text,
                Medicamentos = textBoxMedications.Text,
                Activo = true
            };


            try
            {
                // Guardar el paciente
                _pacienteService.CrearPaciente(paciente);
                LoggerService.WriteLog($"Se creo un paciente con nombre {textBoxName.Text}  {textBoxLastName.Text}(mail {textBoxEmail.Text})  Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                string messageKey = "Paciente creado correctamente.";
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
                string messageKey = "Error al crear paciente";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage  + ex.Message);
                LoggerService.WriteLog($"Se genero un error al crear el paciente:{textBoxName.Text}  {textBoxLastName.Text} " + ex.Message, System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }

        }

        private void AgregarPacienteForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }

        private void AgregarPacienteForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    
                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaAltaPaciente();
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
