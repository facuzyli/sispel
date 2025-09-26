using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
namespace UI.Forms
{
    partial class DeshPacienteForm
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
            this.labelSearchPaciente = new System.Windows.Forms.Label();
            this.sfComboBoxPaciente = new Syncfusion.WinForms.ListView.SfComboBox();
            this.buttonDeshabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxPaciente)).BeginInit();
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
            // 
            // buttonDeshabilitar
            // 
            this.buttonDeshabilitar.Location = new System.Drawing.Point(370, 20);
            this.buttonDeshabilitar.Name = "buttonDeshabilitar";
            this.buttonDeshabilitar.Size = new System.Drawing.Size(120, 23);
            this.buttonDeshabilitar.TabIndex = 2;
            this.buttonDeshabilitar.Tag = "Deshabilitar";
            this.buttonDeshabilitar.Text = "Deshabilitar";
            this.buttonDeshabilitar.UseVisualStyleBackColor = true;
            this.buttonDeshabilitar.Click += new System.EventHandler(this.buttonDeshabilitar_Click);
            // 
            // DeshPacienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 126);
            this.Controls.Add(this.buttonDeshabilitar);
            this.Controls.Add(this.sfComboBoxPaciente);
            this.Controls.Add(this.labelSearchPaciente);
            this.Name = "DeshPacienteForm";
            this.Text = "Deshabilitar Paciente";
            this.Load += new System.EventHandler(this.DeshPacienteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxPaciente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelSearchPaciente;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxPaciente;
        private Button buttonDeshabilitar;
    }
}