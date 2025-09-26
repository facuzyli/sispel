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
    public partial class DeshProfesionalForm : Form
    {
        private readonly ProfesionalService _profesionalService;
        public DeshProfesionalForm()
        {
            InitializeComponent();
            _profesionalService = new ProfesionalService();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cargar los profesionales en el ComboBox
            CargarProfesionalesEnComboBox();
            this.KeyPreview = true;
            this.KeyDown += DeshProfesionalForm_KeyDown;
        }
        private void CargarProfesionalesEnComboBox()
        {
            var profesionales = _profesionalService.ObtenerTodosProfesionales();
            // Filtrar solo profesionales activos para mostrar
            profesionales = profesionales.Where(p => p.Activo).ToList();

            // Cargar en el SfComboBox
            sfComboBoxProfesional.DataSource = profesionales;
            sfComboBoxProfesional.DisplayMember = "NombreCompleto"; // Mostrar Nombre y Apellido
            sfComboBoxProfesional.ValueMember = "Id_Profesional";
        }
        private void buttonDeshabilitar_Click(object sender, EventArgs e)
        {
          if (sfComboBoxProfesional.SelectedItem != null)
                {
                    Guid idProfesional = (Guid)sfComboBoxProfesional.SelectedValue;
                    var profesionalSeleccionado = (Profesional)sfComboBoxProfesional.SelectedItem;

            

                try
                {
                    // Deshabilitar el profesional seleccionado
                    _profesionalService.DeshabilitarProfesional(idProfesional);
                    sfComboBoxProfesional.DataSource = null;
                    string messageKey = "Profesional deshabilitado correctamente.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                    LoggerService.WriteLog($"Se deshabilito el profesional con nombre :{profesionalSeleccionado.NombreCompleto}  Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                    CargarProfesionalesEnComboBox();
                }
                catch (ArgumentException ex)
                {
                    string messageKey = "Error al deshabilitar profesional";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage + ex.Message);
                    LoggerService.WriteLog($"Se genero un error al deshabilitar el profesional:{profesionalSeleccionado.NombreCompleto}  " + ex.Message, System.Diagnostics.TraceLevel.Info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error");
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

        private void DeshProfesionalForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        private void DeshProfesionalForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaDeshProfesional();
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
