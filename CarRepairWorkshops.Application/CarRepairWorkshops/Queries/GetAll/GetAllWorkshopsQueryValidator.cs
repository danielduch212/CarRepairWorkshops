using FluentValidation;
using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;

public class GetAllWorkshopsQueryValidator : AbstractValidator<GetAllWorkshopsQuery>
{
    private int[] allowPageSizes = [5, 10, 15, 30];

    

    public GetAllWorkshopsQueryValidator()
    {
        RuleFor(r => r.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize)
            .Must(value => allowPageSizes.Contains(value))
            .WithMessage($"Page size must be in [{string.Join(",", allowPageSizes)}]");

    }
}
