using UnityEngine;
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


	public static string ToString (this Color color, System.Globalization.CultureInfo culture)
	{
		return color.ToString("f3", culture);
	}

	public static string ToString (this Color color, string format, System.Globalization.CultureInfo culture)
	{
		return string.Format("RGBA({0}, {1}, {2}, {3})",
			color.r.ToString(format, culture),
			color.g.ToString(format, culture),
			color.b.ToString(format, culture),
			color.a.ToString(format, culture)
			);
	}
}