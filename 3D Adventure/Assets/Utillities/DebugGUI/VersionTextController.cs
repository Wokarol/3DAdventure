using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VersionTextController : MonoBehaviour {
	const string versionTag = "{version}";
	const string companyName = "{company}";

	[TextArea(5, 20)]
	[SerializeField] string textTemplate = "Version {version} made by {company}";


	TextMeshProUGUI textMesh;



	[ContextMenu("Recalculate")]
	private void Start () {
		textMesh = GetComponent<TextMeshProUGUI>();
		textMesh.text = ProcessText(textTemplate);
	}

	string ProcessText(string text)
	{
		while (text.Contains(versionTag)) {
			text = text.Replace(versionTag, Application.version);
		}

		while (text.Contains(companyName)) {
			text = text.Replace(companyName, Application.companyName);
		}

		return text;
	}

	private void OnValidate ()
	{
		Start();
	}
}
