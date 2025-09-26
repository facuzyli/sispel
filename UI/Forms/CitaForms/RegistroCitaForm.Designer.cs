using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
namespace UI.Forms
{
    partial class RegistroCitaForm
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.labelSearchPaciente = new System.Windows.Forms.Label();
            this.sfComboBoxPaciente = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfDataGridCitas = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.labelObservaciones = new System.Windows.Forms.Label();
            this.textBoxObservaciones = new System.Windows.Forms.TextBox();
            this.labelRecomendacion = new System.Windows.Forms.Label();
            this.textBoxRecomendacion = new System.Windows.Forms.TextBox();
            this.buttonCrearRegistro = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSearchPaciente
            // 
            this.labelSearchPaciente.AutoSize = true;
            this.labelSearchPaciente.Location = new System.Drawing.Point(25, 20);
            this.labelSearchPaciente.Name = "labelSearchPaciente";
            this.labelSearchPaciente.Size = new System.Drawing.Size(88, 13);
            this.labelSearchPaciente.TabIndex = 0;
            this.labelSearchPaciente.Tag = "BuscarPaciente";
            this.labelSearchPaciente.Text = "Buscar Paciente:";
            // 
            // sfComboBoxPaciente
            // 
            this.sfComboBoxPaciente.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxPaciente.Location = new System.Drawing.Point(155, 20);
            this.sfComboBoxPaciente.Name = "sfComboBoxPaciente";
            this.sfComboBoxPaciente.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxPaciente.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxPaciente.TabIndex = 1;
            this.sfComboBoxPaciente.TabStop = false;
            this.sfComboBoxPaciente.SelectedIndexChanged += new System.EventHandler(this.sfComboBoxPaciente_SelectedIndexChanged);
            // 
            // sfDataGridCitas
            // 
            this.sfDataGridCitas.AccessibleName = "Table";
            this.sfDataGridCitas.AutoGenerateColumns = false;


            this.sfDataGridCitas.AllowEditing = false;


            gridTextColumn1.HeaderText = "IdCita";
            gridTextColumn1.MappingName = "IdCita";
            gridTextColumn1.Width = 150D;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.Visible = false;

            gridTextColumn2.HeaderText = "Fecha";
            gridTextColumn2.MappingName = "Fecha";
            gridTextColumn2.Width = 150D;
            gridTextColumn2.AllowFiltering = true;

            gridTextColumn3.HeaderText = "Nombre Profesional";
            gridTextColumn3.MappingName = "NombreProfesional";
            gridTextColumn3.Width = 150D;
            gridTextColumn3.AllowFiltering = true;

            gridTextColumn4.HeaderText = "Nombre Tratamiento";
            gridTextColumn4.MappingName = "NombreTratamiento";
            gridTextColumn4.Width = 150D;
            gridTextColumn4.AllowFiltering = true;

            gridTextColumn5.HeaderText = "Nombre Etapa";
            gridTextColumn5.MappingName = "NombreEtapa";
            gridTextColumn5.Width = 150D;
            gridTextColumn5.AllowFiltering = true;

            this.sfDataGridCitas.Columns.Add(gridTextColumn1);
            this.sfDataGridCitas.Columns.Add(gridTextColumn2);
            this.sfDataGridCitas.Columns.Add(gridTextColumn3);
            this.sfDataGridCitas.Columns.Add(gridTextColumn4);
            this.sfDataGridCitas.Columns.Add(gridTextColumn5);
            this.sfDataGridCitas.Location = new System.Drawing.Point(20, 60);
            this.sfDataGridCitas.Name = "sfDataGridCitas";
            this.sfDataGridCitas.Size = new System.Drawing.Size(600, 250);
            this.sfDataGridCitas.TabIndex = 2;
            // 
            // labelObservaciones
            // 
            this.labelObservaciones.AutoSize = true;
            this.labelObservaciones.Location = new System.Drawing.Point(25, 330);
            this.labelObservaciones.Name = "labelObservaciones";
            this.labelObservaciones.Size = new System.Drawing.Size(81, 13);
            this.labelObservaciones.TabIndex = 3;
            this.labelObservaciones.Tag = "Observaciones";
            this.labelObservaciones.Text = "Observaciones:";
            // 
            // textBoxObservaciones
            // 
            this.textBoxObservaciones.Location = new System.Drawing.Point(155, 330);
            this.textBoxObservaciones.Multiline = true;
            this.textBoxObservaciones.Name = "textBoxObservaciones";
            this.textBoxObservaciones.Size = new System.Drawing.Size(450, 60);
            this.textBoxObservaciones.TabIndex = 4;
            // 
            // labelRecomendacion
            // 
            this.labelRecomendacion.AutoSize = true;
            this.labelRecomendacion.Location = new System.Drawing.Point(25, 400);
            this.labelRecomendacion.Name = "labelRecomendacion";
            this.labelRecomendacion.Size = new System.Drawing.Size(88, 13);
            this.labelRecomendacion.TabIndex = 5;
            this.labelRecomendacion.Tag = "Recomendacion";
            this.labelRecomendacion.Text = "Recomendación:";
            // 
            // textBoxRecomendacion
            // 
            this.textBoxRecomendacion.Location = new System.Drawing.Point(155, 400);
            this.textBoxRecomendacion.Multiline = true;
            this.textBoxRecomendacion.Name = "textBoxRecomendacion";
            this.textBoxRecomendacion.Size = new System.Drawing.Size(450, 60);
            this.textBoxRecomendacion.TabIndex = 6;
            // 
            // buttonCrearRegistro
            // 
            this.buttonCrearRegistro.Location = new System.Drawing.Point(485, 470);
            this.buttonCrearRegistro.Name = "buttonCrearRegistro";
            this.buttonCrearRegistro.Size = new System.Drawing.Size(120, 23);
            this.buttonCrearRegistro.TabIndex = 7;
            this.buttonCrearRegistro.Tag = "CrearRegistro";
            this.buttonCrearRegistro.Text = "Crear Registro";
            this.buttonCrearRegistro.UseVisualStyleBackColor = true;
            this.buttonCrearRegistro.Click += new System.EventHandler(this.buttonCrearRegistro_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 8;
            this.button1.Tag = "CancelarCita";
            this.button1.Text = "Cancelar Cita";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistroCitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 510);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCrearRegistro);
            this.Controls.Add(this.textBoxRecomendacion);
            this.Controls.Add(this.labelRecomendacion);
            this.Controls.Add(this.textBoxObservaciones);
            this.Controls.Add(this.labelObservaciones);
            this.Controls.Add(this.sfDataGridCitas);
            this.Controls.Add(this.sfComboBoxPaciente);
            this.Controls.Add(this.labelSearchPaciente);
            this.Name = "RegistroCitaForm";
            this.Text = "Registro de Cita";
            this.Load += new System.EventHandler(this.RegistroCitaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelSearchPaciente;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxPaciente;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridCitas;
        private Label labelObservaciones;
        private TextBox textBoxObservaciones;
        private Label labelRecomendacion;
        private TextBox textBoxRecomendacion;
        private Button buttonCrearRegistro;
        private Button button1;
    }
}