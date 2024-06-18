using Oracle.ManagedDataAccess.Client;
using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace PhanHe2
{
    public static class DatabaseHandler
    {
        public static OracleConnection Conn;
        private static string _connectionString = "";
        private static string _username = "";


        public static ConnectionResult Connect(string username, string password)
        {
            string host = ConfigurationManager.AppSettings["Host"];
            string port = ConfigurationManager.AppSettings["Port"];
            string sid = ConfigurationManager.AppSettings["SID"];


            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder
            {
                DataSource = $"(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port}))(CONNECT_DATA=(SID={sid})))",
                UserID = username,
                Password = password,
            };

            _connectionString = builder.ToString();

            try
            {
                Conn = new OracleConnection(_connectionString);
                Conn.Open();

                _username = username.Trim();

                return new ConnectionResult(ConnectionStatus.Success, "Login Successful!"); ;
            }
            catch (OracleException ex)
            {
                // ORA-01017: login denied
                return ex.Number == 1017
                    ? new ConnectionResult(ConnectionStatus.InvalidCredentials, "Invalid username or password!")
                    : new ConnectionResult(ConnectionStatus.ConnectionError, "Failed to connect: " + ex.Message);
            }
            catch (Exception ex)
            {
                return new ConnectionResult(ConnectionStatus.Failure, "An error occurred: " + ex.Message);
            }
        }

        public static void Disconnect()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }

        public static string GetUserRole(string username)
        {
            string role = "";
            string query = "SELECT GRANTED_ROLE FROM USER_ROLE_PRIVS WHERE USERNAME = :username AND GRANTED_ROLE LIKE '%C##RL_%'";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("username", username));
            
            object result = command.ExecuteScalar();
            if (result != null) role = command.ExecuteScalar().ToString();

            return role;
        }

        // test
        public static DataTable GetUserTableNames(string username)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT OWNER, TABLE_NAME FROM USER_TAB_PRIVS WHERE GRANTEE = :username AND PRIVILEGE ='SELECT'";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("username", username));

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            adapter.Fill(dataTable);

            return dataTable;
        }

        // test
        public static DataTable GetUserTable(DataTable namesTable)
        {
            DataTable dataTable = new DataTable();

            foreach (DataRow row in namesTable.Rows)
            {
                string owner = row["OWNER"].ToString();
                string tableName = row["TABLE_NAME"].ToString();

                string query = $"SELECT * FROM {owner}.{tableName}";

                OracleCommand command = new OracleCommand(query, Conn);
                OracleDataAdapter adapter = new OracleDataAdapter(command);

                DataTable tempTable = new DataTable();
                adapter.Fill(tempTable);

                foreach (DataColumn column in tempTable.Columns)
                {
                    column.ColumnName = $"{tableName}_{column.ColumnName}";
                }

                dataTable.Merge(tempTable, true, MissingSchemaAction.Add);
            }

            return dataTable;
        }

        public static List<RoleTablePrivilege> GetRoleTablePrivileges()
        {
            List<RoleTablePrivilege > result = new List<RoleTablePrivilege>();
            string query = $"SELECT * FROM ROLE_TAB_PRIVS";

            OracleCommand command = new OracleCommand(query, Conn);

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string role = reader.GetString(0);
                string owner = reader.GetString(1);
                string tableName = reader.GetString(2);
                object columnData = reader.GetValue(3);
                string columnName = columnData == DBNull.Value ? null : columnData.ToString();
                string privilege = reader.GetString(4);

                RoleTablePrivilege roleTablePrivilege = new RoleTablePrivilege
                {
                    Role = role,
                    Owner = owner,
                    TableName = tableName,
                    ColumnName = columnName,
                    Privilege = privilege
                };

                result.Add(roleTablePrivilege);
            }

            return result;
        }

        /// <summary>
        /// Hàm cập nhật giá trị 1 cột trong bảng dữ liệu
        /// </summary>
        /// <param name="owner">User sở hữu bảng</param>
        /// <param name="tableName">Tên bảng</param>
        /// <param name="colName">Tên cột</param>
        /// <param name="newVal">Giá trị cần update</param>
        /// <returns></returns>
        public static bool UpdateCell(string owner, string tableName, string colName, object newVal)
        {
            string query = $"UPDATE {owner}.{tableName} " +
                $"SET {colName} = :newVal";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("newVal", newVal));

            int rowsAffected = command.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        public static bool UpdateCell(string owner, string tableName, string colName, object newVal, string conditionCol, object conditionVal)
        {
            string query = $"UPDATE {owner}.{tableName} " +
                $"SET {colName} = :newVal " +
                $"WHERE {conditionCol} = :conditionVal";

            OracleCommand command = new OracleCommand(query, Conn) ;
            command.Parameters.Add(new OracleParameter("newVal", newVal)); 
            command.Parameters.Add(new OracleParameter("conditionVal", conditionVal));

            int rowsAffected = command.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        public static DataTable GetAll(string owner, string tableName)
        {
            string query = $"SELECT * FROM {owner}.{tableName}";
            OracleCommand command = new OracleCommand(query, Conn);

            DataTable dataTable = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter(command);
            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}
