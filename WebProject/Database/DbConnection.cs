using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Logic;

namespace WebProject.Database
{
    public class DbConnection
    {
        public DbConnection()
        { }
        private string dbName = string.Empty;

        // Property
        public string DatabaseName
        {
            get
            {
                return dbName;
            }
            set
            {
                dbName = value;
            }
        }

        public string Password { get; set; }
        private SqlConnection connection = null;
        public SqlConnection Connection
        {
            get
            {
                return connection; // returns a connection
            }
        }

        private static DbConnection _instance = null;
        public static DbConnection Instance()
        { 
            if(_instance == null)
            {
                _instance = new DbConnection();
            }
            return _instance;
        }

        public bool IsConnect()
        {
            if(Connection == null)
            {
                if (String.IsNullOrEmpty(dbName))
                
                    return false;
                string connectionString;
                // Data source - is the name of the server in which the DB is placed
                // Catalog - the name of the database
                connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            return true;
        }

        public void Close()
        {
            connection.Close();
        }


        public void insertValidationMessage()
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                connection = new SqlConnection(connectionString);
                connection.Open();
                
                RandomDataGenerator data = new RandomDataGenerator();
               
                string query = "INSERT INTO dbo.PlotValidation (IMEI, ThingType, TotalPlotsReviewed, Missing, LastUpdateTime, PayloadId, FeedProvider,LastMessagedReceived ) VALUES (@Test,@ThingType,@TotalPlotsReviewed,@Missing,@LastUpdateTime,@PayloadId,@FeedProvider,@LastMessagedReceived)";
                
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Test", data.IMEI);
                    cmd.Parameters.AddWithValue("@ThingType", data.thingType);
                    cmd.Parameters.AddWithValue("@TotalPlotsReviewed", data.TotalPlotsReviewed);
                    cmd.Parameters.AddWithValue("@Missing", data.missing);
                    // Remember to format this 
                    cmd.Parameters.AddWithValue("@LastUpdateTime", data.lastUpdateTime);
                    cmd.Parameters.AddWithValue("@PayloadId", data.payload);
                    cmd.Parameters.AddWithValue("@FeedProvider", data.feedProvider);
                    cmd.Parameters.AddWithValue("@LastMessagedReceived", data.LastMessagedReceived);
                    
                    cmd.ExecuteNonQuery();
                }
                
                connection.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error adding row: " + ex.Message);
                Console.WriteLine();
            }

        }
    }
}
