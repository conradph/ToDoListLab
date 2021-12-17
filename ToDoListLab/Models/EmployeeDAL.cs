using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ToDoListLab.Models
{
    public class EmployeeDAL
    {
        public Employee GetEmployee(int id)
        {
            using(var connect = new MySqlConnection(Secret.connection))
            {
                string emSQL = $"Select * from employees where id = {id}";
                connect.Open();
                Employee e = connect.Query<Employee>(emSQL).ToList().First();
                connect.Close();
                return e;
            }
        }
        public List<Employee> GetEmployees()
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string emSQL = $"Select * from employees";
                connect.Open();
                List<Employee> employees = connect.Query<Employee>(emSQL).ToList();
                connect.Close();
                return employees;
            }
        }
        public void CreateEmployee(Employee e)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string emSQL = $"Insert into employees " +
                    $"values(0, '{e.Name}', {e.Hours}, '{e.Title}');";
                connect.Open();
                connect.Query(emSQL);
                connect.Close();
            }
        }
        public void UpdateEmployee(Employee e)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                var sql = $"update employees " +
                    $"set name = '{e.Name}'" +
                    $", hours = {e.Hours}" +
                    $", title = '{e.Title}'" +
                    $" where id = {e.Id}";
                connect.Open();
                connect.Query(sql);
                connect.Close();
            }
        }
        public void DeleteEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                var sql = $"delete from employees " +
                    $" where id = {id}";
                connect.Open();
                connect.Query(sql);
                connect.Close();
            }
        }
    }
}
