using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa los posibles estados de un horario en el sistema.
    /// </summary>
    public enum EstadoHorarios
    {
        /// <summary>
        /// El horario está disponible para ser asignado a una cita.
        /// </summary>
        Disponible = 0,

        /// <summary>
        /// El horario está ocupado y no se puede asignar a otra cita.
        /// </summary>
        Ocupado = 1
    }

}
