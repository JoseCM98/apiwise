using apiwise.Data;
using apiwise.Interface;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using System.Reflection;

namespace apiwise.Service
{
    public class ServiceProcedureSql : IProcedureSql
    {
        public readonly DataContext _datacontext;
        public ServiceProcedureSql(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public string ExecuteProcedureSql(string nameProcedure, MySqlParameter[] param)
        {
            string studentName = "";
            using (var conn = _datacontext.Database.GetDbConnection())
            {
                var cmm = conn.CreateCommand();
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.CommandText = nameProcedure;
                cmm.Parameters.AddRange(param);
                cmm.Connection = conn;
                conn.Open();
                var reader = cmm.ExecuteReader();
                while (reader.Read())
                {
                    studentName = Convert.ToString(reader[0]);
                }
            }
            return studentName;
        }

        public Dictionary<string, dynamic> ExecuteProcedureSqlObj(string nameProcedure, MySqlParameter[] param)
        {
            Dictionary<string, dynamic> Objeto = new();
            using (var conn = _datacontext.Database.GetDbConnection())
            {
                var cmm = conn.CreateCommand();
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.CommandText = nameProcedure;
                cmm.Parameters.AddRange(param);
                cmm.Connection = conn;
                conn.Open();
                var reader = cmm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.FieldCount > 0)
                    {
                        for (int i = 0; i <= reader.FieldCount - 1; i++)
                        {
                            Objeto.Add(reader.GetName(i), reader[i]);
                        }
                    }
                }
            }
            return Objeto;
        }

        public MySqlParameter[] ParameterMysqlObject(Object oss)
        {

            Type t = oss.GetType();
            PropertyInfo[] pi = t.GetProperties();
            MySqlParameter[] param = new MySqlParameter[pi.Length];
            int contador = 0;
            foreach (PropertyInfo p in pi)
            {
                var idCab = p.GetValue(oss);
                param[contador] = (new MySqlParameter() { ParameterName = $"@{p.Name}", Value = idCab });

            }
            return param;

        }


    }
}
