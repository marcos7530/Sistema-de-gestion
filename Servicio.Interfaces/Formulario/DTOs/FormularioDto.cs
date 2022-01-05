namespace Servicio.Interfaces.Formulario.DTOs
{
    using Base;

    public class FormularioDto : BaseDto
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string NombreCompleto { get; set; }

        public bool ExisteBaseDatos { get; set; }
    }
}
