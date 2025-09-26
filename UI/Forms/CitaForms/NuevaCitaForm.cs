using BLL;
using DOMAIN;
using DOMAIN.DTO;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class NuevaCitaForm : Form
    {
        private readonly PacienteService _pacienteService;
        private readonly ProfesionalService _profesionalService;
        private readonly TratamientoService _tratamientoService;
        private readonly CitaService _citaService;
        private readonly HorariosProfesionalService _horariosProfesionalService;
        private EtapaTratamiento _etapaSeleccionada;
        private int _duracionEtapa;
        private Profesional _profesionalSeleccionado;
        private Paciente _pacienteSeleccionado;
        private Tratamiento _tratamientoSeleccionado;
        private EtapaDto _etapatratamientoSeleccionado;

        public NuevaCitaForm()
        {
            InitializeComponent();
            _profesionalService = new ProfesionalService();
            _tratamientoService = new TratamientoService();
            _pacienteService = new PacienteService();
            _horariosProfesionalService = new HorariosProfesionalService();
            _citaService = new CitaService();
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarProfesionales();
            CargarPacientes();
            CargarTratamientos();
            this.KeyPreview = true;
            this.KeyDown += NuevaCitaForm_KeyDown;

            // Cargar datos iniciales



        }
        private void NuevaCitaFrom_Load(object sender, EventArgs e)
        {
            dateTimePickerFecha.ValueChanged += dateTimePickerFecha_ValueChanged_1;
            sfComboBoxProfesional.SelectedIndexChanged += sfComboBoxProfesional_SelectedIndexChanged;
        }
        private void CargarTratamientos()
        {
            var trataminetos = _tratamientoService.ObtenerTodosTratamientos();
            sfComboBoxTratamiento.DataSource = trataminetos;
            sfComboBoxTratamiento.DisplayMember = "NombreCompleto"; // Concatenar Nombre y Apellido
            sfComboBoxTratamiento.ValueMember = "Nombre";

        }
        private void CargarProfesionales()
        {
            var profesionales = _profesionalService.ObtenerTodosProfesionales();
            sfComboBoxProfesional.DataSource = profesionales.Where(p => p.Activo).ToList(); // Solo profesionales activos
            sfComboBoxProfesional.DisplayMember = "NombreCompleto"; // Concatenar Nombre y Apellido
            sfComboBoxProfesional.ValueMember = "Id_Profesional";
        }
        private void CargarPacientes()
        {
            var pacientes = _pacienteService.ObtenerTodosPacientes();
            sfComboBoxPaciente.DataSource = pacientes.Where(p => p.Activo).ToList(); // Solo pacientes activos
            sfComboBoxPaciente.DisplayMember = "NombreCompleto"; // Concatenar Nombre y Apellido
            sfComboBoxPaciente.ValueMember = "Id_Paciente";
        }
       

        private void sfComboBoxPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void buttonCrearCita_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos antes de proceder
                if (!ValidarCampos())
                {
                    return; // Salir si la validación falla
                }

                // Obtener fecha y hora
                var fecha = dateTimePickerFecha.Value;
                var hora = TimeSpan.Parse(comboBox1.SelectedItem.ToString());
                TimeSpan horaInicio = hora; // Usar directamente la hora seleccionada
                TimeSpan horaFin = horaInicio.Add(TimeSpan.FromHours(_duracionEtapa));

                // Obtener tratamientos y profesionales seleccionados
                _tratamientoSeleccionado = sfComboBoxTratamiento.SelectedItem as Tratamiento;
                _profesionalSeleccionado = sfComboBoxProfesional.SelectedItem as Profesional;
                _pacienteSeleccionado = sfComboBoxPaciente.SelectedItem as Paciente;
                _etapatratamientoSeleccionado = sfComboBoxEtapa.SelectedItem as EtapaDto;

                var fechaHora = fecha.Date.Add(hora);

                var cita = new Cita
                {
                    Fecha = fechaHora,
                    Id_Paciente = _pacienteSeleccionado.Id_Paciente,
                    Id_Profesional = _profesionalSeleccionado.Id_Profesional, // obtener el id del profesional
                    Id_Tratamiento = _tratamientoSeleccionado.Id, // obtener el id del tratamiento
                    Id_EtapaTratamiento = _etapatratamientoSeleccionado.Id, // obtener el id de la etapa del tratamiento
                    Estado = EstadoCita.Programada
                };

                // Crear el horario ocupado para el profesional
                HorarioProfesional horarioOcupado = new HorarioProfesional
                {
                    IdHorario = Guid.NewGuid(),
                    Id_Profesional = _profesionalSeleccionado.Id_Profesional,
                    Fecha = fecha,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin, // 1 hora después
                    Id_Cita = cita.Id_Cita, // Asocia la cita con el horario
                    Estado = EstadoHorarios.Ocupado
                };

                // Validar y agregar el horario ocupado
                if (_horariosProfesionalService.EsHorarioDisponible(_profesionalSeleccionado.Id_Profesional, fecha, horaInicio))
                {
                    // Agregar la cita (puedes hacer esto desde tu servicio de citas si ya lo tienes)
                    _citaService.CrearCita(cita);

                    // Agregar el horario ocupado
                    _horariosProfesionalService.AgregarHorarioOcupado(horarioOcupado);

                    LoggerService.WriteLog($"Se creo un cita para el paciente {_pacienteSeleccionado.NombreCompleto} A la hora {horarioOcupado.HoraInicio} En la Fecha {horarioOcupado.Fecha} .Por el usuario: {SesionService.UsuarioLogueado.UserName}", System.Diagnostics.TraceLevel.Info);
                    LoggerService.WriteLog($"Se agrego un horario para el profesional {_profesionalSeleccionado.NombreCompleto} A la hora {horarioOcupado.HoraInicio} En la Fecha {horarioOcupado.Fecha}", System.Diagnostics.TraceLevel.Info);
                    string messageKey = "Cita y horario agregado correctamente.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                    LimpiarFormularioCita();
                }
                else
                {
                  
                    string messageKey = "El horario ya está ocupado, seleccione otro.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                }
               
            }
            catch (ArgumentException ex)
            {
               
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                LoggerService.WriteException(ex);
                
            }


        }



        private bool ValidarCampos()
        {
            if (sfComboBoxTratamiento.SelectedItem == null)
            {
                string messageKey = "Por favor, seleccione un tratamiento.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                return false;
            }

            if (sfComboBoxProfesional.SelectedItem == null)
            {
                string messageKey = "Por favor, seleccione un profesional.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                return false;
            }

            if (sfComboBoxPaciente.SelectedItem == null)
            {
                string messageKey = "Por favor, seleccione un paciente.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                return false;
            }

            if (sfComboBoxEtapa.SelectedItem == null)
            {
                string messageKey = "Por favor, seleccione una etapa del tratamiento.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                return false;
            }

            if (comboBox1.SelectedItem == null)
            {
                string messageKey = "Por favor, seleccione una hora.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                return false;
            }

            return true; // Todos los campos son válidos
        }


        private void CargarHorasComboBox()
        {
            _profesionalSeleccionado = sfComboBoxProfesional.SelectedItem as Profesional;
            _tratamientoSeleccionado = sfComboBoxTratamiento.SelectedItem as Tratamiento;
            
            try
            {
                // Verifica que todos los objetos necesarios estén inicializados
                if (_profesionalSeleccionado == null)
                {
                    string messageKey = "Seleccione un profesional.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_tratamientoSeleccionado == null)
                {
                    string messageKey = "Seleccione un tratamiento.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_etapaSeleccionada == null)
                {
                    string messageKey = "Seleccione una etapa.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener la duración de la etapa seleccionada
                _duracionEtapa = _tratamientoService.ObtenerDuracionEtapa(_etapaSeleccionada.Id);
                DateTime fecha = dateTimePickerFecha.Value.Date;

                // Llamar al servicio para obtener horas disponibles
                var horasDisponibles = _horariosProfesionalService.ObtenerHorasDisponibles(_profesionalSeleccionado.Id_Profesional, fecha, _duracionEtapa);

                // Limpiar el ComboBox antes de agregar los nuevos ítems
                comboBox1.Items.Clear();

                // Agregar las horas disponibles al ComboBox
                foreach (var hora in horasDisponibles)
                {
                    // Convertir TimeSpan a formato de cadena (por ejemplo, "08:00")
                    comboBox1.Items.Add(hora.ToString(@"hh\:mm"));
                }

                // Seleccionar la primera hora como predeterminada, si es necesario
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerService.WriteException(ex);
            }
        }

        private void sfComboBoxTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sfComboBoxTratamiento.SelectedItem != null)
            {
                // Castea el SelectedItem a Tratamiento
                _tratamientoSeleccionado = sfComboBoxTratamiento.SelectedItem as Tratamiento;

                // Verifica que el tratamiento seleccionado no sea nulo
                if (_tratamientoSeleccionado != null)
                {
                    // Obtén el ID del tratamiento seleccionado
                    var tratamientoId = _tratamientoSeleccionado.Id;

                    // Llama al servicio para obtener las etapas del tratamiento seleccionado
                    var etapas = _tratamientoService.ObtenerEtapasPorTratamiento(tratamientoId);

                    // Cargar las etapas en el ComboBox
                    CargarEtapasEnComboBox(etapas);
                }
                else
                {
                    string messageKey = "El tratamiento seleccionado es inválido.";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            }
        }
        private void CargarEtapasEnComboBox(List<EtapaDto> etapas)
        {
            // Limpia el ComboBox antes de cargar nuevos datos
            sfComboBoxEtapa.DataSource = null;

            if (etapas.Any())
            {
                // Asigna la lista de etapas al DataSource del ComboBox
                sfComboBoxEtapa.DataSource = etapas;
                sfComboBoxEtapa.DisplayMember = "Nombre";  // El nombre que se mostrará en el ComboBox
                sfComboBoxEtapa.ValueMember = "Id";  // El valor asociado a cada elemento
            }
            else
            {
                string messageKey = "No se encontraron etapas para el tratamiento seleccionado";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage);
                // Muestra un mensaje si no se encontraron etapas
                
            }
        }
     

        private void sfComboBoxProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarHorasComboBox();
        }

        private void dateTimePickerFecha_ValueChanged_1(object sender, EventArgs e)
        {
           
            CargarHorasComboBox();
        }

        private void sfComboBoxEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sfComboBoxEtapa.SelectedIndex == -1)
                return;
            if (sfComboBoxEtapa.SelectedItem is EtapaDto etapaSeleccionadaDto)
            {
                // Usa el Id del EtapaDto para obtener el objeto EtapaTratamiento
                var etapaSeleccionada = _tratamientoService.ObtenerEtapaPorId(etapaSeleccionadaDto.Id);

                if (etapaSeleccionada != null)
                {
                    _etapaSeleccionada = etapaSeleccionada;
                    // Llama a CargarHorasComboBox para actualizar el ComboBox de horas disponibles
                   
                }
                else
                {
                    string messageKey = "No se encontraron etapas para el tratamiento seleccionado";
                    string translatedMessage = TranslateMessageKey(messageKey);
                    MessageBox.Show(translatedMessage);
                }
            }
            else
            {
                string messageKey = "Seleccione una etapa válida.";
                string translatedMessage = TranslateMessageKey(messageKey);
                MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }

        private void NuevaCitaForm_Load(object sender, EventArgs e)
        {
            IdiomaService.TranslateForm(this);
        }
        private void NuevaCitaForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    ManualService manualService = new ManualService();
                    manualService.AbrirAyudaAltaCita();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error");
                LoggerService.WriteException(ex);
            }

        }
        private void LimpiarFormularioCita()
        {
            dateTimePickerFecha.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            sfComboBoxTratamiento.SelectedIndex = -1;
            sfComboBoxProfesional.SelectedIndex = -1;
            sfComboBoxPaciente.SelectedIndex = -1;
            sfComboBoxEtapa.SelectedIndex = -1;
            _tratamientoSeleccionado = null;
            _profesionalSeleccionado = null;
            _pacienteSeleccionado = null;
            _etapaSeleccionada = null;
        }
    }
}
