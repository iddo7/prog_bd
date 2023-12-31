﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgBD
{
    internal class Task
    {
        string projectCode;
        string employeeCode;
        double hoursWorked;
        double salary;

        public Task()
        {
            this.ProjectCode = string.Empty;
            this.EmployeeCode = string.Empty;
            this.HoursWorked = 0;
            this.Salary = 0;
        }

        public Task(string projectCode, string employeeCode, double hoursWorked = 0, double salary = 0)
        {
            this.ProjectCode = projectCode;
            this.EmployeeCode = employeeCode;
            this.HoursWorked = hoursWorked;
            this.Salary = salary;
        }

        public string ProjectCode { get => projectCode; set => projectCode = value; }
        public string EmployeeCode { get => employeeCode; set => employeeCode = value; }
        public double HoursWorked 
        { 
            get => hoursWorked; 
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(hoursWorked));

                hoursWorked = value;
            }
        }
        public double Salary
        {
            get => salary;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(hoursWorked));

                salary = value;
            }
        }

        public override string ToString()
        {
            return $"Project Code: {ProjectCode}\n" +
                   $"Employee Code: {EmployeeCode}\n" +
                   $"Hours Worked: {HoursWorked}\n" +
                   $"Salary: {Salary}\n";
        }

    }
}
