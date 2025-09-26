using System;
using System.Windows.Forms;
namespace UI.Forms
{
    partial class AgregarTratamientoForm
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonSaveTreatment = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(25, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 23);
            this.labelName.TabIndex = 0;
            this.labelName.Tag = "Nombre";
            this.labelName.Text = "Nombre:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(155, 24);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelDuration
            // 
            this.labelDuration.Location = new System.Drawing.Point(25, 64);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(100, 23);
            this.labelDuration.TabIndex = 2;
            this.labelDuration.Tag = "DuracionTotal";
            this.labelDuration.Text = "Duración Total:";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(155, 64);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(200, 20);
            this.textBoxDuration.TabIndex = 3;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(25, 104);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(100, 23);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Tag = "Descripcion";
            this.labelDescription.Text = "Descripción:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(155, 104);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(200, 60);
            this.textBoxDescription.TabIndex = 5;
            // 
            // buttonSaveTreatment
            // 
            this.buttonSaveTreatment.Location = new System.Drawing.Point(28, 180);
            this.buttonSaveTreatment.Name = "buttonSaveTreatment";
            this.buttonSaveTreatment.Size = new System.Drawing.Size(120, 23);
            this.buttonSaveTreatment.TabIndex = 6;
            this.buttonSaveTreatment.Tag = "GuardarTratamiento";
            this.buttonSaveTreatment.Text = "Guardar Tratamiento";
            this.buttonSaveTreatment.Click += new System.EventHandler(this.buttonSaveTreatment_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(196, 180);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Tag = "Cancelar";
            this.buttonCancel.Text = "Cancelar";
            // 
            // AgregarTratamientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 267);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.textBoxDuration);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.buttonSaveTreatment);
            this.Controls.Add(this.buttonCancel);
            this.Name = "AgregarTratamientoForm";
            this.Text = "AgregarTratamientoForm";
            this.Load += new System.EventHandler(this.AgregarTratamientoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelName;
        private TextBox textBoxName;
        private Label labelDuration;
        private TextBox textBoxDuration;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private Button buttonSaveTreatment;
        private Button buttonCancel;
    }
}