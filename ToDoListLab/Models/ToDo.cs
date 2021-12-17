using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListLab.Models
{
    public class ToDo
    {
        [Key]
        public int id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int AssignedTo { get; set; }
        public int HoursNeeded { get; set; }
        public bool IsCompleted { get; set; }
        public List<Employee> EmployeeList {get; set;}

    }
}
