namespace FlipBuddy.Domain.Validation
{
	public interface IValidationRule
	{
		public bool IsPassingRule(out string validationFailureMessage);
	}
}
