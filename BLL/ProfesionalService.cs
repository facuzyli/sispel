using DAL;
using DAL.Factory;
using DAL.Contracts;
using DOMAIN;
using Service.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.Implementations.SqlServer;
using DAL.Implementations.PDFs;
using BLL.Exceptions;

namespace BLL
{
    /// <summary>
    /// Clase de servicio para la gestión de profesionales, que incluye la creación,
    /// modificación, deshabilitación y obtención de información de profesionales.
    /// </summary>
    public class ProfesionalService
    {
        private readonly IProfesionalRepository _profesionalRepository;

        /// <summary>
        /// Constructor que inicializa el repositorio de profesionales.
        /// </summary>
        public ProfesionalService()
        {
            _profesionalRepository = FactoryDAL.SqlProfesionalRepository;
        }

        /// <summary>
        /// Crea un nuevo profesional después de validar la información proporcionada.
        /// </summary>
        /// <param name="profesional">El objeto profesional a crear.</param>
        /// <exception cref="ArgumentException">Se lanza si la validación falla.</exception>
        public void CrearProfesional(Profesional profesional)
        {
            ValidarProfesional(profesional);
            _profesionalRepository.Add(profesional);
        }

        /// <summary>
        /// Valida la información de un profesional para asegurar que todos los campos obligatorios
        /// estén completos y cumplan con los formatos requeridos.
        /// </summary>
        /// <param name="profesional">El objeto profesional a validar.</param>
        /// <exception cref="ArgumentException">Se lanza si algún campo es inválido.</exception>
        private void ValidarProfesional(Profesional profesional)
        {
            if (string.IsNullOrWhiteSpace(profesional.Nombre) ||
                string.IsNullOrWhiteSpace(profesional.Apellido) ||
                string.IsNullOrWhiteSpace(profesional.Direccion) ||
                string.IsNullOrWhiteSpace(profesional.Telefono) ||
                string.IsNullOrWhiteSpace(profesional.Mail) ||
                string.IsNullOrWhiteSpace(profesional.Especializacion))
            {

                throw ProfesionalException.CamposInvalidos();
            }

            if (!Regex.IsMatch(profesional.Mail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                throw ProfesionalException.CorreoInvalido();
            }

            if (!Regex.IsMatch(profesional.Telefono, @"^\d{10}$"))
            {
                throw ProfesionalException.TelefonoInvalido();
            }
        }

        /// <summary>
        /// Modifica un profesional existente después de validar la información.
        /// </summary>
        /// <param name="profesional">El objeto profesional a modificar.</param>
        /// <exception cref="ArgumentException">Se lanza si la validación falla.</exception>
        public void ModificarProfesional(Profesional profesional)
        {
            ValidarProfesional(profesional);
            _profesionalRepository.Update(profesional);
        }

        /// <summary>
        /// Deshabilita a un profesional identificado por su ID.
        /// </summary>
        /// <param name="idProfesional">El ID del profesional a deshabilitar.</param>
        public void DeshabilitarProfesional(Guid idProfesional)
        {
            _profesionalRepository.Remove(idProfesional);
        }

        /// <summary>
        /// Obtiene una lista de todos los profesionales.
        /// </summary>
        /// <returns>Lista de profesionales.</returns>
        public List<Profesional> ObtenerTodosProfesionales()
        {
            return _profesionalRepository.GetAll();
        }

        /// <summary>
        /// Obtiene un profesional por su ID.
        /// </summary>
        /// <param name="id">El ID del profesional a obtener.</param>
        /// <returns>El objeto profesional.</returns>
        public Profesional ObtenerProfesionalPorId(Guid id)
        {
            return _profesionalRepository.ObtenerProfesionalPorId(id);
        }

        /// <summary>
        /// Obtiene el nombre completo de un profesional por su ID.
        /// </summary>
        /// <param name="idProfesional">El ID del profesional.</param>
        /// <returns>El nombre completo del profesional.</returns>
        public string ObetenerNombrePorId(Guid idProfesional)
        {
            return _profesionalRepository.ObtenerNombreCompletoPorId(idProfesional);
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
