using Syncfusion.WinForms.DataGrid;
using System;
using System.Windows.Forms;
using Syncfusion.WinForms.ListView;
namespace UI.Forms
{
    partial class VerProfesionalForm
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn9 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn10 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn11 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn12 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.sfDataGridProfesionales = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.labelProfesionales = new System.Windows.Forms.Label();
            this.sfComboBoxProfesionales = new Syncfusion.WinForms.ListView.SfComboBox();
            this.labelBuscarProfesional = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridProfesionales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGridProfesionales
            // 
            this.sfDataGridProfesionales.AccessibleName = "Table";
            this.sfDataGridProfesionales.AutoGenerateColumns = false;
            this.sfDataGridProfesionales.AllowEditing = false;
         

            // Configurar las propiedades de las columnas
            gridTextColumn7.HeaderText = "Nombre";
            gridTextColumn7.MappingName = "Nombre";
            gridTextColumn7.Width = 150D;
            gridTextColumn7.AllowFiltering = true;
            gridTextColumn8.HeaderText = "Apellido";
            gridTextColumn8.MappingName = "Apellido";
            gridTextColumn8.Width = 150D;
            gridTextColumn8.AllowFiltering = true;
            gridTextColumn9.HeaderText = "Direccion";
            gridTextColumn9.MappingName = "Direccion";
            gridTextColumn9.Width = 200D;
            gridTextColumn9.AllowFiltering = true;
            gridTextColumn10.HeaderText = "Mail";
            gridTextColumn10.MappingName = "Mail";
            gridTextColumn10.Width = 200D;
            gridTextColumn10.AllowFiltering = true;
            gridTextColumn11.HeaderText = "Telefono";
            gridTextColumn11.MappingName = "Telefono";
            gridTextColumn11.Width = 150D;
            gridTextColumn11.AllowFiltering = true;
            gridTextColumn12.HeaderText = "Especializacion";
            gridTextColumn12.MappingName = "Especializacion";
            gridTextColumn12.Width = 150D;
            gridTextColumn12.AllowFiltering = true;
            this.sfDataGridProfesionales.Columns.Add(gridTextColumn7);
            this.sfDataGridProfesionales.Columns.Add(gridTextColumn8);
            this.sfDataGridProfesionales.Columns.Add(gridTextColumn9);
            this.sfDataGridProfesionales.Columns.Add(gridTextColumn10);
            this.sfDataGridProfesionales.Columns.Add(gridTextColumn11);
            this.sfDataGridProfesionales.Columns.Add(gridTextColumn12);
            this.sfDataGridProfesionales.Location = new System.Drawing.Point(25, 100);
            this.sfDataGridProfesionales.Name = "sfDataGridProfesionales";
            this.sfDataGridProfesionales.Size = new System.Drawing.Size(800, 300);
            this.sfDataGridProfesionales.TabIndex = 0;
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
            // labelProfesionales
            // 
            this.labelProfesionales.AutoSize = true;
            this.labelProfesionales.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelProfesionales.Location = new System.Drawing.Point(20, 20);
            this.labelProfesionales.Name = "labelProfesionales";
            this.labelProfesionales.Size = new System.Drawing.Size(131, 25);
            this.labelProfesionales.TabIndex = 2;
            this.labelProfesionales.Tag = "Profesionales";
            this.labelProfesionales.Text = "Profesionales";
            // 
            // sfComboBoxProfesionales
            // 
            this.sfComboBoxProfesionales.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBoxProfesionales.Location = new System.Drawing.Point(154, 50);
            this.sfComboBoxProfesionales.Name = "sfComboBoxProfesionales";
            this.sfComboBoxProfesionales.Size = new System.Drawing.Size(200, 21);
            this.sfComboBoxProfesionales.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBoxProfesionales.TabIndex = 3;
            this.sfComboBoxProfesionales.TabStop = false;
            this.sfComboBoxProfesionales.SelectedIndexChanged += new System.EventHandler(this.sfComboBoxProfesionales_SelectedIndexChanged);
            // 
            // labelBuscarProfesional
            // 
            this.labelBuscarProfesional.AutoSize = true;
            this.labelBuscarProfesional.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelBuscarProfesional.Location = new System.Drawing.Point(25, 52);
            this.labelBuscarProfesional.Name = "labelBuscarProfesional";
            this.labelBuscarProfesional.Size = new System.Drawing.Size(123, 19);
            this.labelBuscarProfesional.TabIndex = 4;
            this.labelBuscarProfesional.Tag = "BuscarProfesional";
            this.labelBuscarProfesional.Text = "Buscar Profesional:";
            // 
            // VerProfesionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 470);
            this.Controls.Add(this.labelBuscarProfesional);
            this.Controls.Add(this.sfComboBoxProfesionales);
            this.Controls.Add(this.labelProfesionales);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.sfDataGridProfesionales);
            this.Name = "VerProfesionalForm";
            this.Text = "Ver Profesionales";
            this.Load += new System.EventHandler(this.VerProfesionalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGridProfesionales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBoxProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridProfesionales;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Label labelProfesionales;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBoxProfesionales;
        private System.Windows.Forms.Label labelBuscarProfesional;
    }
}