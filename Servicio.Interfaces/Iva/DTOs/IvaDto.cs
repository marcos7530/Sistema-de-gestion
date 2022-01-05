namespace Servicio.Interfaces.Iva.DTOs
{
    public class IvaDto: Base.BaseDto
    {
        public string Descripcion { get; set; }

        public decimal Porcentaje { get; set; }

        public string PorcentajeStr => Porcentaje.ToString();

        public string EliminadoStr => !EstaEliminado ? "Sí" : "No";
    }
}
