using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MuRestful.Core.Domains;
using MyRestful.Api.ViewModels;

namespace MyRestful.Api.Valids
{
    public class CountryValidator<T> : AbstractValidator<T> where T : CountryViewModel
    {
        public CountryValidator()
        {
            RuleFor(x => x.ChineseName)
                .NotEmpty().WithName("英文名").WithMessage("{PropertyName}是必填项")
                .MaximumLength(10).WithMessage("{PropertyName}长度不能超过{MaxLength}");
        }
    }

    public class CountryAddValidator : CountryValidator<CountryViewModel>
    {
        public CountryAddValidator()
        {
            RuleFor(x => x.ChineseName)
                .NotEmpty().WithName("英文名").WithMessage("{PropertyName}是必填项")
                .MaximumLength(10).WithMessage("{PropertyName}长度不能超过{MaxLength}");
        }
    }
}
