using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Data.SqlServerCe;
using log4net;

namespace TalBrody.DataLayer
{
    public class BaseDal
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static dynamic portalConection;
        public static string ConectionString { get; set; }

        public static dynamic PortalConection {
            get
            {
                if (portalConection != null)
                {
                    if (portalConection is SqlConnection)
                        return new SqlConnection(ConectionString);
                    else return new SqlCeConnection(ConectionString);
                }
                return new SqlConnection(ConectionString);
               
            }
            set
            {
                portalConection = value;
            }
        }

        private static string GetAppHarborConnectionString()
        {
            var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];
            var uri = new Uri(uriString);
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = uri.Host,  
                InitialCatalog = uri.AbsolutePath.Trim('/'),
                UserID = uri.UserInfo.Split(':').First(),
                Password = uri.UserInfo.Split(':').Last(),
            }.ConnectionString;

            return connectionString;
        }

        private static dynamic GetPortalConnection()
        {
            dynamic conn = null;
            ConectionString = null;
            if (Global.OnAppHarbor)
            {
                ConectionString = GetAppHarborConnectionString();
                Log.Info("GetPortalConnection: OnAppHarbor, connection string: " + ConectionString);
                conn = new SqlConnection(ConectionString);
                return conn;
            }

            ConectionString = ConfigurationManager.ConnectionStrings["OxifySqlConection"].ConnectionString;
            ConectionString += ";Connect Timeout=1";
            Log.Info("GetPortalConnection: Not OnAppHarbor, connection string: " + ConectionString);
            conn = new SqlConnection(ConectionString);
            if (!CheckIfconectionStringValid(conn))
            {
                ConectionString = ConfigurationManager.ConnectionStrings["OxifyConection"].ConnectionString;
                Log.Info("GetPortalConnection: Not OnAppHarbor, connection string: " + ConectionString);
                CheckAndCreate(ConectionString);
                conn = new SqlCeConnection(ConectionString);
            }
            return conn;
        }

        private static void CheckAndCreate(string ConnectionString)
        {
            try
            {
                SqlCeEngine engine = new SqlCeEngine(ConnectionString);
              
                engine.CreateDatabase();

            }
            catch (Exception )
            {
                // it's ok if its already created...
                return;
            }
        }

        private static bool CheckIfconectionStringValid(SqlConnection con)
        {
            bool result = false;
            try
            {
                con.Open();
                result = true;
                con.Close();

            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }

        public static dynamic GetCommand(string command, dynamic conection)
        {
            dynamic result = null;
            if (portalConection is SqlConnection)
            {
                result = new SqlCommand(command, conection);
            }
            else
            {
                result = new SqlCeCommand(command, conection);
            }

            return result;
        }

        public static dynamic GetSqdataReder(dynamic dr)
        {
            dynamic result = null;
            result =( portalConection is SqlConnection)? (dynamic) (SqlDataReader) dr: (SqlCeDataReader) dr;

            return result;
        }

        static BaseDal()
        {
            PortalConection = GetPortalConnection();
        }

        public bool CheckTableExists(string table)
        {
            bool exists = false;
            try
            {
                using (var myConnection = PortalConection)
                {
                    
                    var myCommand = GetCommand(string.Format("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE  TABLE_NAME = '{0}'", table), myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myConnection.Open();
                    var dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        exists = true;
                    }
                    myConnection.Close();
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Error("CheckParamExists Threw: " + ex.ToString());
                throw;
            }
            return exists;
        }
        public static void AddWithNullableValue(dynamic command, string parameterName, object value)
        {
            command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
        }
    }
}