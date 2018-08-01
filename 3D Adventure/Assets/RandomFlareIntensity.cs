using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(FlareIntensity))]
	public class RandomFlareIntensity : MonoBehaviour 
	{
		// Variables
		FlareIntensity flareIntensity;
		[SerializeField] FloatVariableReference perlinNoiseTest;
		// Functions
		private void Awake ()
		{
			flareIntensity = GetComponent<FlareIntensity>();
		}
		private void Update ()
		{
			perlinNoiseTest.Value = Mathf.PerlinNoise(0, 0);
		}
	}
}