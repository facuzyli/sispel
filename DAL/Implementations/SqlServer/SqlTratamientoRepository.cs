using DOMAIN;
using DOMAIN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para gestionar operaciones relacionadas con los tratamientos y etapas de tratamiento en la base de datos.
    /// Implementa la interfaz <see cref="ITratamientoRepository"/> y proporciona métodos para agregar, obtener y manipular tratamientos y etapas.
    /// </summary>
    public class SqlTratamientoRepository : ITratamientoRepository
    {
        /// <summary>
        /// Agrega un nuevo tratamiento a la base de datos.
        /// </summary>
        /// <param name="tratamiento">El objeto tratamiento a agregar.</param>
        public void AgregarTratamiento(Tratamiento tratamiento)
        {
            // La consulta SQL para insertar un nuevo tratamiento en la tabla Tratamientos
            string commandText = "INSERT INTO Tratamientos (Id, Nombre, DuracionTotal, Descripcion) VALUES (@Id, @Nombre, @DuracionTotal, @Descripcion)";

            // Parámetros para la consulta SQL, utilizando las propiedades del objeto 'tratamiento'
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id", tratamiento.Id),
            new SqlParameter("@Nombre", tratamiento.Nombre),
            new SqlParameter("@DuracionTotal", tratamiento.DuracionTotal),
            new SqlParameter("@Descripcion", tratamiento.Descripcion)
            };

            // Ejecuta la consulta SQL, usando SqlHelper para ejecutar comandos no select
            SqlHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        /// <summary>
        /// Obtiene un tratamiento de la base de datos por su ID.
        /// </summary>
        /// <param name="id">El ID del tratamiento a obtener.</param>
        /// <returns>El tratamiento con el ID especificado, o null si no se encuentra.</returns>
        public Tratamiento ObtenerTratamientoPorId(Guid id)
        {
            // Consulta SQL para obtener el tratamiento por ID
            string commandText = "SELECT * FROM Tratamientos WHERE Id = @Id";

            // Parámetro con el ID del tratamiento a buscar
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Id", id) };

            // Ejecuta la consulta y lee el resultado
            using (var reader = SqlHelper.ExecuteReader(commandText, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    // Mapea el resultado al objeto Tratamiento
                    return new Tratamiento
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("Id")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        DuracionTotal = reader.GetInt32(reader.GetOrdinal("DuracionTotal")),
                        Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                    };
                }
                return null;
            }
        }

        /// <summary>
        /// Agrega una etapa a un tratamiento existente.
        /// </summary>
        /// <param name="tratamientoId">El ID del tratamiento al que se agregará la etapa.</param>
        /// <param name="etapa">El objeto etapa que se agregará.</param>
        public void AgregarEtapaAlTratamiento(Guid tratamientoId, EtapaTratamiento etapa)
        {
            // Consulta SQL para insertar una nueva etapa de tratamiento
            string commandText = "INSERT INTO EtapasTratamiento (Id, NombreEtapa, Duracion, TratamientoId) VALUES (@Id, @NombreEtapa, @Duracion, @TratamientoId)";

            // Parámetros para la consulta SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id", etapa.Id),
            new SqlParameter("@NombreEtapa", etapa.NombreEtapa),
            new SqlParameter("@Duracion", etapa.Duracion),
            new SqlParameter("@TratamientoId", tratamientoId)
            };

            // Ejecuta la consulta para agregar la etapa
            SqlHelper.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        /// <summary>
        /// Obtiene todos los tratamientos almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista con todos los tratamientos.</returns>
        public IEnumerable<Tratamiento> ObtenerTodosTratamientos()
        {
            var tratamientos = new List<Tratamiento>();

            // Consulta SQL para obtener todos los tratamientos
            string commandText = "SELECT * FROM Tratamientos";

            // Ejecuta la consulta y lee los resultados
            using (var reader = SqlHelper.ExecuteReader(commandText, CommandType.Text))
            {
                while (reader.Read())
                {
                    tratamientos.Add(new Tratamiento
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("Id")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        DuracionTotal = reader.GetInt32(reader.GetOrdinal("DuracionTotal")),
                        Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                    });
                }
            }

            return tratamientos;
        }

        /// <summary>
        /// Obtiene los tratamientos junto con sus etapas asociadas.
        /// </summary>
        /// <returns>Una lista con los tratamientos y sus respectivas etapas.</returns>
        public List<TratamientoEtapaDto> ObtenerTratamientosConEtapas()
        {
            // Consulta SQL para obtener tratamientos con sus etapas
            string query = @"
        SELECT 
            t.Nombre AS NombreTratamiento, 
            e.NombreEtapa AS Etapa, 
            e.Duracion AS Duracion, 
            t.DuracionTotal AS DuracionTotal
        FROM 
            Tratamientos t
        INNER JOIN 
            EtapasTratamiento e 
        ON 
            t.Id = e.TratamientoId";

            var tratamientoEtapa = new List<TratamientoEtapaDto>();

            // Ejecuta la consulta y lee los resultados
            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    tratamientoEtapa.Add(new TratamientoEtapaDto
                    {
                        NombreTratamiento = reader.GetString(reader.GetOrdinal("NombreTratamiento")),
                        Etapa = reader.GetString(reader.GetOrdinal("Etapa")),
                        Duracion = reader.GetInt32(reader.GetOrdinal("Duracion")),
                        DuracionTotal = reader.GetInt32(reader.GetOrdinal("DuracionTotal"))
                    });
                }
            }

            return tratamientoEtapa;
        }

        /// <summary>
        /// Obtiene la duración de una etapa de tratamiento específica por su ID.
        /// </summary>
        /// <param name="etapaId">El ID de la etapa.</param>
        /// <returns>La duración de la etapa en minutos.</returns>
        /// <exception cref="Exception">Lanza una excepción si no se encuentra la etapa.</exception>
        public int ObtenerDuracionEtapa(Guid etapaId)
        {
            // Consulta SQL para obtener la duración de una etapa de tratamiento por su ID
            var query = @"SELECT Duracion FROM EtapasTratamiento WHERE Id = @IdEtapa";

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IdEtapa", etapaId) };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    return reader.GetInt32(reader.GetOrdinal("Duracion"));
                }
            }

            throw new Exception("No se encontró la etapa.");
        }

        #region Métodos No Implementados
        /// <summary>
        /// Método que agrega un tratamiento a la base de datos.
        /// Actualmente no está implementado y lanzará una excepción <see cref="NotImplementedException"/> cuando se llame.
        /// Este método debería recibir un objeto de tipo <see cref="Tratamiento"/> y agregarlo a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto de tipo <see cref="Tratamiento"/> que representa el tratamiento que se agregará.</param>
        /// <exception cref="NotImplementedException">Este método no está implementado.</exception>
        public void Add(Tratamiento obj)
        {
            // Lanza una excepción porque el método no está implementado
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que actualiza un tratamiento existente en la base de datos.
        /// Actualmente no está implementado y lanzará una excepción <see cref="NotImplementedException"/> cuando se llame.
        /// Este método debe permitir modificar un tratamiento previamente almacenado usando un objeto <see cref="Tratamiento"/>.
        /// </summary>
        /// <param name="obj">El objeto de tipo <see cref="Tratamiento"/> con los datos actualizados para el tratamiento.</param>
        /// <exception cref="NotImplementedException">Este método no está implementado.</exception>
        public void Update(Tratamiento obj)
        {
            // Lanza una excepción porque el método no está implementado
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que elimina un tratamiento de la base de datos utilizando su ID.
        /// Actualmente no está implementado y lanzará una excepción <see cref="NotImplementedException"/> cuando se llame.
        /// Este método debería recibir el ID del tratamiento que se desea eliminar.
        /// </summary>
        /// <param name="id">El identificador único (ID) del tratamiento que se va a eliminar.</param>
        /// <exception cref="NotImplementedException">Este método no está implementado.</exception>
        public void Remove(Guid id)
        {
            // Lanza una excepción porque el método no está implementado
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que obtiene un tratamiento de la base de datos utilizando su ID.
        /// Actualmente no está implementado y lanzará una excepción <see cref="NotImplementedException"/> cuando se llame.
        /// Este método debería devolver el objeto <see cref="Tratamiento"/> correspondiente al ID proporcionado.
        /// </summary>
        /// <param name="id">El identificador único (ID) del tratamiento que se desea obtener.</param>
        /// <returns>Un objeto de tipo <see cref="Tratamiento"/> correspondiente al ID proporcionado, si existiera.</returns>
        /// <exception cref="NotImplementedException">Este método no está implementado.</exception>
        public Tratamiento GetById(Guid id)
        {
            // Lanza una excepción porque el método no está implementado
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que obtiene todos los tratamientos registrados en la base de datos.
        /// Actualmente no está implementado y lanzará una excepción <see cref="NotImplementedException"/> cuando se llame.
        /// Este método debería devolver una lista de objetos <see cref="Tratamiento"/> que representan todos los tratamientos disponibles.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Tratamiento"/> que contienen todos los tratamientos registrados.</returns>
        /// <exception cref="NotImplementedException">Este método no está implementado.</exception>
        public List<Tratamiento> GetAll()
        {
            // Lanza una excepción porque el método no está implementado
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Obtiene las etapas de un tratamiento específico.
        /// </summary>
        /// <param name="tratamientoId">El ID del tratamiento.</param>
        /// <returns>Una lista con las etapas asociadas al tratamiento.</returns>
        public List<EtapaDto> ObtenerEtapasPorTratamiento(Guid tratamientoId)
        {
            // Consulta SQL para obtener las etapas de un tratamiento específico
            string query = @"
        SELECT 
            e.Id AS IdEtapa, 
            e.NombreEtapa AS NombreEtapa, 
            e.Duracion AS Duracion
        FROM 
            EtapasTratamiento e
        WHERE 
            e.TratamientoId = @TratamientoId";

            var etapas = new List<EtapaDto>();

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@TratamientoId", tratamientoId) };

            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    etapas.Add(new EtapaDto
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("IdEtapa")),
                        Nombre = reader.GetString(reader.GetOrdinal("NombreEtapa")),
                    });
                }
            }

            return etapas;
        }

        /// <summary>
        /// Obtiene una etapa específica por su ID.
        /// </summary>
        /// <param name="etapaId">El ID de la etapa.</param>
        /// <returns>La etapa solicitada.</returns>
        public EtapaTratamiento ObtenerEtapaPorId(Guid etapaId)
        {
            var query = @"SELECT Id, NombreEtapa, Duracion 
                  FROM EtapasTratamiento 
                  WHERE Id = @Id";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Id", etapaId)
            };

            EtapaTratamiento etapa = null;

            using (var reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    etapa = new EtapaTratamiento
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("Id")),
                        NombreEtapa = reader.GetString(reader.GetOrdinal("NombreEtapa")),
                        Duracion = reader.GetInt32(reader.GetOrdinal("Duracion"))
                    };
                }
            }

            return etapa;
        }

    }

}










