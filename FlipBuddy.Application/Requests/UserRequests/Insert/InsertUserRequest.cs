using FlipBuddy.Application.Abstraction;
using FlipBuddy.Domain.Constants;
using FlipBuddy.Domain.Validation;
using FlipBuddy.Domain.Validation.GuidValidation;
using FlipBuddy.Domain.Validation.StringValidation;
using Validator = FlipBuddy.Domain.Validation.Validator;

namespace FlipBuddy.Application.Requests.UserRequests.Insert
{
	public class InsertUserRequest : IValidatable, IRequest
	{
		public InsertUserRequest() { }

		public InsertUserRequest(Guid guid, string userName, string firstName, string lastName, string password, string email)
		{
			Guid = guid;
			Username = userName;
			FirstName = firstName;
			LastName = lastName;
			Password = password;
			Email = email;
		}

		public Guid Guid { get; set; }
		public string Username { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;


		public bool IsValid(out Validator validator)
		{
			validator = new(
				new GuidRequiredRule(Guid, nameof(Guid)),
				new StringLengthLimitRule(Username, nameof(Username), MaxLength.FirstName),
				new StringLengthLimitRule(FirstName, nameof(FirstName), MaxLength.FirstName),
				new StringLengthLimitRule(LastName, nameof(LastName), MaxLength.LastName),
				new StringLengthLimitRule(Email, nameof(Email), MaxLength.Email),
				new StringLengthLimitRule(Password, nameof(Password), MaxLength.PasswordHash)
			);

			return validator.IsPassingAllRules;
		}
	}
}
