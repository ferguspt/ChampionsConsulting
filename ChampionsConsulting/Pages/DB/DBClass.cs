﻿using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;

namespace ChampionsConsulting.Pages.DB
{
    public class DBClass
    {
        // Connection object at the class level
        public static SqlConnection CCDBConnection = new SqlConnection();
        public static SqlConnection AUTHDBConnection = new SqlConnection();

        // Connection string
        // ";TrustServerCertificate=True"
        public static readonly String CCConnString = "Server=Localhost; Database=ChampionsConsulting; Trusted_Connection=True";
        public static readonly String AuthConnString = "Server=Localhost; Database=AUTH; Trusted_Connection=True";

        //Readers for data tables
        public static SqlDataReader UserReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = "SELECT * FROM Users";
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader UserReader(string selectQuery)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

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
            cmdProductRead.CommandText = "SELECT * FROM [Event]";
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
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader EventReader(string selectQuery, SqlParameter[] parameters)
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

        public static SqlDataReader MeetingReader(string selectQuery)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = CCDBConnection;
            cmdProductRead.Connection.ConnectionString = CCConnString;
            cmdProductRead.CommandText = selectQuery;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

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
    }
}

