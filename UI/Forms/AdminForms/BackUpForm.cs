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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace UI.Forms.AdminForms
{
    public partial class BackUpForm : Form
    {
        public BackUpForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += BackUpForm_FormClosed;
            this.KeyPreview = true;
            this.KeyDown += BackUpForm_KeyDown;
        }
        private void BackUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Registrar el cierre del formulario
            LoggerService.WriteLog($"Formulario '{this.Text}' cerrado.", System.Diagnostics.TraceLevel.Info);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar el FolderBrowserDialog para seleccionar la carpeta de destino
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                   
                    folderDialog.Description = $"{TranslateMessageKey("Seleccione la carpeta donde guardar los respaldos")}";

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = folderDialog.SelectedPath;
                        // Ejecutar el backup a través del servicio, pasando la ruta seleccionada
                        BackupService.ExecuteBackup(selectedPath);
                        LoggerService.WriteLog($"Respaldo ejecutado exitosamente. Por : {SesionService.UsuarioLogueado.UserName} ", System.Diagnostics.TraceLevel.Info);
                        string messageKey = "El respaldo se ha completado con éxito.";
                        string translatedMessage = TranslateMessageKey(messageKey);
                        MessageBox.Show(translatedMessage, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar y registrar errores durante el proceso de backup
                LoggerService.WriteLog($"Error al ejecutar el respaldo: {ex.Message}", System.Diagnostics.TraceLevel.Error);
             

                string messageKey = "Ocurrió un error al ejecutar el respaldo:";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage + ex.Message);
                LoggerService.WriteException(ex);
            }
        }

        private void BackUpForm_Load(object sender, EventArgs e)
        {
            LoggerService.WriteLog($"Formulario '{this.Text}' abierto.", System.Diagnostics.TraceLevel.Info);
            IdiomaService.TranslateForm(this);
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
        
        private void BackUpForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaBackUp();
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
