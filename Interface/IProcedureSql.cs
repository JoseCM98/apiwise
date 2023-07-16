using MySqlConnector;

namespace apiwise.Interface
{
    public interface IProcedureSql
    {
        public Dictionary<string, dynamic> ExecuteProcedureSqlObj(string nameProcedure, MySqlParameter[] param);
        public string ExecuteProcedureSql(string nameProcedure, MySqlParameter[] param);
        public MySqlParameter[] ParameterMysqlObject(Object clase);
    }
}
