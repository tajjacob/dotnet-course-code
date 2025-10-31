using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;



namespace HelloWorld.Data
{
    public class DataContextDapper
    {
        private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=false;User Id=sa;Password=SQLConnect1!;"; // for mac or linux authentication

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
                       
                    
                 } public int ExecuteSqlWithRowCount<T>(string sql, T parameters) // explanation: Generic method to execute a SQL command (like INSERT, UPDATE, DELETE)
                 {
                      IDbConnection dbConnection = new SqlConnection(_connectionString); 
                     return dbConnection.Execute(sql, parameters); // returns the number of rows affected 
                       
                    
                 }     }
}
