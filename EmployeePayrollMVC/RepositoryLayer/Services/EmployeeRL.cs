using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration Configuration;
        public EmployeeRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void AddEmployee(EmployeeModel employee)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
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
        public List<EmployeeModel> getEmployeeList()
        {
            List<EmployeeModel> EmpList = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("allEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    EmpList.Add(
                        new EmployeeModel
                        {
                            emp_id = Convert.ToInt32(dr["emp_id"]),
                            NAME = Convert.ToString(dr["NAME"]),
                            IMG = Convert.ToString(dr["IMG"]),
                            GENDER = Convert.ToString(dr["GENDER"]),
                            DEPARTMENT = Convert.ToString(dr["DEPARTMENT"]),
                            SALARY = Convert.ToString(dr["SALARY"]),
                            START_DATE = Convert.ToString(dr["START_DATE"]),
                            NOTES = Convert.ToString(dr["NOTES"])
                        }
                        );
                }
            }
            return EmpList;
        }
        public EmployeeModel getEmployeeById(int? id)
        {
            EmployeeModel employee = new EmployeeModel();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                string sqlQuery = "SELECT * FROM employee_payroll WHERE emp_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.emp_id = Convert.ToInt32(rdr["emp_id"]);
                    employee.NAME = rdr["NAME"].ToString();
                    employee.IMG = rdr["IMG"].ToString();
                    employee.GENDER = rdr["GENDER"].ToString();
                    employee.DEPARTMENT = rdr["DEPARTMENT"].ToString();
                    employee.SALARY = Convert.ToString(rdr["SALARY"]);
                    employee.START_DATE = Convert.ToString(rdr["START_DATE"]);
                    employee.NOTES = rdr["NOTES"].ToString();
                }
            }
            return employee;
        }

        public void deleteEmployee(EmployeeModel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("deleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_id", employeemodel.emp_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void editEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("updateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_id", employeeModel.emp_id);
                cmd.Parameters.AddWithValue("@NAME", employeeModel.NAME);
                cmd.Parameters.AddWithValue("@IMG", employeeModel.IMG);
                cmd.Parameters.AddWithValue("@GENDER", employeeModel.GENDER);
                cmd.Parameters.AddWithValue("@DEPARTMENT", employeeModel.DEPARTMENT);
                cmd.Parameters.AddWithValue("@SALARY", employeeModel.SALARY);
                cmd.Parameters.AddWithValue("@START_DATE", employeeModel.START_DATE);
                cmd.Parameters.AddWithValue("@NOTES", employeeModel.NOTES);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
