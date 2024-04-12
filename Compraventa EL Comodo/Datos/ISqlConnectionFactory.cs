using System.Data.Common;

namespace Compraventa_EL_Comodo
{
    public interface ISqlConnectionFactory
    {
        DbConnection GetDbConnection();
    }
}