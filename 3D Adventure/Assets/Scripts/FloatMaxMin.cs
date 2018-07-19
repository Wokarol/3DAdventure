namespace Wokarol
{
	[System.Serializable]
	public class FloatMaxMin
	{
		public float max;
		public float min;

		public FloatMaxMin (float min, float max)
		{
			this.max = max;
			this.min = min;
		}
	}
}