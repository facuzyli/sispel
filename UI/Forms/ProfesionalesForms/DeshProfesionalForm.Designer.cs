using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
namespace UI.Forms
{
    partial class DeshProfesionalForm
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
            this.labelSearchProfesional = new System.Windows.Forms.Label();
            this.sfComboBoxProfesional = new Syncfusion.WinForms.ListView.SfComboBox();
            this.buttonDeshabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxProfesional)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSearchProfesional
            // 
            this.labelSearchProfesional.AutoSize = true;
            this.labelSearchProfesional.Location = new System.Drawing.Point(25, 20);
            this.labelSearchProfesional.Name = "labelSearchProfesional";
            this.labelSearchProfesional.Size = new System.Drawing.Size(98, 13);
            this.labelSearchProfesional.TabIndex = 0;
            this.labelSearchProfesional.Tag = "BuscarProfesional";
            this.labelSearchProfesional.Text = "Buscar Profesional:";
            // 
            // sfComboBoxProfesional
            // 
            this.sfComboBoxProfesional.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxProfesional.Location = new System.Drawing.Point(155, 20);
            this.sfComboBoxProfesional.Name = "sfComboBoxProfesional";
            this.sfComboBoxProfesional.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxProfesional.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxProfesional.TabIndex = 1;
            this.sfComboBoxProfesional.TabStop = false;
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
            // DeshProfesionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 114);
            this.Controls.Add(this.buttonDeshabilitar);
            this.Controls.Add(this.sfComboBoxProfesional);
            this.Controls.Add(this.labelSearchProfesional);
            this.Name = "DeshProfesionalForm";
            this.Text = "Deshabilitar Profesional";
            this.Load += new System.EventHandler(this.DeshProfesionalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxProfesional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelSearchProfesional;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxProfesional;
        private Button buttonDeshabilitar;
    }
}