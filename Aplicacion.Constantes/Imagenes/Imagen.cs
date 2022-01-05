namespace Aplicacion.Constantes.Imagenes
{
    using System;
    using System.Drawing;
    using System.IO;

    public static class Imagen
    {
        // Recursos de Imagenes
        public static Image Nuevo = Recursos.Nuevo;
        public static Image Actualizar = Recursos.Actualizar;
        public static Image Eliminar = Recursos.Borrar;
        public static Image Buscar = Recursos.Buscar;
        public static Image Modificar = Recursos.Modificar;
        public static Image Imprimir = Recursos.Impresora;
        public static Image Salir = Recursos.Salir;
        public static Image Limpiar = Recursos.Limpiar2;
        public static Image Limpiar2 = Recursos.Limpiar;

        public static Image Grabar = Recursos.Grabar;
        public static Image Guardar = Recursos.Guardar;
        public static Image Configuracion = Recursos.Configuracion;
        public static Image Camara = Recursos.Camara;
        public static Image Candado = Recursos.Candado;
        public static Image Agenda = Recursos.Agenda;
        public static Image Home = Recursos.Casa2;
        public static Image Formularios = Recursos.Formularios;
        public static Image Fondo = Recursos.FondoFormularioNegro2;
        public static Image ImagenFondo = Recursos.ImagenFondo;
        public static Image Usuarios = Recursos.Usuarios;
        public static Image Usuario = Recursos.Usuario;
        public static Image Password = Recursos.llave;
        public static Image BloquearDesbloquear = Recursos.Limpiar;
        public static Image Ojo = Recursos.Ojo;

        public static Image Agregar = Recursos.Agregar;
        public static Image Agregar2 = Recursos.Agregar2;
        public static Image Quitar = Recursos.Quitar;
        public static Image Quitar2 = Recursos.Quitar2;
        public static Image CarritoCompra = Recursos.CarritoCompra;


        // Metodo para convertir una Imagen en bytes
        public static byte[] Convertir(Image img)
        {
            var sTemp = Path.GetTempFileName();

            var fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);

            fs.Position = 0;

            var imgLength = Convert.ToInt32(fs.Length);

            var bytes = new byte[imgLength];

            fs.Read(bytes, 0, imgLength);

            fs.Close();

            return bytes;
        }

        // Metodo para convertir una bytes en Imagen
        public static Image Convertir(byte[] bytes)
        {
            if (bytes == null) return null;

            var ms = new MemoryStream(bytes);

            Bitmap bm = null;

            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return bm;
        }
    }
}
