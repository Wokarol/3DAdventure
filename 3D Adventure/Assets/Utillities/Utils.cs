namespace Wokarol
{
	public static class Utils 
	{
		// Functions
		public static float Map (float value, float baseMin, float baseMax, float targetMin, float targetMax)
		{
			var baseRange = baseMax - baseMin;
			var targetRange = targetMax - targetMin;

			value -= baseMin;
			value /= baseRange;
			value *= targetRange;
			value += targetMin;

			return value;
		}
	}
}