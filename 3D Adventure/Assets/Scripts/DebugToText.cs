using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class DebugToText : MonoBehaviour 
	{
		const string frameCountTag = "{frame}";
		const string logTextTag = "{log}";

		// Variables
		[SerializeField] string lookUpString = ":OnScreen:";
		[TextArea(1, 3)]
		[SerializeField] string messageTemplate = "{frame}: {log}";

		TextMeshProUGUI textMesh;
		// Functions

		private void Awake ()
		{
			textMesh = GetComponent<TextMeshProUGUI>();
			textMesh.text = "";
		}

		private void Update ()
		{
			if (Input.GetKeyDown(KeyCode.F8)) {
				textMesh.text = "";
			}
		}

		string ProcessText(string text, string logString, int frame)
		{
			while (text.Contains(logTextTag)) {
				text = text.Replace(logTextTag, logString);
			}
			while (text.Contains(frameCountTag)) {
				text = text.Replace(frameCountTag, frame.ToString());
			}
			//while (text.Contains("\\t")) {
			//	text = text.Replace(frameCountTag, "\t");
			//}

			return text;
		}

		void OnEnable ()
		{
			Application.logMessageReceived += HandleLog;
		}
		void OnDisable ()
		{
			Application.logMessageReceived -= HandleLog;
		}
		void AddLog(string logString, int frame)
		{
			var text = textMesh.text;
			if (logString.Contains(lookUpString)) {
				string textToShow = logString.Replace(lookUpString, "");
				text += ProcessText(messageTemplate, textToShow, frame);
				text += "\n";
				textMesh.text = text;
			}
		}
		void HandleLog (string logString, string stackTrace, LogType type)
		{
			AddLog(logString, Time.frameCount);
		}

		private void OnValidate ()
		{
			if(textMesh == null) {
				textMesh = GetComponent<TextMeshProUGUI>();
			}
			textMesh.text = "";

			AddLog(lookUpString + "Test log", 45);
			AddLog(lookUpString + "Another thing", 456);
			AddLog(lookUpString + "Hell yeah", 500);
			AddLog(lookUpString + "Testing is fun", 1024);
		}
	}
}