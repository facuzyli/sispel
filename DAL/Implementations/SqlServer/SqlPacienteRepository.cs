using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOMAIN;
using System.Data;
using DAL.Contracts;


namespace DAL.Implementations.SqlServer
{

    /// <summary>
    /// Clase que maneja las operaciones relacionadas con los pacientes en la base de datos.
    /// Implementa la interfaz <see cref="IPacienteRepository"/> para realizar operaciones CRUD sobre los pacientes.
    /// </summary>
    public class SqlPacienteRepository : IPacienteRepository
    {
        /// <summary>
        /// Agrega un nuevo paciente a la base de datos.
        /// </summary>
        /// <param name="paciente">El objeto <see cref="Paciente"/> a agregar a la base de datos.</param>
        public void Add(Paciente paciente)
        {
            string query = "INSERT INTO Pacientes (Id_Paciente, Nombre, Apellido, Direccion, Mail, Telefono, Alergias, Medicamentos, Activo) " +
                           "VALUES (@Id_Paciente, @Nombre, @Apellido, @Direccion, @Mail, @Telefono, @Alergias, @Medicamentos, @Activo)";

            // Definición de los parámetros a insertar en la consulta SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Paciente", paciente.Id_Paciente),
            new SqlParameter("@Nombre", paciente.Nombre),
            new SqlParameter("@Apellido", paciente.Apellido),
            new SqlParameter("@Direccion", paciente.Direccion),
            new SqlParameter("@Mail", paciente.Mail),
            new SqlParameter("@Telefono", paciente.Telefono),
            new SqlParameter("@Alergias", paciente.Alergias),
            new SqlParameter("@Medicamentos", paciente.Medicamentos),
            new SqlParameter("@Activo", paciente.Activo)
            };

            // Ejecución de la consulta para insertar el paciente en la base de datos
            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Actualiza los datos de un paciente en la base de datos.
        /// </summary>
        /// <param name="paciente">El objeto <see cref="Paciente"/> con los nuevos datos a actualizar.</param>
        public void Update(Paciente paciente)
        {
            string query = "UPDATE Pacientes SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, " +
                           "Mail = @Mail, Telefono = @Telefono, Alergias = @Alergias, Medicamentos = @Medicamentos " +
                           "WHERE Id_Paciente = @Id_Paciente";

            // Definición de los parámetros para la actualización en la consulta SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Paciente", paciente.Id_Paciente),
            new SqlParameter("@Nombre", paciente.Nombre),
            new SqlParameter("@Apellido", paciente.Apellido),
            new SqlParameter("@Direccion", paciente.Direccion),
            new SqlParameter("@Mail", paciente.Mail),
            new SqlParameter("@Telefono", paciente.Telefono),
            new SqlParameter("@Alergias", paciente.Alergias),
            new SqlParameter("@Medicamentos", paciente.Medicamentos)
            };

            // Ejecución de la consulta para actualizar el paciente en la base de datos
            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Desactiva un paciente en la base de datos, cambiando su estado de "Activo" a 0.
        /// </summary>
        /// <param name="idPaciente">El identificador único del paciente a desactivar.</param>
        public void Disable(Guid idPaciente)
        {
            string query = "UPDATE Pacientes SET Activo = 0 WHERE Id_Paciente = @Id_Paciente";

            // Definición del parámetro para la desactivación del paciente
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Id_Paciente", idPaciente)
            };

            // Ejecución de la consulta para desactivar el paciente
            SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        /// <summary>
        /// Obtiene una lista de todos los pacientes almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Paciente"/> con todos los pacientes registrados.</returns>
        public List<Paciente> GetAll()
        {
            List<Paciente> pacientes = new List<Paciente>();

            string query = "SELECT * FROM Pacientes";

            // Ejecución de la consulta para obtener todos los pacientes
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                // Lectura de los resultados de la consulta
                while (reader.Read())
                {
                    Paciente paciente = new Paciente()
                    {
                        Id_Paciente = (Guid)reader["Id_Paciente"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Alergias = reader["Alergias"].ToString(),
                        Medicamentos = reader["Medicamentos"].ToString(),
                        Activo = (bool)reader["Activo"]
                    };
                    pacientes.Add(paciente);
                }
            }

            // Retorna la lista de pacientes
            return pacientes;
        }

        /// <summary>
        /// Método no implementado para eliminar un paciente de la base de datos.
        /// </summary>
        /// <param name="id">El identificador único del paciente a eliminar.</param>
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene el nombre completo de un paciente a partir de su identificador único.
        /// </summary>
        /// <param name="idPaciente">El identificador único del paciente.</param>
        /// <returns>El nombre completo del paciente o un mensaje si no se encuentra.</returns>
        public string GetNombreCompletoById(Guid idPaciente)
        {
            string query = "SELECT Nombre, Apellido FROM Pacientes WHERE Id_Paciente = @IdPaciente";

            // Definición del parámetro para la consulta
            SqlParameter[] parameters = {
            new SqlParameter("@IdPaciente", idPaciente)
        };

            // Ejecución de la consulta para obtener el nombre y apellido del paciente
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameters))
            {
                // Si se encuentra el paciente, se devuelve el nombre completo
                if (reader.Read())
                {
                    string nombre = reader["Nombre"].ToString();
                    string apellido = reader["Apellido"].ToString();
                    return $"{nombre} {apellido}";
                }
            }

            // Si no se encuentra el paciente, se retorna un mensaje
            return "Paciente no encontrado";
        }

        /// <summary>
        /// Método no implementado para obtener un paciente por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del paciente.</param>
        /// <returns>Un objeto <see cref="Paciente"/> con los datos del paciente.</returns>
        public Paciente GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

    

