using FluentValidation;

namespace CiberNiteco.Entities.Models.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(t => t.UserName).NotEmpty().WithMessage("Tài khoản là bắt buộc");
            RuleFor(t => t.Password).NotEmpty().WithMessage("Mật khẩu là bắt buộc")
                .MinimumLength(6).WithMessage("Mật khẩu tối thiểu 6 kí tự");
        }
    }
}