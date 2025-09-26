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

namespace UI.Forms.CitaForms
{
    public partial class ListarCitasForm : Form
    {
        private readonly CitaService _citaService;
        public ListarCitasForm()
        {
            _citaService = new CitaService();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyDown += ListarCitasForm_KeyDown;
        }

        private void ListarCitasForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
            UpdateColumnHeaders();


        }
        
        private void ListarCitas(DateTime fechaSeleccionada)
        {
            try
            {
               
                var citas = _citaService.ObtenerCitasByFechaSeleccionada(fechaSeleccionada);

                // Verificar si se encontraron citas
                if (citas == null || citas.Count == 0)
                {
                    string messageKey = "No se encontraron citas para la fecha seleccionada";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                 
                }
                else
                {
                    // Limpiar el DataGrid y cargar las nuevas citas
                    sfDataGrid1.DataSource = citas;
                }
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
        private void UpdateColumnHeaders()
        {
            // Asegúrate de que los encabezados se establezcan en este método
            sfDataGrid1.Columns[0].HeaderText = TranslateMessageKey("Fecha");
            sfDataGrid1.Columns[1].HeaderText = TranslateMessageKey("Hora Inicio");
            sfDataGrid1.Columns[2].HeaderText = TranslateMessageKey("Nombre Paciente");
            sfDataGrid1.Columns[3].HeaderText = TranslateMessageKey("Nombre Profesional");
            sfDataGrid1.Columns[4].HeaderText = TranslateMessageKey("Nombre Tratamiento");
            sfDataGrid1.Columns[5].HeaderText = TranslateMessageKey("Nombre Etapa");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            ListarCitas(fechaSeleccionada);
        }
        private void ListarCitasForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaListarCitas();
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
