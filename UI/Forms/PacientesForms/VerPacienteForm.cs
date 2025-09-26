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
    public partial class VerPacienteForm : Form
    {
        private readonly PacienteService _pacienteService;
        public VerPacienteForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            //(var repository = PacienteRepositoryFactory.CrearRepositorio("SQL", connectionString);
            //_pacienteService = new PacienteService(repository);
            _pacienteService = new PacienteService();
            LoadData();
            this.KeyPreview = true;
            this.KeyDown += VerPacienteForm_KeyDown;

        }
        private void LoadData()
        {
            try
            {
                // Obtener la lista de pacientes desde el servicio
                List<Paciente> pacientes = _pacienteService.ObtenerTodosPacientes();

                // Asignar la lista de pacientes al DataSource del SfDataGrid
                sfDataGridPacientes.DataSource = pacientes;
                LoggerService.WriteLog($"Se listaron todos los paciente", System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                string messageKey = "Error al cargar los datos:";
                string translatedMessage = TranslateMessageKey(messageKey);
                // Manejar cualquier error que ocurra durante la carga de datos
                MessageBox.Show(translatedMessage + ex.Message);
                LoggerService.WriteLog($"Error al listar pacientes: {ex.Message} ", System.Diagnostics.TraceLevel.Info);
            }
        }

        private void VerPacienteForm_Load(object sender, EventArgs e)
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
            sfDataGridPacientes.Columns[0].HeaderText = TranslateMessageKey("Nombre");
            sfDataGridPacientes.Columns[1].HeaderText = TranslateMessageKey("Apellido");
            sfDataGridPacientes.Columns[2].HeaderText = TranslateMessageKey("Direccion");
            sfDataGridPacientes.Columns[3].HeaderText = TranslateMessageKey("Mail");
            sfDataGridPacientes.Columns[4].HeaderText = TranslateMessageKey("Telefono");
            sfDataGridPacientes.Columns[5].HeaderText = TranslateMessageKey("Activo");
        }

        private void VerPacienteForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaVerPaciente();
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
