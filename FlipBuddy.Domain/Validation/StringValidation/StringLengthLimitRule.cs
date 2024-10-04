namespace FlipBuddy.Domain.Validation.StringValidation
{
	public class StringLengthLimitRule : ValidationRule<string>
	{
		public StringLengthLimitRule(string? objectToValidate, string nameOfObjectToValidate, int maxLength, bool isRequiredString = true) : base(objectToValidate, nameOfObjectToValidate)
		{
			_maxLength = maxLength;
			_isRequiredString = isRequiredString;
		}

		private readonly int _maxLength;

		private readonly bool _isRequiredString;

		public override bool IsPassingRule(out string validationFailureMessage)
		{
			if (_isRequiredString)
			{
				if (string.IsNullOrWhiteSpace(ObjectToValidate))
				{
					validationFailureMessage = ValidationFailureMessage.RequiredField(NameOfObjectToValidate);
					return false;
				}
			}

			if (ObjectToValidate != null && ObjectToValidate.Length > _maxLength)
			{
				validationFailureMessage = ValidationFailureMessage.StringExceedingMaxLength(ObjectToValidate, NameOfObjectToValidate, _maxLength);
				return false;
			}

			validationFailureMessage = string.Empty;
			return true;
		}
	}
}
