﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class DebugToText : MonoBehaviour 
	{
		// Variables
		[SerializeField] string lookUpString;

		TextMeshProUGUI textMesh;
		// Functions

		private void Awake ()
		{
			textMesh = GetComponent<TextMeshProUGUI>();
			textMesh.text = "";
		}

		void OnEnable ()
		{
			Application.logMessageReceived += HandleLog;
		}
		void OnDisable ()
		{
			Application.logMessageReceived -= HandleLog;
		}
		void HandleLog (string logString, string stackTrace, LogType type)
		{
			var text = textMesh.text;
			string textToShow = logString.Replace(lookUpString, "");
			text += textToShow;
			text += "\n";
			textMesh.text = text;
		}

	}
}