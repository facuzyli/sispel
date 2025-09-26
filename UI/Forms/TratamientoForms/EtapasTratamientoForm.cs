using BLL;
using DOMAIN;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class EtapasTratamientoForm : Form
    {
        private readonly TratamientoService _tratamientoService;

        public EtapasTratamientoForm()
        {
            InitializeComponent();
            _tratamientoService = new TratamientoService();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cargar los tratamientos en el ComboBox
            CargarTratamientos();
            this.KeyPreview = true;
            this.KeyDown += EtapasTratamientoForm_KeyDown;

        }

        private void CargarTratamientos()
        {
            var tratamientos = _tratamientoService.ObtenerTodosTratamientos();
            sfComboBoxTreatment.DataSource = tratamientos.ToList();
            sfComboBoxTreatment.DisplayMember = "Nombre";
            sfComboBoxTreatment.ValueMember = "Id";
        }

        private void buttonAddEtapa_Click(object sender, EventArgs e)
        {
            var tramientoSeleccionado = (Tratamiento)sfComboBoxTreatment.SelectedItem;
            if (sfComboBoxTreatment.SelectedItem != null)
            {
                try
                {// Crear una nueva etapa a partir de los valores de los TextBox
                    var etapa = new EtapaTratamiento()
                    {
                        NombreEtapa = textBoxNombreEtapa.Text,
                        
                    };

                    // Obtener el tratamiento seleccionado y agregar la etapa
                    var tratamientoId = (Guid)sfComboBoxTreatment.SelectedValue;
                    _tratamientoService.AgregarEtapaAlTratamiento(tratamientoId, etapa, textBoxDuracion.Text);




                    string messageKey = "Etapa agregada correctamente.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                    LoggerService.WriteLog($"La etapa {textBoxNombreEtapa.Text} se agrego correctamente al tratamiento {tramientoSeleccionado.Nombre}  Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);

                    CargarEtapas();

                    textBoxNombreEtapa.Text = "";
                    textBoxDuracion.Text = "";

                }
                catch (ArgumentException ex)
                {
                    string messageKey = "Error al agregar una etapa";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage + ex.Message);
                    LoggerService.WriteLog($"Se genero un error al intentar agregar la etapa {textBoxNombreEtapa.Text} al tratamiento {tramientoSeleccionado.Nombre}  " + ex.Message, System.Diagnostics.TraceLevel.Info);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error");
                    LoggerService.WriteException(ex);
                }

            }


            else
            {
                string messageKey = "Por favor, seleccione un tratamiento";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
            }

           
        }

        private void sfComboBoxTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEtapas();
        }


        private void CargarEtapas()
        {
            if (sfComboBoxTreatment.SelectedValue != null)
            {
                var tratamientoId = (Guid)sfComboBoxTreatment.SelectedValue;

                // Llamar al servicio para obtener los datos de tratamientos con etapas
                var tratamientoEtapas = _tratamientoService.ObtenerTratamientosConEtapas()
                    .Where(te => te.NombreTratamiento == sfComboBoxTreatment.Text).ToList();

                // Mostrar los datos en el DataGridView
                MostrarEtapas(tratamientoEtapas);
            }
            
        }
        private void MostrarEtapas(List<TratamientoEtapaDto> tratamientoEtapa)
            {
                
            sfDataGridEtapas.DataSource = null;
                // Si hay datos, los asignamos al DataSource del DataGridView
                if (tratamientoEtapa.Any())
                {
                    sfDataGridEtapas.DataSource = tratamientoEtapa;
                }
                else
                {
                string messageKey = "No se encontraron etapas para el tratamiento seleccionado.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                }
            }

        private void sfDataGridEtapas_Click(object sender, EventArgs e)
        {

        }

        private void EtapasTratamientoForm_Load(object sender, EventArgs e)
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
            sfDataGridEtapas.Columns[0].HeaderText = TranslateMessageKey("Nombre Tratamiento");
            sfDataGridEtapas.Columns[1].HeaderText = TranslateMessageKey("Etapa");
            sfDataGridEtapas.Columns[2].HeaderText = TranslateMessageKey("Duracion");
            sfDataGridEtapas.Columns[3].HeaderText = TranslateMessageKey("Duracion Total");
        }
        private void EtapasTratamientoForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaAltaEtapa();
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

 

    








