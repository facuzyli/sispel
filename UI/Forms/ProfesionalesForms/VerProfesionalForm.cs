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
    public partial class VerProfesionalForm : Form
    {
        private readonly ProfesionalService _profesionalService;
        public VerProfesionalForm()
        {
            InitializeComponent();

            _profesionalService = new ProfesionalService();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cargar los profesionales en el SfComboBox
            CargarProfesionalesEnComboBox();
            this.KeyPreview = true;
            this.KeyDown += VerProfesionalForm_KeyDown;
        }
        private void CargarProfesionalesEnComboBox()
        {
            var profesionales = _profesionalService.ObtenerTodosProfesionales();
            // Filtrar solo profesionales activos para mostrar
            profesionales = profesionales.Where(p => p.Activo).ToList();

            // Cargar en el SfComboBox
            sfComboBoxProfesionales.DataSource = profesionales;
            sfComboBoxProfesionales.DisplayMember = "NombreCompleto"; // Mostrar Nombre y Apellido
            sfComboBoxProfesionales.ValueMember = "Id_Profesional"; // Usar el Id como valor interno
        }

        private void sfComboBoxProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sfComboBoxProfesionales.SelectedItem != null)
            {
                var idProfesional = (Guid)sfComboBoxProfesionales.SelectedValue;

              


                try
                {
                    // Obtener la lista de pacientes desde el servicio
                    var profesionalSeleccionado = _profesionalService.ObtenerProfesionalPorId(idProfesional);

                    if (profesionalSeleccionado != null)
                    {
                        // Mostrar el profesional seleccionado en el SfDataGrid
                        sfDataGridProfesionales.DataSource = new List<Profesional> { profesionalSeleccionado };
                    }
                    // Asignar la lista de pacientes al DataSource del SfDataGrid

                    LoggerService.WriteLog($"Se listo el profesional {profesionalSeleccionado.Nombre}  {profesionalSeleccionado.Apellido}", System.Diagnostics.TraceLevel.Info);
                }
                catch (Exception ex)
                {
                    string messageKey = "Error al cargar los datos:";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage + ex.Message);
                    // Manejar cualquier error que ocurra durante la carga de datos
               
                    LoggerService.WriteLog($"Error al listar profesional: {ex.Message} ", System.Diagnostics.TraceLevel.Info);
                }
                
            }
        }

            
        

        private void VerProfesionalForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
            UpdateColumnHeaders();
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        private void buttonActualizar_Click(object sender, EventArgs e)
        {

        }

        private void UpdateColumnHeaders()
        {
            // Asegúrate de que los encabezados se establezcan en este método
            sfDataGridProfesionales.Columns[0].HeaderText = TranslateMessageKey("Nombre");
            sfDataGridProfesionales.Columns[1].HeaderText = TranslateMessageKey("Apellido");
            sfDataGridProfesionales.Columns[2].HeaderText = TranslateMessageKey("Direccion");
            sfDataGridProfesionales.Columns[3].HeaderText = TranslateMessageKey("Mail");
            sfDataGridProfesionales.Columns[4].HeaderText = TranslateMessageKey("Telefono");
            sfDataGridProfesionales.Columns[5].HeaderText = TranslateMessageKey("Especializacion");
        }
        private void VerProfesionalForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaVerProfesional();
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
