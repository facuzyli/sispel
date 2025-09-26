using DOMAIN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;

namespace DAL.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio de operaciones de base de datos para la entidad Profesional.
    /// Proporciona métodos para agregar, actualizar, eliminar, obtener y consultar profesionales.
    /// </summary>
    public class SqlProfesionalRepository : IProfesionalRepository
    {
        /// <summary>
        /// Agrega un nuevo profesional a la base de datos.
        /// </summary>
        /// <param name="profesional">El objeto Profesional que se va a agregar.</param>
        public void Add(Profesional profesional)
        {
            // Consulta SQL para insertar los datos del profesional en la tabla Profesionales
            string query = "INSERT INTO Profesionales (Id_Profesional, Nombre, Apellido, Direccion, Mail, Telefono, Especializacion, Activo) " +
                           "VALUES (@Id_Profesional, @Nombre, @Apellido, @Direccion, @Mail, @Telefono, @Especializacion, @Activo)";

            // Definición de parámetros para la consulta SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Profesional", profesional.Id_Profesional),
            new SqlParameter("@Nombre", profesional.Nombre),
            new SqlParameter("@Apellido", profesional.Apellido),
            new SqlParameter("@Direccion", profesional.Direccion),
            new SqlParameter("@Mail", profesional.Mail),
            new SqlParameter("@Telefono", profesional.Telefono),
            new SqlParameter("@Especializacion", profesional.Especializacion),
            new SqlParameter("@Activo", profesional.Activo)
            };

            // Ejecuta la consulta SQL para insertar el profesional
            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Actualiza la información de un profesional existente en la base de datos.
        /// </summary>
        /// <param name="profesional">El objeto Profesional con los datos actualizados.</param>
        public void Update(Profesional profesional)
        {
            // Consulta SQL para actualizar los datos del profesional
            string query = "UPDATE Profesionales SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, " +
                           "Mail = @Mail, Telefono = @Telefono, Especializacion = @Especializacion " +
                           "WHERE Id_Profesional = @Id_Profesional";

            // Definición de parámetros para la consulta SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Profesional", profesional.Id_Profesional),
            new SqlParameter("@Nombre", profesional.Nombre),
            new SqlParameter("@Apellido", profesional.Apellido),
            new SqlParameter("@Direccion", profesional.Direccion),
            new SqlParameter("@Mail", profesional.Mail),
            new SqlParameter("@Telefono", profesional.Telefono),
            new SqlParameter("@Especializacion", profesional.Especializacion)
            };

            // Ejecuta la consulta SQL para actualizar el profesional
            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Desactiva un profesional en la base de datos, poniéndolo como inactivo.
        /// </summary>
        /// <param name="idProfesional">El identificador del profesional que se va a desactivar.</param>
        public void Remove(Guid idProfesional)
        {
            // Consulta SQL para desactivar un profesional (marcarlo como inactivo)
            string query = "UPDATE Profesionales SET Activo = 0 WHERE Id_Profesional = @Id_Profesional";

            // Definición de parámetros para la consulta SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Profesional", idProfesional)
            };

            // Ejecuta la consulta SQL para desactivar el profesional
            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Obtiene todos los profesionales desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Profesional.</returns>
        public List<Profesional> GetAll()
        {
            // Lista para almacenar los profesionales obtenidos
            List<Profesional> profesionales = new List<Profesional>();

            // Consulta SQL para obtener todos los profesionales
            string query = "SELECT * FROM Profesionales";

            // Ejecuta la consulta SQL y lee los resultados
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    // Crea un objeto Profesional con los datos leídos de la base de datos
                    Profesional profesional = new Profesional()
                    {
                        Id_Profesional = (Guid)reader["Id_Profesional"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Especializacion = reader["Especializacion"].ToString(),
                        Activo = (bool)reader["Activo"]
                    };
                    // Agrega el profesional a la lista
                    profesionales.Add(profesional);
                }
            }

            return profesionales;
        }

        /// <summary>
        /// Obtiene un profesional por su ID desde la base de datos.
        /// </summary>
        /// <param name="id">El identificador del profesional.</param>
        /// <returns>Un objeto Profesional si se encuentra, de lo contrario, null.</returns>
        public Profesional ObtenerProfesionalPorId(Guid id)
        {
            // Consulta SQL para obtener un profesional por su ID
            string query = "SELECT * FROM Profesionales WHERE Id_Profesional = @Id";

            // Definición de parámetros para la consulta SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id", id)
            };

            // Ejecuta la consulta SQL y obtiene los resultados
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    // Si se encuentra el profesional, lo devuelve
                    return new Profesional
                    {
                        Id_Profesional = reader.GetGuid(reader.GetOrdinal("Id_Profesional")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                        Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                        Mail = reader.GetString(reader.GetOrdinal("Mail")),
                        Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                        Especializacion = reader.GetString(reader.GetOrdinal("Especializacion")),
                        Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
                    };
                }
            }

            // Si no se encuentra el profesional, devuelve null
            return null;
        }

        /// <summary>
        /// Obtiene el nombre completo de un profesional a partir de su ID.
        /// </summary>
        /// <param name="idProfesional">El identificador del profesional.</param>
        /// <returns>El nombre completo del profesional si se encuentra, o null si no.</returns>
        public string ObtenerNombreCompletoPorId(Guid idProfesional)
        {
            // Consulta SQL para obtener el nombre y apellido de un profesional por su ID
            string query = "SELECT Nombre, Apellido FROM Profesionales WHERE Id_Profesional = @Id";

            // Definición de parámetros para la consulta SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id", idProfesional)
            };

            // Ejecuta la consulta SQL y lee los resultados
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    // Si se encuentra el profesional, devuelve su nombre completo
                    string nombre = reader["Nombre"].ToString();
                    string apellido = reader["Apellido"].ToString();
                    return $"{nombre} {apellido}";
                }
            }

            // Si no se encuentra el profesional, devuelve null
            return null;
        }

        /// <summary>
        /// Método no implementado para obtener un profesional por su ID.
        /// </summary>
        /// <param name="id">El identificador del profesional.</param>
        /// <returns>Siempre lanza una excepción NotImplementedException.</returns>
        public Profesional GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
