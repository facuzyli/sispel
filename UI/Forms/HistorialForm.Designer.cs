using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DOMAIN;
using Syncfusion.WinForms.DataGrid;
namespace UI.Forms
{
    partial class HistorialForm
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.labelHistorialTitle = new System.Windows.Forms.Label();
            this.labelSearchPatient = new System.Windows.Forms.Label();
            this.sfComboBoxPatient = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfDataGridHistorial = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHistorialTitle
            // 
            this.labelHistorialTitle.AutoSize = true;
            this.labelHistorialTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelHistorialTitle.Location = new System.Drawing.Point(25, 20);
            this.labelHistorialTitle.Name = "labelHistorialTitle";
            this.labelHistorialTitle.Size = new System.Drawing.Size(87, 25);
            this.labelHistorialTitle.TabIndex = 0;
            this.labelHistorialTitle.Tag = "Historial";
            this.labelHistorialTitle.Text = "Historial";
            // 
            // labelSearchPatient
            // 
            this.labelSearchPatient.Location = new System.Drawing.Point(25, 60);
            this.labelSearchPatient.Name = "labelSearchPatient";
            this.labelSearchPatient.Size = new System.Drawing.Size(100, 23);
            this.labelSearchPatient.TabIndex = 1;
            this.labelSearchPatient.Tag = "BuscarPaciente";
            this.labelSearchPatient.Text = "Buscar Paciente:";
            // 
            // sfComboBoxPatient
            // 
            this.sfComboBoxPatient.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxPatient.Location = new System.Drawing.Point(155, 60);
            this.sfComboBoxPatient.Name = "sfComboBoxPatient";
            this.sfComboBoxPatient.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxPatient.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxPatient.TabIndex = 2;
            this.sfComboBoxPatient.TabStop = false;
            // 
            // sfDataGridHistorial
            // 

          

            this.sfDataGridHistorial.AccessibleName = "Table";
            this.sfDataGridHistorial.AutoGenerateColumns = false;
            this.sfDataGridHistorial.AllowEditing = false;
            gridTextColumn1.HeaderText = "Fecha";
            gridTextColumn1.MappingName = "Fecha";
            gridTextColumn1.AllowFiltering = true;
          
            gridTextColumn2.HeaderText = "Hora inicio";
            gridTextColumn2.MappingName = "HoraInicio";
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.Width = 100D;
            gridTextColumn3.HeaderText = "Hora fin";
            gridTextColumn3.MappingName = "HoraFin";
            gridTextColumn3.AllowFiltering = true;
            gridTextColumn3.Width = 100D;
            gridTextColumn4.HeaderText = "Profesional";
            gridTextColumn4.MappingName = "NombreProfesional";
            gridTextColumn4.AllowFiltering = true;
            gridTextColumn4.Width = 170D;
            gridTextColumn5.HeaderText = "Tratamiento";
            gridTextColumn5.MappingName = "NombreTratamiento";
            gridTextColumn5.AllowFiltering = true;
            gridTextColumn5.Width = 170D;
            gridTextColumn6.HeaderText = "Etapa";
            gridTextColumn6.MappingName = "EtapaTratamiento";
            gridTextColumn6.AllowFiltering = true;
            gridTextColumn6.Width = 100D;
            gridTextColumn7.HeaderText = "Observaciones";
            gridTextColumn7.MappingName = "Observaciones";
            gridTextColumn7.AllowFiltering = true;
            gridTextColumn7.Width = 200D;
            gridTextColumn8.HeaderText = "Recomendaciones";
            gridTextColumn8.MappingName = "Recomendaciones";
            gridTextColumn8.AllowFiltering = true;
            gridTextColumn6.Width = 200D;
            this.sfDataGridHistorial.Columns.Add(gridTextColumn1);
            this.sfDataGridHistorial.Columns.Add(gridTextColumn2);
            this.sfDataGridHistorial.Columns.Add(gridTextColumn3);
            this.sfDataGridHistorial.Columns.Add(gridTextColumn4);
            this.sfDataGridHistorial.Columns.Add(gridTextColumn5);
            this.sfDataGridHistorial.Columns.Add(gridTextColumn6);
            this.sfDataGridHistorial.Columns.Add(gridTextColumn7);
            this.sfDataGridHistorial.Columns.Add(gridTextColumn8);
            this.sfDataGridHistorial.Location = new System.Drawing.Point(20, 140);
            this.sfDataGridHistorial.Name = "sfDataGridHistorial";
            this.sfDataGridHistorial.Size = new System.Drawing.Size(600, 300);
            this.sfDataGridHistorial.TabIndex = 5;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(400, 60);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(120, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Tag = "Buscar";
            this.buttonSearch.Text = "Buscar";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 7;
            this.button1.Tag = "CrearPDF";
            this.button1.Text = "Crear Pdf";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HistorialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelHistorialTitle);
            this.Controls.Add(this.labelSearchPatient);
            this.Controls.Add(this.sfComboBoxPatient);
            this.Controls.Add(this.sfDataGridHistorial);
            this.Controls.Add(this.buttonSearch);
            this.Name = "HistorialForm";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.HistorialForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private Label labelHistorialTitle;
        private Label labelSearchPatient;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxPatient;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridHistorial;
        private Button buttonSearch;
        private Button button1;
    }
}