using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using week3.Models;

namespace week3.Repositories
{
    public class WeatherforecastRepostory
    {
        //連線字串
        private readonly string _connectString;
        private readonly IConfiguration _config;
        public WeatherforecastRepostory(IConfiguration config)
        {
            _config = config;
            _connectString = _config.GetConnectionString("WeatherforecastDatabase");
        }
        public IEnumerable<WeatherCast> ReadAll()
        {
            using var conn = new SqlConnection(_connectString);
            var result = conn.Query<WeatherCast>(this.ReadAllSql());
            return result;
        }
        public WeatherCast ReadByID(int id)
        {
            using var conn = new SqlConnection(_connectString);
            var result = conn.QueryFirstOrDefault<WeatherCast>(this.ReadByIDSql(id));
            return result;
        }
        public IEnumerable<WeatherCast> ReadByFilter(string filter)
        {
            using var conn = new SqlConnection(_connectString);
            var result = conn.Query<WeatherCast>(this.ReadByFilterSql(filter));
            return result;
        }
        public int Create(WeatherCast w)
        {
            using var conn = new SqlConnection(_connectString);
            var rowschange = conn.Execute(this.CreateSql(), w);
            return rowschange;
        }
        public int Update(int id, WeatherCast w)
        {
            using var conn = new SqlConnection(_connectString);
            var rowschange = conn.Execute(this.UpdateSql(id), w);
            return rowschange;
        }
        public int Delete(int id)
        {
            using var conn = new SqlConnection(_connectString);
            var rowschange = conn.Execute(this.DeleteSql(id));
            return rowschange;
        }
        private string ReadAllSql()
        { 
            return "SELECT * FROM WeatherCast WHERE Is_Deleted = 0"; 
        }
        private string ReadByIDSql(int id)
        { 
            return $"SELECT TOP 1 * FROM WeatherCast WHERE ID = {id} AND Is_Deleted = 0"; 
        }
        private string ReadByFilterSql(string filter)
        {
            return $"SELECT * FROM WeatherCast WHERE Summary = \'{filter}\' AND Is_Deleted = 0";
        }
        private string CreateSql()
        {
            return "INSERT INTO WeatherCast (Date,TempC,TempF,Summary,Is_Deleted) " +
                   "VALUES (@Date,@TempC,@TempF,@Summary,@IsDeleted)"; 
        }
        private string UpdateSql(int id)
        {
            return $"UPDATE WeatherCast SET " +
                   $"Date=@Date, TempC=@TempC, TempF=@TempF, Summary=@Summary "+
                   $"WHERE ID= {id} AND Is_Deleted = 0";
        }
        private string DeleteSql (int id)
        {
            return $"UPDATE WeatherCast SET " +
                   $"Is_Deleted = 1" +
                   $"WHERE ID= {id} AND Is_Deleted = 0";
        }
    }
}
