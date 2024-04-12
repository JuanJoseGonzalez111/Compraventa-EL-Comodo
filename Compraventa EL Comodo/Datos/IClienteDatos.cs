using System.Data;

namespace Compraventa_EL_Comodo.Datos
{
    public interface IClienteDatos
    {
        DataTable LoadCLientes();
        void InsertarClientes(string cedula, string nombre, string apellido, string estado, byte[] imagen);
    }
}