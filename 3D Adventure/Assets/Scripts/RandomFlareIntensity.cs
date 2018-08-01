using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(FlareIntensity))]
	public class RandomFlareIntensity : MonoBehaviour 
	{
		// Variables
		FlareIntensity flareIntensity;
		[SerializeField] float perlinNoiseMultiplier = 20;
		[SerializeField] float frequency = 1;

		[SerializeField] FloatMaxMin intensityMinMax = new FloatMaxMin(0.7f, 1);

		float seed;

		// Functions
		private void Awake ()
		{
			flareIntensity = GetComponent<FlareIntensity>();
			seed = Random.Range(0, 2000); 
		}
		private void Update ()
		{
			var perlinValue = ((Mathf.PerlinNoise(Time.time * frequency, seed) - 0.5f) * perlinNoiseMultiplier) + 0.5f;
			flareIntensity.Intensity = Utils.Map(Mathf.Clamp01(perlinValue), 0, 1, intensityMinMax.min, intensityMinMax.max);
		}
	}
}