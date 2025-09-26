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

namespace UI.Forms.LoginForms
{
    public partial class RecuperoPasswordForm : Form
    {
        public RecuperoPasswordForm()
        {
            InitializeComponent();
            string nombreUsuario = textBoxUser.Text;
            this.KeyPreview = true;
            this.KeyDown += RecuperoPasswordForm_KeyDown;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

       

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxUser.Text;
           
            try
            {
                var usuario = RecuperoPassService.GetUsuario(nombreUsuario);

                string emailSensurado = usuario.Email.Substring(0, 2) + "****" + usuario.Email.Substring(usuario.Email.IndexOf('@'));
              
                RecuperoPassService.GenerarYEnviarMailRecuperacion(nombreUsuario);
                string messageKey = "Se ha enviado un correo con el token de recuperación.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);


                string messageKey1 = "Se ha enviado el token de recuperación de contraseña al mail";
                string translatedMessage1 = TranslateMessageKey(messageKey1);
                label1.Visible = true;
                label1.Text = translatedMessage1 + $"\n{emailSensurado}";
                label1.ForeColor = Color.Green; // Cambia el color del texto a verde
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // Mostrar mensaje de error
            }
        }

        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }

        private void RecuperoPasswordForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxUser.Text;
            string tokenIngresado = textBox1.Text;

            try
            {
                bool isValid = RecuperoPassService.ValidateRecoveryToken(nombreUsuario, tokenIngresado);
                if (isValid)
                {
                    string messageKey = "El token es válido.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                    // Aquí puedes agregar la lógica para permitir que el usuario restablezca su contraseña
                    CambiarContraseñaForm cambiarContraseñaForm = new CambiarContraseñaForm(nombreUsuario, tokenIngresado);
                    cambiarContraseñaForm.Show();
                }
                else
                {
                    string messageKey = "El token no es válido o ha expirado.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // Mostrar mensaje de error
            }

        }
        private void RecuperoPasswordForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaRecuperoPass();
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
