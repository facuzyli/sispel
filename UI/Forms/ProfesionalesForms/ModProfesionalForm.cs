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

namespace UI.Forms
{
    public partial class ModProfesionalForm : Form
    {
        private readonly ProfesionalService _profesionalService;
        private Profesional _profesionalSeleccionado;
        public ModProfesionalForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _profesionalService = new ProfesionalService();
            // Cargar los profesionales en el ComboBox
            CargarProfesionales();
            this.KeyPreview = true;
            this.KeyDown += ModProfesionalForm_KeyDown;
        }
        private void CargarProfesionales()
        {
            var profesionales = _profesionalService.ObtenerTodosProfesionales();
            comboBoxProfesionals.DataSource = profesionales.Where(p => p.Activo).ToList(); // Solo profesionales activos
            comboBoxProfesionals.DisplayMember = "NombreCompleto"; // Concatenar Nombre y Apellido
            comboBoxProfesionals.ValueMember = "Id_Profesional";
        }
        private void buttonModProfessional_Click(object sender, EventArgs e)
        {
            if (_profesionalSeleccionado != null)
            {
                // Actualizar los datos del profesional con la información del formulario
                _profesionalSeleccionado.Nombre = textBoxName.Text;
                _profesionalSeleccionado.Apellido = textBoxLastName.Text;
                _profesionalSeleccionado.Direccion = textBoxAddress.Text;
                _profesionalSeleccionado.Mail = textBoxEmail.Text;
                _profesionalSeleccionado.Telefono = textBoxPhone.Text;
                _profesionalSeleccionado.Especializacion = textBoxSpecialization.Text;

                
             


                try
                {
                    // Llamar al servicio para actualizar el profesional
                    _profesionalService.ModificarProfesional(_profesionalSeleccionado);
                    string messageKey = "Profesional modificado correctamente.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                    LoggerService.WriteLog($"Se modifico el profesional con nombre {textBoxName.Text}  {textBoxLastName.Text} Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                    textBoxName.Text = "";
                    textBoxLastName.Text = "";
                    textBoxAddress.Text = "";
                    textBoxEmail.Text = "";
                    textBoxPhone.Text = "";
                    textBoxSpecialization.Text = "";
                }
                catch (ArgumentException ex)
                {
                    string messageKey = "Error al modificar profesional";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage + ex.Message);
                    LoggerService.WriteLog($"Se genero un error al modificar el profesional:{textBoxName.Text}  {textBoxLastName.Text} " + ex.Message, System.Diagnostics.TraceLevel.Info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message, "Error");
                    LoggerService.WriteException(ex);
                }
            }
            else
            {

                string messageKey = "Por favor, seleccione un profesional.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
            }
        }
      

        private void comboBoxProfesionals_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _profesionalSeleccionado = (Profesional)comboBoxProfesionals.SelectedItem;
            if (_profesionalSeleccionado != null)
            {
                // Mostrar los datos del profesional en los campos de texto
                textBoxName.Text = _profesionalSeleccionado.Nombre;
                textBoxLastName.Text = _profesionalSeleccionado.Apellido;
                textBoxAddress.Text = _profesionalSeleccionado.Direccion;
                textBoxEmail.Text = _profesionalSeleccionado.Mail;
                textBoxPhone.Text = _profesionalSeleccionado.Telefono;
                textBoxSpecialization.Text = _profesionalSeleccionado.Especializacion;

            }
        }

        private void ModProfesionalForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ModProfesionalForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaModProfesional();
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
