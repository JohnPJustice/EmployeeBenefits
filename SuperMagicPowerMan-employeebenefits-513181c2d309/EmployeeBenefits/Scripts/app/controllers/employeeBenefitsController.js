var employeeBenefitsController = function ($scope, $http) {

    $scope.header = 'Employee Benefit Preview';    
    $scope.listEmployees = [];
    $scope.listDependents = [];
    $scope.employeeName = '';
    $scope.dependentName = '';
    $scope.isHideTable = true;
    $scope.previewDependents = '';
    $scope.previewEmployee = '';
    $scope.totalYearlyDuctuction = '';
    $scope.weeklyDeduction = '';
    $scope.discount = '';
    $scope.lblEmployee = '';
    $scope.lblDependents = '';
    $scope.lblTotalDiscounts = '';
    $scope.lblTotalBenefitCost = '';
    $scope.lblTotalBenefit = '';
    $scope.lblTotalSalary = '';
    $scope.lbltotalNetIncome = '';
    $scope.lblWeeklySalary = '';
    $scope.lblWeeklyDeduction = '';
    $scope.lblWeeklyNetIncome = '';
    $scope.Employee = '';
    $scope.Dependents = '';
    $scope.TotalDiscounts = '';
    $scope.TotalBenefitCost = '';
    $scope.TotalBenefit = '';
    $scope.TotalSalary = '';
    $scope.totalNetIncome = '';
    $scope.WeeklySalary = '';
    $scope.WeeklyDeduction = '';
    $scope.WeeklyNetIncome = '';

    $scope.clear = function () {
        $scope.listEmployees = [];
        $scope.listDependents = [];
        $scope.employeeName = '';
        $scope.dependentName = '';
        $scope.isHideTable = true;
        $scope.previewDependents = '';
        $scope.previewEmployee = '';
        $scope.totalYearlyDuctuction = '';
        $scope.weeklyDeduction = '';
        $scope.discount = '';
        $scope.lblEmployee = '';
        $scope.lblDependents = '';
        $scope.lblTotalDiscounts = '';
        $scope.lblTotalBenefitCost = '';
        $scope.lblTotalBenefit = '';
        $scope.lblTotalSalary = '';
        $scope.lbltotalNetIncome = '';
        $scope.lblWeeklySalary = '';
        $scope.lblWeeklyDeduction = '';
        $scope.lblWeeklyNetIncome = '';

        $scope.Employee = '';
        $scope.Dependents = '';
        $scope.TotalDiscounts = '';
        $scope.TotalBenefitCost = '';
        $scope.TotalBenefit = '';
        $scope.TotalSalary = '';
        $scope.totalNetIncome = '';
        $scope.WeeklySalary = '';
        $scope.WeeklyDeduction = '';
        $scope.WeeklyNetIncome = '';
    };

    $scope.submitEmployee = function () {
        if ($scope.employeeName) {
            $scope.listEmployees[0] = this.employeeName;
            $scope.employeeName = '';
        }
    };

    $scope.submitDependent = function () {
        if ($scope.dependentName) {
            $scope.listDependents.push(this.dependentName);
            $scope.dependentName = '';
        }
    };   

    $scope.submit = function () {
        var obj = { "employeeName": $scope.listEmployees[0], "dependents": $scope.listDependents };
        var formattedData = JSON.stringify(obj);
        var url = '/Home/GetBenefitPreview';
        $http.post(url, formattedData).then(function (response) {
            $scope.listDependents = [];
            $scope.listEmployees = [];
            $scope.dependentName = '';
            $scope.employeeName = '';

            $scope.lblEmployee = "Employee's Name: ";
            $scope.lblDependents = "Dependents Name: ";
            $scope.lblTotalDiscounts = "Total Discounts";
            $scope.lblTotalBenefitCost = "Total Benefit Cost";
            $scope.lblTotalBenefit = "Total Benefit with Discounts";
            $scope.lblTotalSalary = "Yearly Net Gross";
            $scope.lbltotalNetIncome = "Yearly Net Income";
            $scope.lblWeeklySalary = "Weekly Net Gross";
            $scope.lblWeeklyDeduction = "Weekly Benefit Deduction";
            $scope.lblWeeklyNetIncome = "Weekly Net Income";
            var obj = JSON.parse(response.data);
            $scope.previewDependents = obj.Dependents;
            $scope.previewEmployee =  obj.EmployeeName;
            $scope.totalEmployeeDeductions = obj.TotalEmployeeDeductions;
            $scope.totalDiscounts = obj.TotalDiscounts;
            $scope.totalBenefit = obj.TotalBenefitCost;
            $scope.totalSalary = obj.SalaryPerYear;
            $scope.totalNetIncome = obj.TotalNetIncome;
            $scope.weeklySalary = obj.SalaryPerWeek;
            $scope.weeklyDeduction = obj.TotalWeeklyDeduction;
            $scope.weeklyNetIncome = obj.WeeklyNetIncome;

            $scope.isHideTable = false;
        })
    };
   
}

employeeBenefitsController.$inject = ['$scope', '$http'];