using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListLab.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [Range(0,40)]
        public int Hours { get; set; }
        [MaxLength(40)]
        public string Title { get; set; }
        public List<ToDo> ToDoList { get; set; }
    }
}
