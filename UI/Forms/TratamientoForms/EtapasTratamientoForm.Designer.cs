using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
namespace UI.Forms
{
    partial class EtapasTratamientoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.labelEtapasTratamientosTitle = new System.Windows.Forms.Label();
            this.labelSearchTreatment = new System.Windows.Forms.Label();
            this.sfComboBoxTreatment = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfDataGridEtapas = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.labelNombreEtapa = new System.Windows.Forms.Label();
            this.textBoxNombreEtapa = new System.Windows.Forms.TextBox();
            this.labelDuracion = new System.Windows.Forms.Label();
            this.textBoxDuracion = new System.Windows.Forms.TextBox();
            this.buttonAddEtapa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxTreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridEtapas)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEtapasTratamientosTitle
            // 
            this.labelEtapasTratamientosTitle.AutoSize = true;
            this.labelEtapasTratamientosTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelEtapasTratamientosTitle.Location = new System.Drawing.Point(25, 20);
            this.labelEtapasTratamientosTitle.Name = "labelEtapasTratamientosTitle";
            this.labelEtapasTratamientosTitle.Size = new System.Drawing.Size(217, 25);
            this.labelEtapasTratamientosTitle.TabIndex = 0;
            this.labelEtapasTratamientosTitle.Tag = "EtapasDeTratamientos";
            this.labelEtapasTratamientosTitle.Text = "Etapas de Tratamientos";
            // 
            // labelSearchTreatment
            // 
            this.labelSearchTreatment.Location = new System.Drawing.Point(25, 60);
            this.labelSearchTreatment.Name = "labelSearchTreatment";
            this.labelSearchTreatment.Size = new System.Drawing.Size(150, 23);
            this.labelSearchTreatment.TabIndex = 1;
            this.labelSearchTreatment.Tag = "BuscarTratamiento";
            this.labelSearchTreatment.Text = "Buscar Tratamiento:";
            // 
            // sfComboBoxTreatment
            // 
            this.sfComboBoxTreatment.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxTreatment.Location = new System.Drawing.Point(180, 60);
            this.sfComboBoxTreatment.Name = "sfComboBoxTreatment";
            this.sfComboBoxTreatment.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxTreatment.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxTreatment.TabIndex = 2;
            this.sfComboBoxTreatment.TabStop = false;
            this.sfComboBoxTreatment.SelectedIndexChanged += new System.EventHandler(this.sfComboBoxTreatment_SelectedIndexChanged);
            // 
            // sfDataGridEtapas
            // 
            this.sfDataGridEtapas.AccessibleName = "Table";
            this.sfDataGridEtapas.AutoGenerateColumns = false;
            
            this.sfDataGridEtapas.AllowEditing = false;
            // Configurar las propiedades de las columnas
            gridTextColumn1.HeaderText = "Nombre Tratamiento";
            gridTextColumn1.MappingName = "NombreTratamiento";
            gridTextColumn1.Width = 150D;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn2.HeaderText = "Etapa";
            gridTextColumn2.MappingName = "Etapa";
            gridTextColumn2.Width = 150D;
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn3.HeaderText = "Duracion";
            gridTextColumn3.MappingName = "Duracion";
            gridTextColumn3.Width = 150D;
            gridTextColumn3.AllowFiltering = true;
            gridTextColumn4.HeaderText = "Duracion Total";
            gridTextColumn4.MappingName = "DuracionTotal";
            gridTextColumn4.Width = 150D;
            gridTextColumn4.AllowFiltering = true;
            this.sfDataGridEtapas.Columns.Add(gridTextColumn1);
            this.sfDataGridEtapas.Columns.Add(gridTextColumn2);
            this.sfDataGridEtapas.Columns.Add(gridTextColumn3);
            this.sfDataGridEtapas.Columns.Add(gridTextColumn4);
            this.sfDataGridEtapas.Location = new System.Drawing.Point(12, 97);
            this.sfDataGridEtapas.Name = "sfDataGridEtapas";
            this.sfDataGridEtapas.Size = new System.Drawing.Size(601, 206);
            this.sfDataGridEtapas.TabIndex = 3;
            this.sfDataGridEtapas.Click += new System.EventHandler(this.sfDataGridEtapas_Click);
            // 
            // labelNombreEtapa
            // 
            this.labelNombreEtapa.Location = new System.Drawing.Point(25, 370);
            this.labelNombreEtapa.Name = "labelNombreEtapa";
            this.labelNombreEtapa.Size = new System.Drawing.Size(100, 23);
            this.labelNombreEtapa.TabIndex = 4;
            this.labelNombreEtapa.Tag = "NombreEtapa";
            this.labelNombreEtapa.Text = "Nombre Etapa:";
            // 
            // textBoxNombreEtapa
            // 
            this.textBoxNombreEtapa.Location = new System.Drawing.Point(130, 370);
            this.textBoxNombreEtapa.Name = "textBoxNombreEtapa";
            this.textBoxNombreEtapa.Size = new System.Drawing.Size(200, 20);
            this.textBoxNombreEtapa.TabIndex = 5;
            // 
            // labelDuracion
            // 
            this.labelDuracion.Location = new System.Drawing.Point(25, 410);
            this.labelDuracion.Name = "labelDuracion";
            this.labelDuracion.Size = new System.Drawing.Size(100, 23);
            this.labelDuracion.TabIndex = 6;
            this.labelDuracion.Tag = "Duracion";
            this.labelDuracion.Text = "Duración:";
            // 
            // textBoxDuracion
            // 
            this.textBoxDuracion.Location = new System.Drawing.Point(130, 410);
            this.textBoxDuracion.Name = "textBoxDuracion";
            this.textBoxDuracion.Size = new System.Drawing.Size(100, 20);
            this.textBoxDuracion.TabIndex = 7;
            // 
            // buttonAddEtapa
            // 
            this.buttonAddEtapa.Location = new System.Drawing.Point(250, 440);
            this.buttonAddEtapa.Name = "buttonAddEtapa";
            this.buttonAddEtapa.Size = new System.Drawing.Size(120, 23);
            this.buttonAddEtapa.TabIndex = 8;
            this.buttonAddEtapa.Tag = "AgregarEtapa";
            this.buttonAddEtapa.Text = "Agregar Etapa";
            this.buttonAddEtapa.UseVisualStyleBackColor = true;
            this.buttonAddEtapa.Click += new System.EventHandler(this.buttonAddEtapa_Click);
            // 
            // EtapasTratamientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.labelEtapasTratamientosTitle);
            this.Controls.Add(this.labelSearchTreatment);
            this.Controls.Add(this.sfComboBoxTreatment);
            this.Controls.Add(this.sfDataGridEtapas);
            this.Controls.Add(this.labelNombreEtapa);
            this.Controls.Add(this.textBoxNombreEtapa);
            this.Controls.Add(this.labelDuracion);
            this.Controls.Add(this.textBoxDuracion);
            this.Controls.Add(this.buttonAddEtapa);
            this.Name = "EtapasTratamientoForm";
            this.Text = "Etapas de Tratamientos";
            this.Load += new System.EventHandler(this.EtapasTratamientoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxTreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridEtapas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelEtapasTratamientosTitle;
        private Label labelSearchTreatment;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxTreatment;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridEtapas;
        private Label labelNombreEtapa;
        private TextBox textBoxNombreEtapa;
        private Label labelDuracion;
        private TextBox textBoxDuracion;
        private Button buttonAddEtapa;
    }
}