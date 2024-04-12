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
    public class Empeñar : IEmpeñar
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public Empeñar(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._connectionFactory = sqlConnectionFactory;
        }
        public DataTable Loadempe()
        {


            using (var connection = _connectionFactory.GetDbConnection())
            {


                
              
                var query = "Select cedula, Articulo,Identificador, Descripcion,fechade_empeño,fechasalida, monto_a_pagar, e.nombre_estado,Photo from empeñar1 a \r\njoin estado e on a.Estado = e.id_estado\r\n where  Estado = 2";
                var adapter = new SqlDataAdapter(query, (SqlConnection)connection);

                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
        /*   public void InsertarEnPeño(string cedula, string articulo, string identificador, string descripcion, DateTime fechaEmpe, DateTime fechaSalida, decimal montoApagar, string estado, decimal Deuda)
           {
               using (var connection = _connectionFactory.GetDbConnection())
               {
                   var query = "INSERT INTO empeñar1 (cedula, Articulo, identificador, Descripcion, fechade_empeño, fechasalida, monto_a_pagar, Estado,Deuda) " +
                               "VALUES (@Cedula, @Articulo, @Identificador, @Descripcion, @FechaEmpe, @FechaSalida, @MontoApagar, @Estado,@Deudaa)";
                   connection.Execute(query, new { Cedula = cedula, Articulo = articulo, Identificador = identificador, Descripcion = descripcion, 
                       FechaEmpe = fechaEmpe, FechaSalida = fechaSalida, MontoApagar = montoApagar, Estado = estado,Deudaa= Deuda});
               }
           }*/
        public void InsertarEnPeño(string cedula, string articulo, string identificador, string descripcion, DateTime fechaEmpe, DateTime fechaSalida, decimal montoApagar, string estado, decimal deuda, byte[] imagen)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var query = @"
            INSERT INTO empeñar1 (cedula, Articulo, identificador, Descripcion, fechade_empeño, fechasalida, monto_a_pagar, Estado, Deuda,photo )
            VALUES (@Cedula, @Articulo, @Identificador, @Descripcion, @FechaEmpe, @FechaSalida, @MontoApagar, @Estado, @Deuda, @Photo)";
                connection.Execute(query, new
                {
                    Cedula = cedula,
                    Articulo = articulo,
                    Identificador = identificador,
                    Descripcion = descripcion,
                    FechaEmpe = fechaEmpe,
                    FechaSalida = fechaSalida,
                    MontoApagar = montoApagar,
                    Estado = estado,
                    Deuda = deuda,
                    Photo = imagen
                });
            }
        }

        public DataTable cargarDeudores(string cedula)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var query = "SELECT cedula, Articulo, Deuda,fechade_empeño, fechasalida, e.nombre_estado,Photo FROM empeñar1 a JOIN estado e ON a.Estado = e.id_estado WHERE cedula = @Cedula and Estado = 2";
                var adapter = new SqlDataAdapter(query, (SqlConnection)connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Cedula", cedula);

                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }


    }
}
