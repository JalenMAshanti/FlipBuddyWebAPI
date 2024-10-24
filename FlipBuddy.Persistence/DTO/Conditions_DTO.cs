﻿using FlipBuddy.Domain.Models;

namespace FlipBuddy.Persistence.DTO
{
	public class Conditions_DTO
	{
		public int ConditionId { get; set; }
		public string ConditionTitle { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public Condition AsDomainCondition() => new Condition(ConditionId, ConditionTitle, Description);
	}
}
