using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compraventa_EL_Comodo.Datos
{
    internal class ClienteDatos : IClienteDatos
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public ClienteDatos(ISqlConnectionFactory sqlConnectionFactory)
        {
            _connectionFactory = sqlConnectionFactory;
            _connectionFactory.GetDbConnection();

        }
        public DataTable LoadCLientes()
        {


            using (var connection = _connectionFactory.GetDbConnection())
            {




                var query = "  Select * from Table_1";
                var adapter = new SqlDataAdapter(query, (SqlConnection)connection);

                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
        public void InsertarClientes(string cedula, string nombre, string apellido, string estado,  byte[] imagen)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var query = @"
            INSERT INTO Cliente (Cedula, Nombre, Apellido,estado,Foto)
            VALUES (@Cedula, @Nombre, @Apellido, @Estado, @Photo)";
                connection.Execute(query, new
                {
                    Cedula = cedula,
                    Nombre = nombre,
                    Apellido = apellido,
                    Estado = estado,
                    Photo = imagen
                   
                });
            }
        }
    }
}
