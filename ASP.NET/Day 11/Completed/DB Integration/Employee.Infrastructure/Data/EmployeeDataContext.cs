using Employee.Infrastructure.Entities;
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

        public EmployeeDataContext(String connectionString)
        {
            _connectionString = connectionString;
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

        public DataTable GetEmployees(int EmployeeId=0)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DataTable dtEmployees = new DataTable();
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetEmployees";
                    if (EmployeeId > 0)
                        command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    conn.Open();
                    SqlDataAdapter adpData = new SqlDataAdapter(command);

                    adpData.Fill(dtEmployees);
                    conn.Close();
                }
                return dtEmployees;
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
