﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(CanvasGroup))]
	public class AlphaFromBool : MonoBehaviour 
	{
		// Variables
		[SerializeField] BoolVariableReference boolValue;
		[SerializeField] FloatMaxMin AlphaValues;

		CanvasGroup canvasGroup;
		// Functions
		private void Awake ()
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}

		private void Update ()
		{
			canvasGroup.alpha = boolValue.Value ? AlphaValues.max : AlphaValues.min;
		}
	}
}