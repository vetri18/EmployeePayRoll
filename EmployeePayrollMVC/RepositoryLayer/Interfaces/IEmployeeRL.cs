﻿using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRL
    {
        public void AddEmployee(EmployeeModel employee);
        List<EmployeeModel> getEmployeeList();
        EmployeeModel getEmployeeById(int? id);
        void deleteEmployee(EmployeeModel employeeModel);
        void editEmployee(EmployeeModel employeeModel);
    }
}
