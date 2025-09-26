using DAL.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN.DTO;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para gestionar las operaciones de la entidad Cita en la base de datos.
    /// </summary>
    public class SqlCitaRepository : ICitaRepository
    {
        
        /// <summary>
        /// Agrega una nueva cita a la base de datos.
        /// </summary>
        /// <param name="cita">Objeto Cita que contiene los datos a agregar.</param>
        public void Add(Cita cita)
        {
            string query = @"INSERT INTO Cita (Id_Cita, Fecha, Id_Paciente, Id_Profesional, Id_Tratamiento, Id_EtapaTratamiento, Estado) 
                         VALUES (@Id_Cita, @Fecha, @Id_Paciente, @Id_Profesional, @Id_Tratamiento, @Id_EtapaTratamiento, @Estado)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Cita", cita.Id_Cita),
            new SqlParameter("@Fecha", cita.Fecha),
            new SqlParameter("@Id_Paciente", cita.Id_Paciente),
            new SqlParameter("@Id_Profesional", cita.Id_Profesional),
            new SqlParameter("@Id_Tratamiento", cita.Id_Tratamiento),
            new SqlParameter("@Id_EtapaTratamiento", cita.Id_EtapaTratamiento),
            new SqlParameter("@Estado", (int)cita.Estado) // Convertir el enum a entero
            };

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }
        /// <summary>
        /// Obtiene una lista de todas las citas desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Cita.</returns>
        public List<Cita> GetAll()
        {
            List<Cita> citas = new List<Cita>();

            string query = "SELECT * FROM Cita";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    Cita cita = new Cita()
                    {
                        Id_Cita = (Guid)reader["Id_Cita"],
                        Fecha = (DateTime)reader["Fecha"],
                        Id_Paciente = (Guid)reader["Id_Paciente"],
                        Id_Profesional = (Guid)reader["Id_Profesional"],
                        Id_Tratamiento = (Guid)reader["Id_Tratamiento"],
                        Id_EtapaTratamiento = (Guid)reader["Id_EtapaTratamiento"],
                        Estado = (EstadoCita)(int)reader["Estado"] // Convertir el entero a enum
                    };
                    citas.Add(cita);
                }
            }

            return citas;
        }
        /// <summary>
        /// Obtiene una cita específica a partir de su identificador.
        /// </summary>
        /// <param name="idCita">El identificador de la cita a obtener.</param>
        /// <returns>El objeto Cita correspondiente.</returns>
        public Cita GetById(Guid idCita)
        {
            string query = "SELECT * FROM Citas WHERE Id_Cita = @Id_Cita";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Cita", idCita)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    return new Cita
                    {
                        Id_Cita = (Guid)reader["Id_Cita"],
                        Fecha = (DateTime)reader["Fecha"],
                        Id_Paciente = (Guid)reader["Id_Paciente"],
                        Id_Profesional = (Guid)reader["Id_Profesional"],
                        Id_Tratamiento = (Guid)reader["Id_Tratamiento"],
                        Id_EtapaTratamiento = (Guid)reader["Id_EtapaTratamiento"],
                        Estado = (EstadoCita)(int)reader["Estado"] // Convertir el entero a enum
                    };
                }
            }
            return null;
        }
        /// <summary>
        /// Elimina una cita especificada por el ID de la cita.
        /// </summary>
        /// <param name="id">El ID de la cita que se desea eliminar.</param>
        public void Remove(Guid id)
        {
            // Implementar si es necesario
            throw new NotImplementedException();
        }
        /// <summary>
        /// Actualiza los datos de una cita existente en la base de datos.
        /// </summary>
        /// <param name="cita">El objeto Cita que contiene la información actualizada.</param>
        public void Update(Cita cita)
        {
            string query = @"UPDATE Cita SET Fecha = @Fecha, Id_Paciente = @Id_Paciente, Id_Profesional = @Id_Profesional, 
                         Id_Tratamiento = @Id_Tratamiento, Id_EtapaTratamiento = @Id_EtapaTratamiento, Estado = @Estado
                         WHERE Id_Cita = @Id_Cita";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Cita", cita.Id_Cita),
            new SqlParameter("@Fecha", cita.Fecha),
            new SqlParameter("@Id_Paciente", cita.Id_Paciente),
            new SqlParameter("@Id_Profesional", cita.Id_Profesional),
            new SqlParameter("@Id_Tratamiento", cita.Id_Tratamiento),
            new SqlParameter("@Id_EtapaTratamiento", cita.Id_EtapaTratamiento),
            new SqlParameter("@Estado", (int)cita.Estado) // Convertir el enum a entero
            };

            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }
        /// <summary>
        /// Obtiene una lista de citas asociadas a un paciente especificado por su ID.
        /// </summary>
        /// <param name="idPaciente">El ID del paciente para el cual se desean obtener las citas.</param>
        /// <returns>Una lista de objetos CitaRegistroDto con los detalles de las citas del paciente.</returns>
        public List<CitaRegistroDto> GetCitasByPaciente(Guid idPaciente)
        {
            List<CitaRegistroDto> citas = new List<CitaRegistroDto>();

            string query = @"
      SELECT 
      C.Id_Cita, -- Incluir IdCita en la consulta
      C.Fecha, 
      P.Nombre AS NombreProfesional, 
      T.Nombre AS NombreTratamiento, 
      E.NombreEtapa AS NombreEtapa
      FROM Cita C
      INNER JOIN Profesionales P ON C.Id_Profesional = P.Id_Profesional
      INNER JOIN Tratamientos T ON C.Id_Tratamiento = T.Id
      INNER JOIN EtapasTratamiento E ON C.Id_EtapaTratamiento = E.Id
      WHERE C.Id_Paciente = @Id_Paciente";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Id_Paciente", idPaciente)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    CitaRegistroDto cita = new CitaRegistroDto
                    {
                        IdCita = (Guid)reader["Id_Cita"],
                        Fecha = (DateTime)reader["Fecha"],
                        NombreProfesional = reader["NombreProfesional"] as string,
                        NombreTratamiento = reader["NombreTratamiento"] as string,
                        NombreEtapa = reader["NombreEtapa"] as string,

                    };
                    citas.Add(cita);
                }
            }

            return citas;
        }
        /// <summary>
        /// Finaliza una cita especificada por el ID de la cita.
        /// </summary>
        /// <param name="idCita">El ID de la cita que se desea finalizar.</param>
        public void FinalizarCita(Guid idCita)
        {
            string commandText = @"
            UPDATE Cita
            SET Estado = @Estado
            WHERE Id_Cita = @IdCita";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@IdCita", idCita),
            new SqlParameter("@Estado", (int)EstadoCita.Finalizada)  // Convertir el enum a su valor entero
            };

            SqlHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }
        /// <summary>
        /// Cancela una cita especificada por el ID de la cita.
        /// </summary>
        /// <param name="idCita">El ID de la cita que se desea cancelar.</param>
        public void CancelarCita(Guid idCita)
        {
            string commandText = @"
            UPDATE Cita
            SET Estado = @Estado
            WHERE Id_Cita = @IdCita";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@IdCita", idCita),
        new SqlParameter("@Estado", (int)EstadoCita.Cancelada)  // Convertir el enum a su valor entero para Cancelada
            };

            SqlHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);

            string commandTextHorario = @"
            DELETE FROM HorariosProfesionales
            WHERE Id_Cita = @IdCita";

            SqlParameter[] parametersHorario = new SqlParameter[]
            {
            new SqlParameter("@IdCita", idCita)
            };

            // Ejecutar el comando para eliminar el registro
            SqlHelper.ExecuteNonQuery(commandTextHorario, CommandType.Text, parametersHorario);

        }
        /// <summary>
        /// Obtiene el estado de una cita especificada por su ID.
        /// </summary>
        /// <param name="idCita">El ID de la cita para obtener su estado.</param>
        /// <returns>El estado de la cita como un valor del enum EstadoCita.</returns>
        /// <exception cref="Exception">Lanza una excepción si no se encuentra el estado de la cita.</exception>
        public EstadoCita ObtenerEstadoCita(Guid idCita)
        {
            string commandText = @"
            SELECT 
                Estado
            FROM 
                Cita
            WHERE 
                Id_Cita = @idCita";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@idCita", idCita)
            };

            object result = SqlHelper.ExecuteScalar(commandText, CommandType.Text, parameters);

            if (result != null)
            {
                int estadoValue;
                if (int.TryParse(result.ToString(), out estadoValue) && Enum.IsDefined(typeof(EstadoCita), estadoValue))
                {
                    return (EstadoCita)estadoValue;
                }
            }

            throw new Exception("No se encontró el estado para la cita con el ID proporcionado.");
        }
        /// <summary>
        /// Obtiene una lista de citas para la fecha actual.
        /// </summary>
        /// <returns>Una lista de objetos CitaMainFormDto con los detalles de las citas del día actual.</returns>
        public List<CitaMainFormDto> GetCitasByFechaActual()
        {
            List<CitaMainFormDto> citas = new List<CitaMainFormDto>();

            // Consulta SQL para obtener las citas del día actual
            string query = @"
            SELECT 
            C.Id_Cita, 
            C.Fecha, 
            HP.HoraInicio,  -- HoraInicio de CitaDetalle
            P.Nombre AS NombrePaciente, 
            PR.Nombre AS NombreProfesional, 
            T.Nombre AS NombreTratamiento, 
            E.NombreEtapa AS NombreEtapa
            FROM Cita C
            INNER JOIN HorariosProfesionales HP ON C.Id_Cita = HP.Id_Cita  -- Unirse a CitaDetalle
            INNER JOIN Pacientes P ON C.Id_Paciente = P.Id_Paciente
            INNER JOIN Profesionales PR ON C.Id_Profesional = PR.Id_Profesional
            INNER JOIN Tratamientos T ON C.Id_Tratamiento = T.Id
            INNER JOIN EtapasTratamiento E ON C.Id_EtapaTratamiento = E.Id
            WHERE C.Fecha >= CAST(GETDATE() AS DATE) AND C.Fecha < DATEADD(DAY, 1, CAST(GETDATE() AS DATE));"; // Filtrar por fecha del día actual

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    CitaMainFormDto cita = new CitaMainFormDto
                    {
                        IdCita = (Guid)reader["Id_Cita"],
                        Fecha = (DateTime)reader["Fecha"],
                        HoraInicio = (TimeSpan)reader["HoraInicio"], // Asegúrate de que 'HoraInicio' sea de tipo TimeSpan en la BD
                        NombrePaciente = reader["NombrePaciente"] as string,
                        NombreProfesional = reader["NombreProfesional"] as string,
                        NombreTratamiento = reader["NombreTratamiento"] as string,
                        NombreEtapa = reader["NombreEtapa"] as string
                    };
                    citas.Add(cita);
                }
            }

            return citas;
        }
        /// <summary>
        /// Obtiene una lista de citas para una fecha seleccionada.
        /// </summary>
        /// <param name="fechaSeleccionada">La fecha seleccionada para filtrar las citas.</param>
        /// <returns>Una lista de objetos CitaMainFormDto con los detalles de las citas de la fecha seleccionada.</returns>
        public List<CitaMainFormDto> GetCitasByFechaSeleccionada(DateTime fechaSeleccionada)
        {
            List<CitaMainFormDto> citas = new List<CitaMainFormDto>();

            // Consulta SQL para obtener las citas de la fecha seleccionada
            string query = @"
    SELECT 
        C.Id_Cita, 
        C.Fecha, 
        HP.HoraInicio,  -- HoraInicio de CitaDetalle
        P.Nombre AS NombrePaciente, 
        PR.Nombre AS NombreProfesional, 
        T.Nombre AS NombreTratamiento, 
        E.NombreEtapa AS NombreEtapa
    FROM Cita C
    INNER JOIN HorariosProfesionales HP ON C.Id_Cita = HP.Id_Cita  -- Unirse a CitaDetalle
    INNER JOIN Pacientes P ON C.Id_Paciente = P.Id_Paciente
    INNER JOIN Profesionales PR ON C.Id_Profesional = PR.Id_Profesional
    INNER JOIN Tratamientos T ON C.Id_Tratamiento = T.Id
    INNER JOIN EtapasTratamiento E ON C.Id_EtapaTratamiento = E.Id
    WHERE CAST(C.Fecha AS DATE) = CAST(@FechaSeleccionada AS DATE);"; // Filtrar por la fecha seleccionada

            // Agregar el parámetro de fecha
            var parameters = new[]
            {
        new SqlParameter("@FechaSeleccionada", SqlDbType.Date) { Value = fechaSeleccionada }
    };

            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
                {
                    while (reader.Read())
                    {
                        CitaMainFormDto cita = new CitaMainFormDto
                        {
                            IdCita = (Guid)reader["Id_Cita"],
                            Fecha = (DateTime)reader["Fecha"],
                            // Verifica si 'HoraInicio' se puede convertir a TimeSpan
                            HoraInicio = (TimeSpan)reader["HoraInicio"], // Asegúrate de que 'HoraInicio' sea de tipo TimeSpan en la BD
                            NombrePaciente = reader["NombrePaciente"] as string,
                            NombreProfesional = reader["NombreProfesional"] as string,
                            NombreTratamiento = reader["NombreTratamiento"] as string,
                            NombreEtapa = reader["NombreEtapa"] as string
                        };
                        citas.Add(cita);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al obtener citas: {ex.Message}");
            }

            return citas;
        }
    }

}


    




