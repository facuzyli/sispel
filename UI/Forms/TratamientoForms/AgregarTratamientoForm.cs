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
    public partial class AgregarTratamientoForm : Form
    {
        private readonly TratamientoService _tratamientoService;
        public AgregarTratamientoForm()
        {
            InitializeComponent();
            _tratamientoService = new TratamientoService();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyDown += AgregarTratamientoForm_KeyDown;

        }

        private void buttonSaveTreatment_Click(object sender, EventArgs e)
        {
            var tratamiento = new Tratamiento
            {
                Id = Guid.NewGuid(),
                Nombre = textBoxName.Text,
                Descripcion = textBoxDescription.Text
            };


            try
            {
                // Guardar el paciente
                _tratamientoService.AgregarTratamiento(tratamiento , textBoxDuration.Text);
                LoggerService.WriteLog($"Se creo un tratamiento con el nombre {textBoxName.Text}  Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                string messageKey = "Tratamiento agregado correctamente.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                textBoxName.Text = "";
                textBoxDescription.Text = "";
                textBoxDuration.Text = "";
            }
            catch (ArgumentException ex)
            {
                string messageKey = "Error al crear el tratamiento";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage + ex.Message);
                LoggerService.WriteLog($"Se genero un error al crear el tratamiento:{textBoxName.Text} " + ex.Message, System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }

            
         
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }

        private void AgregarTratamientoForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }
        private void AgregarTratamientoForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaAltaTratamiento();
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
