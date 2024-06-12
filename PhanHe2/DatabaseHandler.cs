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
            string query = "SELECT GRANTED_ROLE FROM USER_ROLE_PRIVS WHERE USERNAME = :username AND GRANTED_ROLE LIKE '%C##RL_%'";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("username", username));
            
            string role = command.ExecuteScalar().ToString();
            return role;
        }

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

                // Add the table name as a prefix to each column name to avoid conflicts
                foreach (DataColumn column in tempTable.Columns)
                {
                    column.ColumnName = $"{tableName}_{column.ColumnName}";
                }

                dataTable.Merge(tempTable, true, MissingSchemaAction.Add);
            }

            return dataTable;
        }

        public static List<RoleTablePrivilege> GetRoleTablePrivileges(string role)
        {
            List<RoleTablePrivilege > result = new List<RoleTablePrivilege>();
            string query = $"SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE = :role";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("role", role));

            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string owner = reader.GetString(1);
                string tableName = reader.GetString(2);
                string columnName = reader.GetString(3);
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
    }
}
