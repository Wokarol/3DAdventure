using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class DebugModeSwitch : MonoBehaviour 
	{
		// Variables
		[SerializeField] bool debugMode;
		[SerializeField] GameObject[] objects;
		// Functions

		private void Start ()
		{
			SetMode(debugMode);
		}

		private void Update ()
		{
			if (Input.GetKeyDown(KeyCode.F10)) {
				debugMode = !debugMode;
				SetMode(debugMode);
			}
		}

		private void SetMode (bool debugMode)
		{
			for (int i = 0; i < objects.Length; i++) {
				objects[i].SetActive(debugMode);
			}
		}
	}
}