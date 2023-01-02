using BusinessLayer.Interfaces;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL:IEmployeeBL
    {
        IEmployeeRL iemprl;

        public EmployeeBL(IEmployeeRL iemprl)
        {
            this.iemprl = iemprl;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                this.iemprl.AddEmployee(employee);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void deleteEmployee(EmployeeModel employee)
        {
            try
            {
                this.iemprl.deleteEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void editEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.iemprl.editEmployee(employeeModel);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public EmployeeModel getEmployeeById(int? id)
        {
            try
            {
                return this.iemprl.getEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<EmployeeModel> getEmployeeList()
        {
            try
            {
                return this.iemprl.getEmployeeList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

