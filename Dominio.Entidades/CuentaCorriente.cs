namespace Dominio.Entidades
{
    using Aplicacion.Constantes.Clases;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CuentasCorrientes")]
    [MetadataType(typeof(ICuentaCorriente))]
    public class CuentaCorriente: Entidad
    {
    }
}
