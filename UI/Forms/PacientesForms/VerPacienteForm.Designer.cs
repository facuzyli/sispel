using DOMAIN;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace UI.Forms
{
    partial class VerPacienteForm
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
            this.sfDataGridPacientes = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.labelPacientes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGridPacientes
            // 
            this.sfDataGridPacientes.AccessibleName = "Table";
            this.sfDataGridPacientes.AllowFiltering = true;
            this.sfDataGridPacientes.AutoGenerateColumns = false;

            this.sfDataGridPacientes.AllowEditing = false;

            // Configurar las propiedades de las columnas
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.HeaderText = "Nombre";
            gridTextColumn1.MappingName = "Nombre";
            gridTextColumn1.Width = 150D;

            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.HeaderText = "Apellido";
            gridTextColumn2.MappingName = "Apellido";
            gridTextColumn2.Width = 150D;

            gridTextColumn3.AllowFiltering = true;
            gridTextColumn3.HeaderText = "Direccion";
            gridTextColumn3.MappingName = "Direccion";
            gridTextColumn3.Width = 200D;

            gridTextColumn4.AllowFiltering = true;
            gridTextColumn4.HeaderText = "Mail";
            gridTextColumn4.MappingName = "Mail";
            gridTextColumn4.Width = 200D;

            gridTextColumn5.AllowFiltering = true;
            gridTextColumn5.HeaderText = "Telefono";
            gridTextColumn5.MappingName = "Telefono";
            gridTextColumn5.Width = 150D;

            gridTextColumn6.AllowFiltering = true;
            gridTextColumn6.HeaderText = "Activo";
            gridTextColumn6.MappingName = "Activo";
            gridTextColumn6.Width = 100D;
            this.sfDataGridPacientes.Columns.Add(gridTextColumn1);
            this.sfDataGridPacientes.Columns.Add(gridTextColumn2);
            this.sfDataGridPacientes.Columns.Add(gridTextColumn3);
            this.sfDataGridPacientes.Columns.Add(gridTextColumn4);
            this.sfDataGridPacientes.Columns.Add(gridTextColumn5);
            this.sfDataGridPacientes.Columns.Add(gridTextColumn6);
            this.sfDataGridPacientes.Location = new System.Drawing.Point(25, 64);
            this.sfDataGridPacientes.Name = "sfDataGridPacientes";
            this.sfDataGridPacientes.Size = new System.Drawing.Size(800, 350);
            this.sfDataGridPacientes.TabIndex = 0;
           
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Location = new System.Drawing.Point(700, 420);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(120, 30);
            this.buttonActualizar.TabIndex = 1;
            this.buttonActualizar.Tag = "Actualizar";
            this.buttonActualizar.Text = "Actualizar";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // labelPacientes
            // 
            this.labelPacientes.AutoSize = true;
            this.labelPacientes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelPacientes.Location = new System.Drawing.Point(20, 20);
            this.labelPacientes.Name = "labelPacientes";
            this.labelPacientes.Size = new System.Drawing.Size(95, 25);
            this.labelPacientes.TabIndex = 2;
            this.labelPacientes.Tag = "Pacientes";
            this.labelPacientes.Text = "Pacientes";
            // 
            // VerPacienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 470);
            this.Controls.Add(this.labelPacientes);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.sfDataGridPacientes);
            this.Name = "VerPacienteForm";
            this.Text = "Ver Pacientes";
            this.Load += new System.EventHandler(this.VerPacienteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridPacientes;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Label labelPacientes;
        
            
        
    }
}