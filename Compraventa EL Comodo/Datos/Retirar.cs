using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compraventa_EL_Comodo.Datos
{
    internal class Retirar : IRetirar
    {
        private readonly ISqlConnectionFactory _sqlconnectionFactory;
        public Retirar(ISqlConnectionFactory sqlConnectionFactory) 
        
        { 

            this._sqlconnectionFactory = sqlConnectionFactory;
        }
        public void EjecutarProcedimientoAlmacenado(string cedulaCliente, string articulo, DateTime fecha, decimal montoAdeudado, decimal montoPagado, decimal montoFaltante, int estadoRetiro)
        {
            using (var connection = _sqlconnectionFactory.GetDbConnection())
            {
                connection.Open();

                var query = @"
                    EXEC InsertarRetiroYActualizarEmpeñar
                    @cedulaCliente = @CedulaCliente,
                    @articulo = @Articulo,
                    @fecha = @Fecha,
                    @montoAdeudado = @MontoAdeudado,
                    @montoPagado = @MontoPagado,
                    @montoFaltante = @MontoFaltante,
                    @estadoRetiro = @EstadoRetiro";

                connection.Execute(query, new
                {
                    CedulaCliente = cedulaCliente,
                    Articulo = articulo,
                    Fecha = fecha,
                    MontoAdeudado = montoAdeudado,
                    MontoPagado = montoPagado,
                    MontoFaltante = montoFaltante,
                    EstadoRetiro = estadoRetiro
                });

                MessageBox.Show("El retiro se completo correctamente ", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void InsertarAbono(string cedulaCliente, string articulo, DateTime fechaEmpe ,decimal deuda,decimal abono, decimal nuevoMontoDeuda, DateTime nuevaFechaSalida)
        {
            using (var connection = _sqlconnectionFactory.GetDbConnection())
            {
                connection.Open();

                        
                        var queryInsert = @"
                    INSERT INTO Abono (cedula, Articulo, Fechadeempeño, Deuda, Abono)
                    VALUES (@Cedula, @Articulo, @FechaEmpe, @Deuda, @Abono)";

                connection.Execute(queryInsert, new
                {
                    Cedula = cedulaCliente,
                    Articulo = articulo,
                    FechaEmpe = fechaEmpe,
                    Deuda = deuda,
                    Abono = abono
                });

               
                var queryUpdate = @"
                UPDATE empeñar1
                SET Deuda = @NuevoMontoDeuda,
                    fechaSalida = @NuevaFechaSalida
                WHERE cedula = @CedulaCliente AND Articulo = @Articulo";

                connection.Execute(queryUpdate, new
                {
                    NuevoMontoDeuda = nuevoMontoDeuda,
                    NuevaFechaSalida = nuevaFechaSalida,
                    CedulaCliente = cedulaCliente,
                    Articulo = articulo
                });
                MessageBox.Show("Tabla 'empeñar1' actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




    }
}
