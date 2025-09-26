using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN
{
    /// <summary>
    /// Representa los posibles estados de una cita en el sistema.
    /// </summary>
    public enum EstadoCita
    {
        /// <summary>
        /// La cita está programada y pendiente de realizarse.
        /// </summary>
        Programada,  // Estado inicial

        /// <summary>
        /// La cita se ha completado y finalizado.
        /// </summary>
        Finalizada,

        /// <summary>
        /// La cita ha sido cancelada.
        /// </summary>
        Cancelada
    }

}
