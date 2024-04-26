using EmployeeBenefits.Interfaces;
using EmployeeBenefits.Models;
using System.Collections.Generic;
using System;

namespace EmployeeBenefits.Helpers.BenefitCalculator
{
    public class BenefitCalculatorHelper : IBenefitCalculatorHelper
    {
        const int DependentCost = 500;
        const int EmployeeCost = 1000;
        const string DiscountTrigger = "A";

        public EmployeeBenefitPreviewModel CalculateBenefitPreview(EmployeeBenefitPreviewModel model)
        {
            var previewModel = new EmployeeBenefitPreviewModel();
            if (isValid(model))
            {
                if (model.Dependents.Count != 0)
                {
                    var totalDependentDuductions = CalculateDependentDuductions(model.Dependents);
                    var totalEmployeeDuductions = CalculateEmployeeDuductions(model.EmployeeName);
                    var totalDiscounts = CalculateTotalDuctions(totalDependentDuductions, totalEmployeeDuductions);
                    var totalBenefitCost = CalculateTotalBenefitCost(model.EmployeeName, model.Dependents);
                    var totalBenefitCostWithDeduction = CalculateTotalBenefitCostWithDeduction(totalBenefitCost, totalDiscounts);
                    var totalNetIncome = CalculateTotalNetIncome(model.SalaryPerYear, totalBenefitCostWithDeduction);
                    var weeklyBenefitDeduction = CalculateWeeklyBenefitDeduction(totalBenefitCostWithDeduction);
                    var weeklyNetIncome = CalculateWeeklyNetIncome(weeklyBenefitDeduction, model.SalaryPerWeek);

                    previewModel = new EmployeeBenefitPreviewModel()
                    {
                        EmployeeName = model.EmployeeName,
                        Dependents = model.Dependents,
                        SalaryPerWeek = model.SalaryPerWeek,
                        SalaryPerYear = model.SalaryPerYear,
                        TotalBenefitCost = totalBenefitCost,
                        TotalDependentDeductions = totalDependentDuductions,
                        TotalDiscounts = totalDiscounts,
                        TotalEmployeeDeductions = totalEmployeeDuductions,
                        TotalNetIncome = totalNetIncome,
                        TotalWeeklyDeduction = weeklyBenefitDeduction,
                        TotalYearlyDeduction = totalBenefitCost,
                        WeeklyNetIncome = weeklyNetIncome
                    };
                }
            }
            return previewModel;
        }

        private int CalculateWeeklyNetIncome(int weeklyBenefitDeduction, int salaryPerWeek) => salaryPerWeek - weeklyBenefitDeduction;

        private int CalculateWeeklyBenefitDeduction(int totalBenefitCostWithDeduction) => totalBenefitCostWithDeduction / 26;

        private int CalculateTotalNetIncome(int salaryPerYear, int totalBenefitCostWithDeduction) => salaryPerYear - totalBenefitCostWithDeduction;

        private int CalculateTotalDuctions(int totalDependentDuductions, int totalEmployeeDuductions) => totalDependentDuductions + totalEmployeeDuductions;

        private int CalculateTotalBenefitCostWithDeduction(int totalBenefitCost, int totalDiscounts) => totalBenefitCost - totalDiscounts;

        private int CalculateTotalBenefitCost(string employeeName, List<string> dependents)
        {
            var employeeDependentCost = dependents.Count * DependentCost;
            var employeeTotalCost = employeeDependentCost + EmployeeCost;
            return employeeTotalCost;
        }

        private int CalculateEmployeeDuductions(string employeeName)
        {
            var employeeDiscount = 0;
            if (employeeName.ToUpper().StartsWith(DiscountTrigger))
            {
                employeeDiscount = (int)(EmployeeCost * 0.10);
            }
            return employeeDiscount;
        }

        private int CalculateDependentDuductions(List<string> dependents)
        {
            var discountQualifiedDependents = 0;
            var totalDependentDuductions = 0;

            foreach (var dependent in dependents)
            {
                if (dependent.ToUpper().StartsWith(DiscountTrigger))
                {
                    discountQualifiedDependents++;
                }
            }

            for (int i = 0; i < discountQualifiedDependents; i++)
            {
                totalDependentDuductions = (int)(DependentCost * 0.10);
            }

            return totalDependentDuductions;

        }

        private bool isValid(EmployeeBenefitPreviewModel model)
        {
            var response = false;
            if (!string.IsNullOrWhiteSpace(model.EmployeeName))
            {
                response = true;
            }
            return response;
        }
    }
}