using System;
using System.Windows.Forms;
using Syncfusion.WinForms.ListView;

namespace UI.Forms
{
    partial class ModPacienteForm
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
            this.labelSearch = new System.Windows.Forms.Label();
            this.comboBoxPatients = new Syncfusion.WinForms.ListView.SfComboBox();
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
            this.buttonModPatient = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSearch
            // 
            this.labelSearch.Location = new System.Drawing.Point(25, 24);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(100, 23);
            this.labelSearch.TabIndex = 0;
            this.labelSearch.Tag = "BuscarPaciente";
            this.labelSearch.Text = "Buscar Paciente:";
            // 
            // comboBoxPatients
            // 
            this.comboBoxPatients.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.comboBoxPatients.Location = new System.Drawing.Point(155, 24);
            this.comboBoxPatients.Name = "comboBoxPatients";
            this.comboBoxPatients.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPatients.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxPatients.TabIndex = 1;
            this.comboBoxPatients.TabStop = false;
            this.comboBoxPatients.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatients_SelectedIndexChanged);
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(25, 64);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 23);
            this.labelName.TabIndex = 2;
            this.labelName.Tag = "Nombre";
            this.labelName.Text = "Nombre:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(155, 64);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // labelLastName
            // 
            this.labelLastName.Location = new System.Drawing.Point(25, 104);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(100, 23);
            this.labelLastName.TabIndex = 4;
            this.labelLastName.Tag = "Apellido";
            this.labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(155, 104);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(200, 20);
            this.textBoxLastName.TabIndex = 5;
            // 
            // labelAddress
            // 
            this.labelAddress.Location = new System.Drawing.Point(25, 144);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(100, 23);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Tag = "Direccion";
            this.labelAddress.Text = "Dirección:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(155, 144);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(200, 20);
            this.textBoxAddress.TabIndex = 7;
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(25, 184);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(100, 23);
            this.labelEmail.TabIndex = 8;
            this.labelEmail.Tag = "Email";
            this.labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(155, 184);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(200, 20);
            this.textBoxEmail.TabIndex = 9;
            // 
            // labelPhone
            // 
            this.labelPhone.Location = new System.Drawing.Point(25, 224);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(100, 23);
            this.labelPhone.TabIndex = 10;
            this.labelPhone.Tag = "Telefono";
            this.labelPhone.Text = "Teléfono:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(155, 224);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(200, 20);
            this.textBoxPhone.TabIndex = 11;
            // 
            // labelAllergies
            // 
            this.labelAllergies.Location = new System.Drawing.Point(25, 264);
            this.labelAllergies.Name = "labelAllergies";
            this.labelAllergies.Size = new System.Drawing.Size(100, 23);
            this.labelAllergies.TabIndex = 12;
            this.labelAllergies.Tag = "Alergias";
            this.labelAllergies.Text = "Alergias:";
            // 
            // textBoxAllergies
            // 
            this.textBoxAllergies.Location = new System.Drawing.Point(155, 261);
            this.textBoxAllergies.Multiline = true;
            this.textBoxAllergies.Name = "textBoxAllergies";
            this.textBoxAllergies.Size = new System.Drawing.Size(200, 60);
            this.textBoxAllergies.TabIndex = 13;
            // 
            // labelMedications
            // 
            this.labelMedications.Location = new System.Drawing.Point(25, 334);
            this.labelMedications.Name = "labelMedications";
            this.labelMedications.Size = new System.Drawing.Size(100, 23);
            this.labelMedications.TabIndex = 14;
            this.labelMedications.Tag = "Medicaciones";
            this.labelMedications.Text = "Medicaciones:";
            // 
            // textBoxMedications
            // 
            this.textBoxMedications.Location = new System.Drawing.Point(155, 331);
            this.textBoxMedications.Multiline = true;
            this.textBoxMedications.Name = "textBoxMedications";
            this.textBoxMedications.Size = new System.Drawing.Size(200, 60);
            this.textBoxMedications.TabIndex = 15;
            // 
            // buttonModPatient
            // 
            this.buttonModPatient.Location = new System.Drawing.Point(28, 414);
            this.buttonModPatient.Name = "buttonModPatient";
            this.buttonModPatient.Size = new System.Drawing.Size(120, 23);
            this.buttonModPatient.TabIndex = 16;
            this.buttonModPatient.Tag = "ModificarPaciente";
            this.buttonModPatient.Text = "Modificar Paciente";
            this.buttonModPatient.Click += new System.EventHandler(this.buttonModPatient_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(196, 414);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Tag = "Cancelar";
            this.buttonCancel.Text = "Cancelar";
            // 
            // ModPacienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 475);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.comboBoxPatients);
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
            this.Controls.Add(this.buttonModPatient);
            this.Controls.Add(this.buttonCancel);
            this.Name = "ModPacienteForm";
            this.Text = "Modificar Paciente";
            this.Load += new System.EventHandler(this.ModPacienteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelSearch;
        private SfComboBox comboBoxPatients;
        private TextBox textBoxName;
        private TextBox textBoxLastName;
        private TextBox textBoxAddress;
        private TextBox textBoxEmail;
        private TextBox textBoxPhone;
        private TextBox textBoxAllergies;
        private TextBox textBoxMedications;
        private Button buttonModPatient;
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