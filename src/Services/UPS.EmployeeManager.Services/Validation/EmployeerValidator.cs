using System.Text.RegularExpressions;
using FluentValidation;
using UPS.EmployeeManager.Domain.Entities;
using UPS.EmployeeManager.Shared.Models;

namespace UPS.EmployeeManager.Services.Validation;

public class EmployeeValidator : AbstractValidator<EmployeeModel>
{
    public EmployeeValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Please enter a name")
            .Matches("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase)
            .WithMessage("Invalid fullname format, ");
            
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
       
    }
}
