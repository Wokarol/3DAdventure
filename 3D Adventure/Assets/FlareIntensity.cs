using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class FlareIntensity : MonoBehaviour 
	{
		// Variables
		[Range(0,1)] [SerializeField] private float intensity;

		public float Intensity {
			get {
				return intensity;
			}

			set {
				intensity = value;
			}
		}
		// Functions

	}
}