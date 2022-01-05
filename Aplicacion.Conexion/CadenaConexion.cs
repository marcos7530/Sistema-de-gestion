namespace Aplicacion.Conexion
{
    public static class CadenaConexion
    {
       //private const string BaseDatos = "XCommerceDb5"; //=======================> ESTA ES LA QUE VA
        private const string BaseDatos = "XCommercePractica03";
        private const string Servidor = "PORTATIL";
        private const string Usuario = "sa";
        private const string Password = "123";

        public static string ObtenerCadenaConexion => $"Data Source ={Servidor}; " +
                                                      $"Initial Catalog={BaseDatos}; " +
                                                      $"User Id={Usuario}; " +
                                                      $"Password={Password};";
    }
}
