using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;


namespace UI.Forms
{
    partial class HorariosForm
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
        /// private void LoadData()
    
       
    
    private void InitializeComponent()
        {
            this.labelHistorialTitle = new System.Windows.Forms.Label();
            this.labelSearchProfessional = new System.Windows.Forms.Label();
            this.sfComboBoxProfessional = new Syncfusion.WinForms.ListView.SfComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewHistorial = new System.Windows.Forms.DataGridView();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombrePaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreTratamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxProfessional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHistorialTitle
            // 
            this.labelHistorialTitle.AutoSize = true;
            this.labelHistorialTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelHistorialTitle.Location = new System.Drawing.Point(25, 20);
            this.labelHistorialTitle.Name = "labelHistorialTitle";
            this.labelHistorialTitle.Size = new System.Drawing.Size(90, 25);
            this.labelHistorialTitle.TabIndex = 0;
            this.labelHistorialTitle.Tag = "Horarios";
            this.labelHistorialTitle.Text = "Horarios";
            // 
            // labelSearchProfessional
            // 
            this.labelSearchProfessional.Location = new System.Drawing.Point(25, 60);
            this.labelSearchProfessional.Name = "labelSearchProfessional";
            this.labelSearchProfessional.Size = new System.Drawing.Size(100, 23);
            this.labelSearchProfessional.TabIndex = 1;
            this.labelSearchProfessional.Tag = "BuscarProfesional";
            this.labelSearchProfessional.Text = "Buscar Profesional:";
            // 
            // sfComboBoxProfessional
            // 
            this.sfComboBoxProfessional.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxProfessional.Location = new System.Drawing.Point(155, 60);
            this.sfComboBoxProfessional.Name = "sfComboBoxProfessional";
            this.sfComboBoxProfessional.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxProfessional.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxProfessional.TabIndex = 2;
            this.sfComboBoxProfessional.TabStop = false;
            this.sfComboBoxProfessional.SelectedIndexChanged += new System.EventHandler(this.sfComboBoxProfessional_SelectedIndexChanged);
            // 
            // labelDate
            // 
            this.labelDate.Location = new System.Drawing.Point(25, 100);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(100, 23);
            this.labelDate.TabIndex = 3;
            this.labelDate.Tag = "Fecha";
            this.labelDate.Text = "Fecha:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(155, 100);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 4;
            // 
            // dataGridViewHistorial
            // 
            this.dataGridViewHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hora,
            this.NombrePaciente,
            this.TelefonoPaciente,
            this.NombreTratamiento});
            this.dataGridViewHistorial.Location = new System.Drawing.Point(20, 140);
            this.dataGridViewHistorial.Name = "dataGridViewHistorial";
            this.dataGridViewHistorial.Size = new System.Drawing.Size(600, 300);
            this.dataGridViewHistorial.TabIndex = 5;
            // 
            // Hora
            // 
           this.dataGridViewHistorial.ReadOnly = true;
          

            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            
            // 
            // NombrePaciente
            // 
            this.NombrePaciente.HeaderText = "Nombre Paciente";
            this.NombrePaciente.Name = "NombrePaciente";
            // 
            // TelefonoPaciente
            // 
            this.TelefonoPaciente.HeaderText = "Teléfono Paciente";
            this.TelefonoPaciente.Name = "TelefonoPaciente";
            // 
            // NombreTratamiento
            // 
            this.NombreTratamiento.HeaderText = "Nombre Tratamiento";
            this.NombreTratamiento.Name = "NombreTratamiento";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(400, 60);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(120, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Tag = "Buscar";
            this.buttonSearch.Text = "Buscar";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Tag = "CrearPDF";
            this.button1.Text = "Crear PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HorariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelHistorialTitle);
            this.Controls.Add(this.labelSearchProfessional);
            this.Controls.Add(this.sfComboBoxProfessional);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.dataGridViewHistorial);
            this.Controls.Add(this.buttonSearch);
            this.Name = "HorariosForm";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.HorariosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxProfessional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
      
        private Label labelHistorialTitle;
        private Label labelSearchProfessional;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxProfessional;
        private Label labelDate;
        private DateTimePicker dateTimePicker;
        private DataGridView dataGridViewHistorial;
        private Button buttonSearch;
        private DataGridViewTextBoxColumn Hora;
        private DataGridViewTextBoxColumn NombrePaciente;
        private DataGridViewTextBoxColumn TelefonoPaciente;
        private DataGridViewTextBoxColumn NombreTratamiento;
        private Button button1;
    }
}