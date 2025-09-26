using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa un horario específico en el sistema.
    /// </summary>
    public class Horario
    {
        /// <summary>
        /// Obtiene o establece la hora asociada al horario.
        /// </summary>
        public TimeSpan Hora { get; set; }
    }

}
