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
    public partial class CambiarContraseñaForm : Form
    {
        private string _username;
        private string _token;
        public CambiarContraseñaForm(string username, string token)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _username = username;
            _token = token;
            this.KeyPreview = true;
            this.KeyDown += CambiarContraseñaForm_KeyDown;
        }


        private void CambiarContraseñaForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = textBox1.Text;
            string confirmPassword = textBox2.Text;

          
            try
            {
                // Llama a un método para cambiar la contraseña
                bool success = RecuperoPassService.ChangePassword(_username, newPassword, _token, confirmPassword);
                if (success)
                {
                    string messageKey = "La contraseña ha sido cambiada exitosamente.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                    this.Close(); // Cierra el formulario
                }
                else
                {
                    string messageKey = "No se pudo cambiar la contraseña. Intenta de nuevo.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }

        
        private void CambiarContraseñaForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaCambiarPass();
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
