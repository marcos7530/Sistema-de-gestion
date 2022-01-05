using System.Reflection;

namespace Presentacion.Core
{
    public static class CoreAssembly
    {
        public static Assembly GetAssembly => Assembly.GetExecutingAssembly();
    }
}
