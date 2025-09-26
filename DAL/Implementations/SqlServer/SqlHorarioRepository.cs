using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Clase que maneja las operaciones relacionadas con los horarios de los profesionales.
    /// </summary>
    public class SqlHorarioRepository
    {
        /// <summary>
        /// Obtiene los horarios disponibles para un profesional específico, simulando intervalos de una hora
        /// entre las 9 AM y las 5 PM del día actual.
        /// </summary>
        /// <param name="idProfesional">El identificador único del profesional cuyo horario se quiere obtener.</param>
        /// <returns>Una lista de objetos <see cref="HorarioProfesional"/> que representan los horarios disponibles.</returns>
        public List<HorarioProfesional> ObtenerHorariosPorProfesional(Guid idProfesional)
        {
            List<HorarioProfesional> horarios = new List<HorarioProfesional>();

            // Simulamos la carga de horarios con intervalos de 1 hora
            DateTime fechaActual = DateTime.Now.Date; // Fecha actual sin la parte de la hora
            TimeSpan horaInicio = new TimeSpan(9, 0, 0); // Hora de inicio (9 AM)
            TimeSpan horaFin = new TimeSpan(17, 0, 0); // Hora de fin (5 PM)

            // Se genera una lista de horarios con intervalos de 1 hora
            for (TimeSpan hora = horaInicio; hora < horaFin; hora = hora.Add(new TimeSpan(1, 0, 0)))
            {
                HorarioProfesional horario = new HorarioProfesional
                {
                    IdHorario = Guid.NewGuid(), // Se genera un nuevo identificador único para cada horario
                    Id_Profesional = idProfesional, // Se asigna el identificador del profesional
                    Fecha = fechaActual, // Se asigna la fecha actual
                    HoraInicio = hora, // Se asigna la hora de inicio
                    HoraFin = hora.Add(new TimeSpan(1, 0, 0)), // Se asigna la hora de fin (una hora después de la hora de inicio)
                };

                // Se agrega el horario a la lista
                horarios.Add(horario);
            }

            // Se retorna la lista de horarios generados
            return horarios;
        }
    }
}
