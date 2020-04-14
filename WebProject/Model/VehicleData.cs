using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebProject.Model
{
    public class VehicleData
    {
        public VehicleData()
        { }
        public int VehicleTrackingId { get; set; }
        public long IMEI { get; set; }
        public int ThingType { get; set; }
        public int TotalPlotsReviewed { get; set; }
        public float Missing { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string PayloadId { get; set; }
        public string FeedProvider { get; set; }
        public string LastMessagedReceived { get; set; }

        static readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // This method returns a list of VehicleData
        public List<VehicleData> GetVehicleData()
        {
            List<VehicleData> vehicleData = new List<VehicleData>();
            string query = "select * from PlotValidation";

            // Dapper mapper
            using(IDbConnection con = new SqlConnection(connectionstring))
            {
                // If the state of the connection is close, let's open a new one to connect
                if (con.State == ConnectionState.Closed)
                    con.Open();

                // Query() method maps the column in the database table with the properties
                // within this class, and populates the properties with the data from the columns
                vehicleData = con.Query<VehicleData>(query).ToList();
            }
            return vehicleData;
        }
    }
}
