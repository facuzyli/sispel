using DAL;
using DAL.Factory;
using DAL.Implementations.PDFs;
using DOMAIN;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Implementations.SqlServer;
using BLL.Exceptions;


namespace BLL
{
    /// <summary>
    /// Clase de servicio para la gestión de pacientes, que incluye la creación,
    /// modificación, deshabilitación y obtención de información de pacientes.
    /// </summary>
    public class PacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        /// <summary>
        /// Constructor que inicializa el repositorio de pacientes.
        /// </summary>
        public PacienteService()
        {
            _pacienteRepository = FactoryDAL.SqlPacienteRepository;
        }

        /// <summary>
        /// Crea un nuevo paciente después de validar la información proporcionada.
        /// </summary>
        /// <param name="paciente">El objeto paciente a crear.</param>
        /// <exception cref="ArgumentException">Se lanza si la validación falla.</exception>
        public void CrearPaciente(Paciente paciente)
        {
            ValidarPaciente(paciente);
            _pacienteRepository.Add(paciente);
        }

        /// <summary>
        /// Valida la información de un paciente para asegurar que todos los campos obligatorios
        /// estén completos y cumplan con los formatos requeridos.
        /// </summary>
        /// <param name="paciente">El objeto paciente a validar.</param>
        /// <exception cref="ArgumentException">Se lanza si algún campo es inválido.</exception>
        private void ValidarPaciente(Paciente paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.Nombre) ||
                string.IsNullOrWhiteSpace(paciente.Apellido) ||
                string.IsNullOrWhiteSpace(paciente.Direccion) ||
                string.IsNullOrWhiteSpace(paciente.Telefono) ||
                string.IsNullOrWhiteSpace(paciente.Mail) ||
                string.IsNullOrWhiteSpace(paciente.Medicamentos) ||
                string.IsNullOrWhiteSpace(paciente.Alergias))
            {

                throw PacienteException.CamposInvalidos();
            }

            if (!Regex.IsMatch(paciente.Mail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {

                throw PacienteException.CorreoInvalido();
            }

            if (!Regex.IsMatch(paciente.Telefono, @"^\d{10}$"))
            {

                throw PacienteException.TelefonoInvalido();
            }
        }

        /// <summary>
        /// Modifica un paciente existente después de validar la información.
        /// </summary>
        /// <param name="paciente">El objeto paciente a modificar.</param>
        /// <exception cref="ArgumentException">Se lanza si la validación falla.</exception>
        public void ModificarPaciente(Paciente paciente)
        {
            ValidarPaciente(paciente);
            _pacienteRepository.Update(paciente);
        }

        /// <summary>
        /// Deshabilita a un paciente identificado por su ID.
        /// </summary>
        /// <param name="idPaciente">El ID del paciente a deshabilitar.</param>
        public void DeshabilitarPaciente(Guid idPaciente)
        {
            _pacienteRepository.Disable(idPaciente);
        }

        /// <summary>
        /// Obtiene una lista de todos los pacientes.
        /// </summary>
        /// <returns>Lista de pacientes.</returns>
        public List<Paciente> ObtenerTodosPacientes()
        {
            return _pacienteRepository.GetAll();
        }

        /// <summary>
        /// Obtiene un paciente por su ID.
        /// </summary>
        /// <param name="idPaciente">El ID del paciente a obtener.</param>
        /// <returns>El objeto paciente.</returns>
        public Paciente ObtenerPacientePorId(Guid idPaciente)
        {
            return _pacienteRepository.GetById(idPaciente);
        }

        /// <summary>
        /// Obtiene el nombre completo de un paciente por su ID.
        /// </summary>
        /// <param name="idPaciente">El ID del paciente.</param>
        /// <returns>El nombre completo del paciente.</returns>
        public string ObtenerNombreCompletoPorId(Guid idPaciente)
        {
            return _pacienteRepository.GetNombreCompletoById(idPaciente);
        }

        /// <summary>
        /// Traduce una clave de mensaje a un texto en el idioma apropiado.
        /// </summary>
        /// <param name="messageKey">La clave del mensaje a traducir.</param>
        /// <returns>El mensaje traducido.</returns>
        private string TranslateMessageKey(string messageKey)
        {
            return IdiomaService.Translate(messageKey);
        }
    }

}

