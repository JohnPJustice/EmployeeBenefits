using EmployeeBenefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefits.Interfaces
{
    interface IBenefitCalculatorHelper
    {
        EmployeeBenefitPreviewModel CalculateBenefitPreview(EmployeeBenefitPreviewModel model);
    }
}
