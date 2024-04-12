using System;

namespace Compraventa_EL_Comodo.Datos
{
    public interface IRetirar
    {
       void EjecutarProcedimientoAlmacenado(string cedulaCliente, string articulo, DateTime fecha, decimal montoAdeudado, decimal montoPagado, decimal montoFaltante, int estadoRetiro);
        //void ActualizarEmpeñar(String cedulaCliente, string articulo, decimal nuevoMontoDeuda, DateTime nuevaFechaSalida);
        void InsertarAbono(string cedulaCliente, string articulo, DateTime fechaEmpe, decimal deuda, decimal abono, decimal nuevoMontoDeuda, DateTime nuevaFechaSalida);




    }
}