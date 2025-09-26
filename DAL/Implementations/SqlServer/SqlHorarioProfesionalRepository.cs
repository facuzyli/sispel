using DAL.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DOMAIN.DTO;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Clase que implementa la interfaz IHorarioProfesional para realizar operaciones CRUD sobre los horarios profesionales en la base de datos.
    /// </summary>
    public class SqlHorarioProfesionalRepository : IHorarioProfesional
    {
        /// <summary>
        /// Inserta un nuevo horario profesional en la base de datos.
        /// </summary>
        /// <param name="horario">El objeto HorarioProfesional a insertar.</param>
        public void Add(HorarioProfesional horario)
        {
            var query = @"INSERT INTO HorariosProfesionales (IdHorario, Id_Profesional, Fecha, HoraInicio, HoraFin, Id_Cita, Estado)
                  VALUES (@IdHorario, @IdProfesional, @Fecha, @HoraInicio, @HoraFin, @IdCita, @Estado)";

            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@IdHorario", horario.IdHorario),
            new SqlParameter("@IdProfesional", horario.Id_Profesional),
            new SqlParameter("@Fecha", horario.Fecha),
            new SqlParameter("@HoraInicio", horario.HoraInicio),
            new SqlParameter("@HoraFin", horario.HoraFin),
            new SqlParameter("@IdCita", horario.Id_Cita),
            new SqlParameter("@Estado", 1)
        };

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Obtiene todos los horarios profesionales de la base de datos. Este método no está implementado.
        /// </summary>
        /// <returns>Lista de objetos HorarioProfesional.</returns>
        public List<HorarioProfesional> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un horario profesional por su ID. Este método no está implementado.
        /// </summary>
        /// <param name="id">El ID del horario profesional.</param>
        /// <returns>El objeto HorarioProfesional correspondiente.</returns>
        public HorarioProfesional GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elimina un horario profesional por su ID. Este método no está implementado.
        /// </summary>
        /// <param name="id">El ID del horario profesional a eliminar.</param>
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza un horario profesional. Este método no está implementado.
        /// </summary>
        /// <param name="obj">El objeto HorarioProfesional con los datos actualizados.</param>
        public void Update(HorarioProfesional obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene los horarios ocupados de un profesional en una fecha específica. Este método no está implementado.
        /// </summary>
        /// <param name="profesionalId">El ID del profesional.</param>
        /// <param name="fecha">La fecha de los horarios a consultar.</param>
        /// <returns>Lista de objetos HorarioProfesional ocupados.</returns>
        public List<HorarioProfesional> ObtenerHorariosOcupadosPorProfesional1(Guid profesionalId, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene los detalles de la cita para un profesional en una fecha específica.
        /// </summary>
        /// <param name="profesionalId">El ID del profesional.</param>
        /// <param name="fecha">La fecha de las citas a consultar.</param>
        /// <returns>Lista de objetos HorarioProfesionalDto con los detalles de la cita.</returns>
        public List<HorarioProfesionalDto> ObtenerDetallesCitaPorProfesional(Guid profesionalId, DateTime fecha)
        {
            var query = @"
            SELECT hp.HoraInicio, p.Nombre AS NombrePaciente, t.Nombre AS NombreTratamiento, 
                   p.Telefono, e.Duracion AS DuracionEtapa
            FROM HorariosProfesionales hp
            INNER JOIN Cita c ON hp.Id_Cita = c.Id_Cita
            INNER JOIN Pacientes p ON c.Id_Paciente = p.Id_Paciente
            INNER JOIN Tratamientos t ON c.Id_Tratamiento = t.Id
            INNER JOIN EtapasTratamiento e ON c.Id_EtapaTratamiento = e.Id
            WHERE hp.Id_Profesional = @IdProfesional AND hp.Fecha = @Fecha";

            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@IdProfesional", profesionalId),
            new SqlParameter("@Fecha", fecha.Date)
        };

            var listaHorarios = new List<HorarioProfesionalDto>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    var horarioDto = new HorarioProfesionalDto
                    {
                        HoraInicio = TimeSpan.Parse(reader["HoraInicio"].ToString()),
                        NombrePaciente = reader["NombrePaciente"].ToString(),
                        NombreTratamiento = reader["NombreTratamiento"].ToString(),
                        TelefonoPaciente = reader["Telefono"].ToString(),
                        DuracionEtapa = int.Parse(reader["DuracionEtapa"].ToString())
                    };

                    listaHorarios.Add(horarioDto);
                }
            }

            return listaHorarios;
        }

        /// <summary>
        /// Obtiene los horarios ocupados de un profesional en una fecha específica.
        /// </summary>
        /// <param name="profesionalId">El ID del profesional.</param>
        /// <param name="fecha">La fecha de los horarios a consultar.</param>
        /// <returns>Lista de objetos TimeSpan que representan los horarios ocupados.</returns>
        public List<TimeSpan> ObtenerHorariosOcupadosPorProfesional(Guid profesionalId, DateTime fecha)
        {
            var query = @"SELECT HoraInicio, HoraFin FROM HorariosProfesionales 
                      WHERE Id_Profesional = @IdProfesional AND Fecha = @Fecha AND Estado = 1";

            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@IdProfesional", profesionalId),
            new SqlParameter("@Fecha", fecha.Date)
        };

            var horasOcupadas = new List<TimeSpan>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    // Leer la hora de inicio
                    var horaInicioString = reader["HoraInicio"].ToString();
                    if (TimeSpan.TryParse(horaInicioString, out TimeSpan horaInicio))
                    {
                        horasOcupadas.Add(horaInicio); // Agregar hora de inicio ocupada
                    }

                    // Leer la hora de fin
                    var horaFinString = reader["HoraFin"].ToString();
                    if (TimeSpan.TryParse(horaFinString, out TimeSpan horaFin))
                    {
                        // Calcular la duración
                        var duracion = (horaFin - horaInicio).TotalHours;

                        // Agregar horas ocupadas según la duración
                        if (duracion == 1)
                        {
                            horasOcupadas.Add(horaInicio); // Solo agrega la hora de inicio
                        }
                        else if (duracion >= 2)
                        {
                            // Agrega horas intermedias según sea necesario
                            for (var hora = horaInicio; hora < horaFin; hora = hora.Add(TimeSpan.FromHours(1)))
                            {
                                horasOcupadas.Add(hora);
                            }
                        }
                    }
                }
            }

            return horasOcupadas.Distinct().ToList(); // Asegurarse de que no haya duplicados
        }
    }

}
    

    
       
     
       
    

        
    

