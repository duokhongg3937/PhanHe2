using Oracle.ManagedDataAccess.Client;
using PhanHe2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PhanHe2
{
    public static class DatabaseHandler
    {
        public static OracleConnection Conn;
        private static string _connectionString = "";


        private static string _username = "";
        private static string _dbOwner = "QLTruongHoc";

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

        #region ...

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

        public static bool UpdateCell(string owner, string tableName, Dictionary<string, object> updates, Dictionary<string, object> conditions)
        {
            // Construct SET clause
            List<string> updateClauses = new List<string>();
            foreach (var update in updates)
            {
                updateClauses.Add($"{update.Key} = :{update.Key}");
            }
            string updateClause = string.Join(", ", updateClauses);

            // Construct WHERE clause
            List<string> conditionClauses = new List<string>();
            foreach (var condition in conditions)
            {
                conditionClauses.Add($"{condition.Key} = :{condition.Key}");
            }
            string conditionClause = string.Join(" AND ", conditionClauses);

            string query = $"UPDATE {owner}.{tableName} SET {updateClause} WHERE {conditionClause}";

            OracleCommand command = new OracleCommand(query, Conn);

            foreach (var update in updates)
            {
                command.Parameters.Add(new OracleParameter(update.Key, update.Value));
            }

            foreach (var condition in conditions)
            {
                command.Parameters.Add(new OracleParameter(condition.Key, condition.Value));
            }

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

        public static DataTable GetAll(string owner, string tableName, string condition)
        {
            string query = $"SELECT * FROM {owner}.{tableName} WHERE {condition}";
            OracleCommand command = new OracleCommand(query, Conn);

            DataTable dataTable = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter(command);
            adapter.Fill(dataTable);

            return dataTable;
        }

        public static bool Insert(string owner, string tableName, Dictionary<string, object> columnValues)
        {
            string columns = string.Join(", ", columnValues.Keys);
            string values = string.Join(", ", columnValues.Keys.Select(key => $":{key}"));
            string query = $"INSERT INTO {owner}.{tableName} ({columns}) VALUES ({values})";

            OracleCommand command = new OracleCommand(query, Conn);

            foreach (var columnValue in columnValues)
            {
                command.Parameters.Add(new OracleParameter(columnValue.Key, columnValue.Value));
            }

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            } 
            catch (OracleException ex)
            {
                if (ex.ErrorCode == 28815)
                {
                    MessageBox.Show("Không thể thêm do không trong thời gian hiệu chỉnh");
                }
                else
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
                return false;
            }
        }
       
        public static bool Delete(string owner, string tableName, Dictionary<string, object> conditions)
        {
            List<string> conditionClauses = new List<string>();
            foreach (var condition in conditions)
            {
                conditionClauses.Add($"{condition.Key} = :{condition.Key}");
            }
            
            string conditionClause = string.Join(" AND ", conditionClauses);
            string query = $"DELETE FROM {owner}.{tableName} WHERE {conditionClause}";

            OracleCommand command = new OracleCommand(query, Conn);

            foreach (var condition in conditions)
            {
                command.Parameters.Add(new OracleParameter(condition.Key, condition.Value));
            }

            int rowsAffected = command.ExecuteNonQuery();   
            return (rowsAffected > 0);
        }

        public static bool ExecuteCheckValidEnrollingTime(int hk, int nam)
        {
            OracleCommand command = new OracleCommand("SYS.UF_TRONGTHOIGIANDANGKY", Conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            OracleParameter returnValue = new OracleParameter
            {
                OracleDbType = OracleDbType.Int32,
                Direction = ParameterDirection.ReturnValue
            };
            command.Parameters.Add(returnValue);

            OracleParameter p_hk = new OracleParameter("p_hk", OracleDbType.Int32)
            {
                Direction = ParameterDirection.Input,
                Value = hk
            };
            command.Parameters.Add(p_hk);

            OracleParameter p_nam = new OracleParameter("p_nam", OracleDbType.Int32)
            {
                Direction = ParameterDirection.Input,
                Value = nam
            };
            command.Parameters.Add(p_nam);

            command.ExecuteNonQuery();

            int result = Convert.ToInt32(returnValue.Value.ToString());
            return (result == 1);
        }

        #endregion

        #region related func for SINHVIEN portal
        public static bool IsStudent()
        {
            return _username.Contains("SV") ? true : false;
        }

        public static SinhVien GetStudentInfo()
        {
            string query = $"SELECT * FROM QLTruongHoc.SINHVIEN WHERE MASV=:username";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("username", _username));


            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string masv = reader["MASV"].ToString();
                string hoten = reader["HOTEN"].ToString();
                string phai = reader["PHAI"].ToString();
                string dchi = reader["DCHI"].ToString();
                DateTime ngSinh = reader.GetDateTime(reader.GetOrdinal("NGSINH")); // Lấy giá trị kiểu DateTime
                string sdt = reader["SDT"].ToString();
                string mact = reader["MACT"].ToString();
                string manganh = reader["MANGANH"].ToString();
                int sotctl = reader.GetInt32(reader.GetOrdinal("SOTCTL")); // Lấy giá trị kiểu int
                double dtbtl = reader.GetDouble(reader.GetOrdinal("DTBTL")); // Lấy giá trị kiểu double

                SinhVien sv = new SinhVien
                {
                    MaCT = mact,
                    MaSV = masv,
                    MaNganh = manganh,
                    HoTen = hoten,
                    Phai = phai,
                    DChi = dchi,
                    NgSinh = ngSinh,
                    SDT = sdt,
                    SoTCTL = sotctl,
                    DTBTL = dtbtl,
                };

                return sv;
                
            }

            return null;

        }

        public static bool UpdateStudentInfo(string sdt, string diachi)
        {
            string query = $"UPDATE QLTruongHoc.SINHVIEN " +
                            $"SET SDT = :value1 , DCHI = :value2 " +
                            $"WHERE MASV = :masv";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("value1", sdt));
            command.Parameters.Add(new OracleParameter("value2", diachi));
            command.Parameters.Add(new OracleParameter("masv", _username));

            int rowsAffected = command.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        public static DataTable GetAllCourseResult(int year, int semester)
        {
            DataTable dataTable = new DataTable();

            // Thêm một cột mới để lưu số thứ tự
            dataTable.Columns.Add("STT", typeof(int));

            string query = @"
                    SELECT dk.NAM, dk.HK, hp.MAHP, hp.TENHP, hp.SOTC, dk.DIEMTH, dk.DIEMQT, dk.DIEMCK, dk.DIEMTK
                    FROM QLTruongHoc.DANGKY dk JOIN QLTruongHoc.HOCPHAN hp ON dk.MAHP = hp.MAHP
                    WHERE dk.MASV = :userid AND dk.MACT = :mact
            ";

            // Nếu year khác -1, thêm điều kiện dk.NAM = year
            if (year != -1)
            {
                query += " AND dk.NAM = :yearValue";
            }

            // Nếu semester khác -1, thêm điều kiện dk.HK = semester
            if (semester != -1)
            {
                query += " AND dk.HK = :semesterValue";
            }

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("userid", _username));
            command.Parameters.Add(new OracleParameter("mact", GetMaCT()));


            // Thêm tham số yearValue nếu được sử dụng
            if (year != -1)
            {
                command.Parameters.Add(new OracleParameter("yearValue", year));
            }

            // Thêm tham số semesterValue nếu được sử dụng
            if (semester != -1)
            {
                command.Parameters.Add(new OracleParameter("semesterValue", semester));
            }


            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện câu truy vấn: " + ex.Message);
                // Xử lý ngoại lệ nếu cần thiết
            }
            return dataTable;
        }


        public static List<string> GetAllYears_Student_Tab2()
        {
            List<string> res = new List<string>();

                            string query = $"select distinct NAM from QLTruongHoc.DANGKY WHERE MASV = :userid";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("userid", _username));


            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                res.Add(reader.GetInt32(reader.GetOrdinal("NAM")).ToString());

            }

            return res;
        }

        public static List<string> GetAllSemesters_Student_Tab2()
        {
            List<string> res = new List<string>();

            string query = $"select distinct HK from QLTruongHoc.DANGKY WHERE MASV = :userid";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("userid", _username));


            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                res.Add(reader.GetInt32(reader.GetOrdinal("HK")).ToString());

            }

            return res;
        }

        public static DataTable GetAll_KHMO_Tab3(int year, int semester)
        {


            DataTable dataTable = new DataTable();

            // Thêm một cột mới để lưu số thứ tự
            dataTable.Columns.Add("STT", typeof(int));

            string query = @"
                                SELECT khm.NAM, khm.HK, hp.MAHP, hp.TENHP, hp.SOTC, hp.STLT, hp.STTH, hp.SOSVTD
                                FROM QLTruongHoc.HOCPHAN hp join QLTruongHoc.KHMO khm ON hp.MAHP = khm.MAHP
                                WHERE khm.MACT = (SELECT MACT FROM QLTruongHoc.SINHVIEN WHERE MASV = :userid)
            ";

            // Nếu year khác -1, thêm điều kiện dk.NAM = year
            if (year != -1)
            {
                query += " AND khm.NAM = :yearValue";
            }

            // Nếu semester khác -1, thêm điều kiện dk.HK = semester
            if (semester != -1)
            {
                query += " AND khm.HK = :semesterValue";
            }

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("userid", _username));

            // Thêm tham số yearValue nếu được sử dụng
            if (year != -1)
            {
                command.Parameters.Add(new OracleParameter("yearValue", year));
            }

            // Thêm tham số semesterValue nếu được sử dụng
            if (semester != -1)
            {
                command.Parameters.Add(new OracleParameter("semesterValue", semester));
            }


            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện câu truy vấn: " + ex.Message);
                // Xử lý ngoại lệ nếu cần thiết
            }

            return dataTable;
        }

        public static List<string> GetAllYears_KHMO_Tab3()
        {
            List<string> res = new List<string>();

            string query = $"SELECT distinct NAM from QLTRuongHoc.KHMO WHERE MACT = (SELECT MACT FROM QLTruongHoc.SINHVIEN WHERE MASV = :userid)";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("userid", _username));


            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                res.Add(reader.GetInt32(reader.GetOrdinal("NAM")).ToString());

            }

            return res;
        }

        public static List<string> GetAllSemesters_KHMO_Tab3()
        {
            List<string> res = new List<string>();

            string query = $"SELECT distinct HK from QLTRuongHoc.KHMO WHERE MACT = (SELECT MACT FROM QLTruongHoc.SINHVIEN WHERE MASV = :userid)";

            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("userid", _username));


            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                res.Add(reader.GetInt32(reader.GetOrdinal("HK")).ToString());

            }

            return res;
        }

        public static string GetMaCT()
        {
            string mact = "";
            try
            {
                string _query = @"
                            SELECT MACT
                            FROM QLTruongHoc.SINHVIEN
                            WHERE MASV = :masv
        ";

                OracleCommand _command = new OracleCommand(_query, Conn);
                _command.Parameters.Add(new OracleParameter("masv", _username));

                OracleDataReader reader = _command.ExecuteReader();

                if (reader.Read())
                {
                    // Đọc giá trị MACT từ kết quả truy vấn và gán vào thuộc tính dk.MaCT
                    mact = reader["MACT"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Xử lý exception nếu cần thiết
                Console.WriteLine("Lỗi khi đọc MACT từ SINHVIEN: " + ex.Message);

            }
            return mact;
        }

        public static DataTable GetResultCourseRegister(int year, int semester)
        {
            DataTable dataTable = new DataTable();

            // Thêm một cột mới để lưu số thứ tự
            dataTable.Columns.Add("STT", typeof(int));
            string mact = GetMaCT();


            string query = @"
                                SELECT dk.NAM, dk.HK, hp.MAHP, hp.TENHP, hp.SOTC, hp.STLT, hp.STTH, dk.MACT
                                FROM QLTruongHoc.HOCPHAN hp join QLTruongHoc.DANGKY dk ON hp.MAHP = dk.MAHP
                                WHERE dk.MASV = :userid AND dk.NAM = :yearValue AND dk.HK = :semesterValue 
            ";


            OracleCommand command = new OracleCommand(query, Conn);
            command.Parameters.Add(new OracleParameter("userid", _username));

            //command.Parameters.Add(new OracleParameter("mact", mact));

            command.Parameters.Add(new OracleParameter("yearValue", year));        
                command.Parameters.Add(new OracleParameter("semesterValue", semester));


            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực hiện câu truy vấn: " + ex.Message);
                // Xử lý ngoại lệ nếu cần thiết
            }

            return dataTable;
        }

        public static bool CanRegisterCourses(int day, int month, int year, int semester)
        {
            // Tạo đối tượng DateTime từ tham số day, month, year
            DateTime currentDate = new DateTime(year, month, day);

            // Chuẩn bị truy vấn để lấy NGAYBD và NGAYKT từ bảng sự kiện
            string query = @"
            SELECT NGAYBD, NGAYKT
            FROM QLTruongHoc.SUKIEN
            WHERE TENSK = 'DKHP' AND NAM = :year AND HK = :semester 
        ";

            using (OracleCommand command = new OracleCommand(query, Conn))
            {
                // Thêm tham số cho năm và học kỳ
                command.Parameters.Add(":year", OracleDbType.Int32).Value = year;
                command.Parameters.Add(":semester", OracleDbType.Int32).Value = semester;

                // Đọc dữ liệu từ cơ sở dữ liệu
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime ngayBD = reader.GetDateTime(0);
                        DateTime ngayKT = reader.GetDateTime(1);

                        // Kiểm tra ngày hiện tại có nằm trong khoảng ngày bắt đầu và kết thúc của sự kiện DKHP không
                        if (currentDate >= ngayBD && currentDate <= ngayKT)
                        {
                            return true; // Ngày hiện tại nằm trong khoảng ngày bắt đầu và kết thúc của sự kiện DKHP
                        }
                    }
                }
            }
        

            return false;  // Ngày hiện tại không nằm trong khoảng ngày bắt đầu và kết thúc của sự kiện DKHP
        }

        public static DataTable _GetAll_KHMO_UnRegister_Tab4(int year, int semester)
        {
            DataTable dataTable = new DataTable();

            // Thêm một cột mới để lưu số thứ tự
            dataTable.Columns.Add("STT", typeof(int));

            string mact = GetMaCT();

            string query = @"
               SELECT khm.NAM, khm.HK, hp.MAHP, hp.TENHP, hp.SOTC, hp.STLT, hp.STTH, khm.MACT
        FROM QLTruongHoc.HOCPHAN hp 
        JOIN QLTruongHoc.KHMO khm ON hp.MAHP = khm.MAHP
        WHERE TO_CHAR(khm.MACT) = TO_CHAR(:mactValue)
            AND TO_NUMBER(khm.NAM) = TO_NUMBER(:year1) 
            AND TO_NUMBER(khm.HK) = TO_NUMBER(:semester1)
            AND hp.MAHP NOT IN
        (
        SELECT hp.MAHP
        FROM QLTruongHoc.HOCPHAN hp 
        JOIN QLTruongHoc.DANGKY dk ON hp.MAHP = dk.MAHP
        WHERE TO_CHAR(dk.MASV)= TO_CHAR(:userid2) 
            AND TO_NUMBER(dk.NAM) = TO_NUMBER(:year2) 
            AND TO_NUMBER(dk.HK) = TO_NUMBER(:semester2)
        )
";

            {
                using (OracleCommand command = new OracleCommand(query, Conn))
                {
                    command.Parameters.Add(new OracleParameter("userid2", _username));
                    command.Parameters.Add(new OracleParameter("mactValue", OracleDbType.Varchar2) { Value = mact });

                    // Chuyển đổi year và semester sang kiểu NUMBER trước khi thêm vào parameters
                    command.Parameters.Add(new OracleParameter("year1", OracleDbType.Int32) { Value = year });
                    command.Parameters.Add(new OracleParameter("year2", OracleDbType.Int32) { Value = year });
                    command.Parameters.Add(new OracleParameter("semester1", OracleDbType.Int32) { Value = semester });
                    command.Parameters.Add(new OracleParameter("semester2", OracleDbType.Int32) { Value = semester });

                    try
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi thực hiện câu truy vấn: " + ex.Message);
                        // Xử lý ngoại lệ nếu cần thiết
                    }
                }
            }



            return dataTable;
        }

        public static DataTable GetAll_KHMO_UnRegister_Tab4(int year, int semester)
        {
            DataTable dataTable = new DataTable();

            // Thêm một cột mới để lưu số thứ tự
            dataTable.Columns.Add("STT", typeof(int));

            string mact = GetMaCT();

            string query = @"
               SELECT khm.NAM, khm.HK, hp.MAHP, hp.TENHP, hp.SOTC, hp.STLT, hp.STTH, khm.MACT
        FROM QLTruongHoc.HOCPHAN hp 
        JOIN QLTruongHoc.KHMO khm ON hp.MAHP = khm.MAHP
        WHERE TO_CHAR(khm.MACT) = TO_CHAR(:mactValue)
            AND TO_NUMBER(khm.NAM) = TO_NUMBER(:year1) 
            AND TO_NUMBER(khm.HK) = TO_NUMBER(:semester1)
         
";

            {
                using (OracleCommand command = new OracleCommand(query, Conn))
                {
                    command.Parameters.Add(new OracleParameter("mactValue", OracleDbType.Varchar2) { Value = mact });

                    // Chuyển đổi year và semester sang kiểu NUMBER trước khi thêm vào parameters
                    command.Parameters.Add(new OracleParameter("year1", OracleDbType.Int32) { Value = year });
                    command.Parameters.Add(new OracleParameter("semester1", OracleDbType.Int32) { Value = semester });

                    try
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi thực hiện câu truy vấn: " + ex.Message);
                        // Xử lý ngoại lệ nếu cần thiết
                    }
                }
            }



            return dataTable;
        }



        public static bool HandleUnRegisterCourse(DangKy dk)
        {
            bool success = false;

            dk.MaCT = GetMaCT();
            dk.MaSV = _username;

            try
            {
                string deleteQuery = @"
                                        DELETE FROM QLTruongHoc.DANGKY
                                        WHERE MASV = :masv AND MAHP = :mahp AND NAM = :nam AND HK = :hk AND MACT = :mact
    ";

                OracleCommand deleteCommand = new OracleCommand(deleteQuery, Conn);
                deleteCommand.Parameters.Add(new OracleParameter("masv", dk.MaSV));
                deleteCommand.Parameters.Add(new OracleParameter("mahp", dk.MaHP));
                deleteCommand.Parameters.Add(new OracleParameter("nam", dk.Nam));
                deleteCommand.Parameters.Add(new OracleParameter("hk", dk.HK));
                deleteCommand.Parameters.Add(new OracleParameter("mact", dk.MaCT));


                int rowsDeleted = deleteCommand.ExecuteNonQuery();

                if (rowsDeleted > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception nếu cần thiết
                Console.WriteLine("Lỗi khi thực hiện thao tác xóa đăng ký học phần: " + ex.Message);
            }

            return success;


        }

        public static bool HandleRegisterCourse(DangKy dk)
        {

            bool success = false;

            dk.MaSV = _username;
            dk.MaCT = GetMaCT();

            try
            {
                string query = @"
                                INSERT INTO QLTruongHoc.DANGKY (MASV, MAHP, NAM, HK, MACT)
                                VALUES (:masv, :mahp, :nam, :hk, :mact)
        ";

                OracleCommand command = new OracleCommand(query, Conn);
                command.Parameters.Add(new OracleParameter("masv", dk.MaSV));
                command.Parameters.Add(new OracleParameter("mahp", dk.MaHP));
                command.Parameters.Add(new OracleParameter("nam", dk.Nam));
                command.Parameters.Add(new OracleParameter("hk", dk.HK));
                command.Parameters.Add(new OracleParameter("mact", dk.MaCT));

                //  thực thi câu lệnh
                int rowsInserted = command.ExecuteNonQuery();

                if (rowsInserted > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception nếu cần thiết
                Console.WriteLine("Lỗi khi thực hiện thao tác đăng ký học phần: " + ex.Message);

            }

            return success;
        }

        #endregion

    }



}
