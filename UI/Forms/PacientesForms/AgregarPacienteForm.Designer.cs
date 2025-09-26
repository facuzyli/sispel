using System;
using System.Windows.Forms;
namespace UI
{
    partial class AgregarPacienteForm
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
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelAllergies = new System.Windows.Forms.Label();
            this.textBoxAllergies = new System.Windows.Forms.TextBox();
            this.labelMedications = new System.Windows.Forms.Label();
            this.textBoxMedications = new System.Windows.Forms.TextBox();
            this.buttonAddPatient = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(20, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 23);
            this.labelName.TabIndex = 0;
            this.labelName.Tag = "Nombre";
            this.labelName.Text = "Nombre:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(150, 20);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelLastName
            // 
            this.labelLastName.Location = new System.Drawing.Point(20, 60);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(100, 23);
            this.labelLastName.TabIndex = 2;
            this.labelLastName.Tag = "Apellido";
            this.labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(150, 60);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(200, 20);
            this.textBoxLastName.TabIndex = 3;
            // 
            // labelAddress
            // 
            this.labelAddress.Location = new System.Drawing.Point(20, 100);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(100, 23);
            this.labelAddress.TabIndex = 4;
            this.labelAddress.Tag = "Direccion";
            this.labelAddress.Text = "Dirección:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(150, 100);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(200, 20);
            this.textBoxAddress.TabIndex = 5;
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(20, 140);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(100, 23);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Tag = "Email";
            this.labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(150, 140);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(200, 20);
            this.textBoxEmail.TabIndex = 7;
            // 
            // labelPhone
            // 
            this.labelPhone.Location = new System.Drawing.Point(20, 180);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(100, 23);
            this.labelPhone.TabIndex = 8;
            this.labelPhone.Tag = "Telefono";
            this.labelPhone.Text = "Teléfono:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(150, 180);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(200, 20);
            this.textBoxPhone.TabIndex = 9;
            // 
            // labelAllergies
            // 
            this.labelAllergies.Location = new System.Drawing.Point(20, 220);
            this.labelAllergies.Name = "labelAllergies";
            this.labelAllergies.Size = new System.Drawing.Size(100, 23);
            this.labelAllergies.TabIndex = 10;
            this.labelAllergies.Tag = "Alergias";
            this.labelAllergies.Text = "Alergias:";
            // 
            // textBoxAllergies
            // 
            this.textBoxAllergies.Location = new System.Drawing.Point(150, 217);
            this.textBoxAllergies.Multiline = true;
            this.textBoxAllergies.Name = "textBoxAllergies";
            this.textBoxAllergies.Size = new System.Drawing.Size(200, 60);
            this.textBoxAllergies.TabIndex = 11;
            // 
            // labelMedications
            // 
            this.labelMedications.Location = new System.Drawing.Point(20, 290);
            this.labelMedications.Name = "labelMedications";
            this.labelMedications.Size = new System.Drawing.Size(100, 23);
            this.labelMedications.TabIndex = 12;
            this.labelMedications.Tag = "Medicaciones";
            this.labelMedications.Text = "Medicaciones:";
            // 
            // textBoxMedications
            // 
            this.textBoxMedications.Location = new System.Drawing.Point(150, 287);
            this.textBoxMedications.Multiline = true;
            this.textBoxMedications.Name = "textBoxMedications";
            this.textBoxMedications.Size = new System.Drawing.Size(200, 60);
            this.textBoxMedications.TabIndex = 13;
            // 
            // buttonAddPatient
            // 
            this.buttonAddPatient.Location = new System.Drawing.Point(23, 370);
            this.buttonAddPatient.Name = "buttonAddPatient";
            this.buttonAddPatient.Size = new System.Drawing.Size(120, 23);
            this.buttonAddPatient.TabIndex = 14;
            this.buttonAddPatient.Tag = "AñadirPaciente";
            this.buttonAddPatient.Text = "Añadir Paciente";
            this.buttonAddPatient.Click += new System.EventHandler(this.buttonAddPatient_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(191, 370);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Tag = "Cancelar";
            this.buttonCancel.Text = "Cancelar";
            // 
            // AgregarPacienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 431);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelAllergies);
            this.Controls.Add(this.textBoxAllergies);
            this.Controls.Add(this.labelMedications);
            this.Controls.Add(this.textBoxMedications);
            this.Controls.Add(this.buttonAddPatient);
            this.Controls.Add(this.buttonCancel);
            this.Name = "AgregarPacienteForm";
            this.Text = "Agregar Paciente";
            this.Load += new System.EventHandler(this.AgregarPacienteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBoxName;
        private TextBox textBoxLastName;
        private TextBox textBoxAddress;
        private TextBox textBoxEmail;
        private TextBox textBoxPhone;
        private TextBox textBoxAllergies;
        private TextBox textBoxMedications;
        private Button buttonAddPatient;
        private Button buttonCancel;
        private Label labelName;
        private Label labelLastName;
        private Label labelAddress;
        private Label labelEmail;
        private Label labelPhone;
        private Label labelAllergies;
        private Label labelMedications;
    }
}