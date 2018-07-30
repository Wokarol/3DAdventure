using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(Renderer))]
	public class ChangeColorOnPress : MonoBehaviour, IInteractible
	{
		// Variables

		[SerializeField] Color[] colors = new Color[]{Color.blue, Color.green};
		int nextColorIndex = 0;

		new private Renderer renderer;
		new private Light light;

		private MaterialPropertyBlock propertyBlock;

		public string InteractionText {
			get {
				return "Change color";
			}
		}

		public float InteractionDistanceMultiplier {
			get {
				return 1;
			}
		}

		// Functions

		private void Awake ()
		{
			renderer = GetComponent<Renderer>();
			light = GetComponent<Light>();
			propertyBlock = new MaterialPropertyBlock();
		}

		public void Interact ()
		{
			var color = GetNewColor();
			SetColor(color);
		}

		private void SetColor (Color color)
		{
			renderer.GetPropertyBlock(propertyBlock);

			propertyBlock.SetColor("_Color", color);
			propertyBlock.SetColor("_EmissionColor", color);

			renderer.SetPropertyBlock(propertyBlock);

			if (light) {
				light.color = color;
			}
		}

		private Color GetNewColor ()
		{
			return colors[nextColorIndex++%colors.Length];
		}
	}
}