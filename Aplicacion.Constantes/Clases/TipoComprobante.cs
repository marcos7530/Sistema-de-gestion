namespace Aplicacion.Constantes.Clases
{
    public enum TipoComprobante
    {
        A = 1,
        B = 2,
        C = 3,
        Remito = 4,
        Presupuesto = 5,
        Nota_Credito = 6,
        Compra = 7,
    }
}

/* La factura tipo C la entrega el Monotributista a cualquier cliente 
 * independientemente de su condición fiscal. Como el monotributista 
 * no discrimina el IVA (sino que está incluído en el importe que 
 * abona según su rango de facturación) no necesita presentar una 
 * factura con IVA discriminado. */

/* Factura A: emitida por un responsable inscripto a otro responsable inscripto. 
 * El IVA está discriminado.
 * 
 * Factura B: también emitida por un responsable inscripto pero en este caso, 
 * a un consumidor final, un sujeto exento o un monotributista (ya que al pagar 
 * el IVA por régimen simplificado no es necesario discriminar el IVA en la factura).
 * 
 * Factura C: emitida por sujetos no inscriptos en el IVA, es el caso de 
 * monotributistas o exentos, por todas sus ventas de bienes o locaciones de 
 * servicios, sin importar la condición del comprador. */

/* Remito: Lo emite un vendedor con el objetivo de acreditar el envío de ciertas 
 * mercaderías: cuando éstas llegan a destino, el receptor debe firmar el remito 
 * original y devolvérselo al vendedor. El receptor, por su parte, se queda con 
 * una copia del remito. */

/* Es un comprobante que una empresa envía a su cliente para acreditar la 
 * devolución de un valor determinado por el concepto que se indica en la misma nota.*/
