﻿namespace FlipBuddy.Domain.Validation
{
	public interface IValidatable
	{
		public bool IsValid(out Validator validator);
	}
}
