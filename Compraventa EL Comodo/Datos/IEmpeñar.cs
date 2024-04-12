using System;
using System.Data;

namespace Compraventa_EL_Comodo.Datos
{
    public interface IEmpeñar
    {
        DataTable Loadempe();
        void InsertarEnPeño(string cedula, string articulo, string identificador, string descripcion, DateTime fechaEmpe, DateTime fechaSalida, decimal montoApagar, string estado,decimal Deuda, byte[] imagen);

        DataTable cargarDeudores(String cedula);
         
    }
}