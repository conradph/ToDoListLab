using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper; 

namespace ToDoListLab.Models
{
    public class ToDoDAL
    {
        public ToDo GetToDo(int id)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string emSQL = $"Select * from todos where id = {id}";
                connect.Open();
                ToDo t = connect.Query<ToDo>(emSQL).ToList().First();
                connect.Close();
                return t;
            }
        }
        public List<ToDo> GetToDos()
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string emSQL = $"Select * from todos";
                connect.Open();
                List<ToDo> toDos = connect.Query<ToDo>(emSQL).ToList();
                connect.Close();
                return toDos;
            }
        }
        public void CreateToDo(ToDo t)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string emSQL = $"Insert into todos " +
                    $"values(0, '{t.Name}', '{t.Description}', {t.AssignedTo}, {t.HoursNeeded}, {false});";
                connect.Open();
                connect.Query(emSQL);
                connect.Close();
            }
        }
        public void EditToDo(ToDo t)
        {
            using (var connect = new MySqlConnection(Secret.connection))
            {
                string emSQL = $"update todos set " +
                    $"name = '{t.Name}', description = '{t.Description}', assignedto = {t.AssignedTo}, hoursneeded = {t.HoursNeeded}, iscompleted = {t.IsCompleted} " +
                    $"where id = {t.id};";
                connect.Open();
                connect.Query(emSQL);
                connect.Close();
            }
        }
    }
}
