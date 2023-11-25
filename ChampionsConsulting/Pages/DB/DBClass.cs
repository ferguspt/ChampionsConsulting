using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using ChampionsConsulting.Pages.DataClasses;

namespace ChampionsConsulting.Pages.DB
{
    public class DBClass
    {
        // Connection object at the class level
        public static SqlConnection CCDBConnection = new SqlConnection();
        public static SqlConnection AUTHDBConnection = new SqlConnection();

        // Localhost Connection string
        // Use this when testing things locally
        public static readonly String CCConnString = "Server=Localhost; Database=CCDB; Trusted_Connection=True";
        public static readonly String AuthConnString = "Server=Localhost; Database=AUTH; Trusted_Connection=True";


        // AWS Connection String
        // use this when interacting with AWS
        //private static readonly String CCConnString = @"Server=ccmaindb.cev3oaq5oesc.us-east-1.rds.amazonaws.com;
        //                                                Database=CCDB;uid=CCAdmin;password=1Champions!";
        //public static readonly String AuthConnString = @"Server=ccmaindb.cev3oaq5oesc.us-east-1.rds.amazonaws.com; 
        //                                                Database=AUTH;uid=CCAdmin;password=1Champions!";

        //Readers for data tables
        public static SqlDataReader UserReader()
        {
            SqlCommand cmdUserRead = new SqlCommand();
            cmdUserRead.Connection = CCDBConnection;
            cmdUserRead.Connection.ConnectionString = CCConnString;
            cmdUserRead.CommandText = "SELECT * FROM Users";
            cmdUserRead.Connection.Open();

            SqlDataReader tempReader = cmdUserRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader UserReader(string selectQuery)
        {
            SqlCommand cmdUserRead = new SqlCommand();
            cmdUserRead.Connection = CCDBConnection;
            cmdUserRead.Connection.ConnectionString = CCConnString;
            cmdUserRead.CommandText = selectQuery;
            cmdUserRead.Connection.Open();

            SqlDataReader tempReader = cmdUserRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader LoginReader(string selectQuery, SqlParameter[] parameters)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;

            // Add parameters to the command
            if (parameters != null)
            {
                cmdProductRead.Parameters.AddRange(parameters);
            }

            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader EventReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = "SELECT * FROM Events";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader EventReader(string selectQuery)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader EventReaderCheck(string selectQuery)
        {
            SqlCommand cmdEventRead = new SqlCommand();
            cmdEventRead.Connection = CCDBConnection;
            cmdEventRead.Connection.ConnectionString = CCConnString;
            cmdEventRead.CommandText = selectQuery;
            cmdEventRead.Connection.Open();

            SqlDataReader tempReader = cmdEventRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader EventReader(string selectQuery, SqlParameter[] parameters)
        {
            SqlCommand cmdEventRead = new SqlCommand();
            cmdEventRead.Connection = CCDBConnection;
            cmdEventRead.Connection.ConnectionString = CCConnString;
            cmdEventRead.CommandText = selectQuery;

            // Add parameters to the command
            if (parameters != null)
            {
                cmdEventRead.Parameters.AddRange(parameters);
            }

            cmdEventRead.Connection.Open();

            SqlDataReader tempReader = cmdEventRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader SubEventReader()
        {
            SqlCommand cmdSubEventRead = new SqlCommand();
            cmdSubEventRead.Connection = CCDBConnection;
            cmdSubEventRead.Connection.ConnectionString = CCConnString;
            cmdSubEventRead.CommandText = "SELECT * FROM SubEvent";
            cmdSubEventRead.Connection.Open();

            SqlDataReader tempReader = cmdSubEventRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader SubEventReader(string selectQuery)
        {
            SqlCommand cmdSubEventRead = new SqlCommand();
            cmdSubEventRead.Connection = CCDBConnection;
            cmdSubEventRead.Connection.ConnectionString = CCConnString;
            cmdSubEventRead.CommandText = selectQuery;
            cmdSubEventRead.Connection.Open();

            SqlDataReader tempReader = cmdSubEventRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader ConferenceReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = "SELECT * FROM Conference";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader ConferenceReader(string selectQuery)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader RoomReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = "SELECT * FROM Room";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader RoomReader(string selectQuery)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader MeetingReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = "SELECT * FROM Meeting";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        //public static SqlDataReader SubEventReader(string selectQuery)
        //{
        //    SqlCommand cmdProductRead = new SqlCommand();
        //    cmdProductRead.Connection = CCDBConnection;
        //    cmdProductRead.Connection.ConnectionString = CCConnString;
        //    cmdProductRead.CommandText = selectQuery;
        //    cmdProductRead.Connection.Open();

        //    SqlDataReader tempReader = cmdProductRead.ExecuteReader();

        //    return tempReader;
        //}

        public static SqlDataReader LocationReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = "SELECT * FROM Location";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader LocationReader(string selectQuery)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader AttendEventReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = "SELECT * FROM AttendEvent";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader AttendEventReader(string selectQuery)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader MeetingAttendanceReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = "SELECT * FROM MeetingAttendance";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader MeetingAttendanceReader(string selectQuery)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }


        //User Login
        public static int SecureLogin(string Username, string Password)
        {
            string loginQuery =
                "SELECT COUNT(*) FROM Users where Username = @Username and UserPassword = @Password";

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = CCDBConnection;
            cmdLogin.Connection.ConnectionString = CCConnString;

            cmdLogin.CommandText = loginQuery;
            cmdLogin.Parameters.AddWithValue("@Username", Username);    //@[value] means treat input like a normal string
            cmdLogin.Parameters.AddWithValue("@Password", Password);

            cmdLogin.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            int rowCount = (int)cmdLogin.ExecuteScalar();

            return rowCount;
        }

        public static int LoginQuery(string loginQuery)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = new SqlConnection(CCConnString);
            cmdLogin.CommandText = loginQuery;

            cmdLogin.Connection.Open();

            int rowCount = (int)cmdLogin.ExecuteScalar();

            return rowCount;
        }

        //Stored Precedure Secure Login
        public static int ParameterizedLogin(string Username, string Password)
        {
            SqlCommand cmdParameterizedLogin = new SqlCommand();
            cmdParameterizedLogin.Connection = new SqlConnection(CCConnString);
            cmdParameterizedLogin.CommandType = System.Data.CommandType.StoredProcedure;
            cmdParameterizedLogin.Parameters.AddWithValue("@Username", Username);
            cmdParameterizedLogin.Parameters.AddWithValue("@Password", Password);
            cmdParameterizedLogin.CommandText = "sp_ParameterizedLogin";
            cmdParameterizedLogin.Connection.Open();

            int rowCount = 0;
            if (((int)cmdParameterizedLogin.ExecuteScalar()) > 0)
            {
                rowCount = (int)cmdParameterizedLogin.ExecuteScalar();
                return rowCount;
            }

            return 0;
        }

        public static bool HashedParameterLogin(string Username, string Password)
        {
            string loginQuery =
                "SELECT Password FROM HashedCredentials WHERE Username = @Username";

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = AUTHDBConnection;
            cmdLogin.Connection.ConnectionString = AuthConnString;

            cmdLogin.CommandText = loginQuery;
            cmdLogin.Parameters.AddWithValue("@Username", Username);

            cmdLogin.Connection.Open();

            SqlDataReader hashReader = cmdLogin.ExecuteReader();
            if (hashReader.Read())
            {
                string correctHash = hashReader["Password"].ToString();

                if (PasswordHash.ValidatePassword(Password, correctHash))
                {
                    return true;
                }
            }
            return false;
        }

        public static void CreateHashedUser(string Username, string Password)
        {
            string loginQuery =
                "INSERT INTO HashedCredentials (Username, PasswordHash) values (@Username, @Password)";

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = AUTHDBConnection;
            cmdLogin.Connection.ConnectionString = AuthConnString;

            cmdLogin.CommandText = loginQuery;
            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));

            cmdLogin.Connection.Open();
            cmdLogin.ExecuteNonQuery();
        }

        public static void InsertQuery(string sqlQuery)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = CCDBConnection;
            cmdInsert.Connection.ConnectionString = CCConnString;
            cmdInsert.CommandText = sqlQuery;
            cmdInsert.Connection.Open();
            cmdInsert.ExecuteNonQuery();
        }

        public static void UpdateEvent(Event c)
        {
            String sqlQuery = "Update Events SET";
            sqlQuery += "Name='" + c.Name + "',";
            sqlQuery += "Description='" + c.Description + "',";
            sqlQuery += "StartDateAndTime='" + c.StartDateAndTime + "',";
            sqlQuery += "EndDateAndTime='" + c.EndDateAndTime + "',";
            sqlQuery += "LocationID='" + c.LocationID + "'"
                + "'Where EventNumber=" + c.EventID;

            SqlCommand cmdConferenceRead = new SqlCommand();
            cmdConferenceRead.Connection = CCDBConnection;
            cmdConferenceRead.Connection.ConnectionString = CCConnString;
            cmdConferenceRead.CommandText = sqlQuery;
            cmdConferenceRead.Connection.Open();

            cmdConferenceRead.ExecuteNonQuery();
        }
    }
}

