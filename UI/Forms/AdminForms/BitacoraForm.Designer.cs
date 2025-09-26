using DOMAIN;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace UI.Forms.AdminForms
{
    partial class BitacoraForm
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn9 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn10 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.AllowEditing = false;
            this.sfDataGrid1.AllowFiltering = true;
            this.sfDataGrid1.AutoGenerateColumns = false;
            this.sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.AllowFiltering = true;
            gridTextColumn6.HeaderText = "Id_Log";
            gridTextColumn6.MappingName = "Id_Log";
            gridTextColumn6.Visible = false;
            gridTextColumn6.Width = 260D;
            gridTextColumn7.AllowEditing = false;
            gridTextColumn7.AllowFiltering = true;
            gridTextColumn7.HeaderText = "Fecha";
            gridTextColumn7.MappingName = "Fecha";
            gridTextColumn7.Width = 150D;
            gridTextColumn8.AllowEditing = false;
            gridTextColumn8.AllowFiltering = true;
            gridTextColumn8.HeaderText = "TraceLevel";
            gridTextColumn8.MappingName = "TraceLevel";
            gridTextColumn8.Width = 100D;
            gridTextColumn9.AllowEditing = false;
            gridTextColumn9.AllowFiltering = true;
            gridTextColumn9.AllowResizing = true;
            gridTextColumn9.HeaderText = "Mensaje";
            gridTextColumn9.MappingName = "Mensaje";
            gridTextColumn10.AllowEditing = false;
            gridTextColumn10.AllowFiltering = true;
            gridTextColumn10.AllowResizing = true;
            gridTextColumn10.HeaderText = "StackTrace";
            gridTextColumn10.MappingName = "StackTrace";
            this.sfDataGrid1.Columns.Add(gridTextColumn6);
            this.sfDataGrid1.Columns.Add(gridTextColumn7);
            this.sfDataGrid1.Columns.Add(gridTextColumn8);
            this.sfDataGrid1.Columns.Add(gridTextColumn9);
            this.sfDataGrid1.Columns.Add(gridTextColumn10);
            this.sfDataGrid1.Location = new System.Drawing.Point(29, 85);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.RowHeight = 50;
            this.sfDataGrid1.Size = new System.Drawing.Size(1028, 396);
            this.sfDataGrid1.TabIndex = 0;
            this.sfDataGrid1.Text = "sfDataGrid1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Tag = "Bitacora";
            this.label1.Text = "Bitacora:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Tag = "Copiar";
            this.button1.Text = "Copiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCopiar_Click);
            // 
            // BitacoraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 533);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sfDataGrid1);
            this.Name = "BitacoraForm";
            this.Text = "BitacoraForm";
            this.Load += new System.EventHandler(this.BitacoraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
       
        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.Label label1;
        private Button button1;
    }
}