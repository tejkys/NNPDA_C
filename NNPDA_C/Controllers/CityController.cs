using System.Data;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace NNPDA_C.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CityController : ControllerBase
    {
        [HttpGet("{city}")]
        public List<string> GetThreeNearestCities(string city)
        {
            List<string> cityList = new List<string>();
            OracleConnection connection = new();
            connection.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)" +
                                          "(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=medvidek;Password=sexyMedvidek;";
            connection.Open();

            OracleCommand command = new();
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT id, name, SDO_NN_DISTANCE(1) AS distance FROM cities WHERE SDO_NN(location, SDO_GEOMETRY( 2001,8307,SDO_POINT_TYPE((SELECT longitude FROM cities WHERE name=:CITY) ,(SELECT latitude FROM cities WHERE name=:CITY) , NULL),NULL, NULL ),'sdo_num_res=4 unit=KM',1) = 'TRUE' ORDER BY distance";
            command.Parameters.Add(new OracleParameter("CITY", city));
            command.Connection = connection;
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cityList.Add($"Město: {reader.GetString(1)} - {reader.GetString(2)} Km");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                return new List<string>() {"No city found" };}
            
            connection.Close();

            return cityList;
        }
    }
}
