using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeManagement.DataAccessLayer
{
    public static class EmployeeManagement
    {
       static string cs = "Data Source=.;Initial Catalog = EmployeeManagementSystem; Integrated Security = True";

        public static int AddEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
             SqlCommand cmd = new SqlCommand("spAddEmployee",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@comp", emp.compentency);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@dep", emp.Department);
            int i= cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<Employee> GetAllEmployees()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetEmployees",con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.compentency = Convert.ToInt32(dr.GetValue(1).ToString());
                emp.Name = dr.GetValue(2).ToString();
                emp.salary = Convert.ToInt32(dr.GetValue(3).ToString());
                emp.Department = (dr.GetValue(4).ToString());
                employees.Add(emp);
            }
            return employees;
        }

        public static bool UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@comp", emp.compentency);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@dep", emp.Department);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 0)
                return false;
            else
            {
                return true;
            }
        }

        public static bool DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 0)
                return false;
            else
            {
                return true;
            }
        }
    }
}
