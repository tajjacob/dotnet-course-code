using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;



namespace HelloWorld.Data
{
    public class DataContextDapper
    {
        private string? _connectionString;
        // private IConfiguration _config;
        public DataContextDapper(IConfiguration config)
        {
            // _config = config;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<T> LoadData<T>(string sql) // explanation: Generic method to load multiple records from the database
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString); 
            return dbConnection.Query<T>(sql);

        }

        public T LoadDataSingle<T>(string sql) // explanation: Generic method to load a single record from the database
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString); 
            return dbConnection.QuerySingle<T>(sql);


        } 
        
                  public bool ExecuteSql(string sql) // explanation: Generic method to execute a SQL command (like INSERT, UPDATE, DELETE)
                 {
                      IDbConnection dbConnection = new SqlConnection(_connectionString); 
                     return (    dbConnection.Execute(sql) > 0); // returns true if one or more rows were affected
                       
                    
                 } public int ExecuteSqlWithRowCount(string sql, object parameters) // explanation: Generic method to execute a SQL command (like INSERT, UPDATE, DELETE)
                 {
                      IDbConnection dbConnection = new SqlConnection(_connectionString); 
                     return dbConnection.Execute(sql, parameters); // returns the number of rows affected 
                       
                    
                 }
}
}
