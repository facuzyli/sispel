using BLL;
using DOMAIN.DTO;
using Service.DAL.Contracts;
using Service.DOMAIN;
using Service.Facade;
using Service.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class MainForm : Form, IIdiomaObserver
    {
        private readonly CitaService _citaService;
        private readonly DVHService _dvhService;
        private readonly CitaDetalleService _citaDetalleService;

        public MainForm()
        {
            _citaDetalleService = new CitaDetalleService();
            _citaService = new CitaService();
            _dvhService = new DVHService();
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _citaDetalleService.VerificarDVHDeCitaDetalles();
                _dvhService.VerificarDVHDeUsuarios();
                InicializadorDeIdioma();
               

            // Obtener el usuario logueado desde el SesionService
            Usuario usuarioLogueado = SesionService.UsuarioLogueado;
            // Obtener los roles del usuario logueado
            string rolesUsuario = SesionService.ObtenerRolesUsuario();
            // Obtener las patentes del usuario logueado
            List<Patente> patentesDelUsuario = usuarioLogueado.GetPatentes();
            // Obtener las familias para mostrar en el label de perfil
            List<Familia> familiasDelUsuario = usuarioLogueado.GetFamilias();
            // Aplicar los accesos solo a los menús
            AccesoService.ConfigureMenuItems(administradorToolStripMenuItem, patentesDelUsuario);

            label2.Text = $": {usuarioLogueado.UserName}";
            label4.Text = $": {rolesUsuario}";
            // Suscribirse a los cambios de idioma
            IdiomaService.Subscribe(this);

            // Obtener el idioma guardado y aplicarlo
            string currentLanguage = IdiomaService.LoadUserLanguage();

            // Establecer la cultura del hilo principal al idioma guardado
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentLanguage);





            List<CitaMainFormDto> citas = _citaService.ObtenerCitasByFechaActual();
            sfDataGrid1.DataSource = citas;



            // Traducir los controles del formulario
            IdiomaService.TranslateForm(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }




        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                // Cierra el formulario principal
                LoggerService.WriteLog($"El usuario {SesionService.UsuarioLogueado.UserName} cerró sesión.", System.Diagnostics.TraceLevel.Info);
                // Desuscribirse cuando se cierra el formulario

                SesionService.ClearSession(); // Limpiar la sesión  

                Application.Restart();
            }
            catch (Exception ex)
            {
                string messageKey = "Ocurrió un error al cerrar sesión:";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage + ex.Message);
            
                // Manejar errores durante el proceso de cierre de sesión
          
                // Registrar el error
                LoggerService.WriteLog($"Error al cerrar sesión: {ex.Message}", System.Diagnostics.TraceLevel.Error);
            }


        }

        public void UpdateIdioma()
        {
            IdiomaService.TranslateForm(this);
            this.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Volver a obtener las citas de la fecha actual
            List<CitaMainFormDto> citas = _citaService.ObtenerCitasByFechaActual();

            // Asignar la lista de citas como el DataSource del DataGrid
            sfDataGrid1.DataSource = citas;

            // Refrescar el DataGrid para asegurarse de que se muestren los datos actualizados
            sfDataGrid1.Refresh();
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
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaMain();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuarioLogueado = SesionService.UsuarioLogueado;
            Dictionary<string, string> languageMap = new Dictionary<string, string>()
             {
              { "Español", "es-ES" },
              { "Inglés", "en-US" },
             { "Portugués", "pt-PT" }
             };

            string selectedItem = listBox1.SelectedItem.ToString();
            string selectedLanguage = languageMap.ContainsKey(selectedItem) ? languageMap[selectedItem] : "en-US"; // Predeterminado a Inglés si no se encuentra
            Guid userId = usuarioLogueado.IdUsuario;
            UserService.SaveLanguage(userId, selectedLanguage);
            // Guardar el nuevo idioma seleccionado
            IdiomaService.SaveUserLanguage(selectedLanguage);

            // Cambiar la cultura del hilo principal al nuevo idioma
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
            UpdateColumnHeaders();
            // Traducir nuevamente los controles
            IdiomaService.TranslateForm(this);
            this.Refresh();
        }
        private void InicializadorDeIdioma()
        {
            listBox1.Items.AddRange(new string[] { "Español", "Inglés", "Portugués" });
            
            // Seleccionar el idioma actual
            Usuario usuarioLogueado = SesionService.UsuarioLogueado;
          
            string currentLanguage = UserService.GetUserLanguage(usuarioLogueado.IdUsuario);
            //string currentLanguage = IdiomaService.LoadUserLanguage();
            Dictionary<string, string> reverseLanguageMap = new Dictionary<string, string>()
            {
            { "es-ES", "Español" },
            { "en-US", "Inglés" },
            { "pt-PT", "Portugués" }
             };

            // Asignar el idioma seleccionado en la ListBox
            listBox1.SelectedItem = reverseLanguageMap.ContainsKey(currentLanguage) ? reverseLanguageMap[currentLanguage] : "Inglés"; // Predeterminado a Inglés
        }
    }
}
