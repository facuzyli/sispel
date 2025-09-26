using DAL.Contracts;
using DAL.Implementations;
using DAL.Implementations.PDFs;
using DAL.Implementations.SqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Factory
{
    /// <summary>
    /// FactoryDAL es una clase que implementa el patrón Singleton para proporcionar acceso a los repositorios de la capa de acceso a datos (DAL).
    /// Los repositorios se inicializan solo cuando son necesarios y son reutilizados en toda la aplicación.
    /// </summary>
    public static class FactoryDAL
    {
        // Objeto de bloqueo para asegurar que la inicialización de repositorios sea segura en un entorno multi-hilo.
        private static readonly object _lock = new object();

        // Repositorios privados para cada tipo de entidad en la base de datos.
        private static IPacienteRepository _pacienteRepository;
        private static IProfesionalRepository _profesionalRepository;
        private static ITratamientoRepository _tratamientoRepository;
        private static ICitaRepository _citaRepository;
        private static IHorarioProfesional _horarioProfesionalRepository;
        private static ICitaDetalleRepository _citaDetalleRepository;
        private static IPdfRepository _pdfRepository;

        // Variables para leer la configuración del tipo de backend y cadena de conexión.
        private static readonly int backendType;
        private static readonly string connectionString;

        /// <summary>
        /// Constructor estático que se ejecuta una sola vez cuando la clase es referenciada por primera vez.
        /// Inicializa las variables de configuración leyendo el archivo de configuración (App.config o Web.config).
        /// </summary>
        static FactoryDAL()
        {
            // Lee el tipo de backend (por ejemplo, SQL Server) desde la configuración.
            backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            // Lee la cadena de conexión desde la configuración.
            connectionString = ConfigurationManager.AppSettings["MiConexion"];
        }

        /// <summary>
        /// Propiedad para acceder al repositorio de Paciente. Se utiliza el patrón Singleton para asegurarse de que solo se cree una instancia del repositorio.
        /// Dependiendo de la configuración, el repositorio se crea para el tipo de backend especificado.
        /// </summary>
        public static IPacienteRepository SqlPacienteRepository
        {
            get
            {
                if (_pacienteRepository == null)
                {
                    lock (_lock)
                    {
                        if (_pacienteRepository == null)
                        {
                            // Instancia el repositorio de Paciente para el backend SQL Server.
                            switch ((BackendType)backendType)
                            {
                                case BackendType.SqlServer:
                                    _pacienteRepository = new SqlPacienteRepository();
                                    break;

                                default:
                                    throw new NotSupportedException("Backend no soportado.");
                            }
                        }
                    }
                }
                return _pacienteRepository;
            }
        }

        /// <summary>
        /// Propiedad para acceder al repositorio de Profesional. Implementa la misma lógica que SqlPacienteRepository,
        /// asegurando que solo se cree una instancia del repositorio de Profesional.
        /// </summary>
        public static IProfesionalRepository SqlProfesionalRepository
        {
            get
            {
                if (_profesionalRepository == null)
                {
                    lock (_lock)
                    {
                        if (_profesionalRepository == null)
                        {
                            _profesionalRepository = new SqlProfesionalRepository();
                        }
                    }
                }
                return _profesionalRepository;
            }
        }

        /// <summary>
        /// Propiedad para acceder al repositorio de Tratamiento. Al igual que los anteriores, se utiliza el patrón Singleton
        /// para asegurar que solo se cree una instancia.
        /// </summary>
        public static ITratamientoRepository SqlTratamientoRepository
        {
            get
            {
                if (_tratamientoRepository == null)
                {
                    lock (_lock)
                    {
                        if (_tratamientoRepository == null)
                        {
                            _tratamientoRepository = new SqlTratamientoRepository();
                        }
                    }
                }
                return _tratamientoRepository;
            }
        }

        /// <summary>
        /// Propiedad para acceder al repositorio de Cita. Se sigue la misma lógica de inicialización segura.
        /// </summary>
        public static ICitaRepository SqlCitaRepository
        {
            get
            {
                if (_citaRepository == null)
                {
                    lock (_lock)
                    {
                        if (_citaRepository == null)
                        {
                            _citaRepository = new SqlCitaRepository();
                        }
                    }
                }
                return _citaRepository;
            }
        }

        /// <summary>
        /// Propiedad para acceder al repositorio de HorarioProfesional. Se utiliza el patrón Singleton para garantizar
        /// que solo se cree una instancia del repositorio.
        /// </summary>
        public static IHorarioProfesional SqlHorarioProfesionalRepository
        {
            get
            {
                if (_horarioProfesionalRepository == null)
                {
                    lock (_lock)
                    {
                        if (_horarioProfesionalRepository == null)
                        {
                            _horarioProfesionalRepository = new SqlHorarioProfesionalRepository();
                        }
                    }
                }
                return _horarioProfesionalRepository;
            }
        }

        /// <summary>
        /// Propiedad para acceder al repositorio de CitaDetalle. Se asegura que solo se cree una instancia del repositorio
        /// y se reutilice durante toda la aplicación.
        /// </summary>
        public static ICitaDetalleRepository SqlCitaDetalleRepository
        {
            get
            {
                if (_citaDetalleRepository == null)
                {
                    lock (_lock)
                    {
                        if (_citaDetalleRepository == null)
                        {
                            _citaDetalleRepository = new SqlCitaDetalleRepository();
                        }
                    }
                }
                return _citaDetalleRepository;
            }
        }

        /// <summary>
        /// Propiedad para acceder al repositorio de Pdf. Esta propiedad sigue el mismo patrón Singleton para garantizar
        /// que solo se cree una instancia del repositorio de PDFs.
        /// </summary>
        public static IPdfRepository PdfRepository
        {
            get
            {
                if (_pdfRepository == null)
                {
                    lock (_lock)
                    {
                        if (_pdfRepository == null)
                        {
                            _pdfRepository = new PdfRepository(); // Asegúrate de tener una implementación concreta
                        }
                    }
                }
                return _pdfRepository;
            }
        }

        /// <summary>
        /// Enumeración que define los tipos de backend disponibles para el acceso a la base de datos.
        /// En este caso, solo se soporta SQL Server.
        /// </summary>
        internal enum BackendType
        {
            SqlServer = 1
        }
    }
}

