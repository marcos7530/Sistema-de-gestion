namespace Servicio.Interfaces.Localidad.DTOs
{
    using Base;

    public class LocalidadDto : BaseDto
    {
        public long ProvinciaId { get; set; }
        public string Provincia { get; set; }

        public string Descripcion { get; set; }
    }
}
