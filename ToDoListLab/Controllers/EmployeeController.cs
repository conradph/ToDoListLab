using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListLab.Models;
namespace ToDoListLab.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL db = new EmployeeDAL();
        public IActionResult Index()
        {
            List<Employee> employees = db.GetEmployees();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if(ModelState.IsValid)
            {
                db.CreateEmployee(e);
                return RedirectToAction("Index");
            }
            return View(e);
        }
        public IActionResult Edit(int id)
        {
            Employee e = db.GetEmployee(id);
            if(e != null)
            {
                return View(e);
            }
            else
            {
                return RedirectToAction("IDError", id);
            }
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            if(ModelState.IsValid)
            {
                db.UpdateEmployee(e);
                return RedirectToAction("Index");
            }
            return View(e);
        }
        public IActionResult Delete(int id)
        {
            Employee e = db.GetEmployee(id);
            return View(e);
        }
        public IActionResult DeleteFromDB(int id)
        {
            db.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
