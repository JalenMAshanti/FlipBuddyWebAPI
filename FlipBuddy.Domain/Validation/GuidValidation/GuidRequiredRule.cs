namespace FlipBuddy.Domain.Validation.GuidValidation
{
	public class GuidRequiredRule : ValidationRule<Guid?>
	{
		public GuidRequiredRule(Guid? objectToValidate, string nameOfObjectToValidate) : base(objectToValidate, nameOfObjectToValidate) { }

		public override bool IsPassingRule(out string validationFailureMessage)
		{
			if (ObjectToValidate == null || ObjectToValidate == Guid.Empty)
			{
				validationFailureMessage = ValidationFailureMessage.RequiredField(NameOfObjectToValidate);
				return false;
			}

			validationFailureMessage = string.Empty;
			return true;
		}
	}

}

