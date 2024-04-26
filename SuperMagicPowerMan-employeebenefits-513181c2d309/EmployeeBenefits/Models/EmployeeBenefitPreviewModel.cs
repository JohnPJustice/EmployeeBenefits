using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBenefits.Models
{
    public class EmployeeBenefitPreviewModel
    {
        public string EmployeeName { get; set; }
        public List<string> Dependents { get; set; }
        public int TotalYearlyDeduction { get; set; }
        public int TotalWeeklyDeduction { get; set; }
        public int TotalEmployeeDeductions { get; set; }
        public int TotalDependentDeductions { get; set; }
        public int TotalDiscounts { get; set; }
        public int TotalBenefitCost { get; set; }
        public int TotalNetIncome { get; set; }
        public int WeeklyNetIncome { get; set; }
        public int SalaryPerWeek { get; set; } = 2000;
        public int SalaryPerYear { get; set; } = 52000;
    }
}