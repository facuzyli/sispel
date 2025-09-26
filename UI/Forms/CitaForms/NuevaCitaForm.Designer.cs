using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;

namespace UI.Forms
{
    partial class NuevaCitaForm
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
            this.labelNuevaCitaTitle = new System.Windows.Forms.Label();
            this.labelSearchPaciente = new System.Windows.Forms.Label();
            this.sfComboBoxPaciente = new Syncfusion.WinForms.ListView.SfComboBox();
            this.labelSearchProfesional = new System.Windows.Forms.Label();
            this.sfComboBoxProfesional = new Syncfusion.WinForms.ListView.SfComboBox();
            this.labelSearchTratamiento = new System.Windows.Forms.Label();
            this.sfComboBoxTratamiento = new Syncfusion.WinForms.ListView.SfComboBox();
            this.labelSearchEtapa = new System.Windows.Forms.Label();
            this.sfComboBoxEtapa = new Syncfusion.WinForms.ListView.SfComboBox();
            this.labelFecha = new System.Windows.Forms.Label();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.labelHora = new System.Windows.Forms.Label();
            this.buttonCrearCita = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxProfesional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxTratamiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxEtapa)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNuevaCitaTitle
            // 
            this.labelNuevaCitaTitle.AutoSize = true;
            this.labelNuevaCitaTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelNuevaCitaTitle.Location = new System.Drawing.Point(25, 20);
            this.labelNuevaCitaTitle.Name = "labelNuevaCitaTitle";
            this.labelNuevaCitaTitle.Size = new System.Drawing.Size(103, 25);
            this.labelNuevaCitaTitle.TabIndex = 0;
            this.labelNuevaCitaTitle.Tag = "NuevaCita";
            this.labelNuevaCitaTitle.Text = "NuevaCita";
            // 
            // labelSearchPaciente
            // 
            this.labelSearchPaciente.Location = new System.Drawing.Point(25, 60);
            this.labelSearchPaciente.Name = "labelSearchPaciente";
            this.labelSearchPaciente.Size = new System.Drawing.Size(100, 23);
            this.labelSearchPaciente.TabIndex = 1;
            this.labelSearchPaciente.Tag = "BuscarPaciente";
            this.labelSearchPaciente.Text = "Buscar Paciente:";
            // 
            // sfComboBoxPaciente
            // 
            this.sfComboBoxPaciente.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxPaciente.Location = new System.Drawing.Point(130, 60);
            this.sfComboBoxPaciente.Name = "sfComboBoxPaciente";
            this.sfComboBoxPaciente.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxPaciente.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxPaciente.TabIndex = 2;
            this.sfComboBoxPaciente.TabStop = false;
            this.sfComboBoxPaciente.SelectedIndexChanged += new System.EventHandler(this.sfComboBoxPaciente_SelectedIndexChanged);
            // 
            // labelSearchProfesional
            // 
            this.labelSearchProfesional.Location = new System.Drawing.Point(25, 100);
            this.labelSearchProfesional.Name = "labelSearchProfesional";
            this.labelSearchProfesional.Size = new System.Drawing.Size(100, 23);
            this.labelSearchProfesional.TabIndex = 3;
            this.labelSearchProfesional.Tag = "BuscarProfesional";
            this.labelSearchProfesional.Text = "Buscar Profesional:";
            // 
            // sfComboBoxProfesional
            // 
            this.sfComboBoxProfesional.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxProfesional.Location = new System.Drawing.Point(130, 100);
            this.sfComboBoxProfesional.Name = "sfComboBoxProfesional";
            this.sfComboBoxProfesional.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxProfesional.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxProfesional.TabIndex = 4;
            this.sfComboBoxProfesional.TabStop = false;
            this.sfComboBoxProfesional.SelectedIndexChanged += new System.EventHandler(this.sfComboBoxProfesional_SelectedIndexChanged);
            // 
            // labelSearchTratamiento
            // 
            this.labelSearchTratamiento.Location = new System.Drawing.Point(25, 140);
            this.labelSearchTratamiento.Name = "labelSearchTratamiento";
            this.labelSearchTratamiento.Size = new System.Drawing.Size(100, 40);
            this.labelSearchTratamiento.TabIndex = 5;
            this.labelSearchTratamiento.Tag = "BuscarTratamiento";
            this.labelSearchTratamiento.Text = "Buscar Tratamiento:";
            // 
            // sfComboBoxTratamiento
            // 
            this.sfComboBoxTratamiento.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxTratamiento.Location = new System.Drawing.Point(131, 140);
            this.sfComboBoxTratamiento.Name = "sfComboBoxTratamiento";
            this.sfComboBoxTratamiento.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxTratamiento.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxTratamiento.TabIndex = 6;
            this.sfComboBoxTratamiento.TabStop = false;
            this.sfComboBoxTratamiento.SelectedIndexChanged += new System.EventHandler(this.sfComboBoxTratamiento_SelectedIndexChanged);
            // 
            // labelSearchEtapa
            // 
            this.labelSearchEtapa.Location = new System.Drawing.Point(25, 180);
            this.labelSearchEtapa.Name = "labelSearchEtapa";
            this.labelSearchEtapa.Size = new System.Drawing.Size(100, 23);
            this.labelSearchEtapa.TabIndex = 7;
            this.labelSearchEtapa.Tag = "BuscarEtapa";
            this.labelSearchEtapa.Text = "Buscar Etapa:";
            // 
            // sfComboBoxEtapa
            // 
            this.sfComboBoxEtapa.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxEtapa.Location = new System.Drawing.Point(130, 180);
            this.sfComboBoxEtapa.Name = "sfComboBoxEtapa";
            this.sfComboBoxEtapa.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxEtapa.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxEtapa.TabIndex = 8;
            this.sfComboBoxEtapa.TabStop = false;
            this.sfComboBoxEtapa.SelectedIndexChanged += new System.EventHandler(this.sfComboBoxEtapa_SelectedIndexChanged);
            // 
            // labelFecha
            // 
            this.labelFecha.Location = new System.Drawing.Point(25, 220);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(100, 23);
            this.labelFecha.TabIndex = 9;
            this.labelFecha.Tag = "Fecha";
            this.labelFecha.Text = "Fecha:";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(130, 220);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFecha.TabIndex = 10;
            this.dateTimePickerFecha.ValueChanged += new System.EventHandler(this.dateTimePickerFecha_ValueChanged_1);
            // 
            // labelHora
            // 
            this.labelHora.Location = new System.Drawing.Point(25, 260);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(100, 23);
            this.labelHora.TabIndex = 11;
            this.labelHora.Tag = "Hora";
            this.labelHora.Text = "Hora:";
            // 
            // buttonCrearCita
            // 
            this.buttonCrearCita.Location = new System.Drawing.Point(130, 300);
            this.buttonCrearCita.Name = "buttonCrearCita";
            this.buttonCrearCita.Size = new System.Drawing.Size(120, 23);
            this.buttonCrearCita.TabIndex = 13;
            this.buttonCrearCita.Tag = "CrearCita";
            this.buttonCrearCita.Text = "Crear Cita";
            this.buttonCrearCita.UseVisualStyleBackColor = true;
            this.buttonCrearCita.Click += new System.EventHandler(this.buttonCrearCita_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(129, 262);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // NuevaCitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 350);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelNuevaCitaTitle);
            this.Controls.Add(this.labelSearchPaciente);
            this.Controls.Add(this.sfComboBoxPaciente);
            this.Controls.Add(this.labelSearchProfesional);
            this.Controls.Add(this.sfComboBoxProfesional);
            this.Controls.Add(this.labelSearchTratamiento);
            this.Controls.Add(this.sfComboBoxTratamiento);
            this.Controls.Add(this.labelSearchEtapa);
            this.Controls.Add(this.sfComboBoxEtapa);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.labelHora);
            this.Controls.Add(this.buttonCrearCita);
            this.Name = "NuevaCitaForm";
            this.Text = "Nueva Cita";
            this.Load += new System.EventHandler(this.NuevaCitaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxProfesional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxTratamiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxEtapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private Label labelNuevaCitaTitle;
        private Label labelSearchPaciente;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxPaciente;
        private Label labelSearchProfesional;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxProfesional;
        private Label labelSearchTratamiento;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxTratamiento;
        private Label labelSearchEtapa;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxEtapa;
        private Label labelFecha;
        private DateTimePicker dateTimePickerFecha;
        private Label labelHora;
        private Button buttonCrearCita;
        private ComboBox comboBox1;
    }
}