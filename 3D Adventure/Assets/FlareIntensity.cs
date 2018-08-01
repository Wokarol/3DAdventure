using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(Light), typeof(MeshRenderer))]
	public class FlareIntensity : MonoBehaviour 
	{
		// Variables
		[Range(0,1)] [SerializeField] private float intensity = 1;
		public float Intensity {
			get {
				return intensity;
			}

			set {
				intensity = value;
			}
		}

		[SerializeField] int lightMaterialIndex = 0;

		new Light light;
		float lightMaxIntensity;

		MeshRenderer meshRenderer;
		MaterialPropertyBlock materialPropertyBlock;
		Color maxMaterialColor;
		// Functions

		private void Start ()
		{
			materialPropertyBlock = new MaterialPropertyBlock();

			light = GetComponent<Light>();
			lightMaxIntensity = light.intensity;

			meshRenderer = GetComponent<MeshRenderer>();
			maxMaterialColor = meshRenderer.sharedMaterials[lightMaterialIndex].GetColor("_EmissionColor");
		}

		private void Update ()
		{
			SetIntensity(intensity);
		}

		void SetIntensity (float _intensity)
		{
			light.intensity = Mathf.Lerp(0, lightMaxIntensity, _intensity);
			meshRenderer.GetPropertyBlock(materialPropertyBlock, lightMaterialIndex);
			materialPropertyBlock.SetColor("_EmissionColor", Color.Lerp(Color.black, maxMaterialColor, _intensity));
			meshRenderer.SetPropertyBlock(materialPropertyBlock, lightMaterialIndex);
			
		}

	}
}