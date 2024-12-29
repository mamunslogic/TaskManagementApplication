using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Validations
{
    public class NotWeekendAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Friday)
            {
                return new ValidationResult("The due date cannot be on a weekend.");
            }
            return ValidationResult.Success;
        }
    }
}
