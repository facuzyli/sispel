using DAL;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Implementations.SqlServer;
using DAL.Implementations.PDFs;

namespace BLL
{
    /// <summary>
    /// Servicio para gestionar la generación y validación de horarios.
    /// </summary>
    public class HorarioService
    {
        /// <summary>
        /// Genera una lista de horarios fijos predefinidos.
        /// </summary>
        /// <returns>Una lista de horarios con horas fijas.</returns>
        public List<Horario> GenerarHorasFijas()
        {
            return new List<Horario>
        {
            new Horario { Hora = TimeSpan.Parse("08:00") },
            new Horario { Hora = TimeSpan.Parse("09:00") },
            new Horario { Hora = TimeSpan.Parse("10:00") },
            new Horario { Hora = TimeSpan.Parse("11:00") },
            new Horario { Hora = TimeSpan.Parse("13:00") },
            new Horario { Hora = TimeSpan.Parse("14:00") },
            new Horario { Hora = TimeSpan.Parse("15:00") }
        };
        }

        /// <summary>
        /// Obtiene una lista de horas válidas dentro de un rango específico.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="TimeSpan"/> que representan las horas válidas.</returns>
        public List<TimeSpan> ObtenerHorasValidas()
        {
            var horasValidas = new List<TimeSpan>();

            // Añadir horas de 8 a 12 (excluyendo 12)
            for (int hour = 8; hour < 12; hour++)
            {
                horasValidas.Add(new TimeSpan(hour, 0, 0));
            }

            // Añadir horas de 13 a 16 (incluyendo 13)
            for (int hour = 13; hour <= 16; hour++)
            {
                horasValidas.Add(new TimeSpan(hour, 0, 0));
            }

            return horasValidas;
        }

        /// <summary>
        /// Verifica si una hora específica es válida.
        /// </summary>
        /// <param name="hora">La hora a validar.</param>
        /// <returns><c>true</c> si la hora es válida; de lo contrario, <c>false</c>.</returns>
        public bool EsHoraValida(TimeSpan hora)
        {
            var horasValidas = ObtenerHorasValidas();
            return horasValidas.Contains(hora);
        }

        /// <summary>
        /// Combina una fecha y una hora en un solo objeto <see cref="DateTime"/>.
        /// </summary>
        /// <param name="fecha">La fecha a combinar.</param>
        /// <param name="hora">La hora a combinar.</param>
        /// <returns>Un objeto <see cref="DateTime"/> que representa la combinación de la fecha y la hora.</returns>
        public DateTime CombinarFechaHora(DateTime fecha, TimeSpan hora)
        {
            return fecha.Date.Add(hora);
        }
    }
}
