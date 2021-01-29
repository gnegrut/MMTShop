using System.Data;
using System.Data.SqlClient;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null);
    }
}
