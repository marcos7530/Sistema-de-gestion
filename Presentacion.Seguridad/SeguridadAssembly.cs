namespace Presentacion.Seguridad
{
    using System.Reflection;

    public static class SeguridadAssembly
    {
        public static Assembly GetAssembly => Assembly.GetExecutingAssembly();
    }
}
