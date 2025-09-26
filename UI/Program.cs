using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;
using UI.Forms.AdminForms;
using Syncfusion.Licensing;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCd0x0THxbf1x0ZFRGalhSTnJXUj0eQnxTdEFjUH1ccnZRRWRUVEV3Vw==
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXZcc3ZUQ2ldUEB+WUA=");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
