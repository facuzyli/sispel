using Service.DAL.Contracts;
using Service.DOMAIN;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class LoginForm : Form , IIdiomaObserver // Implemento la interface del observer
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormClosed += LoginForm_FormClosed;
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Prevenir el sonido de error del sistema cuando se presiona Enter
                e.Handled = true;
                buttonLogin_Click(sender, e); // Llamar al método de clic del botón
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxUser.Text.Trim();
                string password = textBoxPassword.Text;

                // Validar que el nombre de usuario y la contraseña no estén vacíos
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    string messageKey = "Por favor, ingrese su nombre de usuario y contraseña";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage,"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // Intentar iniciar sesión
                if (UserService.Login(username, password))
                {
                    Usuario user = UserService.GetUsuarioByUsername(username);
                    SesionService.UsuarioLogueado = user;

                    // Ocultar el formulario de login
                    this.Hide();

                    // Crear y mostrar el formulario principal
                    MainForm mainForm = new MainForm();
                    mainForm.Show();

                    // Suscribirse al evento FormClosed para cerrar el formulario de login después
                    mainForm.FormClosed += (s, args) => this.Close();
                    LoggerService.WriteLog($"Inicio de sesión exitoso para el usuario: {username}.", System.Diagnostics.TraceLevel.Info);


                }
                else
                {
                    string messageKey = "Inicio de sesión fallido. Verifique su nombre de usuario y contraseña.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);     
                    LoggerService.WriteLog($"Inicio de sesión fallido para el usuario: {username}.", System.Diagnostics.TraceLevel.Warning);

                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones generales
             
                LoggerService.WriteLog($"Error al intentar iniciar sesión: {ex.Message}", System.Diagnostics.TraceLevel.Error);
                string messageKey = "Ocurrió un error al intentar iniciar sesión:";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoggerService.WriteException(ex);
            }
        }
      
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                InicializadorDeIdioma();
                // Suscribirse a los cambios de idioma
                IdiomaService.Subscribe(this);

                // Cargar el idioma guardado y aplicarlo
                string currentLanguage = IdiomaService.LoadUserLanguage();


                // Establecer la cultura del hilo principal al idioma guardado
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentLanguage);

                // Traducir los controles del formulario
                IdiomaService.TranslateForm(this);

                // Inicializar el ComboBox con las opciones de idioma
                
                LoggerService.WriteLog($"Formulario '{this.Text}' abierto.", System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }
        }
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            IdiomaService.Unsubscribe(this);
            // Registrar el cierre del formulario
            LoggerService.WriteLog($"Formulario '{this.Text}' cerrado.", System.Diagnostics.TraceLevel.Info);
        }

        public void UpdateIdioma()
        {
            // Actualizar la interfaz cuando cambie el idioma
            IdiomaService.TranslateForm(this);
            this.Refresh();
        }


        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        
        Dictionary<string, string> languageMap = new Dictionary<string, string>()
             {
              { "Español", "es-ES" },
              { "Inglés", "en-US" },
             { "Portugués", "pt-PT" }
             };

            string selectedItem = listBox1.SelectedItem.ToString();
            string selectedLanguage = languageMap.ContainsKey(selectedItem) ? languageMap[selectedItem] : "en-US"; // Predeterminado a Inglés si no se encuentra

            // Guardar el nuevo idioma seleccionado
            IdiomaService.SaveUserLanguage(selectedLanguage);

            // Cambiar la cultura del hilo principal al nuevo idioma
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

            // Traducir nuevamente los controles
            IdiomaService.TranslateForm(this);
            this.Refresh();
        }
        
        private void InicializadorDeIdioma()
        {
            listBox1.Items.AddRange(new string[] { "Español", "Inglés", "Portugués" });

            // Seleccionar el idioma actual
            string currentLanguage = IdiomaService.LoadUserLanguage();
            Dictionary<string, string> reverseLanguageMap = new Dictionary<string, string>()
            {
            { "es-ES", "Español" },
            { "en-US", "Inglés" },
            { "pt-PT", "Portugués" }
             };

            // Asignar el idioma seleccionado en la ListBox
            listBox1.SelectedItem = reverseLanguageMap.ContainsKey(currentLanguage) ? reverseLanguageMap[currentLanguage] : "Inglés"; // Predeterminado a Inglés
        }
         
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaLogin();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }

        }
        

        private void checkBoxShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                // Mostrar la contraseña como texto plano
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Ocultar la contraseña con caracteres de seguridad
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        
    }


}

