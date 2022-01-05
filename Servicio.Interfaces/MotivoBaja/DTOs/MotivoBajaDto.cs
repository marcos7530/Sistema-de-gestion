namespace Servicio.Interfaces.MotivoBaja.DTOs
{
    public class MotivoBajaDto: Base.BaseDto
    {
        public string Descripcion { get; set; }
        
        public string EstaEliminadoStr => EstaEliminado ? "Sí" : "No";
    }
}
