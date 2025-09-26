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
    public partial class AgregarProfesionalForm : Form
    {
        private readonly ProfesionalService _profesionalService;
        public AgregarProfesionalForm()
        {
            InitializeComponent();
            _profesionalService = new ProfesionalService();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyDown += AgregarProfesionalForm_KeyDown;

        }

        private void buttonSaveProfessional_Click(object sender, EventArgs e)
        {
            Profesional profesional = new Profesional()
            {
                Nombre = textBoxName.Text,
                Apellido = textBoxLastName.Text,
                Direccion = textBoxAddress.Text,
                Mail = textBoxEmail.Text,
                Telefono = textBoxPhone.Text,
                Especializacion = textBoxSpecialization.Text,
                Activo = true
            };


            try
            {
                // Guardar el profesional
                _profesionalService.CrearProfesional(profesional);
                string messageKey = "Profesional creado correctamente.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                LoggerService.WriteLog($"Se creo el profesional con nombre {textBoxName.Text}  {textBoxLastName.Text}(mail {textBoxEmail.Text})  Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                textBoxName.Text = "";
                textBoxLastName.Text = "";
                textBoxAddress.Text = "";
                textBoxEmail.Text = "";
                textBoxPhone.Text = "";
                textBoxSpecialization.Text = "";
            }
            catch (ArgumentException ex)
            {
                string messageKey = "Error al crear profesional";
                string translatedMessage = TranslateMessageKey(messageKey);

                MessageBox.Show(translatedMessage + ex.Message);
                LoggerService.WriteLog($"Se genero un error al crear el profesional:{textBoxName.Text}  {textBoxLastName.Text} " + ex.Message, System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }
           
        }

        private void AgregarProfesionalForm_Load(object sender, EventArgs e)
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
        private void AgregarProfesionalForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaAltaProfesional();
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
