using DAL.Contracts;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Resources;

using System.Diagnostics;



namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para la gestión de detalles de citas.
    /// Implementa la interfaz ICitaDetalleRepository para manejar la persistencia de datos relacionados con las citas.
    /// </summary>
    public class SqlCitaDetalleRepository : ICitaDetalleRepository
    {
        /// <summary>
        /// Agrega un nuevo detalle de cita en la base de datos.
        /// Obtiene los detalles de la cita y los horarios del profesional, luego inserta la información en la tabla CitaDetalle.
        /// </summary>
        /// <param name="idCita">ID de la cita a la que se le añadirá el detalle.</param>
        /// <param name="observaciones">Observaciones sobre la cita.</param>
        /// <param name="recomendaciones">Recomendaciones para el paciente.</param>
        /// <returns>Un objeto CitaDetalle con los detalles de la cita insertada.</returns>
        public CitaDetalle Add1(Guid idCita, string observaciones, string recomendaciones)
        {
            // Paso 1: Obtener información de la cita
            string commandTextCita = @"
        SELECT 
            C.Id_Cita,
            C.Id_Paciente,
            P.Nombre AS NombreProfesional,
            T.Nombre AS NombreTratamiento,
            E.NombreEtapa AS EtapaTratamiento
        FROM 
            Cita C
        INNER JOIN Profesionales P ON C.Id_Profesional = P.Id_Profesional
        INNER JOIN Tratamientos T ON C.Id_Tratamiento = T.Id
        INNER JOIN EtapasTratamiento E ON C.Id_EtapaTratamiento = E.Id
        WHERE 
            C.Id_Cita = @IdCita";

            SqlParameter[] parametersCita = new SqlParameter[]
            {
        new SqlParameter("@IdCita", idCita)
            };

            CitaDetalle citaDetalle = null;

            using (var reader = SqlHelper.ExecuteReader(commandTextCita, CommandType.Text, parametersCita))
            {
                if (reader.Read())
                {
                    citaDetalle = new CitaDetalle
                    {
                        IdCita = idCita,
                        IdPaciente = reader.GetGuid(reader.GetOrdinal("Id_Paciente")),
                        NombreProfesional = reader["NombreProfesional"] as string,
                        NombreTratamiento = reader["NombreTratamiento"] as string,
                        EtapaTratamiento = reader["EtapaTratamiento"] as string,
                        Observaciones = observaciones,
                        Recomendaciones = recomendaciones
                    };
                }
            }

            if (citaDetalle == null)
            {
                throw new Exception("No se encontró la cita con el ID proporcionado.");
            }

            // Paso 2: Obtener los horarios del profesional
            string commandTextHorario = @"
        SELECT 
            Fecha,
            HoraInicio,
            HoraFin
        FROM 
            HorariosProfesionales
        WHERE 
            Id_Cita = @IdCita";

            SqlParameter[] parametersHorario = new SqlParameter[]
            {
        new SqlParameter("@IdCita", idCita)
            };

            using (var reader = SqlHelper.ExecuteReader(commandTextHorario, CommandType.Text, parametersHorario))
            {
                if (reader.Read())
                {
                    citaDetalle.Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"));
                    citaDetalle.HoraInicio = reader.GetTimeSpan(reader.GetOrdinal("HoraInicio"));
                    citaDetalle.HoraFin = reader.GetTimeSpan(reader.GetOrdinal("HoraFin"));
                }
            }

            // Paso 3: Insertar el detalle de la cita en la base de datos
            string commandTextInsert = @"
    INSERT INTO CitaDetalle
    (IdCita, Fecha, HoraInicio, HoraFin, NombreProfesional, NombreTratamiento, EtapaTratamiento, Observaciones, Recomendaciones, IdPaciente)
    VALUES
    (@IdCita, @Fecha, @HoraInicio, @HoraFin, @NombreProfesional, @NombreTratamiento, @EtapaTratamiento, @Observaciones, @Recomendaciones, @IdPaciente)";

            SqlParameter[] parametersInsert = new SqlParameter[]
            {
        new SqlParameter("@IdCita", citaDetalle.IdCita),
        new SqlParameter("@Fecha", citaDetalle.Fecha),
        new SqlParameter("@HoraInicio", citaDetalle.HoraInicio),
        new SqlParameter("@HoraFin", citaDetalle.HoraFin),
        new SqlParameter("@NombreProfesional", citaDetalle.NombreProfesional),
        new SqlParameter("@NombreTratamiento", citaDetalle.NombreTratamiento),
        new SqlParameter("@EtapaTratamiento", citaDetalle.EtapaTratamiento),
        new SqlParameter("@Observaciones", citaDetalle.Observaciones),
        new SqlParameter("@Recomendaciones", citaDetalle.Recomendaciones),
        new SqlParameter("@IdPaciente", citaDetalle.IdPaciente)
            };

            // Ejecutar el INSERT usando SqlHelper
            SqlHelper.ExecuteNonQuery(commandTextInsert, CommandType.Text, parametersInsert);

            return citaDetalle;
        }
        /// <summary>
        /// Obtiene todos los detalles de las citas de un paciente específico.
        /// </summary>
        /// <param name="idPaciente">ID del paciente para el cual se buscan las citas.</param>
        /// <returns>Una lista de objetos CitaDetalle con los detalles de las citas del paciente.</returns>
        public List<CitaDetalle> ObtenerCitasPorPaciente(Guid idPaciente)
        {
            var query = @"SELECT Fecha, HoraInicio, HoraFin, NombreProfesional, NombreTratamiento, EtapaTratamiento, Observaciones, Recomendaciones
                  FROM CitaDetalle
                  WHERE IdPaciente = @IdPaciente";

            // Parámetro para la consulta
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@IdPaciente", idPaciente)
            };

            var listaCitas = new List<CitaDetalle>();

            // Ejecutar la consulta
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    var citaDetalle = new CitaDetalle
                    {
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        HoraInicio = TimeSpan.Parse(reader["HoraInicio"].ToString()),
                        HoraFin = TimeSpan.Parse(reader["HoraFin"].ToString()),
                        NombreProfesional = reader["NombreProfesional"].ToString(),
                        NombreTratamiento = reader["NombreTratamiento"].ToString(),
                        EtapaTratamiento = reader["EtapaTratamiento"].ToString(),
                        Observaciones = reader["Observaciones"].ToString(),
                        Recomendaciones = reader["Recomendaciones"].ToString(),
                        IdPaciente = idPaciente // Igualar con el parámetro de entrada
                    };

                    listaCitas.Add(citaDetalle); // Agregar la cita a la lista
                }
            }

            return listaCitas; // Retorna la lista con los detalles de la cita
        }
        /// <summary>
        /// Método no implementado para agregar un objeto CitaDetalle.
        /// </summary>
        /// <param name="obj">El objeto CitaDetalle a agregar.</param>
        public void Add(CitaDetalle obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para obtener todos los objetos CitaDetalle.
        /// </summary>
        /// <returns>Lista de objetos CitaDetalle.</returns>
        public List<CitaDetalle> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para obtener un CitaDetalle por ID.
        /// </summary>
        /// <param name="id">El ID del CitaDetalle a obtener.</param>
        /// <returns>El objeto CitaDetalle correspondiente al ID.</returns>
        public CitaDetalle GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para eliminar un CitaDetalle.
        /// </summary>
        /// <param name="id">El ID del CitaDetalle a eliminar.</param>
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para actualizar un objeto CitaDetalle.
        /// </summary>
        /// <param name="obj">El objeto CitaDetalle a actualizar.</param>
        public void Update(CitaDetalle obj)
        {
            throw new NotImplementedException();
        }

        public List<CitaDetalle> ListarCitaDetallesSinDVH()
        {
            List<CitaDetalle> citaDetalles = new List<CitaDetalle>();

            string query = @"
            SELECT * FROM CitaDetalle
            WHERE IdCitaDetalle NOT IN (SELECT IdRegistro FROM DigitosVerificadores WHERE NombreTabla = 'CitaDetalle')";

            // Ejecución de la consulta para obtener los detalles de cita sin DVH
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                // Lectura de los resultados de la consulta
                while (reader.Read())
                {
                    CitaDetalle citaDetalle = new CitaDetalle()
                    {
                        IdCitaDetalle = (Guid)reader["IdCitaDetalle"],
                        IdCita = (Guid)reader["IdCita"],
                        Fecha = (DateTime)reader["Fecha"],
                        HoraInicio = (TimeSpan)reader["HoraInicio"],
                        HoraFin = (TimeSpan)reader["HoraFin"],
                        NombreProfesional = reader["NombreProfesional"].ToString(),
                        NombreTratamiento = reader["NombreTratamiento"].ToString(),
                        EtapaTratamiento = reader["EtapaTratamiento"].ToString(), // Convertir a string si es necesario
                        Observaciones = reader["Observaciones"].ToString(),
                        Recomendaciones = reader["Recomendaciones"].ToString(),
                        IdPaciente = (Guid)reader["IdPaciente"]
                    };
                    citaDetalles.Add(citaDetalle);
                }
            }

            // Retorna la lista de detalles de cita
            return citaDetalles;
        }
        public List<CitaDetalle> ListarCitaDetalles()
        {
            List<CitaDetalle> citaDetalles = new List<CitaDetalle>();

            string query = @"
            SELECT * FROM CitaDetalle";

            // Ejecución de la consulta para obtener todos los detalles de cita utilizando SqlHelper
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                // Lectura de los resultados de la consulta
                while (reader.Read())
                {
                    CitaDetalle citaDetalle = new CitaDetalle()
                    {
                        IdCitaDetalle = (Guid)reader["IdCitaDetalle"],
                        IdCita = (Guid)reader["IdCita"],
                        Fecha = (DateTime)reader["Fecha"],
                        HoraInicio = (TimeSpan)reader["HoraInicio"],
                        HoraFin = (TimeSpan)reader["HoraFin"],
                        NombreProfesional = reader["NombreProfesional"].ToString(),
                        NombreTratamiento = reader["NombreTratamiento"].ToString(),
                        EtapaTratamiento = reader["EtapaTratamiento"].ToString(), // Convertir a string si es necesario
                        Observaciones = reader["Observaciones"].ToString(),
                        Recomendaciones = reader["Recomendaciones"].ToString(),
                        IdPaciente = (Guid)reader["IdPaciente"]
                    };
                    citaDetalles.Add(citaDetalle);
                }
            }

            // Retorna la lista de detalles de cita
            return citaDetalles;
        }
    }
   
}

