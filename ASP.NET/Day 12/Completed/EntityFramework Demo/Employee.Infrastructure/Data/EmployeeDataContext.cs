using Employee.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Employee.Infrastructure.Data
{
    public class EmployeeDataContext : IEmployeeDataContext
    {
        private string _connectionString;
        private readonly IConfiguration _config;
        public EmployeeDataContext(IConfiguration config)
        {
            _config = config;


            _connectionString = _config.GetConnectionString("DBConnection");


        }

        public DataTable GetEmployees()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetEmployees";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();



                }

            }

        }

        public int CreateEmployee(EmployeeEntity Employee)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    int returnValue = -1;
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "CreateEmployee";

                    //adds a single param to the command object
                    SqlParameter param = new SqlParameter("@FirstName", SqlDbType.VarChar);
                    param.Value = Employee.FirstName;
                    param.Direction = ParameterDirection.Input;
                    command.Parameters.Add(param);

                    //adds params in bulk to the command object
                    List<SqlParameter> paramList = new List<SqlParameter>();
                    param = new SqlParameter("@LastName", SqlDbType.VarChar);
                    param.Value = Employee.LastName;
                    paramList.Add(param);

                    param = new SqlParameter("@EmailAddress", SqlDbType.VarChar)
                    {
                        Value = Employee.EmailAddress
                    };
                    paramList.Add(param);

                    param = new SqlParameter("@Worklocation", SqlDbType.VarChar);
                    param.Value = Employee.Worklocation;
                    paramList.Add(param);

                    param = new SqlParameter("@HomeAddress", SqlDbType.VarChar);
                    param.Value = Employee.HomeAddress;
                    paramList.Add(param);

                    param = new SqlParameter("@Country", SqlDbType.VarChar);
                    param.Value = Employee.Country;
                    paramList.Add(param);

                    //out paramater
                    SqlParameter outParam = new SqlParameter("@EmployeeId", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    paramList.Add(outParam);
                    command.Parameters.AddRange(paramList.ToArray());


                    conn.Open();
                    command.ExecuteNonQuery();
                    int.TryParse(outParam.Value.ToString(), out returnValue);
                    conn.Close();
                    return returnValue;
                }

            }
        }

        public DataTable UpdateEmployee(EmployeeEntity Employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            throw new NotImplementedException();
        }
    }
}
