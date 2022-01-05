namespace X_Commerce
{
    using System;
    using System.Windows.Forms;
    using Aplicacion.IoC;
    using IoC;
    using Presentacion.Seguridad;
    using StructureMap;

    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InicializadorInyectorDependencia();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fLogin = ObjectFactory.GetInstance<Login>();
            fLogin.ShowDialog();

            if (fLogin.PuedeAcceder)
            {
                Application.Run(ObjectFactory.GetInstance<Principal>());
            }
        }

        // IoC
        private static void InicializadorInyectorDependencia()
        {
            var ioc = new StructureMapContainer();

            ioc.Configure();

            new StructureMapDependencyResolver(ObjectFactory.Container);
            new StructureMapFilterProvider(ObjectFactory.Container);
        }
    }
}
