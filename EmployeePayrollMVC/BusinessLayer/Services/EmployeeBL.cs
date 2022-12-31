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
    }
}
