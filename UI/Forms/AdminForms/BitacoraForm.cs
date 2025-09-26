using Service.DOMAIN;
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
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

using System.Globalization;

namespace UI.Forms.AdminForms
{
    public partial class BitacoraForm : Form
    {
        public BitacoraForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyDown += BitacoraForm_KeyDown;
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void UpdateColumnHeaders()
        {
            // Asegúrate de que los encabezados se establezcan en este método
            sfDataGrid1.Columns[0].HeaderText = TranslateMessageKey("Id_Log");
            sfDataGrid1.Columns[1].HeaderText = TranslateMessageKey("Fecha");
            sfDataGrid1.Columns[2].HeaderText = TranslateMessageKey("TraceLevel");
            sfDataGrid1.Columns[3].HeaderText = TranslateMessageKey("Mensage");
            sfDataGrid1.Columns[4].HeaderText = TranslateMessageKey("StackTrace");


        }

        private void LoadBitacoraData()
        {
            List<Bitacora> bitacoras = BitacoraService.GetAllBitacora();
            sfDataGrid1.DataSource = bitacoras; // Asigna la lista de bitácoras como DataSource


        }
        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            try
            {
                IdiomaService.TranslateForm(this);
                UpdateColumnHeaders();
                LoadBitacoraData();
            }
            catch (Exception ex)
            {
                string messageKey = "Ocurrió un error al inicar la bitacora.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage + ex.Message);
            }



        }
        public string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }

        private void buttonCopiar_Click(object sender, EventArgs e)
        {
            if (sfDataGrid1.SelectedItems.Count > 0)
            {
                var selectedItem = sfDataGrid1.SelectedItems[0]; // Obtener el primer elemento seleccionado
                var valores = new List<string>();

                // Recorrer las columnas para obtener los valores
                foreach (var column in sfDataGrid1.Columns)
                {
                    var propertyName = column.MappingName;
                    var propertyValue = selectedItem.GetType().GetProperty(propertyName)?.GetValue(selectedItem);
                    valores.Add(propertyValue?.ToString() ?? "");
                }

                // Copiar los valores al portapapeles
                Clipboard.SetText(string.Join("\t", valores));
                MessageBox.Show(TranslateMessageKey("Datos copiados al portapapeles."));
            }
            else
            {
                MessageBox.Show(TranslateMessageKey("No hay elementos seleccionados."));
            }
        }

        private void BitacoraForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaBitacora();
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

    

