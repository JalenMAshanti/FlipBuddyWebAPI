namespace FlipBuddy.Domain.Models
{
	public class Condition
	{
		public Condition() { }

		public Condition(int conditionId,
						string conditionTitle,
						string description)
		{
			ConditionId = conditionId;
			ConditionTitle = conditionTitle;
			Description = description;
		}

		public int ConditionId { get; set; }
		public string? ConditionTitle { get; set; }
		public string? Description { get; set; }
	}
}
