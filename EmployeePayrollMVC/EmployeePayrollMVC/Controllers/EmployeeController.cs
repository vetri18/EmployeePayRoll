using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBL EmployeeBL;


        public EmployeeController(IEmployeeBL empBl)
        {
            this.EmployeeBL = empBl;
        }
        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = EmployeeBL.getEmployeeList().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
              EmployeeBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var employee = EmployeeBL.getEmployeeById(id);
            EmployeeBL.deleteEmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeModel employee)
        {
            if (id != employee.emp_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                EmployeeBL.editEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
