using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL:IEmployeeRL
    {
        public void AddEmployee(EmployeeModel employee)
        {
            string connectionString = "MyDbconnection";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PayformCredentials", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@IMG", employee.IMG);
                cmd.Parameters.AddWithValue("@NAME", employee.NAME);
                cmd.Parameters.AddWithValue("@GENDER", employee.GENDER);
                cmd.Parameters.AddWithValue("@DEPARTMENT", employee.DEPARTMENT);
                cmd.Parameters.AddWithValue("@SALARY", employee.SALARY);
                cmd.Parameters.AddWithValue("@START_DATE", employee.START_DATE);
                cmd.Parameters.AddWithValue("@NOTES", employee.NOTES);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
