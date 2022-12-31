using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System.Collections.Generic;

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
            //lstEmployee = empBl.GetAllEmployees().ToList();

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
    }
}
