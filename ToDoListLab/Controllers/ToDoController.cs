using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListLab.Models;

namespace ToDoListLab.Controllers
{
    public class ToDoController : Controller
    {
        ToDoDAL db = new ToDoDAL();
        EmployeeDAL edb = new EmployeeDAL();
        public IActionResult Index()
        {
            List<ToDo> toDos = db.GetToDos();
            foreach(ToDo t in toDos)
            {
                t.EmployeeList = edb.GetEmployees();
            }
            return View(toDos);
        }
        public IActionResult Create()
        {
            ToDo t = new ToDo();
            t.EmployeeList = edb.GetEmployees();
            return View(t);
        }
        [HttpPost]
        public IActionResult Create(ToDo t)
        {
            if(ModelState.IsValid)
            {
                db.CreateToDo(t);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            ToDo t = db.GetToDo(id);
            t.EmployeeList = edb.GetEmployees();
            return View(t);
        }
        [HttpPost]
        public IActionResult Edit(ToDo t)
        {
            if(ModelState.IsValid)
            {
                db.EditToDo(t);
                return RedirectToAction("index");
            }
            return View(t);
        }
        public IActionResult AssignToDo(int id)
        {
            ToDo t = db.GetToDo(id);
            t.EmployeeList = edb.GetEmployees();
            return View(t);
        }
        [HttpPost]
        public IActionResult AssignToDo(ToDo t)
        {
            t.EmployeeList = edb.GetEmployees();
            ToDo currentTask = db.GetToDo(t.id);
            Employee e = t.EmployeeList.First(x => x.Id == t.AssignedTo);
            if(e.Hours >= currentTask.HoursNeeded)
            {
                currentTask.AssignedTo = t.AssignedTo;
                db.EditToDo(currentTask);
            }
            return RedirectToAction("Index");
        }
        public IActionResult MarkComplete(int id)
        {
            ToDo t = db.GetToDo(id);
            t.IsCompleted = true;
            db.EditToDo(t);
            return RedirectToAction("index");
        }
    }
}
