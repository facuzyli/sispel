using Syncfusion.WinForms.ListView;
using System;
using System.Windows.Forms;
namespace UI.Forms
{
    partial class ModProfesionalForm
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
            this.comboBoxProfesionals = new Syncfusion.WinForms.ListView.SfComboBox();
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
            this.labelSpecialization = new System.Windows.Forms.Label();
            this.textBoxSpecialization = new System.Windows.Forms.TextBox();
            this.buttonModProfessional = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxProfesionals)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSearch
            // 
            this.labelSearch.Location = new System.Drawing.Point(12, 24);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(136, 23);
            this.labelSearch.TabIndex = 0;
            this.labelSearch.Tag = "BuscarProfesional";
            this.labelSearch.Text = "Buscar Profesional:";
            // 
            // comboBoxProfesionals
            // 
            this.comboBoxProfesionals.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.comboBoxProfesionals.Location = new System.Drawing.Point(155, 24);
            this.comboBoxProfesionals.Name = "comboBoxProfesionals";
            this.comboBoxProfesionals.Size = new System.Drawing.Size(200, 21);
            this.comboBoxProfesionals.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxProfesionals.TabIndex = 1;
            this.comboBoxProfesionals.TabStop = false;
            this.comboBoxProfesionals.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfesionals_SelectedIndexChanged_1);
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
            // labelSpecialization
            // 
            this.labelSpecialization.Location = new System.Drawing.Point(25, 264);
            this.labelSpecialization.Name = "labelSpecialization";
            this.labelSpecialization.Size = new System.Drawing.Size(100, 23);
            this.labelSpecialization.TabIndex = 12;
            this.labelSpecialization.Tag = "Especializacion";
            this.labelSpecialization.Text = "Especialización:";
            // 
            // textBoxSpecialization
            // 
            this.textBoxSpecialization.Location = new System.Drawing.Point(155, 264);
            this.textBoxSpecialization.Name = "textBoxSpecialization";
            this.textBoxSpecialization.Size = new System.Drawing.Size(200, 20);
            this.textBoxSpecialization.TabIndex = 13;
            // 
            // buttonModProfessional
            // 
            this.buttonModProfessional.Location = new System.Drawing.Point(28, 304);
            this.buttonModProfessional.Name = "buttonModProfessional";
            this.buttonModProfessional.Size = new System.Drawing.Size(120, 23);
            this.buttonModProfessional.TabIndex = 14;
            this.buttonModProfessional.Tag = "ModificarProfesional";
            this.buttonModProfessional.Text = "Modificar Profesional";
            this.buttonModProfessional.Click += new System.EventHandler(this.buttonModProfessional_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(196, 304);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Tag = "Cancelar";
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ModProfesionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.comboBoxProfesionals);
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
            this.Controls.Add(this.labelSpecialization);
            this.Controls.Add(this.textBoxSpecialization);
            this.Controls.Add(this.buttonModProfessional);
            this.Controls.Add(this.buttonCancel);
            this.Name = "ModProfesionalForm";
            this.Text = "Modificar Profesional";
            this.Load += new System.EventHandler(this.ModProfesionalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxProfesionals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelSearch;
        private SfComboBox comboBoxProfesionals;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelLastName;
        private TextBox textBoxLastName;
        private Label labelAddress;
        private TextBox textBoxAddress;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelSpecialization;
        private TextBox textBoxSpecialization;
        private Button buttonModProfessional;
        private Button buttonCancel;
    }
}