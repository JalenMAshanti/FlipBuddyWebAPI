namespace FlipBuddy.Tests.Shared.TestObjects
{
	public class TestNumber
	{
	
		public static int GetSubTier() 
		{
			Random random = new Random();
			var result = random.Next(1,4);
			return result;
		}

		public static int GetConditionId() 
		{
			Random random = new Random();
			var result = random.Next(500, 1001);
			return result;
		}
	}
}
