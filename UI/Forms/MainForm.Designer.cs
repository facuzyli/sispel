using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using Syncfusion.WinForms.DataGrid;
using System.Configuration;
using UI.Forms.AdminForms;
using System.Drawing;
using Service.Facade;
using UI.Forms.CitaForms;

namespace UI.Forms
{
    public partial class MainForm : Form
    {
       
      

        

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
        /// 
        
        private void InitializeComponent()
        {
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.citasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroCitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarCitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshabilitarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshabilitarProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tratamientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarTratamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etapasTratamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPatenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bakcupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.citasToolStripMenuItem,
            this.pacientesToolStripMenuItem,
            this.profesionalesToolStripMenuItem,
            this.tratamientosToolStripMenuItem,
            this.horariosToolStripMenuItem,
            this.historialToolStripMenuItem,
            this.administradorToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 29);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // citasToolStripMenuItem
            // 
            this.citasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCitaToolStripMenuItem,
            this.registroCitaToolStripMenuItem,
            this.listarCitaToolStripMenuItem});
            this.citasToolStripMenuItem.Name = "citasToolStripMenuItem";
            this.citasToolStripMenuItem.Size = new System.Drawing.Size(56, 25);
            this.citasToolStripMenuItem.Tag = "Citas";
            this.citasToolStripMenuItem.Text = "Citas";
            // 
            // nuevaCitaToolStripMenuItem
            // 
            this.nuevaCitaToolStripMenuItem.Name = "nuevaCitaToolStripMenuItem";
            this.nuevaCitaToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.nuevaCitaToolStripMenuItem.Tag = "NuevaCita";
            this.nuevaCitaToolStripMenuItem.Text = "Nueva Cita";
            this.nuevaCitaToolStripMenuItem.Click += new System.EventHandler(this.NuevaCitaToolStripMenuItem_Click);
            // 
            // registroCitaToolStripMenuItem
            // 
            this.registroCitaToolStripMenuItem.Name = "registroCitaToolStripMenuItem";
            this.registroCitaToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.registroCitaToolStripMenuItem.Tag = "RegistroCita";
            this.registroCitaToolStripMenuItem.Text = "Registro Cita";
            this.registroCitaToolStripMenuItem.Click += new System.EventHandler(this.RegistroCitaToolStripMenuItem_Click);
            // 
            // listarCitaToolStripMenuItem
            // 
            this.listarCitaToolStripMenuItem.Name = "listarCitaToolStripMenuItem";
            this.listarCitaToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.listarCitaToolStripMenuItem.Tag = "ListarCita";
            this.listarCitaToolStripMenuItem.Text = "Lsitar Cita";
            this.listarCitaToolStripMenuItem.Click += new System.EventHandler(this.listarCitaToolStripMenuItem_Click);
            // 
            // pacientesToolStripMenuItem
            // 
            this.pacientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarPacienteToolStripMenuItem,
            this.modificarPacienteToolStripMenuItem,
            this.deshabilitarPacienteToolStripMenuItem,
            this.verPacienteToolStripMenuItem});
            this.pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            this.pacientesToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.pacientesToolStripMenuItem.Tag = "Pacientes";
            this.pacientesToolStripMenuItem.Text = "Pacientes";
            // 
            // agregarPacienteToolStripMenuItem
            // 
            this.agregarPacienteToolStripMenuItem.Name = "agregarPacienteToolStripMenuItem";
            this.agregarPacienteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.agregarPacienteToolStripMenuItem.Tag = "AgregarPaciente";
            this.agregarPacienteToolStripMenuItem.Text = "Agregar Paciente";
            this.agregarPacienteToolStripMenuItem.Click += new System.EventHandler(this.AgregarPacienteToolStripMenuItem_Click);
            // 
            // modificarPacienteToolStripMenuItem
            // 
            this.modificarPacienteToolStripMenuItem.Name = "modificarPacienteToolStripMenuItem";
            this.modificarPacienteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.modificarPacienteToolStripMenuItem.Tag = "ModificarPaciente";
            this.modificarPacienteToolStripMenuItem.Text = "Modificar Paciente";
            this.modificarPacienteToolStripMenuItem.Click += new System.EventHandler(this.ModificarPacienteToolStripMenuItem_Click);
            // 
            // deshabilitarPacienteToolStripMenuItem
            // 
            this.deshabilitarPacienteToolStripMenuItem.Name = "deshabilitarPacienteToolStripMenuItem";
            this.deshabilitarPacienteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.deshabilitarPacienteToolStripMenuItem.Tag = "DeshabilitarPaciente";
            this.deshabilitarPacienteToolStripMenuItem.Text = "Deshabilitar Paciente";
            this.deshabilitarPacienteToolStripMenuItem.Click += new System.EventHandler(this.DeshabilitarPacienteToolStripMenuItem_Click);
            // 
            // verPacienteToolStripMenuItem
            // 
            this.verPacienteToolStripMenuItem.Name = "verPacienteToolStripMenuItem";
            this.verPacienteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.verPacienteToolStripMenuItem.Tag = "ListarPaciente";
            this.verPacienteToolStripMenuItem.Text = "Listar Paciente";
            this.verPacienteToolStripMenuItem.Click += new System.EventHandler(this.VerPacienteToolStripMenuItem_Click);
            // 
            // profesionalesToolStripMenuItem
            // 
            this.profesionalesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProfesionalToolStripMenuItem,
            this.modificarProfesionalToolStripMenuItem,
            this.deshabilitarProfesionalToolStripMenuItem,
            this.verProfesionalToolStripMenuItem});
            this.profesionalesToolStripMenuItem.Name = "profesionalesToolStripMenuItem";
            this.profesionalesToolStripMenuItem.Size = new System.Drawing.Size(115, 25);
            this.profesionalesToolStripMenuItem.Tag = "Profesionales";
            this.profesionalesToolStripMenuItem.Text = "Profesionales";
            // 
            // agregarProfesionalToolStripMenuItem
            // 
            this.agregarProfesionalToolStripMenuItem.Name = "agregarProfesionalToolStripMenuItem";
            this.agregarProfesionalToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.agregarProfesionalToolStripMenuItem.Tag = "AgregarProfesional";
            this.agregarProfesionalToolStripMenuItem.Text = "Agregar Profesional";
            this.agregarProfesionalToolStripMenuItem.Click += new System.EventHandler(this.AgregarProfesionalToolStripMenuItem_Click);
            // 
            // modificarProfesionalToolStripMenuItem
            // 
            this.modificarProfesionalToolStripMenuItem.Name = "modificarProfesionalToolStripMenuItem";
            this.modificarProfesionalToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.modificarProfesionalToolStripMenuItem.Tag = "ModificarProfesional";
            this.modificarProfesionalToolStripMenuItem.Text = "Modificar Profesional";
            this.modificarProfesionalToolStripMenuItem.Click += new System.EventHandler(this.ModificarProfesionalToolStripMenuItem_Click);
            // 
            // deshabilitarProfesionalToolStripMenuItem
            // 
            this.deshabilitarProfesionalToolStripMenuItem.Name = "deshabilitarProfesionalToolStripMenuItem";
            this.deshabilitarProfesionalToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.deshabilitarProfesionalToolStripMenuItem.Tag = "DeshabilitarProfesional";
            this.deshabilitarProfesionalToolStripMenuItem.Text = "Deshabilitar Profesional";
            this.deshabilitarProfesionalToolStripMenuItem.Click += new System.EventHandler(this.DeshabilitarProfesionalToolStripMenuItem_Click);
            // 
            // verProfesionalToolStripMenuItem
            // 
            this.verProfesionalToolStripMenuItem.Name = "verProfesionalToolStripMenuItem";
            this.verProfesionalToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.verProfesionalToolStripMenuItem.Tag = "VerProfesionales";
            this.verProfesionalToolStripMenuItem.Text = "Ver Profesionales";
            this.verProfesionalToolStripMenuItem.Click += new System.EventHandler(this.verProfesionalToolStripMenuItem_Click);
            // 
            // tratamientosToolStripMenuItem
            // 
            this.tratamientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarTratamientoToolStripMenuItem,
            this.etapasTratamientoToolStripMenuItem});
            this.tratamientosToolStripMenuItem.Name = "tratamientosToolStripMenuItem";
            this.tratamientosToolStripMenuItem.Size = new System.Drawing.Size(112, 25);
            this.tratamientosToolStripMenuItem.Tag = "Tratamientos";
            this.tratamientosToolStripMenuItem.Text = "Tratamientos";
            // 
            // agregarTratamientoToolStripMenuItem
            // 
            this.agregarTratamientoToolStripMenuItem.Name = "agregarTratamientoToolStripMenuItem";
            this.agregarTratamientoToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.agregarTratamientoToolStripMenuItem.Tag = "AgregarTratamiento";
            this.agregarTratamientoToolStripMenuItem.Text = "Agregar Tratamiento";
            this.agregarTratamientoToolStripMenuItem.Click += new System.EventHandler(this.AgregarTratamientoToolStripMenuItem_Click);
            // 
            // etapasTratamientoToolStripMenuItem
            // 
            this.etapasTratamientoToolStripMenuItem.Name = "etapasTratamientoToolStripMenuItem";
            this.etapasTratamientoToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.etapasTratamientoToolStripMenuItem.Tag = "EtapasTratamiento";
            this.etapasTratamientoToolStripMenuItem.Text = "Etapas Tratamiento";
            this.etapasTratamientoToolStripMenuItem.Click += new System.EventHandler(this.EtapasTratamientoToolStripMenuItem_Click);
            // 
            // horariosToolStripMenuItem
            // 
            this.horariosToolStripMenuItem.Name = "horariosToolStripMenuItem";
            this.horariosToolStripMenuItem.Size = new System.Drawing.Size(82, 25);
            this.horariosToolStripMenuItem.Tag = "Horarios";
            this.horariosToolStripMenuItem.Text = "Horarios";
            this.horariosToolStripMenuItem.Click += new System.EventHandler(this.HorariosToolStripMenuItem_Click);
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(80, 25);
            this.historialToolStripMenuItem.Tag = "Historial";
            this.historialToolStripMenuItem.Text = "Historial";
            this.historialToolStripMenuItem.Click += new System.EventHandler(this.HistorialToolStripMenuItem_Click);
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignarRolToolStripMenuItem,
            this.crearPatenteToolStripMenuItem,
            this.crearRolToolStripMenuItem,
            this.crearUsuarioToolStripMenuItem,
            this.modificarUsuarioToolStripMenuItem,
            this.mostrarUsuariosToolStripMenuItem,
            this.bakcupToolStripMenuItem,
            this.bitacoraToolStripMenuItem});
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(122, 25);
            this.administradorToolStripMenuItem.Tag = "Administrador";
            this.administradorToolStripMenuItem.Text = "Administrador";
            // 
            // asignarRolToolStripMenuItem
            // 
            this.asignarRolToolStripMenuItem.Name = "asignarRolToolStripMenuItem";
            this.asignarRolToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.asignarRolToolStripMenuItem.Tag = "AsignarRol";
            this.asignarRolToolStripMenuItem.Text = "Asignar Rol";
            this.asignarRolToolStripMenuItem.Click += new System.EventHandler(this.AsignarRolToolStripMenuItem_Click);
            // 
            // crearPatenteToolStripMenuItem
            // 
            this.crearPatenteToolStripMenuItem.Name = "crearPatenteToolStripMenuItem";
            this.crearPatenteToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.crearPatenteToolStripMenuItem.Tag = "CrearPatente";
            this.crearPatenteToolStripMenuItem.Text = "Crear Patente";
            this.crearPatenteToolStripMenuItem.Click += new System.EventHandler(this.CrearPatenteToolStripMenuItem_Click);
            // 
            // crearRolToolStripMenuItem
            // 
            this.crearRolToolStripMenuItem.Name = "crearRolToolStripMenuItem";
            this.crearRolToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.crearRolToolStripMenuItem.Tag = "CrearRol";
            this.crearRolToolStripMenuItem.Text = "CrearRol";
            this.crearRolToolStripMenuItem.Click += new System.EventHandler(this.CrearRolToolStripMenuItem_Click);
            // 
            // crearUsuarioToolStripMenuItem
            // 
            this.crearUsuarioToolStripMenuItem.Name = "crearUsuarioToolStripMenuItem";
            this.crearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.crearUsuarioToolStripMenuItem.Tag = "CrearUsuario";
            this.crearUsuarioToolStripMenuItem.Text = "Crear Usuario";
            this.crearUsuarioToolStripMenuItem.Click += new System.EventHandler(this.CrearUsuarioToolStripMenuItem_Click);
            // 
            // modificarUsuarioToolStripMenuItem
            // 
            this.modificarUsuarioToolStripMenuItem.Name = "modificarUsuarioToolStripMenuItem";
            this.modificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.modificarUsuarioToolStripMenuItem.Tag = "ModificarUsuario";
            this.modificarUsuarioToolStripMenuItem.Text = "Modificar Usuario";
            this.modificarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.ModificarUsuarioToolStripMenuItem_Click);
            // 
            // mostrarUsuariosToolStripMenuItem
            // 
            this.mostrarUsuariosToolStripMenuItem.Name = "mostrarUsuariosToolStripMenuItem";
            this.mostrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.mostrarUsuariosToolStripMenuItem.Tag = "MostrarUsuarios";
            this.mostrarUsuariosToolStripMenuItem.Text = "Mostrar Usuarios";
            this.mostrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.MostrarUsuariosToolStripMenuItem_Click);
            // 
            // bakcupToolStripMenuItem
            // 
            this.bakcupToolStripMenuItem.Name = "bakcupToolStripMenuItem";
            this.bakcupToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.bakcupToolStripMenuItem.Tag = "RealizarBackUp";
            this.bakcupToolStripMenuItem.Text = "Realizar Back Up";
            this.bakcupToolStripMenuItem.Click += new System.EventHandler(this.bakcupToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.bitacoraToolStripMenuItem.Tag = "Bitacora";
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Tag = "Usuario";
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Tag = "Roles";
            this.label3.Text = "Roles:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 5;
            this.button1.Tag = "CerraSesion";
            this.button1.Text = "Cerra sesión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.AllowEditing = false;
            this.sfDataGrid1.AllowFiltering = true;
            this.sfDataGrid1.AutoGenerateColumns = false;
            gridTextColumn1.AllowEditing = false;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.Format = "dd/MM/yyyy";
            gridTextColumn1.HeaderText = "Fecha";
            gridTextColumn1.MappingName = "Fecha";
            gridTextColumn1.Width = 100D;
            gridTextColumn2.AllowEditing = false;
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.HeaderText = "Hora Inicio";
            gridTextColumn2.MappingName = "HoraInicio";
            gridTextColumn2.Width = 100D;
            gridTextColumn3.AllowEditing = false;
            gridTextColumn3.AllowFiltering = true;
            gridTextColumn3.HeaderText = "Nombre Paciente";
            gridTextColumn3.MappingName = "NombrePaciente";
            gridTextColumn3.Width = 150D;
            gridTextColumn4.AllowEditing = false;
            gridTextColumn4.AllowFiltering = true;
            gridTextColumn4.HeaderText = "Nombre Profesional";
            gridTextColumn4.MappingName = "NombreProfesional";
            gridTextColumn4.Width = 150D;
            gridTextColumn5.AllowEditing = false;
            gridTextColumn5.AllowFiltering = true;
            gridTextColumn5.HeaderText = "Nombre Tratamiento";
            gridTextColumn5.MappingName = "NombreTratamiento";
            gridTextColumn5.Width = 150D;
            gridTextColumn6.AllowEditing = false;
            gridTextColumn6.AllowFiltering = true;
            gridTextColumn6.HeaderText = "Nombre Etapa";
            gridTextColumn6.MappingName = "NombreEtapa";
            gridTextColumn6.Width = 150D;
            this.sfDataGrid1.Columns.Add(gridTextColumn1);
            this.sfDataGrid1.Columns.Add(gridTextColumn2);
            this.sfDataGrid1.Columns.Add(gridTextColumn3);
            this.sfDataGrid1.Columns.Add(gridTextColumn4);
            this.sfDataGrid1.Columns.Add(gridTextColumn5);
            this.sfDataGrid1.Columns.Add(gridTextColumn6);
            this.sfDataGrid1.Location = new System.Drawing.Point(12, 126);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.Size = new System.Drawing.Size(747, 226);
            this.sfDataGrid1.TabIndex = 6;
            this.sfDataGrid1.Text = "sfDataGrid1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 18);
            this.label5.TabIndex = 7;
            this.label5.Tag = "Resumendecitasdehoy";
            this.label5.Text = "Resumen de citas de hoy:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources._2546743;
            this.pictureBox1.Location = new System.Drawing.Point(715, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(529, 380);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 69);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Gestión Clínica";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
       
        private void NuevaCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show New Appointment Form
            var form = new NuevaCitaForm();
            form.Show();
        }

        private void RegistroCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Appointment Registration Form
            var form = new RegistroCitaForm();
            form.Show();
        }
        private void listarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ListarCitasForm();
            form.Show();
        }


        private void AgregarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Add Patient Form
            var form = new AgregarPacienteForm();
            form.Show();
        }

        private void ModificarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Modify Patient Form
            var form = new ModPacienteForm();
            form.Show();
        }

        private void DeshabilitarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Disable Patient Form
            var form = new DeshPacienteForm();
            form.Show();
        }
        private void VerPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Disable Patient Form
            var form = new VerPacienteForm();
            form.Show();
        }
        private void AgregarProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Add Professional Form
            var form = new AgregarProfesionalForm();
            form.Show();
        }

        private void ModificarProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Modify Professional Form
            var form = new ModProfesionalForm();
            form.Show();
        }

        private void DeshabilitarProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Disable Professional Form
            var form = new DeshProfesionalForm();
            form.Show();
        }

   
        private void verProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Disable Professional Form
            var form = new VerProfesionalForm();
            form.Show();
        }
        private void AgregarTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Add Treatment Form
            var form = new AgregarTratamientoForm();
            form.Show();
        }

        private void EtapasTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Treatment Stages Form
            var form = new EtapasTratamientoForm();
            form.Show();
        }

        private void HorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Schedules Form
            var form = new HorariosForm();
            form.Show();
        }

        private void HistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show History Form
            var form = new HistorialForm();
            form.Show();
        }
        private void AsignarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario AsignarRolForm
            var form = new AsignarRolForm();
            form.Show();
        }

        private void CrearPatenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario CrearPatenteForm
            var form = new CrearPatenteForm();
            form.Show();
        }

        private void CrearRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario CrearRolForm
            var form = new CrearRolForm();
            form.Show();
        }

        private void CrearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario CrearUsuarioForm
            var form = new CrearUsuarioForm();
            form.Show();
        }

        private void ModificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario ModificarUsuarioForm
            var form = new ModificarUsuarioForm();
            form.Show();
        }

        private void MostrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario MostrarUsuariosForm
            var form = new MostrarUsuariosForm();
            form.Show();
        }
        private void bakcupToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            var form = new BackUpForm();
            form.Show();
        }
        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var form = new BitacoraForm();
            form.Show();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem citasToolStripMenuItem;
        private ToolStripMenuItem nuevaCitaToolStripMenuItem;
        private ToolStripMenuItem registroCitaToolStripMenuItem;
        private ToolStripMenuItem listarCitaToolStripMenuItem;
        private ToolStripMenuItem pacientesToolStripMenuItem;
        private ToolStripMenuItem agregarPacienteToolStripMenuItem;
        private ToolStripMenuItem modificarPacienteToolStripMenuItem;
        private ToolStripMenuItem verPacienteToolStripMenuItem;
        private ToolStripMenuItem deshabilitarPacienteToolStripMenuItem;
        private ToolStripMenuItem profesionalesToolStripMenuItem;
        private ToolStripMenuItem agregarProfesionalToolStripMenuItem;
        private ToolStripMenuItem modificarProfesionalToolStripMenuItem;
        private ToolStripMenuItem deshabilitarProfesionalToolStripMenuItem;
        private ToolStripMenuItem verProfesionalToolStripMenuItem;
        private ToolStripMenuItem tratamientosToolStripMenuItem;
        private ToolStripMenuItem agregarTratamientoToolStripMenuItem;
        private ToolStripMenuItem etapasTratamientoToolStripMenuItem;
        private ToolStripMenuItem horariosToolStripMenuItem;
        private ToolStripMenuItem historialToolStripMenuItem;
        private ToolStripMenuItem administradorToolStripMenuItem;
        private ToolStripMenuItem asignarRolToolStripMenuItem;
        private ToolStripMenuItem crearPatenteToolStripMenuItem;
        private ToolStripMenuItem crearRolToolStripMenuItem;
        private ToolStripMenuItem crearUsuarioToolStripMenuItem;
        private ToolStripMenuItem modificarUsuarioToolStripMenuItem;
        private ToolStripMenuItem mostrarUsuariosToolStripMenuItem;
        private ToolStripMenuItem bakcupToolStripMenuItem;
        private ToolStripMenuItem bitacoraToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private SfDataGrid sfDataGrid1;
        private Label label5;
        private PictureBox pictureBox1;
        private ListBox listBox1;
    }
}