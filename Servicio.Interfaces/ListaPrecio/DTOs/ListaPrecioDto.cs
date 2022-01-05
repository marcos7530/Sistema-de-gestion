namespace Servicio.Interfaces.ListaPrecio.DTOs
{
    public class ListaPrecioDto: Base.BaseDto
    {
        public string Descripcion { get; set; }

        public decimal PorcentajeGanancia { get; set; }

        public bool NecesitaAutorizacion { get; set; }

        public string NecesitaAutorizacionStr => NecesitaAutorizacion ? "Sí" : "No";
    }
}
