using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wokarol
{
	[RequireComponent(typeof(Slider))]
	public class FloatToSlider : MonoBehaviour 
	{
		// Variables
		[SerializeField] FloatVariableReference floatValue;
		[SerializeField] float smoothTime = 0;


		Slider canvasGroup;
		private float currentVelocity;

		// Functions
		private void Awake ()
		{
			canvasGroup = GetComponent<Slider>();
		}

		private void Update ()
		{
			canvasGroup.value = Mathf.SmoothDamp(canvasGroup.value, floatValue.Value, ref currentVelocity, smoothTime);
		}
	}
}